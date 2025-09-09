namespace RemoteLoaderControl
{
    partial class form_main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_tcp_server_ip = new System.Windows.Forms.TextBox();
            this.button_tcp_open = new System.Windows.Forms.Button();
            this.groupBox_connection_tcp = new System.Windows.Forms.GroupBox();
            this.numericUpDown_tcp_server_port = new System.Windows.Forms.NumericUpDown();
            this.button_tcp_close = new System.Windows.Forms.Button();
            this.groupBox_connection_reserve = new System.Windows.Forms.GroupBox();
            this.button_com_port_close = new System.Windows.Forms.Button();
            this.button_com_port_open = new System.Windows.Forms.Button();
            this.numericUpDown_com_port_baudrate = new System.Windows.Forms.NumericUpDown();
            this.comboBox_com_port_names = new System.Windows.Forms.ComboBox();
            this.groupBox_hid_joystiks = new System.Windows.Forms.GroupBox();
            this.button_joysticks_calibration_reset = new System.Windows.Forms.Button();
            this.button_joysticks_calibration = new System.Windows.Forms.Button();
            this.label_info_joysticks_calibration = new System.Windows.Forms.Label();
            this.pictureBox_state_joysticks_calibration = new System.Windows.Forms.PictureBox();
            this.label_info_joystick_left = new System.Windows.Forms.Label();
            this.label_info_joystick_right = new System.Windows.Forms.Label();
            this.pictureBox_state_joystick_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_state_joystick_right = new System.Windows.Forms.PictureBox();
            this.pictureBox_state_controller_connected = new System.Windows.Forms.PictureBox();
            this.label_info_state_controller_connected = new System.Windows.Forms.Label();
            this.label_info_state_ECU_connected = new System.Windows.Forms.Label();
            this.pictureBox_state_ECU_connected = new System.Windows.Forms.PictureBox();
            this.panel_central = new System.Windows.Forms.Panel();
            this.label_info_interval_packet_transmit = new System.Windows.Forms.Label();
            this.numericUpDown_interval_packet_transmit = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_hydraulic_oil_temp_level = new System.Windows.Forms.PictureBox();
            this.pictureBox_rpm_meter = new System.Windows.Forms.PictureBox();
            this.pictureBox_cooltant_temp_level = new System.Windows.Forms.PictureBox();
            this.pictureBox_fuel_level = new System.Windows.Forms.PictureBox();
            this.pictureBox_joystick_position_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_joystick_position_right = new System.Windows.Forms.PictureBox();
            this.checkBox_cmd_microphone = new System.Windows.Forms.CheckBox();
            this.button_cmd_start_engine = new System.Windows.Forms.Button();
            this.button_cmd_stop_engine = new System.Windows.Forms.Button();
            this.checkBox_cmd_ignition = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_brake_parking = new System.Windows.Forms.CheckBox();
            this.button_cmd_brake = new System.Windows.Forms.Button();
            this.button_cmd_horn = new System.Windows.Forms.Button();
            this.checkBox_cmd_hazard_light = new System.Windows.Forms.CheckBox();
            this.button_cmd_left_turn_signal = new System.Windows.Forms.Button();
            this.button_cmd_right_turn_signal = new System.Windows.Forms.Button();
            this.checkBox_cmd_head_light = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_rear_light = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_wipers = new System.Windows.Forms.CheckBox();
            this.label_info_interval_packet_recive = new System.Windows.Forms.Label();
            this.numericUpDown_interval_packet_recive = new System.Windows.Forms.NumericUpDown();
            this.label_info_interval_update_panel = new System.Windows.Forms.Label();
            this.numericUpDown_interval_update_panel = new System.Windows.Forms.NumericUpDown();
            this.label_info_interval_req_telemetry = new System.Windows.Forms.Label();
            this.numericUpDown_interval_req_telemetry = new System.Windows.Forms.NumericUpDown();
            this.checkBox_perm_transmit_joystick_values = new System.Windows.Forms.CheckBox();
            this.textBox_telemetry_data = new System.Windows.Forms.TextBox();
            this.groupBox_connection_tcp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).BeginInit();
            this.groupBox_connection_reserve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_com_port_baudrate)).BeginInit();
            this.groupBox_hid_joystiks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_controller_connected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_ECU_connected)).BeginInit();
            this.panel_central.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_packet_transmit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hydraulic_oil_temp_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rpm_meter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cooltant_temp_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fuel_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_packet_recive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_update_panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_telemetry)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_tcp_server_ip
            // 
            this.textBox_tcp_server_ip.Location = new System.Drawing.Point(6, 19);
            this.textBox_tcp_server_ip.Name = "textBox_tcp_server_ip";
            this.textBox_tcp_server_ip.Size = new System.Drawing.Size(124, 20);
            this.textBox_tcp_server_ip.TabIndex = 0;
            // 
            // button_tcp_open
            // 
            this.button_tcp_open.Location = new System.Drawing.Point(219, 19);
            this.button_tcp_open.Name = "button_tcp_open";
            this.button_tcp_open.Size = new System.Drawing.Size(75, 23);
            this.button_tcp_open.TabIndex = 2;
            this.button_tcp_open.Text = "Открыть";
            this.button_tcp_open.UseVisualStyleBackColor = true;
            // 
            // groupBox_connection_tcp
            // 
            this.groupBox_connection_tcp.Controls.Add(this.numericUpDown_tcp_server_port);
            this.groupBox_connection_tcp.Controls.Add(this.button_tcp_close);
            this.groupBox_connection_tcp.Controls.Add(this.textBox_tcp_server_ip);
            this.groupBox_connection_tcp.Controls.Add(this.button_tcp_open);
            this.groupBox_connection_tcp.Location = new System.Drawing.Point(12, 12);
            this.groupBox_connection_tcp.Name = "groupBox_connection_tcp";
            this.groupBox_connection_tcp.Size = new System.Drawing.Size(394, 55);
            this.groupBox_connection_tcp.TabIndex = 3;
            this.groupBox_connection_tcp.TabStop = false;
            this.groupBox_connection_tcp.Text = "TCP соединение";
            // 
            // numericUpDown_tcp_server_port
            // 
            this.numericUpDown_tcp_server_port.Location = new System.Drawing.Point(136, 19);
            this.numericUpDown_tcp_server_port.Name = "numericUpDown_tcp_server_port";
            this.numericUpDown_tcp_server_port.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown_tcp_server_port.TabIndex = 4;
            // 
            // button_tcp_close
            // 
            this.button_tcp_close.Location = new System.Drawing.Point(300, 19);
            this.button_tcp_close.Name = "button_tcp_close";
            this.button_tcp_close.Size = new System.Drawing.Size(75, 23);
            this.button_tcp_close.TabIndex = 3;
            this.button_tcp_close.Text = "Закрыть";
            this.button_tcp_close.UseVisualStyleBackColor = true;
            // 
            // groupBox_connection_reserve
            // 
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_close);
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_open);
            this.groupBox_connection_reserve.Controls.Add(this.numericUpDown_com_port_baudrate);
            this.groupBox_connection_reserve.Controls.Add(this.comboBox_com_port_names);
            this.groupBox_connection_reserve.Location = new System.Drawing.Point(412, 12);
            this.groupBox_connection_reserve.Name = "groupBox_connection_reserve";
            this.groupBox_connection_reserve.Size = new System.Drawing.Size(431, 55);
            this.groupBox_connection_reserve.TabIndex = 5;
            this.groupBox_connection_reserve.TabStop = false;
            this.groupBox_connection_reserve.Text = "Ревервный канал соединение";
            // 
            // button_com_port_close
            // 
            this.button_com_port_close.Location = new System.Drawing.Point(291, 19);
            this.button_com_port_close.Name = "button_com_port_close";
            this.button_com_port_close.Size = new System.Drawing.Size(75, 23);
            this.button_com_port_close.TabIndex = 7;
            this.button_com_port_close.Text = "Закрыть";
            this.button_com_port_close.UseVisualStyleBackColor = true;
            // 
            // button_com_port_open
            // 
            this.button_com_port_open.Location = new System.Drawing.Point(210, 19);
            this.button_com_port_open.Name = "button_com_port_open";
            this.button_com_port_open.Size = new System.Drawing.Size(75, 23);
            this.button_com_port_open.TabIndex = 6;
            this.button_com_port_open.Text = "Открыть";
            this.button_com_port_open.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_com_port_baudrate
            // 
            this.numericUpDown_com_port_baudrate.Location = new System.Drawing.Point(105, 19);
            this.numericUpDown_com_port_baudrate.Name = "numericUpDown_com_port_baudrate";
            this.numericUpDown_com_port_baudrate.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown_com_port_baudrate.TabIndex = 6;
            // 
            // comboBox_com_port_names
            // 
            this.comboBox_com_port_names.FormattingEnabled = true;
            this.comboBox_com_port_names.Location = new System.Drawing.Point(6, 19);
            this.comboBox_com_port_names.Name = "comboBox_com_port_names";
            this.comboBox_com_port_names.Size = new System.Drawing.Size(93, 21);
            this.comboBox_com_port_names.TabIndex = 6;
            // 
            // groupBox_hid_joystiks
            // 
            this.groupBox_hid_joystiks.Controls.Add(this.button_joysticks_calibration_reset);
            this.groupBox_hid_joystiks.Controls.Add(this.button_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joystick_left);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joystick_right);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joystick_left);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joystick_right);
            this.groupBox_hid_joystiks.Location = new System.Drawing.Point(849, 12);
            this.groupBox_hid_joystiks.Name = "groupBox_hid_joystiks";
            this.groupBox_hid_joystiks.Size = new System.Drawing.Size(462, 55);
            this.groupBox_hid_joystiks.TabIndex = 6;
            this.groupBox_hid_joystiks.TabStop = false;
            this.groupBox_hid_joystiks.Text = "Джостики";
            // 
            // button_joysticks_calibration_reset
            // 
            this.button_joysticks_calibration_reset.Location = new System.Drawing.Point(365, 19);
            this.button_joysticks_calibration_reset.Name = "button_joysticks_calibration_reset";
            this.button_joysticks_calibration_reset.Size = new System.Drawing.Size(73, 23);
            this.button_joysticks_calibration_reset.TabIndex = 12;
            this.button_joysticks_calibration_reset.Text = "Сброс";
            this.button_joysticks_calibration_reset.UseVisualStyleBackColor = true;
            // 
            // button_joysticks_calibration
            // 
            this.button_joysticks_calibration.Location = new System.Drawing.Point(273, 19);
            this.button_joysticks_calibration.Name = "button_joysticks_calibration";
            this.button_joysticks_calibration.Size = new System.Drawing.Size(86, 23);
            this.button_joysticks_calibration.TabIndex = 7;
            this.button_joysticks_calibration.Text = "Калибровка";
            this.button_joysticks_calibration.UseVisualStyleBackColor = true;
            // 
            // label_info_joysticks_calibration
            // 
            this.label_info_joysticks_calibration.AutoSize = true;
            this.label_info_joysticks_calibration.Location = new System.Drawing.Point(199, 24);
            this.label_info_joysticks_calibration.Name = "label_info_joysticks_calibration";
            this.label_info_joysticks_calibration.Size = new System.Drawing.Size(68, 13);
            this.label_info_joysticks_calibration.TabIndex = 10;
            this.label_info_joysticks_calibration.Text = "Калибровка";
            // 
            // pictureBox_state_joysticks_calibration
            // 
            this.pictureBox_state_joysticks_calibration.Location = new System.Drawing.Point(168, 19);
            this.pictureBox_state_joysticks_calibration.Name = "pictureBox_state_joysticks_calibration";
            this.pictureBox_state_joysticks_calibration.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joysticks_calibration.TabIndex = 11;
            this.pictureBox_state_joysticks_calibration.TabStop = false;
            // 
            // label_info_joystick_left
            // 
            this.label_info_joystick_left.AutoSize = true;
            this.label_info_joystick_left.Location = new System.Drawing.Point(37, 24);
            this.label_info_joystick_left.Name = "label_info_joystick_left";
            this.label_info_joystick_left.Size = new System.Drawing.Size(41, 13);
            this.label_info_joystick_left.TabIndex = 8;
            this.label_info_joystick_left.Text = "Левый";
            // 
            // label_info_joystick_right
            // 
            this.label_info_joystick_right.AutoSize = true;
            this.label_info_joystick_right.Location = new System.Drawing.Point(115, 24);
            this.label_info_joystick_right.Name = "label_info_joystick_right";
            this.label_info_joystick_right.Size = new System.Drawing.Size(47, 13);
            this.label_info_joystick_right.TabIndex = 7;
            this.label_info_joystick_right.Text = "Правый";
            // 
            // pictureBox_state_joystick_left
            // 
            this.pictureBox_state_joystick_left.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_state_joystick_left.Name = "pictureBox_state_joystick_left";
            this.pictureBox_state_joystick_left.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joystick_left.TabIndex = 9;
            this.pictureBox_state_joystick_left.TabStop = false;
            // 
            // pictureBox_state_joystick_right
            // 
            this.pictureBox_state_joystick_right.Location = new System.Drawing.Point(84, 19);
            this.pictureBox_state_joystick_right.Name = "pictureBox_state_joystick_right";
            this.pictureBox_state_joystick_right.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joystick_right.TabIndex = 7;
            this.pictureBox_state_joystick_right.TabStop = false;
            // 
            // pictureBox_state_controller_connected
            // 
            this.pictureBox_state_controller_connected.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_state_controller_connected.Name = "pictureBox_state_controller_connected";
            this.pictureBox_state_controller_connected.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_controller_connected.TabIndex = 8;
            this.pictureBox_state_controller_connected.TabStop = false;
            // 
            // label_info_state_controller_connected
            // 
            this.label_info_state_controller_connected.AutoSize = true;
            this.label_info_state_controller_connected.Location = new System.Drawing.Point(34, 9);
            this.label_info_state_controller_connected.Name = "label_info_state_controller_connected";
            this.label_info_state_controller_connected.Size = new System.Drawing.Size(123, 13);
            this.label_info_state_controller_connected.TabIndex = 8;
            this.label_info_state_controller_connected.Text = "Связь с контроллером";
            // 
            // label_info_state_ECU_connected
            // 
            this.label_info_state_ECU_connected.AutoSize = true;
            this.label_info_state_ECU_connected.Location = new System.Drawing.Point(194, 9);
            this.label_info_state_ECU_connected.Name = "label_info_state_ECU_connected";
            this.label_info_state_ECU_connected.Size = new System.Drawing.Size(72, 13);
            this.label_info_state_ECU_connected.TabIndex = 9;
            this.label_info_state_ECU_connected.Text = "Связь с ECU";
            // 
            // pictureBox_state_ECU_connected
            // 
            this.pictureBox_state_ECU_connected.Location = new System.Drawing.Point(163, 3);
            this.pictureBox_state_ECU_connected.Name = "pictureBox_state_ECU_connected";
            this.pictureBox_state_ECU_connected.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_ECU_connected.TabIndex = 10;
            this.pictureBox_state_ECU_connected.TabStop = false;
            // 
            // panel_central
            // 
            this.panel_central.Controls.Add(this.textBox_telemetry_data);
            this.panel_central.Controls.Add(this.checkBox_perm_transmit_joystick_values);
            this.panel_central.Controls.Add(this.label_info_interval_req_telemetry);
            this.panel_central.Controls.Add(this.numericUpDown_interval_req_telemetry);
            this.panel_central.Controls.Add(this.label_info_interval_update_panel);
            this.panel_central.Controls.Add(this.numericUpDown_interval_update_panel);
            this.panel_central.Controls.Add(this.label_info_interval_packet_recive);
            this.panel_central.Controls.Add(this.numericUpDown_interval_packet_recive);
            this.panel_central.Controls.Add(this.checkBox_cmd_wipers);
            this.panel_central.Controls.Add(this.checkBox_cmd_rear_light);
            this.panel_central.Controls.Add(this.checkBox_cmd_head_light);
            this.panel_central.Controls.Add(this.button_cmd_right_turn_signal);
            this.panel_central.Controls.Add(this.button_cmd_left_turn_signal);
            this.panel_central.Controls.Add(this.checkBox_cmd_hazard_light);
            this.panel_central.Controls.Add(this.button_cmd_horn);
            this.panel_central.Controls.Add(this.button_cmd_brake);
            this.panel_central.Controls.Add(this.checkBox_cmd_brake_parking);
            this.panel_central.Controls.Add(this.checkBox_cmd_ignition);
            this.panel_central.Controls.Add(this.button_cmd_stop_engine);
            this.panel_central.Controls.Add(this.button_cmd_start_engine);
            this.panel_central.Controls.Add(this.checkBox_cmd_microphone);
            this.panel_central.Controls.Add(this.label_info_interval_packet_transmit);
            this.panel_central.Controls.Add(this.numericUpDown_interval_packet_transmit);
            this.panel_central.Controls.Add(this.pictureBox_hydraulic_oil_temp_level);
            this.panel_central.Controls.Add(this.pictureBox_rpm_meter);
            this.panel_central.Controls.Add(this.pictureBox_cooltant_temp_level);
            this.panel_central.Controls.Add(this.pictureBox_fuel_level);
            this.panel_central.Controls.Add(this.pictureBox_joystick_position_left);
            this.panel_central.Controls.Add(this.pictureBox_joystick_position_right);
            this.panel_central.Controls.Add(this.label_info_state_ECU_connected);
            this.panel_central.Controls.Add(this.pictureBox_state_ECU_connected);
            this.panel_central.Controls.Add(this.pictureBox_state_controller_connected);
            this.panel_central.Controls.Add(this.label_info_state_controller_connected);
            this.panel_central.Location = new System.Drawing.Point(12, 73);
            this.panel_central.Name = "panel_central";
            this.panel_central.Size = new System.Drawing.Size(1299, 526);
            this.panel_central.TabIndex = 8;
            // 
            // label_info_interval_packet_transmit
            // 
            this.label_info_interval_packet_transmit.AutoSize = true;
            this.label_info_interval_packet_transmit.Location = new System.Drawing.Point(1045, 505);
            this.label_info_interval_packet_transmit.Name = "label_info_interval_packet_transmit";
            this.label_info_interval_packet_transmit.Size = new System.Drawing.Size(173, 13);
            this.label_info_interval_packet_transmit.TabIndex = 18;
            this.label_info_interval_packet_transmit.Text = "Интервал передачи пакетов, мс:";
            // 
            // numericUpDown_interval_packet_transmit
            // 
            this.numericUpDown_interval_packet_transmit.Location = new System.Drawing.Point(1224, 503);
            this.numericUpDown_interval_packet_transmit.Name = "numericUpDown_interval_packet_transmit";
            this.numericUpDown_interval_packet_transmit.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_packet_transmit.TabIndex = 17;
            // 
            // pictureBox_hydraulic_oil_temp_level
            // 
            this.pictureBox_hydraulic_oil_temp_level.Location = new System.Drawing.Point(818, 121);
            this.pictureBox_hydraulic_oil_temp_level.Name = "pictureBox_hydraulic_oil_temp_level";
            this.pictureBox_hydraulic_oil_temp_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_hydraulic_oil_temp_level.TabIndex = 16;
            this.pictureBox_hydraulic_oil_temp_level.TabStop = false;
            // 
            // pictureBox_rpm_meter
            // 
            this.pictureBox_rpm_meter.Location = new System.Drawing.Point(508, 121);
            this.pictureBox_rpm_meter.Name = "pictureBox_rpm_meter";
            this.pictureBox_rpm_meter.Size = new System.Drawing.Size(170, 145);
            this.pictureBox_rpm_meter.TabIndex = 15;
            this.pictureBox_rpm_meter.TabStop = false;
            // 
            // pictureBox_cooltant_temp_level
            // 
            this.pictureBox_cooltant_temp_level.Location = new System.Drawing.Point(374, 121);
            this.pictureBox_cooltant_temp_level.Name = "pictureBox_cooltant_temp_level";
            this.pictureBox_cooltant_temp_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_cooltant_temp_level.TabIndex = 14;
            this.pictureBox_cooltant_temp_level.TabStop = false;
            // 
            // pictureBox_fuel_level
            // 
            this.pictureBox_fuel_level.Location = new System.Drawing.Point(684, 121);
            this.pictureBox_fuel_level.Name = "pictureBox_fuel_level";
            this.pictureBox_fuel_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_fuel_level.TabIndex = 13;
            this.pictureBox_fuel_level.TabStop = false;
            // 
            // pictureBox_joystick_position_left
            // 
            this.pictureBox_joystick_position_left.Location = new System.Drawing.Point(553, 9);
            this.pictureBox_joystick_position_left.Name = "pictureBox_joystick_position_left";
            this.pictureBox_joystick_position_left.Size = new System.Drawing.Size(90, 90);
            this.pictureBox_joystick_position_left.TabIndex = 12;
            this.pictureBox_joystick_position_left.TabStop = false;
            // 
            // pictureBox_joystick_position_right
            // 
            this.pictureBox_joystick_position_right.Location = new System.Drawing.Point(649, 9);
            this.pictureBox_joystick_position_right.Name = "pictureBox_joystick_position_right";
            this.pictureBox_joystick_position_right.Size = new System.Drawing.Size(90, 90);
            this.pictureBox_joystick_position_right.TabIndex = 11;
            this.pictureBox_joystick_position_right.TabStop = false;
            // 
            // checkBox_cmd_microphone
            // 
            this.checkBox_cmd_microphone.AutoSize = true;
            this.checkBox_cmd_microphone.Location = new System.Drawing.Point(420, 287);
            this.checkBox_cmd_microphone.Name = "checkBox_cmd_microphone";
            this.checkBox_cmd_microphone.Size = new System.Drawing.Size(79, 17);
            this.checkBox_cmd_microphone.TabIndex = 19;
            this.checkBox_cmd_microphone.Text = "Микрофон";
            this.checkBox_cmd_microphone.UseVisualStyleBackColor = true;
            // 
            // button_cmd_start_engine
            // 
            this.button_cmd_start_engine.Location = new System.Drawing.Point(420, 333);
            this.button_cmd_start_engine.Name = "button_cmd_start_engine";
            this.button_cmd_start_engine.Size = new System.Drawing.Size(135, 23);
            this.button_cmd_start_engine.TabIndex = 20;
            this.button_cmd_start_engine.Text = "Запускать двигатель";
            this.button_cmd_start_engine.UseVisualStyleBackColor = true;
            // 
            // button_cmd_stop_engine
            // 
            this.button_cmd_stop_engine.Location = new System.Drawing.Point(420, 362);
            this.button_cmd_stop_engine.Name = "button_cmd_stop_engine";
            this.button_cmd_stop_engine.Size = new System.Drawing.Size(135, 23);
            this.button_cmd_stop_engine.TabIndex = 21;
            this.button_cmd_stop_engine.Text = "Остановить двигатель";
            this.button_cmd_stop_engine.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_ignition
            // 
            this.checkBox_cmd_ignition.AutoSize = true;
            this.checkBox_cmd_ignition.Location = new System.Drawing.Point(420, 310);
            this.checkBox_cmd_ignition.Name = "checkBox_cmd_ignition";
            this.checkBox_cmd_ignition.Size = new System.Drawing.Size(82, 17);
            this.checkBox_cmd_ignition.TabIndex = 22;
            this.checkBox_cmd_ignition.Text = "Зажигание";
            this.checkBox_cmd_ignition.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_brake_parking
            // 
            this.checkBox_cmd_brake_parking.AutoSize = true;
            this.checkBox_cmd_brake_parking.Location = new System.Drawing.Point(420, 391);
            this.checkBox_cmd_brake_parking.Name = "checkBox_cmd_brake_parking";
            this.checkBox_cmd_brake_parking.Size = new System.Drawing.Size(127, 17);
            this.checkBox_cmd_brake_parking.TabIndex = 23;
            this.checkBox_cmd_brake_parking.Text = "Стояночный тормоз";
            this.checkBox_cmd_brake_parking.UseVisualStyleBackColor = true;
            // 
            // button_cmd_brake
            // 
            this.button_cmd_brake.Location = new System.Drawing.Point(420, 414);
            this.button_cmd_brake.Name = "button_cmd_brake";
            this.button_cmd_brake.Size = new System.Drawing.Size(79, 23);
            this.button_cmd_brake.TabIndex = 24;
            this.button_cmd_brake.Text = "Тормоз";
            this.button_cmd_brake.UseVisualStyleBackColor = true;
            // 
            // button_cmd_horn
            // 
            this.button_cmd_horn.Location = new System.Drawing.Point(420, 443);
            this.button_cmd_horn.Name = "button_cmd_horn";
            this.button_cmd_horn.Size = new System.Drawing.Size(79, 23);
            this.button_cmd_horn.TabIndex = 25;
            this.button_cmd_horn.Text = "Сигналка";
            this.button_cmd_horn.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_hazard_light
            // 
            this.checkBox_cmd_hazard_light.AutoSize = true;
            this.checkBox_cmd_hazard_light.Location = new System.Drawing.Point(658, 287);
            this.checkBox_cmd_hazard_light.Name = "checkBox_cmd_hazard_light";
            this.checkBox_cmd_hazard_light.Size = new System.Drawing.Size(135, 17);
            this.checkBox_cmd_hazard_light.TabIndex = 26;
            this.checkBox_cmd_hazard_light.Text = "Аварейный лампочка";
            this.checkBox_cmd_hazard_light.UseVisualStyleBackColor = true;
            // 
            // button_cmd_left_turn_signal
            // 
            this.button_cmd_left_turn_signal.Location = new System.Drawing.Point(658, 310);
            this.button_cmd_left_turn_signal.Name = "button_cmd_left_turn_signal";
            this.button_cmd_left_turn_signal.Size = new System.Drawing.Size(123, 23);
            this.button_cmd_left_turn_signal.TabIndex = 27;
            this.button_cmd_left_turn_signal.Text = "Поворотник налево";
            this.button_cmd_left_turn_signal.UseVisualStyleBackColor = true;
            // 
            // button_cmd_right_turn_signal
            // 
            this.button_cmd_right_turn_signal.Location = new System.Drawing.Point(787, 310);
            this.button_cmd_right_turn_signal.Name = "button_cmd_right_turn_signal";
            this.button_cmd_right_turn_signal.Size = new System.Drawing.Size(123, 23);
            this.button_cmd_right_turn_signal.TabIndex = 28;
            this.button_cmd_right_turn_signal.Text = "Поворотник направо";
            this.button_cmd_right_turn_signal.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_head_light
            // 
            this.checkBox_cmd_head_light.AutoSize = true;
            this.checkBox_cmd_head_light.Location = new System.Drawing.Point(658, 339);
            this.checkBox_cmd_head_light.Name = "checkBox_cmd_head_light";
            this.checkBox_cmd_head_light.Size = new System.Drawing.Size(105, 17);
            this.checkBox_cmd_head_light.TabIndex = 29;
            this.checkBox_cmd_head_light.Text = "Передний фара";
            this.checkBox_cmd_head_light.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_rear_light
            // 
            this.checkBox_cmd_rear_light.AutoSize = true;
            this.checkBox_cmd_rear_light.Location = new System.Drawing.Point(658, 362);
            this.checkBox_cmd_rear_light.Name = "checkBox_cmd_rear_light";
            this.checkBox_cmd_rear_light.Size = new System.Drawing.Size(92, 17);
            this.checkBox_cmd_rear_light.TabIndex = 30;
            this.checkBox_cmd_rear_light.Text = "Задний фара";
            this.checkBox_cmd_rear_light.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_wipers
            // 
            this.checkBox_cmd_wipers.AutoSize = true;
            this.checkBox_cmd_wipers.Location = new System.Drawing.Point(658, 385);
            this.checkBox_cmd_wipers.Name = "checkBox_cmd_wipers";
            this.checkBox_cmd_wipers.Size = new System.Drawing.Size(77, 17);
            this.checkBox_cmd_wipers.TabIndex = 31;
            this.checkBox_cmd_wipers.Text = "Дворники";
            this.checkBox_cmd_wipers.UseVisualStyleBackColor = true;
            // 
            // label_info_interval_packet_recive
            // 
            this.label_info_interval_packet_recive.AutoSize = true;
            this.label_info_interval_packet_recive.Location = new System.Drawing.Point(1002, 481);
            this.label_info_interval_packet_recive.Name = "label_info_interval_packet_recive";
            this.label_info_interval_packet_recive.Size = new System.Drawing.Size(215, 13);
            this.label_info_interval_packet_recive.TabIndex = 33;
            this.label_info_interval_packet_recive.Text = "Интервал проверка приема пакетов, мс:";
            // 
            // numericUpDown_interval_packet_recive
            // 
            this.numericUpDown_interval_packet_recive.Location = new System.Drawing.Point(1224, 479);
            this.numericUpDown_interval_packet_recive.Name = "numericUpDown_interval_packet_recive";
            this.numericUpDown_interval_packet_recive.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_packet_recive.TabIndex = 32;
            // 
            // label_info_interval_update_panel
            // 
            this.label_info_interval_update_panel.AutoSize = true;
            this.label_info_interval_update_panel.Location = new System.Drawing.Point(1036, 455);
            this.label_info_interval_update_panel.Name = "label_info_interval_update_panel";
            this.label_info_interval_update_panel.Size = new System.Drawing.Size(181, 13);
            this.label_info_interval_update_panel.TabIndex = 35;
            this.label_info_interval_update_panel.Text = "Интервал обновление панель, мс:";
            // 
            // numericUpDown_interval_update_panel
            // 
            this.numericUpDown_interval_update_panel.Location = new System.Drawing.Point(1224, 453);
            this.numericUpDown_interval_update_panel.Name = "numericUpDown_interval_update_panel";
            this.numericUpDown_interval_update_panel.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_update_panel.TabIndex = 34;
            // 
            // label_info_interval_req_telemetry
            // 
            this.label_info_interval_req_telemetry.AutoSize = true;
            this.label_info_interval_req_telemetry.Location = new System.Drawing.Point(1037, 429);
            this.label_info_interval_req_telemetry.Name = "label_info_interval_req_telemetry";
            this.label_info_interval_req_telemetry.Size = new System.Drawing.Size(181, 13);
            this.label_info_interval_req_telemetry.TabIndex = 37;
            this.label_info_interval_req_telemetry.Text = "Интервал запрос телеметрий, мс:";
            // 
            // numericUpDown_interval_req_telemetry
            // 
            this.numericUpDown_interval_req_telemetry.Location = new System.Drawing.Point(1224, 427);
            this.numericUpDown_interval_req_telemetry.Name = "numericUpDown_interval_req_telemetry";
            this.numericUpDown_interval_req_telemetry.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_req_telemetry.TabIndex = 36;
            // 
            // checkBox_perm_transmit_joystick_values
            // 
            this.checkBox_perm_transmit_joystick_values.AutoSize = true;
            this.checkBox_perm_transmit_joystick_values.Location = new System.Drawing.Point(658, 443);
            this.checkBox_perm_transmit_joystick_values.Name = "checkBox_perm_transmit_joystick_values";
            this.checkBox_perm_transmit_joystick_values.Size = new System.Drawing.Size(189, 17);
            this.checkBox_perm_transmit_joystick_values.TabIndex = 38;
            this.checkBox_perm_transmit_joystick_values.Text = "Передовать значение джостика";
            this.checkBox_perm_transmit_joystick_values.UseVisualStyleBackColor = true;
            // 
            // textBox_telemetry_data
            // 
            this.textBox_telemetry_data.Location = new System.Drawing.Point(955, 121);
            this.textBox_telemetry_data.Multiline = true;
            this.textBox_telemetry_data.Name = "textBox_telemetry_data";
            this.textBox_telemetry_data.Size = new System.Drawing.Size(341, 264);
            this.textBox_telemetry_data.TabIndex = 39;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 611);
            this.Controls.Add(this.groupBox_hid_joystiks);
            this.Controls.Add(this.groupBox_connection_reserve);
            this.Controls.Add(this.groupBox_connection_tcp);
            this.Controls.Add(this.panel_central);
            this.Name = "form_main";
            this.Text = "Program";
            this.groupBox_connection_tcp.ResumeLayout(false);
            this.groupBox_connection_tcp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).EndInit();
            this.groupBox_connection_reserve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_com_port_baudrate)).EndInit();
            this.groupBox_hid_joystiks.ResumeLayout(false);
            this.groupBox_hid_joystiks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_controller_connected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_ECU_connected)).EndInit();
            this.panel_central.ResumeLayout(false);
            this.panel_central.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_packet_transmit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hydraulic_oil_temp_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rpm_meter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cooltant_temp_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fuel_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_packet_recive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_update_panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_telemetry)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_tcp_server_ip;
        private System.Windows.Forms.Button button_tcp_open;
        private System.Windows.Forms.GroupBox groupBox_connection_tcp;
        private System.Windows.Forms.Button button_tcp_close;
        private System.Windows.Forms.NumericUpDown numericUpDown_tcp_server_port;
        private System.Windows.Forms.GroupBox groupBox_connection_reserve;
        private System.Windows.Forms.Button button_com_port_close;
        private System.Windows.Forms.Button button_com_port_open;
        private System.Windows.Forms.NumericUpDown numericUpDown_com_port_baudrate;
        private System.Windows.Forms.ComboBox comboBox_com_port_names;
        private System.Windows.Forms.GroupBox groupBox_hid_joystiks;
        private System.Windows.Forms.Label label_info_joystick_left;
        private System.Windows.Forms.Label label_info_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_left;
        private System.Windows.Forms.Button button_joysticks_calibration;
        private System.Windows.Forms.Label label_info_joysticks_calibration;
        private System.Windows.Forms.PictureBox pictureBox_state_joysticks_calibration;
        private System.Windows.Forms.Button button_joysticks_calibration_reset;
        private System.Windows.Forms.PictureBox pictureBox_state_controller_connected;
        private System.Windows.Forms.Label label_info_state_ECU_connected;
        private System.Windows.Forms.PictureBox pictureBox_state_ECU_connected;
        private System.Windows.Forms.Label label_info_state_controller_connected;
        private System.Windows.Forms.Panel panel_central;
        private System.Windows.Forms.PictureBox pictureBox_joystick_position_left;
        private System.Windows.Forms.PictureBox pictureBox_joystick_position_right;
        private System.Windows.Forms.PictureBox pictureBox_fuel_level;
        private System.Windows.Forms.PictureBox pictureBox_cooltant_temp_level;
        private System.Windows.Forms.PictureBox pictureBox_rpm_meter;
        private System.Windows.Forms.PictureBox pictureBox_hydraulic_oil_temp_level;
        private System.Windows.Forms.Label label_info_interval_packet_transmit;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_packet_transmit;
        private System.Windows.Forms.CheckBox checkBox_cmd_microphone;
        private System.Windows.Forms.CheckBox checkBox_cmd_wipers;
        private System.Windows.Forms.CheckBox checkBox_cmd_rear_light;
        private System.Windows.Forms.CheckBox checkBox_cmd_head_light;
        private System.Windows.Forms.Button button_cmd_right_turn_signal;
        private System.Windows.Forms.Button button_cmd_left_turn_signal;
        private System.Windows.Forms.CheckBox checkBox_cmd_hazard_light;
        private System.Windows.Forms.Button button_cmd_horn;
        private System.Windows.Forms.Button button_cmd_brake;
        private System.Windows.Forms.CheckBox checkBox_cmd_brake_parking;
        private System.Windows.Forms.CheckBox checkBox_cmd_ignition;
        private System.Windows.Forms.Button button_cmd_stop_engine;
        private System.Windows.Forms.Button button_cmd_start_engine;
        private System.Windows.Forms.Label label_info_interval_packet_recive;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_packet_recive;
        private System.Windows.Forms.Label label_info_interval_update_panel;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_update_panel;
        private System.Windows.Forms.Label label_info_interval_req_telemetry;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_req_telemetry;
        private System.Windows.Forms.CheckBox checkBox_perm_transmit_joystick_values;
        private System.Windows.Forms.TextBox textBox_telemetry_data;
    }
}

