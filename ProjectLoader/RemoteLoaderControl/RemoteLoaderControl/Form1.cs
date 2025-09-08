using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NAudio.Wave;
using SharpDX.DirectInput;
using System.IO.Ports;

namespace RemoteLoaderControl
{
    public partial class form_main : Form
    {
        // ************************************************** variables
        static TcpClient tcp_client;
        static NetworkStream tcp_stream;
        static WaveInEvent mic_waveIn;
        DirectInput directInput;

        System.Windows.Forms.Timer timer_check_joysticks;
        Joystick[] joysticks = new Joystick[2];
        Joystick joystick_left;
        Joystick joystick_right;
        bool state_is_connect_joysticks = false;
        bool state_connect_joystick_left = false;
        bool state_connect_joystick_right = false;
        bool state_calibration_joysticks = false;
        bool joystick_switch_msg_1 = true;

        bool cmd_joysticks_calibration = false;
        int seq_joysticks_calibration = 0;

        bool state_tcp_connect = false;

        // ************************************************** initialization functions

        public form_main()
        {
            InitializeComponent();
            init_win_form();
            init_variables();
            init_control_elements();
            update_panel_joysticks();
            update_panel_tcp_connection();
        }

        void init_win_form()
        {
            this.Text = "Remote loader control L753";
            this.Icon = new Icon("prog_ico.ico");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.FormClosing += Form_main_FormClosing;
        }

        void init_control_elements()
        {
            textBox_tcp_server_ip.KeyPress += TextBox_tcp_server_ip_KeyPress;
            textBox_tcp_server_ip.TextChanged += TextBox_tcp_server_ip_TextChanged;
            textBox_tcp_server_ip.MaxLength = 15;

            numericUpDown_tcp_server_port.Minimum = 0;
            numericUpDown_tcp_server_port.Maximum = 65535;

            textBox_tcp_server_ip.Text = Properties.Settings.Default.tcp_ip;
            numericUpDown_tcp_server_port.Value = Properties.Settings.Default.tcp_port;

            numericUpDown_com_port_baudrate.Minimum = 300;
            numericUpDown_com_port_baudrate.Maximum = 256000;
            numericUpDown_com_port_baudrate.Value = Properties.Settings.Default.com_port_baudrate;

            button_joysticks_calibration.Click += Button_joysticks_calibration_Click;

            button_tcp_open.Click += Button_tcp_open_Click;
            button_tcp_close.Click += Button_tcp_close_Click;
        }

        void init_variables()
        {
            directInput = new DirectInput();

            timer_check_joysticks = new System.Windows.Forms.Timer();
            timer_check_joysticks.Interval = 1000;
            timer_check_joysticks.Tick += Timer_check_joysticks_Tick;
            timer_check_joysticks.Enabled = true;
        }

        // ************************************************** handler functions

        private void Button_tcp_close_Click(object sender, EventArgs e)
        {
            state_tcp_connect = false;
            tcp_client.Close();
            update_panel_tcp_connection();
        }

