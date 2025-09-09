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

namespace RemoteLoaderControl
{
    public partial class form_main : Form
    {
        // ************************************************** variables
        static TcpClient tcp_client;
        static NetworkStream tcp_stream;
        static WaveInEvent waveIn_mic;
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

        bool state_controller_connected = false;
        bool state_ECU_connected = false;

        int loader_fuel_level = 0;
        int loader_cooltant_temp_level = 0;
        int loader_rmp_motor = 0;
        int loader_hydraulic_oil_temp_level = 0;

        int joystick_left_position_x = 0;
        int joystick_left_position_y = 0;
        int joystick_right_position_x = 0;
        int joystick_right_position_y = 0;

        enum tcp_type_packet
        {
            tcp_type_packet_test = 0,
            tcp_type_packet_resp,
            tcp_type_packet_no_resp,
        }

        enum tcp_type_msg
        {
            tcp_type_msg_tick = 0,
            tcp_type_msg_cmd_ignition,
            tcp_type_msg_cmd_engine,
            tcp_type_msg_cmd_brake_parking,
            tcp_type_msg_cmd_brake,
            tcp_type_msg_cmd_hazard_light,
            tcp_type_msg_cmd_left_turn_signal,
            tcp_type_msg_cmd_right_turn_signal,
            tcp_type_msg_cmd_head_light,
            tcp_type_msg_cmd_rear_light,
            tcp_type_msg_cmd_wipers,
            tcp_type_msg_cmd_horn,
            tcp_type_msg_cmd_audio_play,
            tcp_type_msg_cmd_audio_packet,
            tcp_type_msg_cmd_audio_stop,
            tcp_type_msg_gas_pedal_push,
            tcp_type_msg_gas_pedal_release,
            tcp_type_msg_switch_speed,
            tcp_type_msg_joystick_values,
        }

        struct ecu_L753_states_struct
        {
            public bool ignition;
            public bool engine;
            public bool brake_parking;
            public bool brake;
            public bool hazard_light;
            public bool left_turn_signal;
            public bool right_turn_signal;
            public bool head_light;
            public bool rear_light;
            public bool wipers;
            public bool horn;
        }

        struct ecu_L753_indicators_struct
        {
            public bool min_fuel;
            public bool min_hydraulic_oil;
            public bool switch_speed;
            public bool rear_cover;
            public bool heating_engine;
        }

        struct ecu_L753_telemety_struct
        {
            public ecu_L753_states_struct states;
            public ecu_L753_indicators_struct indicators;
            public UInt16 rpm_motor;
            public float voltage_battery;
            public float hydraulic_oil_temp;
            public float coolant_temp;
            public byte fuel_level;
        };

        ecu_L753_telemety_struct L753_telemety = new ecu_L753_telemety_struct() { };

        static System.Timers.Timer timer_handle_tcp_recive;
        static System.Timers.Timer timer_handle_tcp_transmit;
        static System.Timers.Timer timer_handle_tcp_req_telemetry;

        System.Windows.Forms.Timer timer_update_panel_telemetry;

        bool cmd_update_panel_telemetry = false;

        Stopwatch sw_update_telemetry_data = Stopwatch.StartNew();
        long timer_update_telemetry_data = 0;

        // ************************************************** initialization functions

        public form_main()
        {
            InitializeComponent();
            init_win_form();
            init_variables();
            init_control_elements();
            update_panel_joysticks();
            update_panel_tcp_connection();
            update_central_panel_status_connections();
            draw_position_joysticks();
            draw_fuel_level();
            draw_cooltant_temp_level();
            draw_rmp_meter();
            draw_hydraulic_oil_temp_level();
        }

        void init_win_form()
        {
            this.Text = "Remote loader control L753";
            this.Icon = new Icon("prog_ico.ico");
            //this.FormBorderStyle = FormBorderStyle.Sizable;
            //this.WindowState = FormWindowState.Maximized;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.FormClosing += Form_main_FormClosing;
        }

