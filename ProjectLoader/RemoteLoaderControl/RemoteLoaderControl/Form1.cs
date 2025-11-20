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
using System.Timers;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace RemoteLoaderControl
{
    public partial class form_main : Form
    {
        TcpClient tcp_client;
        NetworkStream tcp_stream;
        WaveInEvent waveIn_mic;
        DirectInput directInput;
        SerialPort com_port;

        bool state_tcp_is_connected = false;

        bool state_com_port_is_connected = false;

        System.Windows.Forms.Timer timer_check_joysticks;
        Joystick[] joysticks = new Joystick[2];
        Joystick joystick_left;
        Joystick joystick_right;
        bool state_joysticks_is_connected = false;
        bool state_joystick_left_is_connected = false;
        bool state_joystick_right_is_connected = false;
        bool state_calibration_joysticks = false;
        bool joystick_switch_msg_1 = true;
        bool cmd_joysticks_calibration = false;
        int seq_joysticks_calibration = 0;

        int joystick_left_position_x = 0;
        int joystick_left_position_y = 0;
        int joystick_right_position_x = 0;
        int joystick_right_position_y = 0;

        bool joystick_reader_is_thread = false;
        bool com_port_is_thread = false;
        bool tcp_is_thread = false;
        bool tcp_req_packet_perm = false;
        bool tcp_transmit_packet_perm = false;

        int interval_req_packet_com_port = 0;
        int interval_req_packet_tcp = 0;
        int interval_transmit_packet_tcp = 0;

        long tcp_timer_req_ms = 0;
        long tcp_timer_transmit_ms = 0;

        bool tcp_auto_reconnect = false;

        int tcp_reconnect_indicate_count = 0;

        // -------------------------------------------------- communication packet
        const byte com_port_start_packet = 0x24; // '$'
        const byte com_port_end_packet = 0x0A;  // '\n'

        enum comm_type_packet : byte
        {
            comm_type_packet_test = 0,
            comm_type_packet_resp,
            comm_type_packet_no_resp,
            comm_type_packet_nrf_resp,
            comm_type_packet_nrf_no_resp,
            comm_type_packet_result,
        }

        enum comm_type_msg : byte
        {
            comm_type_msg_tick = 0,
            comm_type_msg_cmd_ignition,
            comm_type_msg_cmd_engine,
            comm_type_msg_cmd_brake_parking,
            comm_type_msg_cmd_brake,
            comm_type_msg_cmd_hazard_light,
            comm_type_msg_cmd_left_turn_signal,
            comm_type_msg_cmd_right_turn_signal,
            comm_type_msg_cmd_head_light,
            comm_type_msg_cmd_rear_light,
            comm_type_msg_cmd_wipers,
            comm_type_msg_cmd_horn,
            comm_type_msg_cmd_switch_speed,
            comm_type_msg_cmd_audio_play,
            comm_type_msg_cmd_audio_packet,
            comm_type_msg_cmd_audio_stop,
            comm_type_msg_joystick_values,
            comm_type_msg_nrf_req_states,
            comm_type_msg_nrf_resp_states,
            comm_type_msg_nrf_emergency_stop,
            comm_type_msg_cmd_locked,
            comm_type_msg_cmd_unlocked,
            comm_type_msg_cmd_beacon_light
        }

        bool L753_state_ignition = false;
        bool L753_state_engine = false;
        bool L753_state_brake = false;
        bool L753_state_brake_parking = false;
        bool L753_state_hazard_light = false;
        bool L753_state_left_turn_signal = false;
        bool L753_state_right_turn_signal = false;
        bool L753_state_head_light = false;
        bool L753_state_rear_light = false;
        bool L753_state_wipers = false;
        bool L753_state_horn = false;

        bool L753_ind_min_fuel = false;
        bool L753_ind_min_hydraulic_oil = false;
        bool L753_ind_switch_speed = false;
        bool L753_ind_rear_cover = false;
        bool L753_ind_heating_engine = false;

        UInt16 L753_rpm_motor = 0;
        float L753_voltage_battery = 0;
        float L753_hydraulic_oil_temp = 0;
        float L753_coolant_temp = 0;
        byte L753_fuel_level = 0;

        bool L753_loader_is_locked = true;
        bool L753_tcp_socket_is_connected = false;
        bool L753_nrf_is_connected = false;
        bool L753_ecu_is_connected = false;

        // --------------------------------------------------

        public form_main()
        {
            InitializeComponent();

            this.Text = "Remote loader control L753";
            this.Icon = new Icon("prog_ico.ico");
            this.MaximizeBox = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += Form_main_FormClosing;

            waveIn_mic = new WaveInEvent();
            waveIn_mic.DeviceNumber = 0;
            waveIn_mic.WaveFormat = new WaveFormat(8000, 8, 1); // 8 kHz, 8 bit, mono
            waveIn_mic.BufferMilliseconds = 100; // 8000 * 0.1 = 800 byte
            waveIn_mic.DataAvailable += WaveIn_mic_DataAvailable;

            directInput = new DirectInput();

            com_port = new SerialPort();
            com_port.ReadTimeout = 1000;
            comboBox_com_port_baudrate.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_com_port_baudrate.Items.Add("9600");
            comboBox_com_port_baudrate.Items.Add("19200");
            comboBox_com_port_baudrate.Items.Add("38400");
            comboBox_com_port_baudrate.Items.Add("57600");
            comboBox_com_port_baudrate.Items.Add("115200");
            comboBox_com_port_baudrate.SelectedIndex = Properties.Settings.Default.com_port_baudrate_select_index;
            comboBox_com_port_port_names.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_com_port_port_names.DropDown += ComboBox_com_port_port_names_DropDown;
            ComboBox_com_port_port_names_DropDown(null, null);
            if (comboBox_com_port_port_names.Items.Count > 0) comboBox_com_port_port_names.SelectedIndex = 0;
            button_com_port_open.Click += Button_com_port_open_Click;
            button_com_port_close.Click += Button_com_port_close_Click;
            numericUpDown_interval_req_packet_com_port.Minimum = 100;
            numericUpDown_interval_req_packet_com_port.Maximum = 1000;
            numericUpDown_interval_req_packet_com_port.Value = Properties.Settings.Default.interval_packet_req_com_port;
            numericUpDown_interval_req_packet_com_port.ValueChanged += NumericUpDown_interval_req_packet_com_port_ValueChanged;
            textBox_com_port_uuid_dev.MaxLength = 10;
            textBox_com_port_uuid_dev.Text = Properties.Settings.Default.com_port_uuid_dev;
            textBox_com_port_uuid_dev.TextChanged += TextBox_com_port_uuid_dev_TextChanged;
            textBox_com_port_uuid_dev.LostFocus += TextBox_com_port_uuid_dev_LostFocus;
            com_port_is_thread = true;
            interval_req_packet_com_port = (int)numericUpDown_interval_req_packet_com_port.Value;
            Thread com_port_thread = new Thread(com_port_thread_func);
            com_port_thread.Start();
            update_com_port_elements();

            textBox_tcp_server_ip.MaxLength = 15;
            textBox_tcp_server_ip.TextChanged += TextBox_tcp_server_ip_TextChanged;
            textBox_tcp_server_ip.LostFocus += TextBox_tcp_server_ip_LostFocus;
            textBox_tcp_server_ip.Text = Properties.Settings.Default.tcp_ip;
            numericUpDown_tcp_server_port.Minimum = 0;
            numericUpDown_tcp_server_port.Maximum = 65535;
            numericUpDown_tcp_server_port.Value = numericUpDown_tcp_server_port.Minimum;
            numericUpDown_tcp_server_port.Value = Properties.Settings.Default.tcp_port;
            numericUpDown_interval_req_packet_tcp.Minimum = 100;
            numericUpDown_interval_req_packet_tcp.Maximum = 1000;
            numericUpDown_interval_req_packet_tcp.Value = Properties.Settings.Default.interval_packet_req_tcp;
            numericUpDown_interval_req_packet_tcp.ValueChanged += NumericUpDown_interval_req_packet_tcp_ValueChanged;
            numericUpDown_interval_transmit_packet_tcp.Minimum = 10;
            numericUpDown_interval_transmit_packet_tcp.Maximum = 500;
            numericUpDown_interval_transmit_packet_tcp.Value = Properties.Settings.Default.interval_packet_transmit_tcp;
            numericUpDown_interval_transmit_packet_tcp.ValueChanged += NumericUpDown_interval_transmit_packet_tcp_ValueChanged;
            interval_req_packet_tcp = (int)numericUpDown_interval_req_packet_tcp.Value;
            interval_transmit_packet_tcp = (int)numericUpDown_interval_transmit_packet_tcp.Value;
            button_tcp_open.Click += Button_tcp_open_Click;
            button_tcp_close.Click += Button_tcp_close_Click;
            tcp_is_thread = true;
            Thread tcp_thread = new Thread(tcp_thread_func);
            tcp_thread.Start();
            update_panel_tcp_connection();

            timer_check_joysticks = new System.Windows.Forms.Timer();
            timer_check_joysticks.Interval = 1000;
            timer_check_joysticks.Tick += Timer_check_joysticks_Tick;
            timer_check_joysticks.Enabled = true;
            button_joysticks_calibration.Click += Button_joysticks_calibration_Click;
            button_joysticks_calibration_reset.Click += Button_joysticks_calibration_reset_Click;

            joystick_reader_is_thread = true;
            Thread joystick_reader_thread = new Thread(joystick_reader);
            joystick_reader_thread.Start();

            pictureBox_fuel_level.BackgroundImage = new Bitmap("icons/fuel_level_background.png");
            pictureBox_cooltant_temp_level.BackgroundImage = new Bitmap("icons/coolant_temp_level_background.png");
            pictureBox_rpm_meter.BackgroundImage = new Bitmap("icons/rmp_meter_background.png");
            pictureBox_hydraulic_oil_temp_level.BackgroundImage = new Bitmap("icons/hydraulic_oil_temp_level_background.png");

            update_panel_joysticks();

            update_panel_status_and_indicators();
            update_panel_telemetry_and_visualization();

            button_cmd_unlocked.Click += Button_cmd_unlocked_Click;
            button_cmd_locked.Click += Button_cmd_locked_Click;

            checkBox_cmd_ignition.CheckedChanged += CheckBox_cmd_ignition_CheckedChanged;

            button_cmd_start_engine.Click += Button_cmd_start_engine_Click;
            button_cmd_stop_engine.Click += Button_cmd_stop_engine_Click;

            button_cmd_brake.MouseUp += Button_cmd_brake_MouseUp;
            button_cmd_brake.MouseDown += Button_cmd_brake_MouseDown;

            checkBox_cmd_brake_parking.CheckedChanged += CheckBox_cmd_brake_parking_CheckedChanged;            

            checkBox_cmd_head_light.CheckedChanged += CheckBox_cmd_head_light_CheckedChanged;
            checkBox_cmd_rear_light.CheckedChanged += CheckBox_cmd_rear_light_CheckedChanged;

            checkBox_cmd_wipers.CheckedChanged += CheckBox_cmd_wipers_CheckedChanged;

            checkBox_cmd_microphone.CheckedChanged += CheckBox_cmd_microphone_CheckedChanged;

            button_cmd_horn.MouseUp += Button_cmd_horn_MouseUp;
            button_cmd_horn.MouseDown += Button_cmd_horn_MouseDown;

            checkBox_cmd_beacon_light.CheckedChanged += CheckBox_cmd_beacon_light_CheckedChanged;

            checkBox_cmd_hazard_light.CheckedChanged += CheckBox_cmd_hazard_light_CheckedChanged;

            button_cmd_left_turn_signal.MouseUp += Button_cmd_left_turn_signal_MouseUp;
            button_cmd_left_turn_signal.MouseDown += Button_cmd_left_turn_signal_MouseDown;
            button_cmd_right_turn_signal.MouseUp += Button_cmd_right_turn_signal_MouseUp;
            button_cmd_right_turn_signal.MouseDown += Button_cmd_right_turn_signal_MouseDown;

            button_cmd_switch_speed.Click += Button_cmd_switch_speed_Click;

            checkBox_perm_transmit_joystick_values.CheckedChanged += CheckBox_perm_transmit_joystick_values_CheckedChanged;
        }

        private void CheckBox_cmd_beacon_light_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_beacon_light, (byte)(checkBox_cmd_beacon_light.Checked ? 1 : 0));
        }

        private void Button_cmd_switch_speed_Click(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_switch_speed, null);
        }

        private void Button_cmd_right_turn_signal_MouseDown(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_right_turn_signal, 0x01);
        }

        private void Button_cmd_right_turn_signal_MouseUp(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_right_turn_signal, 0x00);
        }

        private void Button_cmd_left_turn_signal_MouseDown(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_left_turn_signal, 0x01);
        }

        private void Button_cmd_left_turn_signal_MouseUp(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_left_turn_signal, 0x00);
        }

        private void CheckBox_cmd_hazard_light_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_hazard_light, (byte)(checkBox_cmd_hazard_light.Checked ? 1 : 0));
        }

        private void Button_cmd_horn_MouseDown(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_horn, 0x01);
        }

        private void Button_cmd_horn_MouseUp(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_horn, 0x00);
        }

        private void CheckBox_cmd_wipers_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_wipers, (byte)(checkBox_cmd_wipers.Checked ? 1 : 0));
        }

        private void CheckBox_cmd_rear_light_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_rear_light, (byte)(checkBox_cmd_rear_light.Checked ? 1 : 0));
        }

        private void CheckBox_cmd_head_light_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_head_light, (byte)(checkBox_cmd_head_light.Checked ? 1 : 0));
        }

        private void CheckBox_cmd_brake_parking_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_brake_parking, (byte)(checkBox_cmd_brake_parking.Checked ? 1 : 0));
        }

        private void Button_cmd_brake_MouseDown(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_brake, 0x01);
        }

        private void Button_cmd_brake_MouseUp(object sender, MouseEventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_brake, 0x00);
        }

        private void Button_cmd_stop_engine_Click(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_engine, 0x00);
        }

        private void Button_cmd_start_engine_Click(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_engine, 0x01);
        }

        private void Button_cmd_locked_Click(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_locked, null);
        }

        private void Button_cmd_unlocked_Click(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_unlocked, null);
        }

        private void CheckBox_cmd_ignition_CheckedChanged(object sender, EventArgs e)
        {
            reset_timers_tcp();
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_ignition, (byte)(checkBox_cmd_ignition.Checked ? 1 : 0));
        }

        private void CheckBox_perm_transmit_joystick_values_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_cmd_microphone.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_unlocked.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_locked.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_ignition.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_start_engine.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_stop_engine.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_brake.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_brake_parking.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_head_light.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_rear_light.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_wipers.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_horn.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_hazard_light.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_left_turn_signal.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_right_turn_signal.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            button_cmd_switch_speed.Enabled = !checkBox_perm_transmit_joystick_values.Checked;
            checkBox_cmd_beacon_light.Enabled = !checkBox_perm_transmit_joystick_values.Checked;

            if (checkBox_cmd_microphone.Checked)
            {
                checkBox_cmd_microphone.Checked = false;
            }

            reset_timers_tcp();
            tcp_transmit_packet_perm = checkBox_perm_transmit_joystick_values.Checked;
        }

        private void CheckBox_cmd_microphone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cmd_microphone.Checked)
            {
                tcp_req_packet_perm = false;
                tcp_transmit_packet_perm = false;
                reset_timers_tcp();
                transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_audio_play, null);
                waveIn_mic.StartRecording();
            }
            else
            {
                transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_audio_stop, null);
                waveIn_mic.StopRecording();
                tcp_req_packet_perm = true;
                tcp_transmit_packet_perm = checkBox_perm_transmit_joystick_values.Checked;
                reset_timers_tcp();
            }
        }

        private void NumericUpDown_interval_transmit_packet_tcp_ValueChanged(object sender, EventArgs e)
        {
            interval_transmit_packet_tcp = (int)numericUpDown_interval_transmit_packet_tcp.Value;
        }

        private void NumericUpDown_interval_req_packet_tcp_ValueChanged(object sender, EventArgs e)
        {
            interval_req_packet_tcp = (int)numericUpDown_interval_req_packet_tcp.Value;
        }

        private void NumericUpDown_interval_req_packet_com_port_ValueChanged(object sender, EventArgs e)
        {
            interval_req_packet_com_port = (int)numericUpDown_interval_req_packet_com_port.Value;
        }

        private void TextBox_com_port_uuid_dev_LostFocus(object sender, EventArgs e)
        {
            if (check_format_uuid_dev(textBox_com_port_uuid_dev.Text) == false) textBox_com_port_uuid_dev.BackColor = Color.Red;
            else textBox_com_port_uuid_dev.BackColor = SystemColors.Window;
        }

        private void TextBox_com_port_uuid_dev_TextChanged(object sender, EventArgs e)
        {
            if (check_format_uuid_dev(textBox_com_port_uuid_dev.Text) == false) textBox_com_port_uuid_dev.BackColor = Color.Red;
            else textBox_com_port_uuid_dev.BackColor = SystemColors.Window;
        }

        private void Button_joysticks_calibration_reset_Click(object sender, EventArgs e)
        {
            MsgBox.Close();
            timer_check_joysticks.Interval = 1000;
            state_calibration_joysticks = false;
            cmd_joysticks_calibration = false;
            update_panel_joysticks();
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
            if (state_joysticks_is_connected == false)
            {
                var devices = directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices);

                if (devices.Count >= 2)
                {
                    joysticks[0] = new Joystick(directInput, devices[0].InstanceGuid);
                    joysticks[1] = new Joystick(directInput, devices[1].InstanceGuid);
                    joysticks[0].Acquire();
                    joysticks[1].Acquire();

                    joystick_switch_msg_1 = true;
                    state_joysticks_is_connected = true;
                    state_joystick_left_is_connected = true;
                    state_joystick_right_is_connected = true;

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

            if(state_calibration_joysticks == false)
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
                    state_joysticks_is_connected = false;
                    cmd_joysticks_calibration = false;
                    timer_check_joysticks.Interval = 1000;
                    state_calibration_joysticks = false;
                    update_panel_joysticks();
                }
            }
        }

        private void WaveIn_mic_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] pcm_u8 = e.Buffer;
            transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_cmd_audio_packet, pcm_u8);
        }

        private void Button_tcp_close_Click(object sender, EventArgs e)
        {
            if (checkBox_cmd_microphone.Checked == true) checkBox_cmd_microphone.Checked = false;
            if (checkBox_perm_transmit_joystick_values.Checked == true) checkBox_perm_transmit_joystick_values.Checked = false;
            tcp_auto_reconnect = false;

            tcp_req_packet_perm = false;
            state_tcp_is_connected = false;
            tcp_client.Close();
            update_panel_tcp_connection();
        }

        private void Button_tcp_open_Click(object sender, EventArgs e)
        {
            if (check_format_ip_addr(textBox_tcp_server_ip.Text) == false)
            {
                MessageBox.Show("Format IP address not correct");
                return;
            }

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
                    state_tcp_is_connected = true;
                    tcp_req_packet_perm = true;
                    update_panel_tcp_connection();
                }
                else
                {
                    state_tcp_is_connected = false;
                    update_panel_tcp_connection();
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Timeout");
                state_tcp_is_connected = false;
                update_panel_tcp_connection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connect" + ex.Message);
                state_tcp_is_connected = false;
                update_panel_tcp_connection();
            }
        }

        private void TextBox_tcp_server_ip_LostFocus(object sender, EventArgs e)
        {
            if (check_format_ip_addr(textBox_tcp_server_ip.Text) == false) textBox_tcp_server_ip.BackColor = Color.Red;
            else textBox_tcp_server_ip.BackColor = SystemColors.Window;
        }

        private void TextBox_tcp_server_ip_TextChanged(object sender, EventArgs e)
        {
            if (check_format_ip_addr(textBox_tcp_server_ip.Text) == false) textBox_tcp_server_ip.BackColor = Color.Red;
            else textBox_tcp_server_ip.BackColor = SystemColors.Window;
        }

        private void Button_com_port_close_Click(object sender, EventArgs e)
        {
            if (com_port.IsOpen)
            {
                state_com_port_is_connected = false;
                com_port.Close();
            }
            update_com_port_elements();
        }

        private void Button_com_port_open_Click(object sender, EventArgs e)
        {
            if (comboBox_com_port_port_names.Text.Length == 0)
            {
                MessageBox.Show("Select COM port");
                return;
            }

            if (check_format_uuid_dev(textBox_com_port_uuid_dev.Text) == false)
            {
                MessageBox.Show("Format uuid dev not correct");
                return;
            }

            com_port.PortName = comboBox_com_port_port_names.Text;
            com_port.BaudRate = int.Parse(comboBox_com_port_baudrate.Text);
            if (com_port.IsOpen == false)
            {
                com_port.Open();
                state_com_port_is_connected = true;
            }
            update_com_port_elements();
        }

        private void ComboBox_com_port_port_names_DropDown(object sender, EventArgs e)
        {
            comboBox_com_port_port_names.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox_com_port_port_names.Items.Add(port);
            }
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.tcp_ip = textBox_tcp_server_ip.Text;
            Properties.Settings.Default.tcp_port = (int)numericUpDown_tcp_server_port.Value;
            Properties.Settings.Default.com_port_baudrate_select_index = comboBox_com_port_baudrate.SelectedIndex;
            Properties.Settings.Default.interval_packet_transmit_tcp = (int)numericUpDown_interval_transmit_packet_tcp.Value;
            Properties.Settings.Default.interval_packet_req_tcp = (int)numericUpDown_interval_req_packet_tcp.Value;
            Properties.Settings.Default.interval_packet_req_com_port = (int)numericUpDown_interval_req_packet_com_port.Value;
            Properties.Settings.Default.com_port_uuid_dev = textBox_com_port_uuid_dev.Text;
            Properties.Settings.Default.Save();

            if (tcp_client != null)
            {
                state_tcp_is_connected = false;
                tcp_client.Close();
            }
            if (com_port.IsOpen)
            {
                state_com_port_is_connected = false;
                com_port.Close();
            }

            joystick_reader_is_thread = false;
            com_port_is_thread = false;
            tcp_is_thread = false;
        }

        void update_com_port_elements()
        {
            if (state_com_port_is_connected)
            {
                button_com_port_close.Enabled = true;
                button_com_port_open.Enabled = false;
                comboBox_com_port_port_names.Enabled = false;
                comboBox_com_port_baudrate.Enabled = false;
                numericUpDown_interval_req_packet_com_port.Enabled = false;
                textBox_com_port_uuid_dev.Enabled = false;

                panel_dashboard.Enabled = true;
                groupBox_loader_status_and_indicators.Enabled = true;
            }
            else
            {
                button_com_port_close.Enabled = false;
                button_com_port_open.Enabled = true;
                comboBox_com_port_port_names.Enabled = true;
                comboBox_com_port_baudrate.Enabled = true;
                numericUpDown_interval_req_packet_com_port.Enabled = true;
                textBox_com_port_uuid_dev.Enabled = true;

                if (state_tcp_is_connected == false)
                {
                    panel_dashboard.Enabled = false;
                    groupBox_loader_status_and_indicators.Enabled = false;
                }
            }
        }

        bool check_format_ip_addr(string text_ip)
        {
            string pattern = @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\."
                   + @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\."
                   + @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)\."
                   + @"(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)$";

            if (!Regex.IsMatch(text_ip, pattern))
            {
                return false;
            }
            else return true;
        }

        bool check_format_uuid_dev(string text_ip)
        {
            string pattern = @"^(0x[0-9A-F]{8})$";

            if (!Regex.IsMatch(text_ip, pattern))
            {
                return false;
            }
            else return true;
        }

        void update_panel_tcp_connection()
        {
            if (state_tcp_is_connected)
            {
                button_tcp_close.Enabled = true;
                button_tcp_open.Enabled = false;
                textBox_tcp_server_ip.Enabled = false;
                numericUpDown_tcp_server_port.Enabled = false;
                numericUpDown_interval_req_packet_tcp.Enabled = false;
                numericUpDown_interval_transmit_packet_tcp.Enabled = false;

                panel_dashboard.Enabled = true;
                groupBox_loader_status_and_indicators.Enabled = true;
                groupBox_telemetry_and_visualization.Enabled = true;
                groupBox_loader_commands.Enabled = true;

                label_info_tcp_info.Text = "TCP: Connected";
            }
            else
            {
                button_tcp_close.Enabled = false;
                button_tcp_open.Enabled = true;
                textBox_tcp_server_ip.Enabled = true;
                numericUpDown_tcp_server_port.Enabled = true;
                numericUpDown_interval_req_packet_tcp.Enabled = true;
                numericUpDown_interval_transmit_packet_tcp.Enabled = true;

                if (state_com_port_is_connected)
                {
                    groupBox_telemetry_and_visualization.Enabled = false;
                    groupBox_loader_commands.Enabled = false;
                }
                else
                {
                    panel_dashboard.Enabled = false;
                    groupBox_loader_status_and_indicators.Enabled = false;
                    groupBox_telemetry_and_visualization.Enabled = false;
                    groupBox_loader_commands.Enabled = false;
                }

                label_info_tcp_info.Text = "TCP: Disconnected";
            }
        }

        void update_panel_joysticks()
        {
            if (state_joystick_left_is_connected)
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

            if (state_joystick_right_is_connected)
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

        int map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

        void draw_position_joysticks()
        {
            int img_width = pictureBox_joystick_position_left.Width;
            int img_height = pictureBox_joystick_position_left.Height;
            int joy_x = map(joystick_left_position_x, 0, 65535, 0, img_width);
            int joy_y = map(joystick_left_position_y, 0, 65535, 0, img_height);
            Bitmap bmp_background = new Bitmap(img_width, img_height);
            pictureBox_joystick_position_left.Image = bmp_background;
            using (Graphics g = Graphics.FromImage(bmp_background))
            {
                g.Clear(Color.White);
                Pen pen_black = new Pen(Color.Black, 1);
                g.DrawLine(pen_black, img_width / 2, 0, img_width / 2, (img_height - 1));
                g.DrawLine(pen_black, 0, img_height / 2, (img_width - 1), img_height / 2);
                if (state_calibration_joysticks)
                {
                    SolidBrush brush_blue = new SolidBrush(Color.Green);
                    g.FillEllipse(brush_blue, joy_x - 5, joy_y - 5, 10, 10);
                }
            }
            pictureBox_joystick_position_left.Refresh();

            img_width = pictureBox_joystick_position_right.Width;
            img_height = pictureBox_joystick_position_right.Height;
            joy_x = map(joystick_right_position_x, 0, 65535, 0, img_width);
            joy_y = map(joystick_right_position_y, 0, 65535, 0, img_height);
            bmp_background = new Bitmap(img_width, img_height);
            pictureBox_joystick_position_right.Image = bmp_background;
            using (Graphics g = Graphics.FromImage(bmp_background))
            {
                g.Clear(Color.White);
                Pen pen_black = new Pen(Color.Black, 1);
                g.DrawLine(pen_black, img_width / 2, 0, img_width / 2, (img_height - 1));
                g.DrawLine(pen_black, 0, img_height / 2, (img_width - 1), img_height / 2);
                if (state_calibration_joysticks)
                {
                    SolidBrush brush_blue = new SolidBrush(Color.Green);
                    g.FillEllipse(brush_blue, joy_x - 5, joy_y - 5, 10, 10);
                }
            }
            pictureBox_joystick_position_right.Refresh();
        }

        void safe_invoke(Action action)
        {
            if (this.IsHandleCreated && !this.IsDisposed)
            {
                try
                {
                    this.BeginInvoke(action);
                }
                catch { }
            }
        }

        void joystick_reader()
        {
            long last_now_ms = Environment.TickCount;
            while (joystick_reader_is_thread)
            {

                if (state_joysticks_is_connected)
                {
                    if (state_calibration_joysticks)
                    {
                        try
                        {
                            joystick_left.Poll();
                            JoystickState states_joystick_left = joystick_left.GetCurrentState();
                            joystick_left_position_x = states_joystick_left.X;
                            joystick_left_position_y = states_joystick_left.Y;

                            if (states_joystick_left.Buttons[2] == true)
                            {
                                safe_invoke(joy_button_handler_disable);
                            }

                            if (states_joystick_left.Buttons[3] == true)
                            {
                                safe_invoke(joy_button_handler_enable);
                            }
                        }
                        catch (Exception)
                        {
                            state_calibration_joysticks = false;
                            state_joystick_left_is_connected = false;
                            safe_invoke(update_panel_joysticks);
                        }

                        try
                        {
                            joystick_right.Poll();
                            JoystickState states_joystick_right = joystick_right.GetCurrentState();
                            joystick_right_position_x = states_joystick_right.X;
                            joystick_right_position_y = states_joystick_right.Y;

                            if (states_joystick_right.Buttons[2] == true)
                            {
                                safe_invoke(joy_button_handler_disable);
                            }

                            if (states_joystick_right.Buttons[3] == true)
                            {
                                safe_invoke(joy_button_handler_enable);
                            }
                        }
                        catch (Exception)
                        {
                            state_calibration_joysticks = false;
                            state_joystick_right_is_connected = false;
                            safe_invoke(update_panel_joysticks);
                        }
                    }
                    else
                    {
                        joystick_left_position_x = 0;
                        joystick_left_position_y = 0;
                        joystick_right_position_x = 0;
                        joystick_right_position_y = 0;
                    }
                }
                else
                {
                    joystick_left_position_x = 0;
                    joystick_left_position_y = 0;
                    joystick_right_position_x = 0;
                    joystick_right_position_y = 0;
                }

                long now_ms = Environment.TickCount;
                if ((now_ms - last_now_ms) >= 100)
                {
                    safe_invoke(draw_position_joysticks);
                    last_now_ms = now_ms;
                }

                Thread.Sleep(5);

            }
        }

        void com_port_thread_func()
        {
            int available_len = 0;
            int last_available_len = 0;
            long last_now_ms = Environment.TickCount;

            while (com_port_is_thread)
            {
                if (com_port.IsOpen)
                {
                    try
                    {
                        available_len = com_port.BytesToRead;
                        if (available_len > 0 && last_available_len > 0 && (available_len == last_available_len))
                        {
                            byte[] read_data = new byte[available_len];
                            com_port.Read(read_data, 0, available_len);

                            if (read_data[0] == com_port_start_packet)
                            {
                                UInt32 uuid_dev_val = Convert.ToUInt32(textBox_com_port_uuid_dev.Text, 16);
                                UInt32 uuid_test = BitConverter.ToUInt32(read_data, 1);
                                if (uuid_test == uuid_dev_val)
                                {
                                    byte seq_packet = read_data[5];
                                    byte type_packet = read_data[6];
                                    byte type_msg = read_data[7];
                                    UInt16 len_msg = BitConverter.ToUInt16(read_data, 8);
                                    if (type_packet == (byte)comm_type_packet.comm_type_packet_result && type_msg == (byte)comm_type_msg.comm_type_msg_nrf_resp_states)
                                    {
                                        if (len_msg == 4)
                                        {
                                            L753_loader_is_locked = BitConverter.ToBoolean(read_data, 10);
                                            L753_tcp_socket_is_connected = BitConverter.ToBoolean(read_data, 11);
                                            L753_nrf_is_connected = BitConverter.ToBoolean(read_data, 12);
                                            L753_ecu_is_connected = BitConverter.ToBoolean(read_data, 13);
                                            safe_invoke(update_panel_status_and_indicators);
                                        }
                                    }
                                }
                            }

                        }
                        last_available_len = available_len;

                        long now_ms = Environment.TickCount;
                        if ((now_ms - last_now_ms) >= interval_req_packet_com_port)
                        {
                            transmit_comand_com_port(comm_type_packet.comm_type_packet_nrf_resp, 0x00, comm_type_msg.comm_type_msg_nrf_req_states);
                            last_now_ms = now_ms;
                        }
                    }
                    catch { }
                }

                Thread.Sleep(5);
            }
        }

        void transmit_comand_com_port(comm_type_packet type_packet, byte seq_packet, comm_type_msg type_msg)
        {
            UInt32 uuid_dev_val = Convert.ToUInt32(textBox_com_port_uuid_dev.Text, 16);
            byte[] uuid_dev_bytes = BitConverter.GetBytes(uuid_dev_val);

            UInt16 len_msg = 0;
            byte[] len_msg_bytes = BitConverter.GetBytes(len_msg);

            byte[] data = new byte[32];
            data[0] = com_port_start_packet;
            data[1] = uuid_dev_bytes[0];
            data[2] = uuid_dev_bytes[1];
            data[3] = uuid_dev_bytes[2];
            data[4] = uuid_dev_bytes[3];
            data[5] = seq_packet;
            data[6] = (byte)type_packet;
            data[7] = (byte)type_msg;
            data[8] = len_msg_bytes[0];
            data[9] = len_msg_bytes[1];
            data[10] = com_port_end_packet;

            try
            {
                com_port.Write(data, 0, 32);
            }
            catch (Exception) { }
        }

        void transmit_comand_tcp(comm_type_packet type_packet, byte seq_packet, comm_type_msg type_msg, byte msg)
        {
            if (state_tcp_is_connected == false) return;

            UInt16 len_msg = 1;
            byte[] data_tcp = new byte[7 + len_msg + 1];
            data_tcp[0] = (byte)'$';
            data_tcp[1] = (byte)type_packet;
            data_tcp[2] = seq_packet;
            data_tcp[3] = 0x01;
            data_tcp[4] = (byte)type_msg;
            data_tcp[5] = (byte)(len_msg >> 8);
            data_tcp[6] = (byte)len_msg;
            data_tcp[7] = msg;
            data_tcp[data_tcp.Length - 1] = (byte)'\n';

            try
            {
                tcp_stream.Write(data_tcp, 0, data_tcp.Length);
            }
            catch
            {
                safe_invoke(handle_tcp_error);
            }
        }

        void transmit_comand_tcp(comm_type_packet type_packet, byte seq_packet, comm_type_msg type_msg, byte[] msg)
        {
            if (state_tcp_is_connected == false) return;

            UInt16 len_msg = 0;
            if (msg != null) len_msg = (UInt16)msg.Length;

            byte[] data_tcp = new byte[7 + len_msg + 1];
            data_tcp[0] = (byte)'$';
            data_tcp[1] = (byte)type_packet;
            data_tcp[2] = seq_packet;
            data_tcp[3] = 0x01;
            data_tcp[4] = (byte)type_msg;
            data_tcp[5] = (byte)(len_msg >> 8);
            data_tcp[6] = (byte)len_msg;
            if (msg != null) Buffer.BlockCopy(msg, 0, data_tcp, 7, len_msg);
            data_tcp[data_tcp.Length - 1] = (byte)'\n';

            try
            {
                tcp_stream.Write(data_tcp, 0, data_tcp.Length);
            }
            catch
            {
                safe_invoke(handle_tcp_error);
            }
        }

        void handle_tcp_error()
        {
            if (checkBox_cmd_microphone.Checked == true) checkBox_cmd_microphone.Checked = false;
            if (checkBox_perm_transmit_joystick_values.Checked == true) checkBox_perm_transmit_joystick_values.Checked = false;

            Button_tcp_close_Click(null, null);
            //MessageBox.Show("TCP, error");
            tcp_auto_reconnect = true;
        }

        void update_panel_status_and_indicators()
        {
            if (L753_loader_is_locked) pictureBox_status_loader_is_locked.Image = new Bitmap("icons/locked.png");
            else pictureBox_status_loader_is_locked.Image = new Bitmap("icons/unlocked.png");

            if (L753_tcp_socket_is_connected) pictureBox_status_tcp_is_connected.Image = new Bitmap("icons/connection.png");
            else pictureBox_status_tcp_is_connected.Image = new Bitmap("icons/disconnection.png");

            if (L753_nrf_is_connected) pictureBox_status_nrf_is_connected.Image = new Bitmap("icons/connection.png");
            else pictureBox_status_nrf_is_connected.Image = new Bitmap("icons/disconnection.png");

            if (L753_ecu_is_connected) pictureBox_status_ecu_is_connected.Image = new Bitmap("icons/connection.png");
            else pictureBox_status_ecu_is_connected.Image = new Bitmap("icons/disconnection.png");

            if (L753_state_ignition) pictureBox_status_ignition.Image = new Bitmap("icons/on.png");
            else pictureBox_status_ignition.Image = new Bitmap("icons/off.png");

            if (L753_state_engine) pictureBox_status_engine.Image = new Bitmap("icons/on.png");
            else pictureBox_status_engine.Image = new Bitmap("icons/off.png");

            if (L753_state_brake) pictureBox_status_brake.Image = new Bitmap("icons/on.png");
            else pictureBox_status_brake.Image = new Bitmap("icons/off.png");

            if (L753_state_brake_parking) pictureBox_status_brake_parking.Image = new Bitmap("icons/on.png");
            else pictureBox_status_brake_parking.Image = new Bitmap("icons/off.png");

            if (L753_state_hazard_light) pictureBox_status_hazard_light.Image = new Bitmap("icons/on.png");
            else pictureBox_status_hazard_light.Image = new Bitmap("icons/off.png");

            if (L753_state_left_turn_signal) pictureBox_status_left_turn_signal.Image = new Bitmap("icons/on.png");
            else pictureBox_status_left_turn_signal.Image = new Bitmap("icons/off.png");

            if (L753_state_right_turn_signal) pictureBox_status_right_turn_signal.Image = new Bitmap("icons/on.png");
            else pictureBox_status_right_turn_signal.Image = new Bitmap("icons/off.png");

            if (L753_state_head_light) pictureBox_status_head_light.Image = new Bitmap("icons/on.png");
            else pictureBox_status_head_light.Image = new Bitmap("icons/off.png");

            if (L753_state_rear_light) pictureBox_status_rear_light.Image = new Bitmap("icons/on.png");
            else pictureBox_status_rear_light.Image = new Bitmap("icons/off.png");

            if (L753_state_wipers) pictureBox_status_wipers.Image = new Bitmap("icons/on.png");
            else pictureBox_status_wipers.Image = new Bitmap("icons/off.png");

            if (L753_state_horn) pictureBox_status_horn.Image = new Bitmap("icons/on.png");
            else pictureBox_status_horn.Image = new Bitmap("icons/off.png");

            if (L753_ind_min_fuel) pictureBox_ind_min_fuel.Image = new Bitmap("icons/ind_min_fuel.png");
            else pictureBox_ind_min_fuel.Image = new Bitmap("icons/ind_off.png");

            if (L753_ind_min_hydraulic_oil) pictureBox_ind_min_hydraulic_oil.Image = new Bitmap("icons/ind_min_oil.png");
            else pictureBox_ind_min_hydraulic_oil.Image = new Bitmap("icons/ind_off.png");

            if (L753_ind_switch_speed) pictureBox_ind_switch_speed.Image = new Bitmap("icons/ind_switch_speed.png");
            else pictureBox_ind_switch_speed.Image = new Bitmap("icons/ind_off.png");

            if (L753_ind_rear_cover) pictureBox_ind_rear_cover.Image = new Bitmap("icons/ind_rear_cover.png");
            else pictureBox_ind_rear_cover.Image = new Bitmap("icons/ind_off.png");

            if (L753_ind_heating_engine) pictureBox_ind_heating_engine.Image = new Bitmap("icons/ind_heating_engine.png");
            else pictureBox_ind_heating_engine.Image = new Bitmap("icons/ind_off.png");
        }

        void reset_timers_tcp()
        {
            tcp_timer_req_ms = Environment.TickCount;
            tcp_timer_transmit_ms = Environment.TickCount;
        }

        void tcp_thread_func()
        {
            tcp_timer_req_ms = Environment.TickCount;
            tcp_timer_transmit_ms = Environment.TickCount;

            while (tcp_is_thread)
            {
                try
                {
                    if (state_tcp_is_connected && tcp_stream != null)
                    {
                        if (tcp_stream.DataAvailable)
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead_len = tcp_stream.Read(buffer, 0, buffer.Length);

                            if (buffer[0] == '$' && buffer[bytesRead_len - 1] == '\n')
                            {
                                L753_state_ignition = buffer[2] == 1;
                                L753_state_engine = buffer[3] == 1;
                                L753_state_brake_parking = buffer[4] == 1;
                                L753_state_brake = buffer[5] == 1;
                                L753_state_hazard_light = buffer[6] == 1;
                                L753_state_left_turn_signal = buffer[7] == 1;
                                L753_state_right_turn_signal = buffer[8] == 1;
                                L753_state_head_light = buffer[9] == 1;
                                L753_state_rear_light = buffer[10] == 1;
                                L753_state_wipers = buffer[11] == 1;
                                L753_state_horn = buffer[12] == 1;
                                L753_ind_min_fuel = buffer[13] == 1;
                                L753_ind_min_hydraulic_oil = buffer[14] == 1;
                                L753_ind_switch_speed = buffer[15] == 1;
                                L753_ind_rear_cover = buffer[16] == 1;
                                L753_ind_heating_engine = buffer[17] == 1;

                                L753_rpm_motor = BitConverter.ToUInt16(buffer, 18);
                                L753_voltage_battery = BitConverter.ToSingle(buffer, 20);
                                L753_hydraulic_oil_temp = BitConverter.ToSingle(buffer, 24);
                                L753_coolant_temp = BitConverter.ToSingle(buffer, 28);
                                L753_fuel_level = buffer[32];

                                L753_loader_is_locked = buffer[33] == 1;
                                L753_tcp_socket_is_connected = buffer[34] == 1;
                                L753_nrf_is_connected = buffer[35] == 1;
                                L753_ecu_is_connected = buffer[36] == 1;

                                if (L753_fuel_level > 8) L753_fuel_level = 8;
                                else if (L753_fuel_level < 0) L753_fuel_level = 0;

                                if (L753_coolant_temp > 120) L753_coolant_temp = 120;
                                else if (L753_coolant_temp < 0) L753_coolant_temp = 0;

                                if (L753_rpm_motor > 4000) L753_rpm_motor = 4000;
                                else if (L753_rpm_motor < 0) L753_rpm_motor = 0;

                                if (L753_hydraulic_oil_temp > 100) L753_hydraulic_oil_temp = 100;
                                else if (L753_hydraulic_oil_temp < 0) L753_hydraulic_oil_temp = 0;

                                safe_invoke(update_panel_status_and_indicators);
                                safe_invoke(update_panel_telemetry_and_visualization);
                            }
                        }

                        long now_ms = Environment.TickCount;

                        if (tcp_req_packet_perm)
                        {
                            if ((now_ms - tcp_timer_req_ms) >= interval_req_packet_tcp)
                            {
                                transmit_comand_tcp(comm_type_packet.comm_type_packet_resp, 0x00, comm_type_msg.comm_type_msg_tick, null);
                                tcp_timer_req_ms = now_ms;
                            }
                        }

                        if (tcp_transmit_packet_perm)
                        {
                            if ((now_ms - tcp_timer_transmit_ms) >= interval_transmit_packet_tcp)
                            {
                                UInt16 servo_left_x_value = (UInt16)(joystick_left_position_x);
                                UInt16 servo_left_y_value = (UInt16)(joystick_left_position_y);
                                UInt16 servo_right_x_value = (UInt16)joystick_right_position_x;
                                UInt16 servo_right_y_value = (UInt16)joystick_right_position_y;

                                byte[] msg_joy = new byte[8];
                                msg_joy[0] = (byte)(servo_left_x_value & 0xFF);
                                msg_joy[1] = (byte)((servo_left_x_value >> 8) & 0xFF);
                                msg_joy[2] = (byte)(servo_left_y_value & 0xFF);
                                msg_joy[3] = (byte)((servo_left_y_value >> 8) & 0xFF);
                                msg_joy[4] = (byte)(servo_right_x_value & 0xFF);
                                msg_joy[5] = (byte)((servo_right_x_value >> 8) & 0xFF);
                                msg_joy[6] = (byte)(servo_right_y_value & 0xFF);
                                msg_joy[7] = (byte)((servo_right_y_value >> 8) & 0xFF);

                                transmit_comand_tcp(comm_type_packet.comm_type_packet_no_resp, 0x00, comm_type_msg.comm_type_msg_joystick_values, msg_joy);

                                tcp_timer_transmit_ms = now_ms;
                            }
                        }
                    }
                }
                catch { }


                if (!state_tcp_is_connected && tcp_auto_reconnect)
                {
                    try
                    {
                        tcp_client = new TcpClient();

                        var connectTask = tcp_client.ConnectAsync(textBox_tcp_server_ip.Text, (int)numericUpDown_tcp_server_port.Value);

                        safe_invoke(tcp_reconnecting_indicate);

                        if (!connectTask.Wait(1000))
                        {
                            tcp_client.Close();
                            throw new TimeoutException("Connected timeout");
                        }

                        if (tcp_client.Connected)
                        {
                            tcp_stream = tcp_client.GetStream();
                            state_tcp_is_connected = true;
                            tcp_req_packet_perm = true;
                            safe_invoke(update_panel_tcp_connection);
                        }
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }

                Thread.Sleep(5);
            }
        }

        void update_panel_telemetry_and_visualization()
        {
            draw_fuel_level();
            draw_cooltant_temp_level();
            draw_rpm_meter();
            draw_hydraulic_oil_temp_level();

            label_info_rpm_meter.Text = "Оборот двигателья\n" + L753_rpm_motor.ToString();
            label_info_hydraulic_oil_temp_level.Text = "Температура гидравлического масло\n" + L753_hydraulic_oil_temp.ToString("F2");
            label_info_cooltant_temp_level.Text = "Температура\nохлаждающий\nжидкости\n" + L753_coolant_temp.ToString("F2");
            label_info_fuel_level.Text = "Уровень топлива\n" + L753_fuel_level.ToString();
        }

        void draw_fuel_level()
        {
            int angle = map(L753_fuel_level, 0, 8, 0, 90);

            Bitmap bmp_src = new Bitmap("icons/fuel_level_arrow.png");
            Bitmap bmp_rot = new Bitmap(bmp_src.Width, bmp_src.Height);
            bmp_rot.SetResolution(bmp_src.HorizontalResolution, bmp_src.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bmp_rot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(110, 72);
                g.RotateTransform(angle);
                g.TranslateTransform(-110, -72);
                g.DrawImage(bmp_src, new Point(0, 0));
            }
            pictureBox_fuel_level.Image = bmp_rot;

        }

        void draw_cooltant_temp_level()
        {
            int angle = map((int)L753_coolant_temp, 0, 120, 0, 90);

            Bitmap bmp_src = new Bitmap("icons/coolant_temp_arrow.png");
            Bitmap bmp_rot = new Bitmap(bmp_src.Width, bmp_src.Height);
            bmp_rot.SetResolution(bmp_src.HorizontalResolution, bmp_src.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bmp_rot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(110, 72);
                g.RotateTransform(angle);
                g.TranslateTransform(-110, -72);
                g.DrawImage(bmp_src, new Point(0, 0));
            }
            pictureBox_cooltant_temp_level.Image = bmp_rot;
        }

        void draw_rpm_meter()
        {
            int angle = map(L753_rpm_motor, 0, 4000, 0, 270);

            Bitmap bmp_src = new Bitmap("icons/rmp_meter_arrow.png");
            Bitmap bmp_rot = new Bitmap(bmp_src.Width, bmp_src.Height);
            bmp_rot.SetResolution(bmp_src.HorizontalResolution, bmp_src.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bmp_rot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(81, 81);
                g.RotateTransform(angle);
                g.TranslateTransform(-81, -81);
                g.DrawImage(bmp_src, new Point(0, 0));
            }
            pictureBox_rpm_meter.Image = bmp_rot;
        }

        void draw_hydraulic_oil_temp_level()
        {
            int angle = map((int)L753_hydraulic_oil_temp, 0, 100, 0, 90);

            Bitmap bmp_src = new Bitmap("icons/hydraulic_oil_temp_level_arrow.png");
            Bitmap bmp_rot = new Bitmap(bmp_src.Width, bmp_src.Height);
            bmp_rot.SetResolution(bmp_src.HorizontalResolution, bmp_src.VerticalResolution);
            using (Graphics g = Graphics.FromImage(bmp_rot))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.TranslateTransform(110, 72);
                g.RotateTransform(angle);
                g.TranslateTransform(-110, -72);
                g.DrawImage(bmp_src, new Point(0, 0));
            }
            pictureBox_hydraulic_oil_temp_level.Image = bmp_rot;
        }

        void joy_button_handler_disable()
        {
            if (state_tcp_is_connected == false) return;
            if (checkBox_perm_transmit_joystick_values.Checked == true) checkBox_perm_transmit_joystick_values.Checked = false;
        }

        void joy_button_handler_enable()
        {
            if (state_tcp_is_connected == false) return;
            if (checkBox_perm_transmit_joystick_values.Checked == false) checkBox_perm_transmit_joystick_values.Checked = true;
        }

        void tcp_reconnecting_indicate()
        {
            label_info_tcp_info.Text = "TCP: Reconnect";
            for (int i = 0; i < tcp_reconnect_indicate_count; i++)
            {
                label_info_tcp_info.Text += ".";
            }
            tcp_reconnect_indicate_count++;
            if (tcp_reconnect_indicate_count >= 5) tcp_reconnect_indicate_count = 0;
        }

    }
}
