namespace Proyecto_MAD
{
    partial class GestionUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionUsuarios));
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.GrdUusuarios = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbEstado = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNomina = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelCasa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCelular = new System.Windows.Forms.TextBox();
            this.datFechNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbUsuarioId = new System.Windows.Forms.Label();
            this.lbEst = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNewPassword = new System.Windows.Forms.Button();
            this.btnHabilitar = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ShowPassword = new System.Windows.Forms.Button();
            this.lbErrorNombre = new System.Windows.Forms.Label();
            this.lbErrorApellidos = new System.Windows.Forms.Label();
            this.lbErrorCorreo = new System.Windows.Forms.Label();
            this.lbErrorPassword = new System.Windows.Forms.Label();
            this.lbErrorNomina = new System.Windows.Forms.Label();
            this.lbErrorTelef1 = new System.Windows.Forms.Label();
            this.lbErrorTelef2 = new System.Windows.Forms.Label();
            this.lbErrorFechaNac = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GrdUusuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuarios:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Gainsboro;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(1249, 740);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "Regresar";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GrdUusuarios
            // 
            this.GrdUusuarios.AllowUserToAddRows = false;
            this.GrdUusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GrdUusuarios.Location = new System.Drawing.Point(31, 335);
            this.GrdUusuarios.MultiSelect = false;
            this.GrdUusuarios.Name = "GrdUusuarios";
            this.GrdUusuarios.ReadOnly = true;
            this.GrdUusuarios.RowHeadersWidth = 51;
            this.GrdUusuarios.RowTemplate.Height = 24;
            this.GrdUusuarios.Size = new System.Drawing.Size(1332, 384);
            this.GrdUusuarios.StandardTab = true;
            this.GrdUusuarios.TabIndex = 14;
            this.GrdUusuarios.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 18);
            this.label6.TabIndex = 28;
            this.label6.Text = "*Correo electrónico: ";
            // 
            // txtCorreo
            // 
            this.txtCorreo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCorreo.Location = new System.Drawing.Point(174, 54);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(273, 22);
            this.txtCorreo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "*Contraseña: ";
            // 
            // txtPassword
            // 
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Location = new System.Drawing.Point(127, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(251, 22);
            this.txtPassword.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "*Nombre: ";
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNombre.Location = new System.Drawing.Point(104, 142);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 22);
            this.txtNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "*Apellidos: ";
            // 
            // lbEstado
            // 
            this.lbEstado.AutoSize = true;
            this.lbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstado.Location = new System.Drawing.Point(795, 244);
            this.lbEstado.Name = "lbEstado";
            this.lbEstado.Size = new System.Drawing.Size(131, 18);
            this.lbEstado.TabIndex = 50;
            this.lbEstado.Text = "Estado del usuario";
            this.lbEstado.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(730, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 18);
            this.label10.TabIndex = 38;
            this.label10.Text = "*Número de nómina: ";
            // 
            // txtNomina
            // 
            this.txtNomina.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNomina.Location = new System.Drawing.Point(885, 47);
            this.txtNomina.Name = "txtNomina";
            this.txtNomina.Size = new System.Drawing.Size(253, 22);
            this.txtNomina.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(730, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 18);
            this.label9.TabIndex = 40;
            this.label9.Text = "Teléfono de Casa: ";
            // 
            // txtTelCasa
            // 
            this.txtTelCasa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTelCasa.Location = new System.Drawing.Point(869, 94);
            this.txtTelCasa.Name = "txtTelCasa";
            this.txtTelCasa.Size = new System.Drawing.Size(233, 22);
            this.txtTelCasa.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(730, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 42;
            this.label7.Text = "*Celular: ";
            // 
            // txtCelular
            // 
            this.txtCelular.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCelular.Location = new System.Drawing.Point(804, 141);
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(216, 22);
            this.txtCelular.TabIndex = 9;
            // 
            // datFechNacimiento
            // 
            this.datFechNacimiento.Location = new System.Drawing.Point(906, 193);
            this.datFechNacimiento.Name = "datFechNacimiento";
            this.datFechNacimiento.Size = new System.Drawing.Size(267, 22);
            this.datFechNacimiento.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(730, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 18);
            this.label8.TabIndex = 45;
            this.label8.Text = "*Fecha de Nacimiento: ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 18);
            this.label11.TabIndex = 47;
            this.label11.Text = "UsuarioID: ";
            // 
            // lbUsuarioId
            // 
            this.lbUsuarioId.AutoSize = true;
            this.lbUsuarioId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuarioId.Location = new System.Drawing.Point(116, 9);
            this.lbUsuarioId.Name = "lbUsuarioId";
            this.lbUsuarioId.Size = new System.Drawing.Size(106, 18);
            this.lbUsuarioId.TabIndex = 48;
            this.lbUsuarioId.Text = "ID del susuario";
            // 
            // lbEst
            // 
            this.lbEst.AutoSize = true;
            this.lbEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEst.Location = new System.Drawing.Point(730, 244);
            this.lbEst.Name = "lbEst";
            this.lbEst.Size = new System.Drawing.Size(63, 18);
            this.lbEst.TabIndex = 49;
            this.lbEst.Text = "Estado: ";
            this.lbEst.Visible = false;
            // 
            // txtApellidos
            // 
            this.txtApellidos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtApellidos.Location = new System.Drawing.Point(109, 189);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(216, 22);
            this.txtApellidos.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(160, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(175, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancelar Seleccion";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNewPassword
            // 
            this.btnNewPassword.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPassword.Location = new System.Drawing.Point(384, 95);
            this.btnNewPassword.Name = "btnNewPassword";
            this.btnNewPassword.Size = new System.Drawing.Size(157, 23);
            this.btnNewPassword.TabIndex = 4;
            this.btnNewPassword.Text = "Cambiar Contraseña";
            this.btnNewPassword.UseVisualStyleBackColor = false;
            this.btnNewPassword.Visible = false;
            this.btnNewPassword.Click += new System.EventHandler(this.btnNewPassword_Click);
            // 
            // btnHabilitar
            // 
            this.btnHabilitar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHabilitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitar.Location = new System.Drawing.Point(733, 275);
            this.btnHabilitar.Name = "btnHabilitar";
            this.btnHabilitar.Size = new System.Drawing.Size(108, 29);
            this.btnHabilitar.TabIndex = 13;
            this.btnHabilitar.Text = "Estado";
            this.btnHabilitar.UseVisualStyleBackColor = false;
            this.btnHabilitar.Visible = false;
            this.btnHabilitar.Click += new System.EventHandler(this.btnHabilitar_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(31, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ShowPassword
            // 
            this.ShowPassword.BackColor = System.Drawing.Color.White;
            this.ShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShowPassword.Image = ((System.Drawing.Image)(resources.GetObject("ShowPassword.Image")));
            this.ShowPassword.Location = new System.Drawing.Point(348, 95);
            this.ShowPassword.Name = "ShowPassword";
            this.ShowPassword.Size = new System.Drawing.Size(30, 22);
            this.ShowPassword.TabIndex = 3;
            this.ShowPassword.UseVisualStyleBackColor = false;
            this.ShowPassword.Visible = false;
            this.ShowPassword.Click += new System.EventHandler(this.ShowPassword_Click);
            // 
            // lbErrorNombre
            // 
            this.lbErrorNombre.AutoSize = true;
            this.lbErrorNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNombre.Location = new System.Drawing.Point(43, 164);
            this.lbErrorNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorNombre.Name = "lbErrorNombre";
            this.lbErrorNombre.Size = new System.Drawing.Size(292, 16);
            this.lbErrorNombre.TabIndex = 60;
            this.lbErrorNombre.Text = "El nombre solo debe contener letras y espacios";
            this.lbErrorNombre.Visible = false;
            // 
            // lbErrorApellidos
            // 
            this.lbErrorApellidos.AutoSize = true;
            this.lbErrorApellidos.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorApellidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorApellidos.ForeColor = System.Drawing.Color.Red;
            this.lbErrorApellidos.Location = new System.Drawing.Point(43, 214);
            this.lbErrorApellidos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorApellidos.Name = "lbErrorApellidos";
            this.lbErrorApellidos.Size = new System.Drawing.Size(313, 16);
            this.lbErrorApellidos.TabIndex = 71;
            this.lbErrorApellidos.Text = "Los Apellidos solo debe contener letras y espacios";
            this.lbErrorApellidos.Visible = false;
            // 
            // lbErrorCorreo
            // 
            this.lbErrorCorreo.AutoSize = true;
            this.lbErrorCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.lbErrorCorreo.Location = new System.Drawing.Point(43, 76);
            this.lbErrorCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorCorreo.Name = "lbErrorCorreo";
            this.lbErrorCorreo.Size = new System.Drawing.Size(526, 16);
            this.lbErrorCorreo.TabIndex = 72;
            this.lbErrorCorreo.Text = "El correo debe terminar con @email.com, @gmail.com, @hotmail.com o @outlook.com";
            this.lbErrorCorreo.Visible = false;
            // 
            // lbErrorPassword
            // 
            this.lbErrorPassword.AutoSize = true;
            this.lbErrorPassword.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorPassword.ForeColor = System.Drawing.Color.Red;
            this.lbErrorPassword.Location = new System.Drawing.Point(43, 120);
            this.lbErrorPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorPassword.Name = "lbErrorPassword";
            this.lbErrorPassword.Size = new System.Drawing.Size(580, 16);
            this.lbErrorPassword.TabIndex = 73;
            this.lbErrorPassword.Text = "La contraseña debe tener:- Al menos 8 caracteres, 1 mayúscula, 1 minúscula, 1 car" +
    "ácter especial";
            this.lbErrorPassword.Visible = false;
            // 
            // lbErrorNomina
            // 
            this.lbErrorNomina.AutoSize = true;
            this.lbErrorNomina.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorNomina.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorNomina.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNomina.Location = new System.Drawing.Point(730, 71);
            this.lbErrorNomina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorNomina.Name = "lbErrorNomina";
            this.lbErrorNomina.Size = new System.Drawing.Size(381, 16);
            this.lbErrorNomina.TabIndex = 74;
            this.lbErrorNomina.Text = "La nómina debe tener 3 letras mayúsculas al inicio y 5 numeros";
            this.lbErrorNomina.Visible = false;
            // 
            // lbErrorTelef1
            // 
            this.lbErrorTelef1.AutoSize = true;
            this.lbErrorTelef1.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorTelef1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorTelef1.ForeColor = System.Drawing.Color.Red;
            this.lbErrorTelef1.Location = new System.Drawing.Point(730, 119);
            this.lbErrorTelef1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorTelef1.Name = "lbErrorTelef1";
            this.lbErrorTelef1.Size = new System.Drawing.Size(239, 16);
            this.lbErrorTelef1.TabIndex = 75;
            this.lbErrorTelef1.Text = "El teléfono debe tener mas de 6 dígitos";
            this.lbErrorTelef1.Visible = false;
            // 
            // lbErrorTelef2
            // 
            this.lbErrorTelef2.AutoSize = true;
            this.lbErrorTelef2.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorTelef2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorTelef2.ForeColor = System.Drawing.Color.Red;
            this.lbErrorTelef2.Location = new System.Drawing.Point(730, 166);
            this.lbErrorTelef2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorTelef2.Name = "lbErrorTelef2";
            this.lbErrorTelef2.Size = new System.Drawing.Size(231, 16);
            this.lbErrorTelef2.TabIndex = 76;
            this.lbErrorTelef2.Text = "El celular debe tener mas de 6 dígitos";
            this.lbErrorTelef2.Visible = false;
            // 
            // lbErrorFechaNac
            // 
            this.lbErrorFechaNac.AutoSize = true;
            this.lbErrorFechaNac.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorFechaNac.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorFechaNac.ForeColor = System.Drawing.Color.Red;
            this.lbErrorFechaNac.Location = new System.Drawing.Point(730, 218);
            this.lbErrorFechaNac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbErrorFechaNac.Name = "lbErrorFechaNac";
            this.lbErrorFechaNac.Size = new System.Drawing.Size(218, 16);
            this.lbErrorFechaNac.TabIndex = 77;
            this.lbErrorFechaNac.Text = "El usuario debe ser mayor de edad";
            this.lbErrorFechaNac.Visible = false;
            // 
            // GestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 787);
            this.Controls.Add(this.lbErrorFechaNac);
            this.Controls.Add(this.lbErrorTelef2);
            this.Controls.Add(this.lbErrorTelef1);
            this.Controls.Add(this.lbErrorNomina);
            this.Controls.Add(this.lbErrorPassword);
            this.Controls.Add(this.lbErrorCorreo);
            this.Controls.Add(this.lbErrorApellidos);
            this.Controls.Add(this.lbErrorNombre);
            this.Controls.Add(this.ShowPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNewPassword);
            this.Controls.Add(this.btnHabilitar);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbEstado);
            this.Controls.Add(this.lbEst);
            this.Controls.Add(this.lbUsuarioId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.datFechNacimiento);
            this.Controls.Add(this.txtCelular);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTelCasa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNomina);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.GrdUusuarios);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Usuarios";
            this.Load += new System.EventHandler(this.GestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GrdUusuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView GrdUusuarios;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNomina;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelCasa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCelular;
        private System.Windows.Forms.DateTimePicker datFechNacimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbUsuarioId;
        private System.Windows.Forms.Label lbEst;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNewPassword;
        private System.Windows.Forms.Button btnHabilitar;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button ShowPassword;
        private System.Windows.Forms.Label lbErrorNombre;
        private System.Windows.Forms.Label lbErrorApellidos;
        private System.Windows.Forms.Label lbErrorCorreo;
        private System.Windows.Forms.Label lbErrorPassword;
        private System.Windows.Forms.Label lbErrorNomina;
        private System.Windows.Forms.Label lbErrorTelef1;
        private System.Windows.Forms.Label lbErrorTelef2;
        private System.Windows.Forms.Label lbErrorFechaNac;
    }
}