        private void Button_tcp_open_Click(object sender, EventArgs e)
        {
            try
            {
                tcp_client = new TcpClient();

                var connectTask = tcp_client.ConnectAsync(textBox_tcp_server_ip.Text, (int)numericUpDown_tcp_server_port.Value);
                if (!connectTask.Wait(1000))
                {
                    tcp_client.Close();
                    throw new TimeoutException("Connected timeout");
                }

                if (tcp_client.Connected)
                {
                    tcp_stream = tcp_client.GetStream();
                    state_tcp_connect = true;
                    update_panel_tcp_connection();
                }
                else
                {
                    state_tcp_connect = false;
                    update_panel_tcp_connection();
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Timeout");
                state_tcp_connect = false;
                update_panel_tcp_connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connect" + ex.Message);
                state_tcp_connect = false;
                update_panel_tcp_connection();
            }
        }

        private void Button_joysticks_calibration_Click(object sender, EventArgs e)
        {
            if (state_calibration_joysticks)
            {
                MessageBox.Show("Откалиброванный");
                return;
            }

            cmd_joysticks_calibration = true;
            seq_joysticks_calibration = 0;
        }

        private void Timer_check_joysticks_Tick(object sender, EventArgs e)
        {
            if (state_is_connect_joysticks == false)
            {
                var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);

                if (devices.Count >= 2)
                {
                    joysticks[0] = new Joystick(directInput, devices[0].InstanceGuid);
                    joysticks[1] = new Joystick(directInput, devices[1].InstanceGuid);
                    joysticks[0].Acquire();
                    joysticks[1].Acquire();

                    joystick_switch_msg_1 = true;
                    state_is_connect_joysticks = true;
                    state_connect_joystick_left = true;
                    state_connect_joystick_right = true;

                    update_panel_joysticks();

                    MessageBox.Show("Джостики найдены, пожалуйста сделайте калибровку");
                }
                else
                {
                    if (joystick_switch_msg_1)
                    {
                        joystick_switch_msg_1 = false;
                        MessageBox.Show("Подключайте джостики");
                    }
                }
            }

            if (state_calibration_joysticks)
            {
                try
                {
                    joystick_left.Poll();
                    JoystickState states_joystick_left = joystick_left.GetCurrentState();
                }
                catch (Exception)
                {
                    state_calibration_joysticks = false;
                    state_connect_joystick_left = false;
                    update_panel_joysticks();
                }

                try
                {
                    joystick_right.Poll();
                    JoystickState states_joystick_right = joystick_right.GetCurrentState();
                }
                catch (Exception)
                {
                    state_calibration_joysticks = false;
                    state_connect_joystick_right = false;
                    update_panel_joysticks();
                }
            }
            else
            {
                try
                {
                    joysticks[0].Poll();
                    joysticks[1].Poll();
                    JoystickState statesJoy1 = joysticks[0].GetCurrentState();
                    JoystickState statesJoy2 = joysticks[1].GetCurrentState();

                    if (cmd_joysticks_calibration)
                    {
                        switch (seq_joysticks_calibration)
                        {
                            case 0:
                                timer_check_joysticks.Interval = 100;
                                MsgBox.Show("Нажимайте красную кнопку, левую сторону");
                                seq_joysticks_calibration++;
                                break;
                            case 1:
                                if (statesJoy1.Buttons[3] == true)
                                {
                                    MsgBox.Close();
                                    joystick_left = joysticks[0];
                                    seq_joysticks_calibration++;
                                }

                                if (statesJoy2.Buttons[3] == true)
                                {
                                    timer_check_joysticks.Interval = 1000;
                                    MsgBox.Close();
                                    joystick_left = joysticks[1];
                                    seq_joysticks_calibration++;
                                }
                                break;
                            case 2:
                                timer_check_joysticks.Interval = 100;
                                MsgBox.Show("Нажимайте красную кнопку, правую сторону");
                                seq_joysticks_calibration++;
                                break;
                            case 3:
                                if (statesJoy1.Buttons[3] == true)
                                {
                                    MsgBox.Close();
                                    joystick_right = joysticks[0];
                                    seq_joysticks_calibration++;
                                }

                                if (statesJoy2.Buttons[3] == true)
                                {
                                    MsgBox.Close();
                                    joystick_right = joysticks[1];
                                    seq_joysticks_calibration++;
                                }
                                break;
                            case 4:
                                timer_check_joysticks.Interval = 1000;
                                cmd_joysticks_calibration = false;
                                state_calibration_joysticks = true;
                                seq_joysticks_calibration = 100;
                                update_panel_joysticks();
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    MsgBox.Close();
                    state_is_connect_joysticks = false;
                    cmd_joysticks_calibration = false;
                    timer_check_joysticks.Interval = 1000;
                    state_calibration_joysticks = false;
                    update_panel_joysticks();
                }
            }
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.tcp_ip = textBox_tcp_server_ip.Text;
            Properties.Settings.Default.tcp_port = (int)numericUpDown_tcp_server_port.Value;
            Properties.Settings.Default.com_port_baudrate = (int)numericUpDown_com_port_baudrate.Value;
            Properties.Settings.Default.Save();
        }

        private void TextBox_tcp_server_ip_TextChanged(object sender, EventArgs e)
        {
            IPAddress ip;

            if (IPAddress.TryParse(textBox_tcp_server_ip.Text, out ip))
            {
                textBox_tcp_server_ip.BackColor = SystemColors.Window;
            }
            else
            {
                textBox_tcp_server_ip.BackColor = Color.LightCoral;
            }
        }

        private void TextBox_tcp_server_ip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        // ************************************************** work functions
        
        void update_panel_joysticks()
        {
            if (state_connect_joystick_left)
            {
                if (state_calibration_joysticks)
                {
                    pictureBox_state_joystick_left.Image = new Bitmap("icons/joystick_connect.png");
                }
                else
                {
                    pictureBox_state_joystick_left.Image = new Bitmap("icons/joystick_undefined.png");
                }
            }
            else
            {
                pictureBox_state_joystick_left.Image = new Bitmap("icons/joystick_disconnect.png");
            }

            if (state_connect_joystick_right)
            {
                if (state_calibration_joysticks)
                {
                    pictureBox_state_joystick_right.Image = new Bitmap("icons/joystick_connect.png");
                }
                else
                {
                    pictureBox_state_joystick_right.Image = new Bitmap("icons/joystick_undefined.png");
                }
            }
            else
            {
                pictureBox_state_joystick_right.Image = new Bitmap("icons/joystick_disconnect.png");
            }

            if (state_calibration_joysticks)
            {
                pictureBox_state_joysticks_calibration.Image = new Bitmap("icons/joystick_connect.png");
            }
            else
            {
                pictureBox_state_joysticks_calibration.Image = new Bitmap("icons/joystick_disconnect.png");
            }
        }

        void update_panel_tcp_connection()
        {
            if (state_tcp_connect)
            {
                button_tcp_close.Enabled = true;
                button_tcp_open.Enabled = false;
                textBox_tcp_server_ip.Enabled = false;
                numericUpDown_tcp_server_port.Enabled = false;
            }
            else
            {
                button_tcp_close.Enabled = false;
                button_tcp_open.Enabled = true;
                textBox_tcp_server_ip.Enabled = true;
                numericUpDown_tcp_server_port.Enabled = true;
            }
        }
    }
}