        void init_control_elements()
        {
            waveIn_mic = new WaveInEvent();
            waveIn_mic.DeviceNumber = 0;
            waveIn_mic.WaveFormat = new WaveFormat(8000, 8, 1); // 8 kHz, 8 bit, mono
            waveIn_mic.BufferMilliseconds = 100; // 8000 * 0.1 = 800 byte
            waveIn_mic.DataAvailable += WaveIn_mic_DataAvailable; ;

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
            button_joysticks_calibration_reset.Click += Button_joysticks_calibration_reset_Click;

            button_tcp_open.Click += Button_tcp_open_Click;
            button_tcp_close.Click += Button_tcp_close_Click;

            comboBox_com_port_names.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_com_port_names.DropDown += ComboBox_com_port_names_DropDown;
            ComboBox_com_port_names_DropDown(null, null);
            if (comboBox_com_port_names.Items.Count > 0) comboBox_com_port_names.SelectedIndex = 0;

            pictureBox_fuel_level.BackgroundImage = new Bitmap("icons/fuel_level_background.png");
            pictureBox_cooltant_temp_level.BackgroundImage = new Bitmap("icons/coolant_temp_level_background.png");
            pictureBox_rpm_meter.BackgroundImage = new Bitmap("icons/rmp_meter_background.png");
            pictureBox_hydraulic_oil_temp_level.BackgroundImage = new Bitmap("icons/hydraulic_oil_temp_level_background.png");

            numericUpDown_interval_packet_transmit.Minimum = 10;
            numericUpDown_interval_packet_transmit.Maximum = 500;
            numericUpDown_interval_packet_transmit.Value = Properties.Settings.Default.interval_packet_transmit;
            numericUpDown_interval_packet_transmit.ValueChanged += NumericUpDown_interval_packet_transmit_ValueChanged;

            numericUpDown_interval_packet_recive.Minimum = 10;
            numericUpDown_interval_packet_recive.Maximum = 500;
            numericUpDown_interval_packet_recive.Value = Properties.Settings.Default.interval_packet_recive;
            numericUpDown_interval_packet_recive.ValueChanged += NumericUpDown_interval_packet_recive_ValueChanged;

            numericUpDown_interval_update_panel.Minimum = 100;
            numericUpDown_interval_update_panel.Maximum = 1000;
            numericUpDown_interval_update_panel.Value = Properties.Settings.Default.interval_update_panel;
            numericUpDown_interval_update_panel.ValueChanged += NumericUpDown_interval_update_panel_ValueChanged;

            checkBox_cmd_microphone.CheckedChanged += CheckBox_cmd_microphone_CheckedChanged;

            timer_handle_tcp_recive = new System.Timers.Timer();
            timer_handle_tcp_recive.Interval = (int)numericUpDown_interval_packet_recive.Value;
            timer_handle_tcp_recive.AutoReset = true;
            timer_handle_tcp_recive.Elapsed += Timer_handle_tcp_recive_Elapsed;
            timer_handle_tcp_recive.Start();

            timer_check_joysticks = new System.Windows.Forms.Timer();
            timer_check_joysticks.Interval = 1000;
            timer_check_joysticks.Tick += Timer_check_joysticks_Tick;
            timer_check_joysticks.Enabled = true;

            timer_update_panel_telemetry = new System.Windows.Forms.Timer();
            timer_update_panel_telemetry.Interval = (int)numericUpDown_interval_update_panel.Value;
            timer_update_panel_telemetry.Tick += Timer_update_panel_telemetry_Tick;
            timer_update_panel_telemetry.Enabled = true;

            timer_handle_tcp_transmit = new System.Timers.Timer();
            timer_handle_tcp_transmit.Interval = (int)numericUpDown_interval_packet_transmit.Value;
            timer_handle_tcp_transmit.AutoReset = true;
            timer_handle_tcp_transmit.Elapsed += Timer_handle_tcp_transmit_Elapsed;
            timer_handle_tcp_transmit.Start();


            numericUpDown_interval_req_telemetry.Minimum = 100;
            numericUpDown_interval_req_telemetry.Maximum = 1000;
            numericUpDown_interval_req_telemetry.Value = Properties.Settings.Default.interval_req_telemetry;
            numericUpDown_interval_req_telemetry.ValueChanged += NumericUpDown_interval_req_telemetry_ValueChanged;

            timer_handle_tcp_req_telemetry = new System.Timers.Timer();
            timer_handle_tcp_req_telemetry.Interval = (int)numericUpDown_interval_req_telemetry.Value;
            timer_handle_tcp_req_telemetry.AutoReset = true;
            timer_handle_tcp_req_telemetry.Elapsed += Timer_handle_tcp_req_telemetry_Elapsed;
            timer_handle_tcp_req_telemetry.Start();

            // comand elements
            checkBox_cmd_ignition.CheckedChanged += CheckBox_cmd_ignition_CheckedChanged;
            button_cmd_start_engine.Click += Button_cmd_start_engine_Click;
            button_cmd_stop_engine.Click += Button_cmd_stop_engine_Click;
            checkBox_cmd_brake_parking.CheckedChanged += CheckBox_cmd_brake_parking_CheckedChanged;
            button_cmd_brake.MouseUp += Button_cmd_brake_MouseUp;
            button_cmd_brake.MouseDown += Button_cmd_brake_MouseDown;
            button_cmd_horn.MouseUp += Button_cmd_horn_MouseUp;
            button_cmd_horn.MouseDown += Button_cmd_horn_MouseDown;
            checkBox_cmd_hazard_light.CheckedChanged += CheckBox_cmd_hazard_light_CheckedChanged;
            button_cmd_left_turn_signal.MouseUp += Button_cmd_left_turn_signal_MouseUp;
            button_cmd_left_turn_signal.MouseDown += Button_cmd_left_turn_signal_MouseDown;
            button_cmd_right_turn_signal.MouseUp += Button_cmd_right_turn_signal_MouseUp;
            button_cmd_right_turn_signal.MouseDown += Button_cmd_right_turn_signal_MouseDown;
            checkBox_cmd_head_light.CheckedChanged += CheckBox_cmd_head_light_CheckedChanged;
            checkBox_cmd_rear_light.CheckedChanged += CheckBox_cmd_rear_light_CheckedChanged;
            checkBox_cmd_wipers.CheckedChanged += CheckBox_cmd_wipers_CheckedChanged;

            textBox_telemetry_data.ReadOnly = true;
        }

