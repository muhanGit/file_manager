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
            this.label_info_interval_req_packet_tcp = new System.Windows.Forms.Label();
            this.numericUpDown_interval_req_packet_tcp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_interval_transmit_packet_tcp = new System.Windows.Forms.NumericUpDown();
            this.label_info_interval_transmit_packet_tcp = new System.Windows.Forms.Label();
            this.groupBox_connection_reserve = new System.Windows.Forms.GroupBox();
            this.label_info_com_port_uuid_dev = new System.Windows.Forms.Label();
            this.textBox_com_port_uuid_dev = new System.Windows.Forms.TextBox();
            this.comboBox_com_port_baudrate = new System.Windows.Forms.ComboBox();
            this.label_info_interval_req_packet_com_port = new System.Windows.Forms.Label();
            this.button_com_port_close = new System.Windows.Forms.Button();
            this.numericUpDown_interval_req_packet_com_port = new System.Windows.Forms.NumericUpDown();
            this.button_com_port_open = new System.Windows.Forms.Button();
            this.comboBox_com_port_port_names = new System.Windows.Forms.ComboBox();
            this.groupBox_hid_joystik = new System.Windows.Forms.GroupBox();
            this.button_joysticks_calibration_reset = new System.Windows.Forms.Button();
            this.button_joysticks_calibration = new System.Windows.Forms.Button();
            this.label_info_state_joysticks_calibration = new System.Windows.Forms.Label();
            this.pictureBox_state_joysticks_calibration = new System.Windows.Forms.PictureBox();
            this.label_info_state_joystick_left = new System.Windows.Forms.Label();
            this.label_info_state_joystick_right = new System.Windows.Forms.Label();
            this.pictureBox_state_joystick_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_state_joystick_right = new System.Windows.Forms.PictureBox();
            this.pictureBox_joystick_position_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_joystick_position_right = new System.Windows.Forms.PictureBox();
            this.panel_dashboard = new System.Windows.Forms.Panel();
            this.groupBox_telemetry_and_visualization = new System.Windows.Forms.GroupBox();
            this.label_info_cooltant_temp_level = new System.Windows.Forms.Label();
            this.label_info_fuel_level = new System.Windows.Forms.Label();
            this.label_info_hydraulic_oil_temp_level = new System.Windows.Forms.Label();
            this.label_info_rpm_meter = new System.Windows.Forms.Label();
            this.pictureBox_hydraulic_oil_temp_level = new System.Windows.Forms.PictureBox();
            this.pictureBox_fuel_level = new System.Windows.Forms.PictureBox();
            this.pictureBox_rpm_meter = new System.Windows.Forms.PictureBox();
            this.pictureBox_cooltant_temp_level = new System.Windows.Forms.PictureBox();
            this.groupBox_loader_commands = new System.Windows.Forms.GroupBox();
            this.button_cmd_switch_speed = new System.Windows.Forms.Button();
            this.button_cmd_locked = new System.Windows.Forms.Button();
            this.button_cmd_unlocked = new System.Windows.Forms.Button();
            this.checkBox_cmd_hazard_light = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_microphone = new System.Windows.Forms.CheckBox();
            this.checkBox_perm_transmit_joystick_values = new System.Windows.Forms.CheckBox();
            this.button_cmd_start_engine = new System.Windows.Forms.Button();
            this.checkBox_cmd_wipers = new System.Windows.Forms.CheckBox();
            this.button_cmd_stop_engine = new System.Windows.Forms.Button();
            this.checkBox_cmd_rear_light = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_ignition = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_head_light = new System.Windows.Forms.CheckBox();
            this.checkBox_cmd_brake_parking = new System.Windows.Forms.CheckBox();
            this.button_cmd_right_turn_signal = new System.Windows.Forms.Button();
            this.button_cmd_brake = new System.Windows.Forms.Button();
            this.button_cmd_left_turn_signal = new System.Windows.Forms.Button();
            this.button_cmd_horn = new System.Windows.Forms.Button();
            this.groupBox_loader_status_and_indicators = new System.Windows.Forms.GroupBox();
            this.label_info_ind_heating_engine = new System.Windows.Forms.Label();
            this.pictureBox_ind_heating_engine = new System.Windows.Forms.PictureBox();
            this.label_info_ind_rear_cover = new System.Windows.Forms.Label();
            this.pictureBox_ind_rear_cover = new System.Windows.Forms.PictureBox();
            this.label_info_ind_switch_speed = new System.Windows.Forms.Label();
            this.pictureBox_ind_switch_speed = new System.Windows.Forms.PictureBox();
            this.label_info_ind_min_hydraulic_oil = new System.Windows.Forms.Label();
            this.pictureBox_ind_min_hydraulic_oil = new System.Windows.Forms.PictureBox();
            this.label_info_ind_min_fuel = new System.Windows.Forms.Label();
            this.pictureBox_ind_min_fuel = new System.Windows.Forms.PictureBox();
            this.label_info_status_horn = new System.Windows.Forms.Label();
            this.pictureBox_status_horn = new System.Windows.Forms.PictureBox();
            this.label_info_status_wipers = new System.Windows.Forms.Label();
            this.pictureBox_status_wipers = new System.Windows.Forms.PictureBox();
            this.label_info_status_rear_light = new System.Windows.Forms.Label();
            this.pictureBox_status_rear_light = new System.Windows.Forms.PictureBox();
            this.label_info_status_right_turn_signal = new System.Windows.Forms.Label();
            this.pictureBox_status_right_turn_signal = new System.Windows.Forms.PictureBox();
            this.label_info_status_head_light = new System.Windows.Forms.Label();
            this.pictureBox_status_head_light = new System.Windows.Forms.PictureBox();
            this.label_info_status_left_turn_signal = new System.Windows.Forms.Label();
            this.pictureBox_status_left_turn_signal = new System.Windows.Forms.PictureBox();
            this.label_info_status_hazard_light = new System.Windows.Forms.Label();
            this.pictureBox_status_hazard_light = new System.Windows.Forms.PictureBox();
            this.label_info_status_brake_parking = new System.Windows.Forms.Label();
            this.pictureBox_status_brake_parking = new System.Windows.Forms.PictureBox();
            this.label_info_status_brake = new System.Windows.Forms.Label();
            this.pictureBox_status_brake = new System.Windows.Forms.PictureBox();
            this.label_info_status_engine = new System.Windows.Forms.Label();
            this.pictureBox_status_engine = new System.Windows.Forms.PictureBox();
            this.label_info_status_ignition = new System.Windows.Forms.Label();
            this.pictureBox_status_ignition = new System.Windows.Forms.PictureBox();
            this.label_info_status_ecu_is_connected = new System.Windows.Forms.Label();
            this.pictureBox_status_ecu_is_connected = new System.Windows.Forms.PictureBox();
            this.label_info_status_nrf_is_connected = new System.Windows.Forms.Label();
            this.pictureBox_status_nrf_is_connected = new System.Windows.Forms.PictureBox();
            this.label_info_status_tcp_is_connected = new System.Windows.Forms.Label();
            this.pictureBox_status_tcp_is_connected = new System.Windows.Forms.PictureBox();
            this.label_info_status_loader_is_locked = new System.Windows.Forms.Label();
            this.pictureBox_status_loader_is_locked = new System.Windows.Forms.PictureBox();
            this.label_info_tcp_info = new System.Windows.Forms.Label();
            this.checkBox_cmd_beacon_light = new System.Windows.Forms.CheckBox();
            this.groupBox_connection_tcp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_packet_tcp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_transmit_packet_tcp)).BeginInit();
            this.groupBox_connection_reserve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_packet_com_port)).BeginInit();
            this.groupBox_hid_joystik.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_right)).BeginInit();
            this.panel_dashboard.SuspendLayout();
            this.groupBox_telemetry_and_visualization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hydraulic_oil_temp_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fuel_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rpm_meter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cooltant_temp_level)).BeginInit();
            this.groupBox_loader_commands.SuspendLayout();
            this.groupBox_loader_status_and_indicators.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_heating_engine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_rear_cover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_switch_speed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_min_hydraulic_oil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_min_fuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_horn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_wipers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_rear_light)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_right_turn_signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_head_light)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_left_turn_signal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_hazard_light)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_brake_parking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_brake)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_engine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_ignition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_ecu_is_connected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_nrf_is_connected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_tcp_is_connected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_loader_is_locked)).BeginInit();
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
            this.groupBox_connection_tcp.Controls.Add(this.label_info_tcp_info);
            this.groupBox_connection_tcp.Controls.Add(this.numericUpDown_tcp_server_port);
            this.groupBox_connection_tcp.Controls.Add(this.button_tcp_close);
            this.groupBox_connection_tcp.Controls.Add(this.label_info_interval_req_packet_tcp);
            this.groupBox_connection_tcp.Controls.Add(this.textBox_tcp_server_ip);
            this.groupBox_connection_tcp.Controls.Add(this.numericUpDown_interval_req_packet_tcp);
            this.groupBox_connection_tcp.Controls.Add(this.button_tcp_open);
            this.groupBox_connection_tcp.Controls.Add(this.numericUpDown_interval_transmit_packet_tcp);
            this.groupBox_connection_tcp.Controls.Add(this.label_info_interval_transmit_packet_tcp);
            this.groupBox_connection_tcp.Location = new System.Drawing.Point(12, 12);
            this.groupBox_connection_tcp.Name = "groupBox_connection_tcp";
            this.groupBox_connection_tcp.Size = new System.Drawing.Size(380, 114);
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
            // label_info_interval_req_packet_tcp
            // 
            this.label_info_interval_req_packet_tcp.AutoSize = true;
            this.label_info_interval_req_packet_tcp.Location = new System.Drawing.Point(142, 50);
            this.label_info_interval_req_packet_tcp.Name = "label_info_interval_req_packet_tcp";
            this.label_info_interval_req_packet_tcp.Size = new System.Drawing.Size(155, 13);
            this.label_info_interval_req_packet_tcp.TabIndex = 37;
            this.label_info_interval_req_packet_tcp.Text = "Интервал запрос пакеты, мс";
            // 
            // numericUpDown_interval_req_packet_tcp
            // 
            this.numericUpDown_interval_req_packet_tcp.Location = new System.Drawing.Point(303, 48);
            this.numericUpDown_interval_req_packet_tcp.Name = "numericUpDown_interval_req_packet_tcp";
            this.numericUpDown_interval_req_packet_tcp.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_req_packet_tcp.TabIndex = 36;
            // 
            // numericUpDown_interval_transmit_packet_tcp
            // 
            this.numericUpDown_interval_transmit_packet_tcp.Location = new System.Drawing.Point(303, 74);
            this.numericUpDown_interval_transmit_packet_tcp.Name = "numericUpDown_interval_transmit_packet_tcp";
            this.numericUpDown_interval_transmit_packet_tcp.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_transmit_packet_tcp.TabIndex = 17;
            // 
            // label_info_interval_transmit_packet_tcp
            // 
            this.label_info_interval_transmit_packet_tcp.AutoSize = true;
            this.label_info_interval_transmit_packet_tcp.Location = new System.Drawing.Point(128, 75);
            this.label_info_interval_transmit_packet_tcp.Name = "label_info_interval_transmit_packet_tcp";
            this.label_info_interval_transmit_packet_tcp.Size = new System.Drawing.Size(169, 13);
            this.label_info_interval_transmit_packet_tcp.TabIndex = 18;
            this.label_info_interval_transmit_packet_tcp.Text = "Интервал передачи пакеты, мс:";
            // 
            // groupBox_connection_reserve
            // 
            this.groupBox_connection_reserve.Controls.Add(this.label_info_com_port_uuid_dev);
            this.groupBox_connection_reserve.Controls.Add(this.textBox_com_port_uuid_dev);
            this.groupBox_connection_reserve.Controls.Add(this.comboBox_com_port_baudrate);
            this.groupBox_connection_reserve.Controls.Add(this.label_info_interval_req_packet_com_port);
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_close);
            this.groupBox_connection_reserve.Controls.Add(this.numericUpDown_interval_req_packet_com_port);
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_open);
            this.groupBox_connection_reserve.Controls.Add(this.comboBox_com_port_port_names);
            this.groupBox_connection_reserve.Location = new System.Drawing.Point(398, 12);
            this.groupBox_connection_reserve.Name = "groupBox_connection_reserve";
            this.groupBox_connection_reserve.Size = new System.Drawing.Size(371, 114);
            this.groupBox_connection_reserve.TabIndex = 5;
            this.groupBox_connection_reserve.TabStop = false;
            this.groupBox_connection_reserve.Text = "Ревервный канал соединение";
            // 
            // label_info_com_port_uuid_dev
            // 
            this.label_info_com_port_uuid_dev.AutoSize = true;
            this.label_info_com_port_uuid_dev.Location = new System.Drawing.Point(180, 77);
            this.label_info_com_port_uuid_dev.Name = "label_info_com_port_uuid_dev";
            this.label_info_com_port_uuid_dev.Size = new System.Drawing.Size(96, 13);
            this.label_info_com_port_uuid_dev.TabIndex = 42;
            this.label_info_com_port_uuid_dev.Text = "UUID девайс, hex";
            // 
            // textBox_com_port_uuid_dev
            // 
            this.textBox_com_port_uuid_dev.Location = new System.Drawing.Point(282, 74);
            this.textBox_com_port_uuid_dev.Name = "textBox_com_port_uuid_dev";
            this.textBox_com_port_uuid_dev.Size = new System.Drawing.Size(83, 20);
            this.textBox_com_port_uuid_dev.TabIndex = 41;
            // 
            // comboBox_com_port_baudrate
            // 
            this.comboBox_com_port_baudrate.FormattingEnabled = true;
            this.comboBox_com_port_baudrate.Location = new System.Drawing.Point(105, 19);
            this.comboBox_com_port_baudrate.Name = "comboBox_com_port_baudrate";
            this.comboBox_com_port_baudrate.Size = new System.Drawing.Size(99, 21);
            this.comboBox_com_port_baudrate.TabIndex = 40;
            // 
            // label_info_interval_req_packet_com_port
            // 
            this.label_info_interval_req_packet_com_port.AutoSize = true;
            this.label_info_interval_req_packet_com_port.Location = new System.Drawing.Point(132, 50);
            this.label_info_interval_req_packet_com_port.Name = "label_info_interval_req_packet_com_port";
            this.label_info_interval_req_packet_com_port.Size = new System.Drawing.Size(155, 13);
            this.label_info_interval_req_packet_com_port.TabIndex = 39;
            this.label_info_interval_req_packet_com_port.Text = "Интервал запрос пакеты, мс";
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
            // numericUpDown_interval_req_packet_com_port
            // 
            this.numericUpDown_interval_req_packet_com_port.Location = new System.Drawing.Point(293, 48);
            this.numericUpDown_interval_req_packet_com_port.Name = "numericUpDown_interval_req_packet_com_port";
            this.numericUpDown_interval_req_packet_com_port.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_interval_req_packet_com_port.TabIndex = 38;
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
            // comboBox_com_port_port_names
            // 
            this.comboBox_com_port_port_names.FormattingEnabled = true;
            this.comboBox_com_port_port_names.Location = new System.Drawing.Point(6, 19);
            this.comboBox_com_port_port_names.Name = "comboBox_com_port_port_names";
            this.comboBox_com_port_port_names.Size = new System.Drawing.Size(93, 21);
            this.comboBox_com_port_port_names.TabIndex = 6;
            // 
            // groupBox_hid_joystik
            // 
            this.groupBox_hid_joystik.Controls.Add(this.button_joysticks_calibration_reset);
            this.groupBox_hid_joystik.Controls.Add(this.button_joysticks_calibration);
            this.groupBox_hid_joystik.Controls.Add(this.label_info_state_joysticks_calibration);
            this.groupBox_hid_joystik.Controls.Add(this.pictureBox_state_joysticks_calibration);
            this.groupBox_hid_joystik.Controls.Add(this.label_info_state_joystick_left);
            this.groupBox_hid_joystik.Controls.Add(this.label_info_state_joystick_right);
            this.groupBox_hid_joystik.Controls.Add(this.pictureBox_state_joystick_left);
            this.groupBox_hid_joystik.Controls.Add(this.pictureBox_state_joystick_right);
            this.groupBox_hid_joystik.Controls.Add(this.pictureBox_joystick_position_left);
            this.groupBox_hid_joystik.Controls.Add(this.pictureBox_joystick_position_right);
            this.groupBox_hid_joystik.Location = new System.Drawing.Point(775, 12);
            this.groupBox_hid_joystik.Name = "groupBox_hid_joystik";
            this.groupBox_hid_joystik.Size = new System.Drawing.Size(464, 114);
            this.groupBox_hid_joystik.TabIndex = 6;
            this.groupBox_hid_joystik.TabStop = false;
            this.groupBox_hid_joystik.Text = "Джостики";
            // 
            // button_joysticks_calibration_reset
            // 
            this.button_joysticks_calibration_reset.Location = new System.Drawing.Point(98, 79);
            this.button_joysticks_calibration_reset.Name = "button_joysticks_calibration_reset";
            this.button_joysticks_calibration_reset.Size = new System.Drawing.Size(73, 23);
            this.button_joysticks_calibration_reset.TabIndex = 12;
            this.button_joysticks_calibration_reset.Text = "Сброс";
            this.button_joysticks_calibration_reset.UseVisualStyleBackColor = true;
            // 
            // button_joysticks_calibration
            // 
            this.button_joysticks_calibration.Location = new System.Drawing.Point(6, 79);
            this.button_joysticks_calibration.Name = "button_joysticks_calibration";
            this.button_joysticks_calibration.Size = new System.Drawing.Size(86, 23);
            this.button_joysticks_calibration.TabIndex = 7;
            this.button_joysticks_calibration.Text = "Калибровка";
            this.button_joysticks_calibration.UseVisualStyleBackColor = true;
            // 
            // label_info_state_joysticks_calibration
            // 
            this.label_info_state_joysticks_calibration.AutoSize = true;
            this.label_info_state_joysticks_calibration.Location = new System.Drawing.Point(199, 24);
            this.label_info_state_joysticks_calibration.Name = "label_info_state_joysticks_calibration";
            this.label_info_state_joysticks_calibration.Size = new System.Drawing.Size(68, 13);
            this.label_info_state_joysticks_calibration.TabIndex = 10;
            this.label_info_state_joysticks_calibration.Text = "Калибровка";
            // 
            // pictureBox_state_joysticks_calibration
            // 
            this.pictureBox_state_joysticks_calibration.Location = new System.Drawing.Point(168, 19);
            this.pictureBox_state_joysticks_calibration.Name = "pictureBox_state_joysticks_calibration";
            this.pictureBox_state_joysticks_calibration.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joysticks_calibration.TabIndex = 11;
            this.pictureBox_state_joysticks_calibration.TabStop = false;
            // 
            // label_info_state_joystick_left
            // 
            this.label_info_state_joystick_left.AutoSize = true;
            this.label_info_state_joystick_left.Location = new System.Drawing.Point(37, 24);
            this.label_info_state_joystick_left.Name = "label_info_state_joystick_left";
            this.label_info_state_joystick_left.Size = new System.Drawing.Size(41, 13);
            this.label_info_state_joystick_left.TabIndex = 8;
            this.label_info_state_joystick_left.Text = "Левый";
            // 
            // label_info_state_joystick_right
            // 
            this.label_info_state_joystick_right.AutoSize = true;
            this.label_info_state_joystick_right.Location = new System.Drawing.Point(115, 24);
            this.label_info_state_joystick_right.Name = "label_info_state_joystick_right";
            this.label_info_state_joystick_right.Size = new System.Drawing.Size(47, 13);
            this.label_info_state_joystick_right.TabIndex = 7;
            this.label_info_state_joystick_right.Text = "Правый";
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
            // pictureBox_joystick_position_left
            // 
            this.pictureBox_joystick_position_left.Location = new System.Drawing.Point(273, 12);
            this.pictureBox_joystick_position_left.Name = "pictureBox_joystick_position_left";
            this.pictureBox_joystick_position_left.Size = new System.Drawing.Size(90, 90);
            this.pictureBox_joystick_position_left.TabIndex = 12;
            this.pictureBox_joystick_position_left.TabStop = false;
            // 
            // pictureBox_joystick_position_right
            // 
            this.pictureBox_joystick_position_right.Location = new System.Drawing.Point(369, 12);
            this.pictureBox_joystick_position_right.Name = "pictureBox_joystick_position_right";
            this.pictureBox_joystick_position_right.Size = new System.Drawing.Size(90, 90);
            this.pictureBox_joystick_position_right.TabIndex = 11;
            this.pictureBox_joystick_position_right.TabStop = false;
            // 
            // panel_dashboard
            // 
            this.panel_dashboard.Controls.Add(this.groupBox_telemetry_and_visualization);
            this.panel_dashboard.Controls.Add(this.groupBox_loader_commands);
            this.panel_dashboard.Controls.Add(this.groupBox_loader_status_and_indicators);
            this.panel_dashboard.Location = new System.Drawing.Point(12, 132);
            this.panel_dashboard.Name = "panel_dashboard";
            this.panel_dashboard.Size = new System.Drawing.Size(1227, 592);
            this.panel_dashboard.TabIndex = 8;
            // 
            // groupBox_telemetry_and_visualization
            // 
            this.groupBox_telemetry_and_visualization.Controls.Add(this.label_info_cooltant_temp_level);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.label_info_fuel_level);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.label_info_hydraulic_oil_temp_level);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.label_info_rpm_meter);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.pictureBox_hydraulic_oil_temp_level);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.pictureBox_fuel_level);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.pictureBox_rpm_meter);
            this.groupBox_telemetry_and_visualization.Controls.Add(this.pictureBox_cooltant_temp_level);
            this.groupBox_telemetry_and_visualization.Location = new System.Drawing.Point(3, 134);
            this.groupBox_telemetry_and_visualization.Name = "groupBox_telemetry_and_visualization";
            this.groupBox_telemetry_and_visualization.Size = new System.Drawing.Size(587, 453);
            this.groupBox_telemetry_and_visualization.TabIndex = 41;
            this.groupBox_telemetry_and_visualization.TabStop = false;
            this.groupBox_telemetry_and_visualization.Text = "Телеметрия и визуализация";
            // 
            // label_info_cooltant_temp_level
            // 
            this.label_info_cooltant_temp_level.AutoSize = true;
            this.label_info_cooltant_temp_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_cooltant_temp_level.Location = new System.Drawing.Point(28, 294);
            this.label_info_cooltant_temp_level.Name = "label_info_cooltant_temp_level";
            this.label_info_cooltant_temp_level.Size = new System.Drawing.Size(100, 68);
            this.label_info_cooltant_temp_level.TabIndex = 20;
            this.label_info_cooltant_temp_level.Text = "Температура\r\nохлаждающий\r\nжидкости\r\n0";
            this.label_info_cooltant_temp_level.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_info_fuel_level
            // 
            this.label_info_fuel_level.AutoSize = true;
            this.label_info_fuel_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_fuel_level.Location = new System.Drawing.Point(445, 294);
            this.label_info_fuel_level.Name = "label_info_fuel_level";
            this.label_info_fuel_level.Size = new System.Drawing.Size(121, 34);
            this.label_info_fuel_level.TabIndex = 19;
            this.label_info_fuel_level.Text = "Уровень топлива\r\n0";
            this.label_info_fuel_level.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_info_hydraulic_oil_temp_level
            // 
            this.label_info_hydraulic_oil_temp_level.AutoSize = true;
            this.label_info_hydraulic_oil_temp_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_hydraulic_oil_temp_level.Location = new System.Drawing.Point(139, 396);
            this.label_info_hydraulic_oil_temp_level.Name = "label_info_hydraulic_oil_temp_level";
            this.label_info_hydraulic_oil_temp_level.Size = new System.Drawing.Size(255, 34);
            this.label_info_hydraulic_oil_temp_level.TabIndex = 18;
            this.label_info_hydraulic_oil_temp_level.Text = "Температура гидравлического масло\r\n0";
            this.label_info_hydraulic_oil_temp_level.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_info_rpm_meter
            // 
            this.label_info_rpm_meter.AutoSize = true;
            this.label_info_rpm_meter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_rpm_meter.Location = new System.Drawing.Point(204, 167);
            this.label_info_rpm_meter.Name = "label_info_rpm_meter";
            this.label_info_rpm_meter.Size = new System.Drawing.Size(136, 34);
            this.label_info_rpm_meter.TabIndex = 17;
            this.label_info_rpm_meter.Text = "Оборот двигателья\r\n0";
            this.label_info_rpm_meter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox_hydraulic_oil_temp_level
            // 
            this.pictureBox_hydraulic_oil_temp_level.Location = new System.Drawing.Point(207, 248);
            this.pictureBox_hydraulic_oil_temp_level.Name = "pictureBox_hydraulic_oil_temp_level";
            this.pictureBox_hydraulic_oil_temp_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_hydraulic_oil_temp_level.TabIndex = 16;
            this.pictureBox_hydraulic_oil_temp_level.TabStop = false;
            // 
            // pictureBox_fuel_level
            // 
            this.pictureBox_fuel_level.Location = new System.Drawing.Point(440, 146);
            this.pictureBox_fuel_level.Name = "pictureBox_fuel_level";
            this.pictureBox_fuel_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_fuel_level.TabIndex = 13;
            this.pictureBox_fuel_level.TabStop = false;
            // 
            // pictureBox_rpm_meter
            // 
            this.pictureBox_rpm_meter.Location = new System.Drawing.Point(186, 19);
            this.pictureBox_rpm_meter.Name = "pictureBox_rpm_meter";
            this.pictureBox_rpm_meter.Size = new System.Drawing.Size(170, 145);
            this.pictureBox_rpm_meter.TabIndex = 15;
            this.pictureBox_rpm_meter.TabStop = false;
            // 
            // pictureBox_cooltant_temp_level
            // 
            this.pictureBox_cooltant_temp_level.Location = new System.Drawing.Point(19, 146);
            this.pictureBox_cooltant_temp_level.Name = "pictureBox_cooltant_temp_level";
            this.pictureBox_cooltant_temp_level.Size = new System.Drawing.Size(128, 145);
            this.pictureBox_cooltant_temp_level.TabIndex = 14;
            this.pictureBox_cooltant_temp_level.TabStop = false;
            // 
            // groupBox_loader_commands
            // 
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_beacon_light);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_switch_speed);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_locked);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_unlocked);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_hazard_light);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_microphone);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_perm_transmit_joystick_values);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_start_engine);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_wipers);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_stop_engine);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_rear_light);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_ignition);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_head_light);
            this.groupBox_loader_commands.Controls.Add(this.checkBox_cmd_brake_parking);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_right_turn_signal);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_brake);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_left_turn_signal);
            this.groupBox_loader_commands.Controls.Add(this.button_cmd_horn);
            this.groupBox_loader_commands.Location = new System.Drawing.Point(596, 134);
            this.groupBox_loader_commands.Name = "groupBox_loader_commands";
            this.groupBox_loader_commands.Size = new System.Drawing.Size(626, 453);
            this.groupBox_loader_commands.TabIndex = 40;
            this.groupBox_loader_commands.TabStop = false;
            this.groupBox_loader_commands.Text = "Команды";
            // 
            // button_cmd_switch_speed
            // 
            this.button_cmd_switch_speed.Location = new System.Drawing.Point(312, 141);
            this.button_cmd_switch_speed.Name = "button_cmd_switch_speed";
            this.button_cmd_switch_speed.Size = new System.Drawing.Size(179, 23);
            this.button_cmd_switch_speed.TabIndex = 41;
            this.button_cmd_switch_speed.Text = "Переключатель скорости";
            this.button_cmd_switch_speed.UseVisualStyleBackColor = true;
            // 
            // button_cmd_locked
            // 
            this.button_cmd_locked.Location = new System.Drawing.Point(130, 19);
            this.button_cmd_locked.Name = "button_cmd_locked";
            this.button_cmd_locked.Size = new System.Drawing.Size(118, 23);
            this.button_cmd_locked.TabIndex = 40;
            this.button_cmd_locked.Text = "Заблокировать";
            this.button_cmd_locked.UseVisualStyleBackColor = true;
            // 
            // button_cmd_unlocked
            // 
            this.button_cmd_unlocked.Location = new System.Drawing.Point(6, 19);
            this.button_cmd_unlocked.Name = "button_cmd_unlocked";
            this.button_cmd_unlocked.Size = new System.Drawing.Size(118, 23);
            this.button_cmd_unlocked.TabIndex = 39;
            this.button_cmd_unlocked.Text = "Разблокировать";
            this.button_cmd_unlocked.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_hazard_light
            // 
            this.checkBox_cmd_hazard_light.AutoSize = true;
            this.checkBox_cmd_hazard_light.Location = new System.Drawing.Point(369, 73);
            this.checkBox_cmd_hazard_light.Name = "checkBox_cmd_hazard_light";
            this.checkBox_cmd_hazard_light.Size = new System.Drawing.Size(135, 17);
            this.checkBox_cmd_hazard_light.TabIndex = 26;
            this.checkBox_cmd_hazard_light.Text = "Аварейный лампочка";
            this.checkBox_cmd_hazard_light.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_microphone
            // 
            this.checkBox_cmd_microphone.AutoSize = true;
            this.checkBox_cmd_microphone.Location = new System.Drawing.Point(6, 345);
            this.checkBox_cmd_microphone.Name = "checkBox_cmd_microphone";
            this.checkBox_cmd_microphone.Size = new System.Drawing.Size(79, 17);
            this.checkBox_cmd_microphone.TabIndex = 19;
            this.checkBox_cmd_microphone.Text = "Микрофон";
            this.checkBox_cmd_microphone.UseVisualStyleBackColor = true;
            // 
            // checkBox_perm_transmit_joystick_values
            // 
            this.checkBox_perm_transmit_joystick_values.AutoSize = true;
            this.checkBox_perm_transmit_joystick_values.Location = new System.Drawing.Point(360, 184);
            this.checkBox_perm_transmit_joystick_values.Name = "checkBox_perm_transmit_joystick_values";
            this.checkBox_perm_transmit_joystick_values.Size = new System.Drawing.Size(88, 17);
            this.checkBox_perm_transmit_joystick_values.TabIndex = 38;
            this.checkBox_perm_transmit_joystick_values.Text = "Управление";
            this.checkBox_perm_transmit_joystick_values.UseVisualStyleBackColor = true;
            // 
            // button_cmd_start_engine
            // 
            this.button_cmd_start_engine.Location = new System.Drawing.Point(6, 96);
            this.button_cmd_start_engine.Name = "button_cmd_start_engine";
            this.button_cmd_start_engine.Size = new System.Drawing.Size(135, 23);
            this.button_cmd_start_engine.TabIndex = 20;
            this.button_cmd_start_engine.Text = "Запускать двигатель";
            this.button_cmd_start_engine.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_wipers
            // 
            this.checkBox_cmd_wipers.AutoSize = true;
            this.checkBox_cmd_wipers.Location = new System.Drawing.Point(6, 311);
            this.checkBox_cmd_wipers.Name = "checkBox_cmd_wipers";
            this.checkBox_cmd_wipers.Size = new System.Drawing.Size(77, 17);
            this.checkBox_cmd_wipers.TabIndex = 31;
            this.checkBox_cmd_wipers.Text = "Дворники";
            this.checkBox_cmd_wipers.UseVisualStyleBackColor = true;
            // 
            // button_cmd_stop_engine
            // 
            this.button_cmd_stop_engine.Location = new System.Drawing.Point(6, 125);
            this.button_cmd_stop_engine.Name = "button_cmd_stop_engine";
            this.button_cmd_stop_engine.Size = new System.Drawing.Size(135, 23);
            this.button_cmd_stop_engine.TabIndex = 21;
            this.button_cmd_stop_engine.Text = "Остановить двигатель";
            this.button_cmd_stop_engine.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_rear_light
            // 
            this.checkBox_cmd_rear_light.AutoSize = true;
            this.checkBox_cmd_rear_light.Location = new System.Drawing.Point(139, 259);
            this.checkBox_cmd_rear_light.Name = "checkBox_cmd_rear_light";
            this.checkBox_cmd_rear_light.Size = new System.Drawing.Size(92, 17);
            this.checkBox_cmd_rear_light.TabIndex = 30;
            this.checkBox_cmd_rear_light.Text = "Задний фара";
            this.checkBox_cmd_rear_light.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_ignition
            // 
            this.checkBox_cmd_ignition.AutoSize = true;
            this.checkBox_cmd_ignition.Location = new System.Drawing.Point(6, 73);
            this.checkBox_cmd_ignition.Name = "checkBox_cmd_ignition";
            this.checkBox_cmd_ignition.Size = new System.Drawing.Size(82, 17);
            this.checkBox_cmd_ignition.TabIndex = 22;
            this.checkBox_cmd_ignition.Text = "Зажигание";
            this.checkBox_cmd_ignition.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_head_light
            // 
            this.checkBox_cmd_head_light.AutoSize = true;
            this.checkBox_cmd_head_light.Location = new System.Drawing.Point(6, 259);
            this.checkBox_cmd_head_light.Name = "checkBox_cmd_head_light";
            this.checkBox_cmd_head_light.Size = new System.Drawing.Size(105, 17);
            this.checkBox_cmd_head_light.TabIndex = 29;
            this.checkBox_cmd_head_light.Text = "Передний фара";
            this.checkBox_cmd_head_light.UseVisualStyleBackColor = true;
            // 
            // checkBox_cmd_brake_parking
            // 
            this.checkBox_cmd_brake_parking.AutoSize = true;
            this.checkBox_cmd_brake_parking.Location = new System.Drawing.Point(6, 207);
            this.checkBox_cmd_brake_parking.Name = "checkBox_cmd_brake_parking";
            this.checkBox_cmd_brake_parking.Size = new System.Drawing.Size(127, 17);
            this.checkBox_cmd_brake_parking.TabIndex = 23;
            this.checkBox_cmd_brake_parking.Text = "Стояночный тормоз";
            this.checkBox_cmd_brake_parking.UseVisualStyleBackColor = true;
            // 
            // button_cmd_right_turn_signal
            // 
            this.button_cmd_right_turn_signal.Location = new System.Drawing.Point(408, 96);
            this.button_cmd_right_turn_signal.Name = "button_cmd_right_turn_signal";
            this.button_cmd_right_turn_signal.Size = new System.Drawing.Size(123, 23);
            this.button_cmd_right_turn_signal.TabIndex = 28;
            this.button_cmd_right_turn_signal.Text = "Поворотник направо";
            this.button_cmd_right_turn_signal.UseVisualStyleBackColor = true;
            // 
            // button_cmd_brake
            // 
            this.button_cmd_brake.Location = new System.Drawing.Point(6, 178);
            this.button_cmd_brake.Name = "button_cmd_brake";
            this.button_cmd_brake.Size = new System.Drawing.Size(79, 23);
            this.button_cmd_brake.TabIndex = 24;
            this.button_cmd_brake.Text = "Тормоз";
            this.button_cmd_brake.UseVisualStyleBackColor = true;
            // 
            // button_cmd_left_turn_signal
            // 
            this.button_cmd_left_turn_signal.Location = new System.Drawing.Point(279, 96);
            this.button_cmd_left_turn_signal.Name = "button_cmd_left_turn_signal";
            this.button_cmd_left_turn_signal.Size = new System.Drawing.Size(123, 23);
            this.button_cmd_left_turn_signal.TabIndex = 27;
            this.button_cmd_left_turn_signal.Text = "Поворотник налево";
            this.button_cmd_left_turn_signal.UseVisualStyleBackColor = true;
            // 
            // button_cmd_horn
            // 
            this.button_cmd_horn.Location = new System.Drawing.Point(6, 384);
            this.button_cmd_horn.Name = "button_cmd_horn";
            this.button_cmd_horn.Size = new System.Drawing.Size(79, 23);
            this.button_cmd_horn.TabIndex = 25;
            this.button_cmd_horn.Text = "Сигналка";
            this.button_cmd_horn.UseVisualStyleBackColor = true;
            // 
            // groupBox_loader_status_and_indicators
            // 
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_ind_heating_engine);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_ind_heating_engine);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_ind_rear_cover);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_ind_rear_cover);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_ind_switch_speed);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_ind_switch_speed);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_ind_min_hydraulic_oil);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_ind_min_hydraulic_oil);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_ind_min_fuel);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_ind_min_fuel);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_horn);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_horn);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_wipers);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_wipers);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_rear_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_rear_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_right_turn_signal);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_right_turn_signal);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_head_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_head_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_left_turn_signal);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_left_turn_signal);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_hazard_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_hazard_light);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_brake_parking);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_brake_parking);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_brake);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_brake);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_engine);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_engine);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_ignition);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_ignition);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_ecu_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_ecu_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_nrf_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_nrf_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_tcp_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_tcp_is_connected);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.label_info_status_loader_is_locked);
            this.groupBox_loader_status_and_indicators.Controls.Add(this.pictureBox_status_loader_is_locked);
            this.groupBox_loader_status_and_indicators.Location = new System.Drawing.Point(3, 3);
            this.groupBox_loader_status_and_indicators.Name = "groupBox_loader_status_and_indicators";
            this.groupBox_loader_status_and_indicators.Size = new System.Drawing.Size(1219, 125);
            this.groupBox_loader_status_and_indicators.TabIndex = 39;
            this.groupBox_loader_status_and_indicators.TabStop = false;
            this.groupBox_loader_status_and_indicators.Text = "Статусы и индикаторы";
            // 
            // label_info_ind_heating_engine
            // 
            this.label_info_ind_heating_engine.AutoSize = true;
            this.label_info_ind_heating_engine.Location = new System.Drawing.Point(1090, 27);
            this.label_info_ind_heating_engine.Name = "label_info_ind_heating_engine";
            this.label_info_ind_heating_engine.Size = new System.Drawing.Size(79, 13);
            this.label_info_ind_heating_engine.TabIndex = 39;
            this.label_info_ind_heating_engine.Text = "Heating engine";
            // 
            // pictureBox_ind_heating_engine
            // 
            this.pictureBox_ind_heating_engine.Location = new System.Drawing.Point(1116, 43);
            this.pictureBox_ind_heating_engine.Name = "pictureBox_ind_heating_engine";
            this.pictureBox_ind_heating_engine.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_ind_heating_engine.TabIndex = 38;
            this.pictureBox_ind_heating_engine.TabStop = false;
            // 
            // label_info_ind_rear_cover
            // 
            this.label_info_ind_rear_cover.AutoSize = true;
            this.label_info_ind_rear_cover.Location = new System.Drawing.Point(1027, 71);
            this.label_info_ind_rear_cover.Name = "label_info_ind_rear_cover";
            this.label_info_ind_rear_cover.Size = new System.Drawing.Size(60, 13);
            this.label_info_ind_rear_cover.TabIndex = 37;
            this.label_info_ind_rear_cover.Text = "Rear cover";
            // 
            // pictureBox_ind_rear_cover
            // 
            this.pictureBox_ind_rear_cover.Location = new System.Drawing.Point(1040, 87);
            this.pictureBox_ind_rear_cover.Name = "pictureBox_ind_rear_cover";
            this.pictureBox_ind_rear_cover.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_ind_rear_cover.TabIndex = 36;
            this.pictureBox_ind_rear_cover.TabStop = false;
            // 
            // label_info_ind_switch_speed
            // 
            this.label_info_ind_switch_speed.AutoSize = true;
            this.label_info_ind_switch_speed.Location = new System.Drawing.Point(1013, 27);
            this.label_info_ind_switch_speed.Name = "label_info_ind_switch_speed";
            this.label_info_ind_switch_speed.Size = new System.Drawing.Size(71, 13);
            this.label_info_ind_switch_speed.TabIndex = 35;
            this.label_info_ind_switch_speed.Text = "Switch speed";
            // 
            // pictureBox_ind_switch_speed
            // 
            this.pictureBox_ind_switch_speed.Location = new System.Drawing.Point(1040, 43);
            this.pictureBox_ind_switch_speed.Name = "pictureBox_ind_switch_speed";
            this.pictureBox_ind_switch_speed.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_ind_switch_speed.TabIndex = 34;
            this.pictureBox_ind_switch_speed.TabStop = false;
            // 
            // label_info_ind_min_hydraulic_oil
            // 
            this.label_info_ind_min_hydraulic_oil.AutoSize = true;
            this.label_info_ind_min_hydraulic_oil.Location = new System.Drawing.Point(922, 71);
            this.label_info_ind_min_hydraulic_oil.Name = "label_info_ind_min_hydraulic_oil";
            this.label_info_ind_min_hydraulic_oil.Size = new System.Drawing.Size(82, 13);
            this.label_info_ind_min_hydraulic_oil.TabIndex = 33;
            this.label_info_ind_min_hydraulic_oil.Text = "Min hydraulic oil";
            // 
            // pictureBox_ind_min_hydraulic_oil
            // 
            this.pictureBox_ind_min_hydraulic_oil.Location = new System.Drawing.Point(953, 87);
            this.pictureBox_ind_min_hydraulic_oil.Name = "pictureBox_ind_min_hydraulic_oil";
            this.pictureBox_ind_min_hydraulic_oil.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_ind_min_hydraulic_oil.TabIndex = 32;
            this.pictureBox_ind_min_hydraulic_oil.TabStop = false;
            // 
            // label_info_ind_min_fuel
            // 
            this.label_info_ind_min_fuel.AutoSize = true;
            this.label_info_ind_min_fuel.Location = new System.Drawing.Point(943, 27);
            this.label_info_ind_min_fuel.Name = "label_info_ind_min_fuel";
            this.label_info_ind_min_fuel.Size = new System.Drawing.Size(44, 13);
            this.label_info_ind_min_fuel.TabIndex = 31;
            this.label_info_ind_min_fuel.Text = "Min fuel";
            // 
            // pictureBox_ind_min_fuel
            // 
            this.pictureBox_ind_min_fuel.Location = new System.Drawing.Point(953, 43);
            this.pictureBox_ind_min_fuel.Name = "pictureBox_ind_min_fuel";
            this.pictureBox_ind_min_fuel.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_ind_min_fuel.TabIndex = 30;
            this.pictureBox_ind_min_fuel.TabStop = false;
            // 
            // label_info_status_horn
            // 
            this.label_info_status_horn.AutoSize = true;
            this.label_info_status_horn.Location = new System.Drawing.Point(710, 71);
            this.label_info_status_horn.Name = "label_info_status_horn";
            this.label_info_status_horn.Size = new System.Drawing.Size(30, 13);
            this.label_info_status_horn.TabIndex = 29;
            this.label_info_status_horn.Text = "Horn";
            // 
            // pictureBox_status_horn
            // 
            this.pictureBox_status_horn.Location = new System.Drawing.Point(713, 87);
            this.pictureBox_status_horn.Name = "pictureBox_status_horn";
            this.pictureBox_status_horn.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_horn.TabIndex = 28;
            this.pictureBox_status_horn.TabStop = false;
            // 
            // label_info_status_wipers
            // 
            this.label_info_status_wipers.AutoSize = true;
            this.label_info_status_wipers.Location = new System.Drawing.Point(641, 71);
            this.label_info_status_wipers.Name = "label_info_status_wipers";
            this.label_info_status_wipers.Size = new System.Drawing.Size(40, 13);
            this.label_info_status_wipers.TabIndex = 27;
            this.label_info_status_wipers.Text = "Wipers";
            // 
            // pictureBox_status_wipers
            // 
            this.pictureBox_status_wipers.Location = new System.Drawing.Point(646, 87);
            this.pictureBox_status_wipers.Name = "pictureBox_status_wipers";
            this.pictureBox_status_wipers.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_wipers.TabIndex = 26;
            this.pictureBox_status_wipers.TabStop = false;
            // 
            // label_info_status_rear_light
            // 
            this.label_info_status_rear_light.AutoSize = true;
            this.label_info_status_rear_light.Location = new System.Drawing.Point(700, 27);
            this.label_info_status_rear_light.Name = "label_info_status_rear_light";
            this.label_info_status_rear_light.Size = new System.Drawing.Size(52, 13);
            this.label_info_status_rear_light.TabIndex = 25;
            this.label_info_status_rear_light.Text = "Rear light";
            // 
            // pictureBox_status_rear_light
            // 
            this.pictureBox_status_rear_light.Location = new System.Drawing.Point(713, 43);
            this.pictureBox_status_rear_light.Name = "pictureBox_status_rear_light";
            this.pictureBox_status_rear_light.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_rear_light.TabIndex = 24;
            this.pictureBox_status_rear_light.TabStop = false;
            // 
            // label_info_status_right_turn_signal
            // 
            this.label_info_status_right_turn_signal.AutoSize = true;
            this.label_info_status_right_turn_signal.Location = new System.Drawing.Point(527, 71);
            this.label_info_status_right_turn_signal.Name = "label_info_status_right_turn_signal";
            this.label_info_status_right_turn_signal.Size = new System.Drawing.Size(83, 13);
            this.label_info_status_right_turn_signal.TabIndex = 23;
            this.label_info_status_right_turn_signal.Text = "Right turn signal";
            // 
            // pictureBox_status_right_turn_signal
            // 
            this.pictureBox_status_right_turn_signal.Location = new System.Drawing.Point(554, 87);
            this.pictureBox_status_right_turn_signal.Name = "pictureBox_status_right_turn_signal";
            this.pictureBox_status_right_turn_signal.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_right_turn_signal.TabIndex = 22;
            this.pictureBox_status_right_turn_signal.TabStop = false;
            // 
            // label_info_status_head_light
            // 
            this.label_info_status_head_light.AutoSize = true;
            this.label_info_status_head_light.Location = new System.Drawing.Point(633, 27);
            this.label_info_status_head_light.Name = "label_info_status_head_light";
            this.label_info_status_head_light.Size = new System.Drawing.Size(55, 13);
            this.label_info_status_head_light.TabIndex = 21;
            this.label_info_status_head_light.Text = "Head light";
            // 
            // pictureBox_status_head_light
            // 
            this.pictureBox_status_head_light.Location = new System.Drawing.Point(646, 43);
            this.pictureBox_status_head_light.Name = "pictureBox_status_head_light";
            this.pictureBox_status_head_light.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_head_light.TabIndex = 20;
            this.pictureBox_status_head_light.TabStop = false;
            // 
            // label_info_status_left_turn_signal
            // 
            this.label_info_status_left_turn_signal.AutoSize = true;
            this.label_info_status_left_turn_signal.Location = new System.Drawing.Point(445, 71);
            this.label_info_status_left_turn_signal.Name = "label_info_status_left_turn_signal";
            this.label_info_status_left_turn_signal.Size = new System.Drawing.Size(76, 13);
            this.label_info_status_left_turn_signal.TabIndex = 19;
            this.label_info_status_left_turn_signal.Text = "Left turn signal";
            // 
            // pictureBox_status_left_turn_signal
            // 
            this.pictureBox_status_left_turn_signal.Location = new System.Drawing.Point(464, 87);
            this.pictureBox_status_left_turn_signal.Name = "pictureBox_status_left_turn_signal";
            this.pictureBox_status_left_turn_signal.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_left_turn_signal.TabIndex = 18;
            this.pictureBox_status_left_turn_signal.TabStop = false;
            // 
            // label_info_status_hazard_light
            // 
            this.label_info_status_hazard_light.AutoSize = true;
            this.label_info_status_hazard_light.Location = new System.Drawing.Point(494, 27);
            this.label_info_status_hazard_light.Name = "label_info_status_hazard_light";
            this.label_info_status_hazard_light.Size = new System.Drawing.Size(63, 13);
            this.label_info_status_hazard_light.TabIndex = 17;
            this.label_info_status_hazard_light.Text = "Hazard light";
            // 
            // pictureBox_status_hazard_light
            // 
            this.pictureBox_status_hazard_light.Location = new System.Drawing.Point(513, 43);
            this.pictureBox_status_hazard_light.Name = "pictureBox_status_hazard_light";
            this.pictureBox_status_hazard_light.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_hazard_light.TabIndex = 16;
            this.pictureBox_status_hazard_light.TabStop = false;
            // 
            // label_info_status_brake_parking
            // 
            this.label_info_status_brake_parking.AutoSize = true;
            this.label_info_status_brake_parking.Location = new System.Drawing.Point(366, 71);
            this.label_info_status_brake_parking.Name = "label_info_status_brake_parking";
            this.label_info_status_brake_parking.Size = new System.Drawing.Size(73, 13);
            this.label_info_status_brake_parking.TabIndex = 15;
            this.label_info_status_brake_parking.Text = "Brake parking";
            // 
            // pictureBox_status_brake_parking
            // 
            this.pictureBox_status_brake_parking.Location = new System.Drawing.Point(385, 87);
            this.pictureBox_status_brake_parking.Name = "pictureBox_status_brake_parking";
            this.pictureBox_status_brake_parking.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_brake_parking.TabIndex = 14;
            this.pictureBox_status_brake_parking.TabStop = false;
            // 
            // label_info_status_brake
            // 
            this.label_info_status_brake.AutoSize = true;
            this.label_info_status_brake.Location = new System.Drawing.Point(327, 71);
            this.label_info_status_brake.Name = "label_info_status_brake";
            this.label_info_status_brake.Size = new System.Drawing.Size(35, 13);
            this.label_info_status_brake.TabIndex = 13;
            this.label_info_status_brake.Text = "Brake";
            // 
            // pictureBox_status_brake
            // 
            this.pictureBox_status_brake.Location = new System.Drawing.Point(331, 87);
            this.pictureBox_status_brake.Name = "pictureBox_status_brake";
            this.pictureBox_status_brake.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_brake.TabIndex = 12;
            this.pictureBox_status_brake.TabStop = false;
            // 
            // label_info_status_engine
            // 
            this.label_info_status_engine.AutoSize = true;
            this.label_info_status_engine.Location = new System.Drawing.Point(377, 27);
            this.label_info_status_engine.Name = "label_info_status_engine";
            this.label_info_status_engine.Size = new System.Drawing.Size(40, 13);
            this.label_info_status_engine.TabIndex = 11;
            this.label_info_status_engine.Text = "Engine";
            // 
            // pictureBox_status_engine
            // 
            this.pictureBox_status_engine.Location = new System.Drawing.Point(385, 43);
            this.pictureBox_status_engine.Name = "pictureBox_status_engine";
            this.pictureBox_status_engine.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_engine.TabIndex = 10;
            this.pictureBox_status_engine.TabStop = false;
            // 
            // label_info_status_ignition
            // 
            this.label_info_status_ignition.AutoSize = true;
            this.label_info_status_ignition.Location = new System.Drawing.Point(325, 27);
            this.label_info_status_ignition.Name = "label_info_status_ignition";
            this.label_info_status_ignition.Size = new System.Drawing.Size(41, 13);
            this.label_info_status_ignition.TabIndex = 9;
            this.label_info_status_ignition.Text = "Ignition";
            // 
            // pictureBox_status_ignition
            // 
            this.pictureBox_status_ignition.Location = new System.Drawing.Point(331, 43);
            this.pictureBox_status_ignition.Name = "pictureBox_status_ignition";
            this.pictureBox_status_ignition.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_ignition.TabIndex = 8;
            this.pictureBox_status_ignition.TabStop = false;
            // 
            // label_info_status_ecu_is_connected
            // 
            this.label_info_status_ecu_is_connected.AutoSize = true;
            this.label_info_status_ecu_is_connected.Location = new System.Drawing.Point(97, 71);
            this.label_info_status_ecu_is_connected.Name = "label_info_status_ecu_is_connected";
            this.label_info_status_ecu_is_connected.Size = new System.Drawing.Size(85, 13);
            this.label_info_status_ecu_is_connected.TabIndex = 7;
            this.label_info_status_ecu_is_connected.Text = "ECU connection";
            // 
            // pictureBox_status_ecu_is_connected
            // 
            this.pictureBox_status_ecu_is_connected.Location = new System.Drawing.Point(122, 87);
            this.pictureBox_status_ecu_is_connected.Name = "pictureBox_status_ecu_is_connected";
            this.pictureBox_status_ecu_is_connected.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_ecu_is_connected.TabIndex = 6;
            this.pictureBox_status_ecu_is_connected.TabStop = false;
            // 
            // label_info_status_nrf_is_connected
            // 
            this.label_info_status_nrf_is_connected.AutoSize = true;
            this.label_info_status_nrf_is_connected.Location = new System.Drawing.Point(97, 27);
            this.label_info_status_nrf_is_connected.Name = "label_info_status_nrf_is_connected";
            this.label_info_status_nrf_is_connected.Size = new System.Drawing.Size(85, 13);
            this.label_info_status_nrf_is_connected.TabIndex = 5;
            this.label_info_status_nrf_is_connected.Text = "NRF connection";
            // 
            // pictureBox_status_nrf_is_connected
            // 
            this.pictureBox_status_nrf_is_connected.Location = new System.Drawing.Point(122, 43);
            this.pictureBox_status_nrf_is_connected.Name = "pictureBox_status_nrf_is_connected";
            this.pictureBox_status_nrf_is_connected.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_nrf_is_connected.TabIndex = 4;
            this.pictureBox_status_nrf_is_connected.TabStop = false;
            // 
            // label_info_status_tcp_is_connected
            // 
            this.label_info_status_tcp_is_connected.AutoSize = true;
            this.label_info_status_tcp_is_connected.Location = new System.Drawing.Point(6, 71);
            this.label_info_status_tcp_is_connected.Name = "label_info_status_tcp_is_connected";
            this.label_info_status_tcp_is_connected.Size = new System.Drawing.Size(84, 13);
            this.label_info_status_tcp_is_connected.TabIndex = 3;
            this.label_info_status_tcp_is_connected.Text = "TCP connection";
            // 
            // pictureBox_status_tcp_is_connected
            // 
            this.pictureBox_status_tcp_is_connected.Location = new System.Drawing.Point(31, 87);
            this.pictureBox_status_tcp_is_connected.Name = "pictureBox_status_tcp_is_connected";
            this.pictureBox_status_tcp_is_connected.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_tcp_is_connected.TabIndex = 2;
            this.pictureBox_status_tcp_is_connected.TabStop = false;
            // 
            // label_info_status_loader_is_locked
            // 
            this.label_info_status_loader_is_locked.AutoSize = true;
            this.label_info_status_loader_is_locked.Location = new System.Drawing.Point(6, 27);
            this.label_info_status_loader_is_locked.Name = "label_info_status_loader_is_locked";
            this.label_info_status_loader_is_locked.Size = new System.Drawing.Size(85, 13);
            this.label_info_status_loader_is_locked.TabIndex = 1;
            this.label_info_status_loader_is_locked.Text = "Loader is locked";
            // 
            // pictureBox_status_loader_is_locked
            // 
            this.pictureBox_status_loader_is_locked.Location = new System.Drawing.Point(31, 43);
            this.pictureBox_status_loader_is_locked.Name = "pictureBox_status_loader_is_locked";
            this.pictureBox_status_loader_is_locked.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_status_loader_is_locked.TabIndex = 0;
            this.pictureBox_status_loader_is_locked.TabStop = false;
            // 
            // label_info_tcp_info
            // 
            this.label_info_tcp_info.AutoSize = true;
            this.label_info_tcp_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_info_tcp_info.ForeColor = System.Drawing.Color.Blue;
            this.label_info_tcp_info.Location = new System.Drawing.Point(3, 94);
            this.label_info_tcp_info.Name = "label_info_tcp_info";
            this.label_info_tcp_info.Size = new System.Drawing.Size(62, 17);
            this.label_info_tcp_info.TabIndex = 38;
            this.label_info_tcp_info.Text = "Info TCP";
            // 
            // checkBox_cmd_beacon_light
            // 
            this.checkBox_cmd_beacon_light.AutoSize = true;
            this.checkBox_cmd_beacon_light.Location = new System.Drawing.Point(6, 422);
            this.checkBox_cmd_beacon_light.Name = "checkBox_cmd_beacon_light";
            this.checkBox_cmd_beacon_light.Size = new System.Drawing.Size(99, 17);
            this.checkBox_cmd_beacon_light.TabIndex = 42;
            this.checkBox_cmd_beacon_light.Text = "Маяк мигалка";
            this.checkBox_cmd_beacon_light.UseVisualStyleBackColor = true;
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 731);
            this.Controls.Add(this.groupBox_hid_joystik);
            this.Controls.Add(this.groupBox_connection_reserve);
            this.Controls.Add(this.groupBox_connection_tcp);
            this.Controls.Add(this.panel_dashboard);
            this.Name = "form_main";
            this.Text = "Program";
            this.groupBox_connection_tcp.ResumeLayout(false);
            this.groupBox_connection_tcp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_packet_tcp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_transmit_packet_tcp)).EndInit();
            this.groupBox_connection_reserve.ResumeLayout(false);
            this.groupBox_connection_reserve.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_interval_req_packet_com_port)).EndInit();
            this.groupBox_hid_joystik.ResumeLayout(false);
            this.groupBox_hid_joystik.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_joystick_position_right)).EndInit();
            this.panel_dashboard.ResumeLayout(false);
            this.groupBox_telemetry_and_visualization.ResumeLayout(false);
            this.groupBox_telemetry_and_visualization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hydraulic_oil_temp_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_fuel_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_rpm_meter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cooltant_temp_level)).EndInit();
            this.groupBox_loader_commands.ResumeLayout(false);
            this.groupBox_loader_commands.PerformLayout();
            this.groupBox_loader_status_and_indicators.ResumeLayout(false);
            this.groupBox_loader_status_and_indicators.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_heating_engine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_rear_cover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_switch_speed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_min_hydraulic_oil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ind_min_fuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_horn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_wipers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_rear_light)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_right_turn_signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_head_light)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_left_turn_signal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_hazard_light)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_brake_parking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_brake)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_engine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_ignition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_ecu_is_connected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_nrf_is_connected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_tcp_is_connected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_status_loader_is_locked)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox_com_port_port_names;
        private System.Windows.Forms.GroupBox groupBox_hid_joystik;
        private System.Windows.Forms.Label label_info_state_joystick_left;
        private System.Windows.Forms.Label label_info_state_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_left;
        private System.Windows.Forms.Button button_joysticks_calibration;
        private System.Windows.Forms.Label label_info_state_joysticks_calibration;
        private System.Windows.Forms.PictureBox pictureBox_state_joysticks_calibration;
        private System.Windows.Forms.Button button_joysticks_calibration_reset;
        private System.Windows.Forms.Panel panel_dashboard;
        private System.Windows.Forms.PictureBox pictureBox_joystick_position_left;
        private System.Windows.Forms.PictureBox pictureBox_joystick_position_right;
        private System.Windows.Forms.PictureBox pictureBox_fuel_level;
        private System.Windows.Forms.PictureBox pictureBox_cooltant_temp_level;
        private System.Windows.Forms.PictureBox pictureBox_rpm_meter;
        private System.Windows.Forms.PictureBox pictureBox_hydraulic_oil_temp_level;
        private System.Windows.Forms.Label label_info_interval_transmit_packet_tcp;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_transmit_packet_tcp;
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
        private System.Windows.Forms.Label label_info_interval_req_packet_tcp;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_req_packet_tcp;
        private System.Windows.Forms.CheckBox checkBox_perm_transmit_joystick_values;
        private System.Windows.Forms.Label label_info_interval_req_packet_com_port;
        private System.Windows.Forms.NumericUpDown numericUpDown_interval_req_packet_com_port;
        private System.Windows.Forms.ComboBox comboBox_com_port_baudrate;
        private System.Windows.Forms.GroupBox groupBox_loader_commands;
        private System.Windows.Forms.GroupBox groupBox_loader_status_and_indicators;
        private System.Windows.Forms.GroupBox groupBox_telemetry_and_visualization;
        private System.Windows.Forms.Label label_info_com_port_uuid_dev;
        private System.Windows.Forms.TextBox textBox_com_port_uuid_dev;
        private System.Windows.Forms.Label label_info_status_ecu_is_connected;
        private System.Windows.Forms.PictureBox pictureBox_status_ecu_is_connected;
        private System.Windows.Forms.Label label_info_status_nrf_is_connected;
        private System.Windows.Forms.PictureBox pictureBox_status_nrf_is_connected;
        private System.Windows.Forms.Label label_info_status_tcp_is_connected;
        private System.Windows.Forms.PictureBox pictureBox_status_tcp_is_connected;
        private System.Windows.Forms.Label label_info_status_loader_is_locked;
        private System.Windows.Forms.PictureBox pictureBox_status_loader_is_locked;
        private System.Windows.Forms.Label label_info_status_horn;
        private System.Windows.Forms.PictureBox pictureBox_status_horn;
        private System.Windows.Forms.Label label_info_status_wipers;
        private System.Windows.Forms.PictureBox pictureBox_status_wipers;
        private System.Windows.Forms.Label label_info_status_rear_light;
        private System.Windows.Forms.PictureBox pictureBox_status_rear_light;
        private System.Windows.Forms.Label label_info_status_right_turn_signal;
        private System.Windows.Forms.PictureBox pictureBox_status_right_turn_signal;
        private System.Windows.Forms.Label label_info_status_head_light;
        private System.Windows.Forms.PictureBox pictureBox_status_head_light;
        private System.Windows.Forms.Label label_info_status_left_turn_signal;
        private System.Windows.Forms.PictureBox pictureBox_status_left_turn_signal;
        private System.Windows.Forms.Label label_info_status_hazard_light;
        private System.Windows.Forms.PictureBox pictureBox_status_hazard_light;
        private System.Windows.Forms.Label label_info_status_brake_parking;
        private System.Windows.Forms.PictureBox pictureBox_status_brake_parking;
        private System.Windows.Forms.Label label_info_status_brake;
        private System.Windows.Forms.PictureBox pictureBox_status_brake;
        private System.Windows.Forms.Label label_info_status_engine;
        private System.Windows.Forms.PictureBox pictureBox_status_engine;
        private System.Windows.Forms.Label label_info_status_ignition;
        private System.Windows.Forms.PictureBox pictureBox_status_ignition;
        private System.Windows.Forms.Label label_info_ind_min_fuel;
        private System.Windows.Forms.PictureBox pictureBox_ind_min_fuel;
        private System.Windows.Forms.Label label_info_ind_heating_engine;
        private System.Windows.Forms.PictureBox pictureBox_ind_heating_engine;
        private System.Windows.Forms.Label label_info_ind_rear_cover;
        private System.Windows.Forms.PictureBox pictureBox_ind_rear_cover;
        private System.Windows.Forms.Label label_info_ind_switch_speed;
        private System.Windows.Forms.PictureBox pictureBox_ind_switch_speed;
        private System.Windows.Forms.Label label_info_ind_min_hydraulic_oil;
        private System.Windows.Forms.PictureBox pictureBox_ind_min_hydraulic_oil;
        private System.Windows.Forms.Label label_info_rpm_meter;
        private System.Windows.Forms.Label label_info_hydraulic_oil_temp_level;
        private System.Windows.Forms.Label label_info_cooltant_temp_level;
        private System.Windows.Forms.Label label_info_fuel_level;
        private System.Windows.Forms.Button button_cmd_locked;
        private System.Windows.Forms.Button button_cmd_unlocked;
        private System.Windows.Forms.Button button_cmd_switch_speed;
        private System.Windows.Forms.Label label_info_tcp_info;
        private System.Windows.Forms.CheckBox checkBox_cmd_beacon_light;
    }
}

