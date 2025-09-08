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
            this.button_tcp_close = new System.Windows.Forms.Button();
            this.numericUpDown_tcp_server_port = new System.Windows.Forms.NumericUpDown();
            this.groupBox_connection_reserve = new System.Windows.Forms.GroupBox();
            this.comboBox_com_port_name = new System.Windows.Forms.ComboBox();
            this.numericUpDown_com_port_baudrate = new System.Windows.Forms.NumericUpDown();
            this.button_com_port_open = new System.Windows.Forms.Button();
            this.button_com_port_close = new System.Windows.Forms.Button();
            this.groupBox_hid_joystiks = new System.Windows.Forms.GroupBox();
            this.pictureBox_state_joystick_right = new System.Windows.Forms.PictureBox();
            this.label_info_joystick_right = new System.Windows.Forms.Label();
            this.label_info_joystick_left = new System.Windows.Forms.Label();
            this.pictureBox_state_joystick_left = new System.Windows.Forms.PictureBox();
            this.button_joysticks_calibration = new System.Windows.Forms.Button();
            this.label_info_joysticks_calibration = new System.Windows.Forms.Label();
            this.pictureBox_state_joysticks_calibration = new System.Windows.Forms.PictureBox();
            this.groupBox_connection_tcp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).BeginInit();
            this.groupBox_connection_reserve.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_com_port_baudrate)).BeginInit();
            this.groupBox_hid_joystiks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).BeginInit();
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
            // button_tcp_close
            // 
            this.button_tcp_close.Location = new System.Drawing.Point(300, 19);
            this.button_tcp_close.Name = "button_tcp_close";
            this.button_tcp_close.Size = new System.Drawing.Size(75, 23);
            this.button_tcp_close.TabIndex = 3;
            this.button_tcp_close.Text = "Закрыть";
            this.button_tcp_close.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_tcp_server_port
            // 
            this.numericUpDown_tcp_server_port.Location = new System.Drawing.Point(136, 19);
            this.numericUpDown_tcp_server_port.Name = "numericUpDown_tcp_server_port";
            this.numericUpDown_tcp_server_port.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown_tcp_server_port.TabIndex = 4;
            // 
            // groupBox_connection_reserve
            // 
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_close);
            this.groupBox_connection_reserve.Controls.Add(this.button_com_port_open);
            this.groupBox_connection_reserve.Controls.Add(this.numericUpDown_com_port_baudrate);
            this.groupBox_connection_reserve.Controls.Add(this.comboBox_com_port_name);
            this.groupBox_connection_reserve.Location = new System.Drawing.Point(412, 12);
            this.groupBox_connection_reserve.Name = "groupBox_connection_reserve";
            this.groupBox_connection_reserve.Size = new System.Drawing.Size(431, 55);
            this.groupBox_connection_reserve.TabIndex = 5;
            this.groupBox_connection_reserve.TabStop = false;
            this.groupBox_connection_reserve.Text = "Ревервный канал соединение";
            // 
            // comboBox_com_port_name
            // 
            this.comboBox_com_port_name.FormattingEnabled = true;
            this.comboBox_com_port_name.Location = new System.Drawing.Point(6, 19);
            this.comboBox_com_port_name.Name = "comboBox_com_port_name";
            this.comboBox_com_port_name.Size = new System.Drawing.Size(93, 21);
            this.comboBox_com_port_name.TabIndex = 6;
            // 
            // numericUpDown_com_port_baudrate
            // 
            this.numericUpDown_com_port_baudrate.Location = new System.Drawing.Point(105, 19);
            this.numericUpDown_com_port_baudrate.Name = "numericUpDown_com_port_baudrate";
            this.numericUpDown_com_port_baudrate.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown_com_port_baudrate.TabIndex = 6;
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
            // button_com_port_close
            // 
            this.button_com_port_close.Location = new System.Drawing.Point(291, 19);
            this.button_com_port_close.Name = "button_com_port_close";
            this.button_com_port_close.Size = new System.Drawing.Size(75, 23);
            this.button_com_port_close.TabIndex = 7;
            this.button_com_port_close.Text = "Закрыть";
            this.button_com_port_close.UseVisualStyleBackColor = true;
            // 
            // groupBox_hid_joystiks
            // 
            this.groupBox_hid_joystiks.Controls.Add(this.button_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joysticks_calibration);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joystick_left);
            this.groupBox_hid_joystiks.Controls.Add(this.label_info_joystick_right);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joystick_left);
            this.groupBox_hid_joystiks.Controls.Add(this.pictureBox_state_joystick_right);
            this.groupBox_hid_joystiks.Location = new System.Drawing.Point(849, 12);
            this.groupBox_hid_joystiks.Name = "groupBox_hid_joystiks";
            this.groupBox_hid_joystiks.Size = new System.Drawing.Size(386, 55);
            this.groupBox_hid_joystiks.TabIndex = 6;
            this.groupBox_hid_joystiks.TabStop = false;
            this.groupBox_hid_joystiks.Text = "Джостики";
            // 
            // pictureBox_state_joystick_right
            // 
            this.pictureBox_state_joystick_right.Location = new System.Drawing.Point(84, 19);
            this.pictureBox_state_joystick_right.Name = "pictureBox_state_joystick_right";
            this.pictureBox_state_joystick_right.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joystick_right.TabIndex = 7;
            this.pictureBox_state_joystick_right.TabStop = false;
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
            // label_info_joystick_left
            // 
            this.label_info_joystick_left.AutoSize = true;
            this.label_info_joystick_left.Location = new System.Drawing.Point(37, 24);
            this.label_info_joystick_left.Name = "label_info_joystick_left";
            this.label_info_joystick_left.Size = new System.Drawing.Size(41, 13);
            this.label_info_joystick_left.TabIndex = 8;
            this.label_info_joystick_left.Text = "Левый";
            // 
            // pictureBox_state_joystick_left
            // 
            this.pictureBox_state_joystick_left.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_state_joystick_left.Name = "pictureBox_state_joystick_left";
            this.pictureBox_state_joystick_left.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_state_joystick_left.TabIndex = 9;
            this.pictureBox_state_joystick_left.TabStop = false;
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
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.groupBox_hid_joystiks);
            this.Controls.Add(this.groupBox_connection_reserve);
            this.Controls.Add(this.groupBox_connection_tcp);
            this.Name = "form_main";
            this.Text = "Program";
            this.groupBox_connection_tcp.ResumeLayout(false);
            this.groupBox_connection_tcp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tcp_server_port)).EndInit();
            this.groupBox_connection_reserve.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_com_port_baudrate)).EndInit();
            this.groupBox_hid_joystiks.ResumeLayout(false);
            this.groupBox_hid_joystiks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joystick_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state_joysticks_calibration)).EndInit();
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
        private System.Windows.Forms.ComboBox comboBox_com_port_name;
        private System.Windows.Forms.GroupBox groupBox_hid_joystiks;
        private System.Windows.Forms.Label label_info_joystick_left;
        private System.Windows.Forms.Label label_info_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_right;
        private System.Windows.Forms.PictureBox pictureBox_state_joystick_left;
        private System.Windows.Forms.Button button_joysticks_calibration;
        private System.Windows.Forms.Label label_info_joysticks_calibration;
        private System.Windows.Forms.PictureBox pictureBox_state_joysticks_calibration;
    }
}