        void init_variables()
        {
            directInput = new DirectInput();
        }

        // ************************************************** handler functions

        private void CheckBox_cmd_wipers_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_wipers, (byte)(checkBox_cmd_wipers.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void CheckBox_cmd_rear_light_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_rear_light, (byte)(checkBox_cmd_rear_light.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void CheckBox_cmd_head_light_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_head_light, (byte)(checkBox_cmd_head_light.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void Button_cmd_right_turn_signal_MouseDown(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_right_turn_signal, 0x01);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_right_turn_signal_MouseUp(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_right_turn_signal, 0x00);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_left_turn_signal_MouseDown(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_left_turn_signal, 0x01);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_left_turn_signal_MouseUp(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_left_turn_signal, 0x00);
            start_timers_in_process_transmit();
        }

        private void CheckBox_cmd_hazard_light_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_hazard_light, (byte)(checkBox_cmd_hazard_light.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void Button_cmd_horn_MouseDown(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_horn, 0x01);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_horn_MouseUp(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_horn, 0x00);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_brake_MouseDown(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_brake, 0x01);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_brake_MouseUp(object sender, MouseEventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_brake, 0x00);
            start_timers_in_process_transmit();
        }

        private void CheckBox_cmd_brake_parking_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_brake_parking, (byte)(checkBox_cmd_brake_parking.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void Button_cmd_stop_engine_Click(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_engine, 0x00);
            start_timers_in_process_transmit();
        }

        private void Button_cmd_start_engine_Click(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_engine, 0x01);
            start_timers_in_process_transmit();
        }

        private void CheckBox_cmd_ignition_CheckedChanged(object sender, EventArgs e)
        {
            stop_timers_in_process_transmit();
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_ignition, (byte)(checkBox_cmd_ignition.Checked ? 1 : 0));
            start_timers_in_process_transmit();
        }

        private void Timer_handle_tcp_req_telemetry_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (state_tcp_connect && tcp_client != null)
            {
                transmit_comand((byte)tcp_type_packet.tcp_type_packet_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_tick, null);
            }
        }

        private void NumericUpDown_interval_req_telemetry_ValueChanged(object sender, EventArgs e)
        {
            timer_handle_tcp_req_telemetry.Interval = (int)numericUpDown_interval_req_telemetry.Value;
        }

        private void Timer_handle_tcp_transmit_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (state_calibration_joysticks)
            {
                try
                {
                    joystick_left.Poll();
                    JoystickState states_joystick_left = joystick_left.GetCurrentState();
                    joystick_left_position_x = states_joystick_left.X;
                    joystick_left_position_y = states_joystick_left.Y;
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
                    joystick_right_position_x = states_joystick_right.X;
                    joystick_right_position_y = states_joystick_right.Y;
                }
                catch (Exception)
                {
                    state_calibration_joysticks = false;
                    state_connect_joystick_right = false;
                    update_panel_joysticks();
                }
            }

            if (checkBox_perm_transmit_joystick_values.Checked == false) return;

            UInt16 servo_left_y_value = (UInt16)(65535 - joystick_left_position_y);
            UInt16 servo_right_y_value = (UInt16)joystick_right_position_y;

            byte[] msg_joy = new byte[4];
            msg_joy[0] = (byte)(servo_left_y_value & 0xFF);
            msg_joy[1] = (byte)((servo_left_y_value >> 8) & 0xFF);
            msg_joy[2] = (byte)(servo_right_y_value & 0xFF);
            msg_joy[3] = (byte)((servo_right_y_value >> 8) & 0xFF);

            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_joystick_values, msg_joy);
        }

        private void Timer_update_panel_telemetry_Tick(object sender, EventArgs e)
        {
            draw_position_joysticks();

            if (cmd_update_panel_telemetry)
            {
                if (sw_update_telemetry_data.ElapsedMilliseconds - timer_update_telemetry_data >= 1000)
                {
                    textBox_telemetry_data.Text = "";
                    textBox_telemetry_data.AppendText("Ignition: " + L753_telemety.states.ignition.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Engine: " + L753_telemety.states.engine.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Brake parking: " + L753_telemety.states.brake_parking.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Brake: " + L753_telemety.states.brake.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Hazard light: " + L753_telemety.states.hazard_light.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Left turn signal: " + L753_telemety.states.left_turn_signal.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Right turn signal: " + L753_telemety.states.right_turn_signal.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Head light: " + L753_telemety.states.head_light.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Rear light: " + L753_telemety.states.rear_light.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Wipers: " + L753_telemety.states.wipers.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Horn: " + L753_telemety.states.horn.ToString() + "\r\n");

                    textBox_telemetry_data.AppendText("Min fuel: " + L753_telemety.indicators.min_fuel.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Min hydraulic oil: " + L753_telemety.indicators.min_hydraulic_oil.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Switch speed: " + L753_telemety.indicators.switch_speed.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Rear cover: " + L753_telemety.indicators.rear_cover.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Heating engine: " + L753_telemety.indicators.heating_engine.ToString() + "\r\n");

                    textBox_telemetry_data.AppendText("Rpm motor: " + L753_telemety.rpm_motor.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Voltage battery: " + L753_telemety.voltage_battery.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Hydraulic oil temp: " + L753_telemety.hydraulic_oil_temp.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Coolant temp: " + L753_telemety.coolant_temp.ToString() + "\r\n");
                    textBox_telemetry_data.AppendText("Fuel level: " + L753_telemety.fuel_level.ToString() + "\r\n");

                    timer_update_telemetry_data = sw_update_telemetry_data.ElapsedMilliseconds;
                }



                loader_fuel_level = L753_telemety.fuel_level;
                if (loader_fuel_level > 8) loader_fuel_level = 8;
                else if (loader_fuel_level < 0) loader_fuel_level = 0;

                loader_cooltant_temp_level = (int)L753_telemety.coolant_temp;
                if (loader_cooltant_temp_level > 120) loader_cooltant_temp_level = 120;
                else if (loader_cooltant_temp_level < 0) loader_cooltant_temp_level = 0;

                loader_rmp_motor = L753_telemety.rpm_motor;
                if (loader_rmp_motor > 4000) loader_rmp_motor = 4000;
                else if (loader_rmp_motor < 0) loader_rmp_motor = 0;

                loader_hydraulic_oil_temp_level = (int)L753_telemety.hydraulic_oil_temp;
                if (loader_hydraulic_oil_temp_level > 100) loader_hydraulic_oil_temp_level = 100;
                else if (loader_hydraulic_oil_temp_level < 0) loader_hydraulic_oil_temp_level = 0;

                draw_fuel_level();
                draw_cooltant_temp_level();
                draw_rmp_meter();
                draw_hydraulic_oil_temp_level();

                cmd_update_panel_telemetry = false;
            }
        }

        private void NumericUpDown_interval_packet_transmit_ValueChanged(object sender, EventArgs e)
        {
            timer_handle_tcp_transmit.Interval = (int)numericUpDown_interval_packet_transmit.Value;
        }

        private void NumericUpDown_interval_update_panel_ValueChanged(object sender, EventArgs e)
        {
            timer_update_panel_telemetry.Interval = (int)numericUpDown_interval_update_panel.Value;
        }

        private void NumericUpDown_interval_packet_recive_ValueChanged(object sender, EventArgs e)
        {
            timer_handle_tcp_recive.Interval = (int)numericUpDown_interval_packet_recive.Value;
        }

        private void Timer_handle_tcp_recive_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (state_tcp_connect && tcp_stream != null)
            {
                if (tcp_stream.DataAvailable)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead_len = tcp_stream.Read(buffer, 0, buffer.Length);

                    if (buffer[0] == '$' && buffer[bytesRead_len - 1] == '\n')
                    {
                        L753_telemety.states.ignition = buffer[2] == 1;
                        L753_telemety.states.engine = buffer[3] == 1;
                        L753_telemety.states.brake_parking = buffer[4] == 1;
                        L753_telemety.states.brake = buffer[5] == 1;
                        L753_telemety.states.hazard_light = buffer[6] == 1;
                        L753_telemety.states.left_turn_signal = buffer[7] == 1;
                        L753_telemety.states.right_turn_signal = buffer[8] == 1;
                        L753_telemety.states.head_light = buffer[9] == 1;
                        L753_telemety.states.rear_light = buffer[10] == 1;
                        L753_telemety.states.wipers = buffer[11] == 1;
                        L753_telemety.states.horn = buffer[12] == 1;
                        L753_telemety.indicators.min_fuel = buffer[13] == 1;
                        L753_telemety.indicators.min_hydraulic_oil = buffer[14] == 1;
                        L753_telemety.indicators.switch_speed = buffer[15] == 1;
                        L753_telemety.indicators.rear_cover = buffer[16] == 1;
                        L753_telemety.indicators.heating_engine = buffer[17] == 1;

                        L753_telemety.rpm_motor = BitConverter.ToUInt16(buffer, 18);
                        L753_telemety.voltage_battery = BitConverter.ToSingle(buffer, 20);
                        L753_telemety.hydraulic_oil_temp = BitConverter.ToSingle(buffer, 24);
                        L753_telemety.coolant_temp = BitConverter.ToSingle(buffer, 28);
                        L753_telemety.fuel_level = buffer[32];

                        cmd_update_panel_telemetry = true;
                    }
                }
            }
        }

        private void CheckBox_cmd_microphone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_cmd_microphone.Checked)
            {
                stop_timers_in_process_transmit();
                transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_audio_play, null);
                waveIn_mic.StartRecording();
            }
            else
            {
                transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_audio_stop, null);
                waveIn_mic.StopRecording();
                start_timers_in_process_transmit();
            }
        }

        private void WaveIn_mic_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] pcm_u8 = e.Buffer;
            transmit_comand((byte)tcp_type_packet.tcp_type_packet_no_resp, 0x00, (byte)tcp_type_msg.tcp_type_msg_cmd_audio_packet, pcm_u8);
        }

        private void ComboBox_com_port_names_DropDown(object sender, EventArgs e)
        {
            comboBox_com_port_names.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBox_com_port_names.Items.Add(port);
            }
        }

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
                /*
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
                */
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
            Properties.Settings.Default.interval_packet_transmit = (int)numericUpDown_interval_packet_transmit.Value;
            Properties.Settings.Default.interval_packet_recive = (int)numericUpDown_interval_packet_recive.Value;
            Properties.Settings.Default.interval_update_panel = (int)numericUpDown_interval_update_panel.Value;
            Properties.Settings.Default.interval_req_telemetry = (int)numericUpDown_interval_req_telemetry.Value;
            Properties.Settings.Default.Save();

            if (tcp_client != null)
            {
                tcp_client.Close();
            }
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

        void reset_timers_in_process_transmit()
        {
            timer_handle_tcp_transmit.Stop();
            timer_handle_tcp_req_telemetry.Stop();
            timer_handle_tcp_transmit.Start();
            timer_handle_tcp_req_telemetry.Start();
        }

        void start_timers_in_process_transmit()
        {
            timer_handle_tcp_transmit.Start();
            timer_handle_tcp_req_telemetry.Start();
        }

        void stop_timers_in_process_transmit()
        {
            timer_handle_tcp_transmit.Stop();
            timer_handle_tcp_req_telemetry.Stop();
        }

        void transmit_comand(byte type_packet, byte seq_packet, byte msg_type, byte msg)
        {
            UInt16 len_msg = 1;
            byte[] data_tcp = new byte[7 + len_msg + 1];
            data_tcp[0] = (byte)'$';
            data_tcp[1] = type_packet;
            data_tcp[2] = seq_packet;
            data_tcp[3] = 0x01;
            data_tcp[4] = msg_type;
            data_tcp[5] = (byte)(len_msg >> 8);
            data_tcp[6] = (byte)len_msg;
            data_tcp[7] = msg;
            data_tcp[data_tcp.Length - 1] = (byte)'\n';

            try
            {
                tcp_stream.Write(data_tcp, 0, data_tcp.Length);
            }
            catch (Exception) { }
        }

        void transmit_comand(byte type_packet, byte seq_packet, byte msg_type, byte[] msg)
        {
            UInt16 len_msg = 0;
            if (msg != null) len_msg = (UInt16)msg.Length;

            byte[] data_tcp = new byte[7 + len_msg + 1];
            data_tcp[0] = (byte)'$';
            data_tcp[1] = type_packet;
            data_tcp[2] = seq_packet;
            data_tcp[3] = 0x01;
            data_tcp[4] = msg_type;
            data_tcp[5] = (byte)(len_msg >> 8);
            data_tcp[6] = (byte)len_msg;
            if (msg != null) Buffer.BlockCopy(msg, 0, data_tcp, 7, len_msg);
            data_tcp[data_tcp.Length - 1] = (byte)'\n';

            try
            {
                tcp_stream.Write(data_tcp, 0, data_tcp.Length);
            }
            catch (Exception) { }
        }

        int map(int x, int in_min, int in_max, int out_min, int out_max)
        {
            return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
        }

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

                panel_central.Enabled = true;

                // templ
                state_controller_connected = true;
                state_ECU_connected = true;
                update_central_panel_status_connections();
            }
            else
            {
                button_tcp_close.Enabled = false;
                button_tcp_open.Enabled = true;
                textBox_tcp_server_ip.Enabled = true;
                numericUpDown_tcp_server_port.Enabled = true;

                panel_central.Enabled = false;

                // templ
                state_controller_connected = false;
                state_ECU_connected = false;
                update_central_panel_status_connections();
            }
        }

        void update_central_panel_status_connections()
        {
            if (state_controller_connected) pictureBox_state_controller_connected.Image = new Bitmap("icons/connection.png");
            else pictureBox_state_controller_connected.Image = new Bitmap("icons/disconnection.png");

            if (state_ECU_connected) pictureBox_state_ECU_connected.Image = new Bitmap("icons/connection.png");
            else pictureBox_state_ECU_connected.Image = new Bitmap("icons/disconnection.png");

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

        void draw_fuel_level()
        {
            int angle = map(loader_fuel_level, 0, 8, 0, 90);

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
            int angle = map(loader_cooltant_temp_level, 0, 120, 0, 90);

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

        void draw_rmp_meter()
        {
            int angle = map(loader_rmp_motor, 0, 4000, 0, 270);

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
            int angle = map(loader_hydraulic_oil_temp_level, 0, 100, 0, 90);

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
    }
}
