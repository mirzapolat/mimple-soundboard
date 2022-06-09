namespace Soundboard
{
    partial class ListElement
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.QuickInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tb_Shortcut = new System.Windows.Forms.TextBox();
            this.progb_audio = new System.Windows.Forms.ProgressBar();
            this.pb_delete = new System.Windows.Forms.PictureBox();
            this.pb_play = new System.Windows.Forms.PictureBox();
            this.tmr_ProgressTracker = new System.Windows.Forms.Timer(this.components);
            this.lb_name = new System.Windows.Forms.Label();
            this.lb_DeleteShortcut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_play)).BeginInit();
            this.SuspendLayout();
            // 
            // QuickInfo
            // 
            this.QuickInfo.AutoPopDelay = 5000;
            this.QuickInfo.InitialDelay = 200;
            this.QuickInfo.ReshowDelay = 100;
            // 
            // tb_Shortcut
            // 
            this.tb_Shortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Shortcut.BackColor = System.Drawing.Color.White;
            this.tb_Shortcut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Shortcut.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Shortcut.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tb_Shortcut.Location = new System.Drawing.Point(597, 25);
            this.tb_Shortcut.Name = "tb_Shortcut";
            this.tb_Shortcut.ReadOnly = true;
            this.tb_Shortcut.Size = new System.Drawing.Size(174, 27);
            this.tb_Shortcut.TabIndex = 4;
            this.tb_Shortcut.TabStop = false;
            this.tb_Shortcut.Text = "Taste wählen";
            this.tb_Shortcut.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QuickInfo.SetToolTip(this.tb_Shortcut, "Taste zum automatischen abspielen wählen");
            this.tb_Shortcut.Click += new System.EventHandler(this.tb_Shortcut_Click);
            // 
            // progb_audio
            // 
            this.progb_audio.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progb_audio.Location = new System.Drawing.Point(0, 68);
            this.progb_audio.Name = "progb_audio";
            this.progb_audio.Size = new System.Drawing.Size(794, 5);
            this.progb_audio.TabIndex = 5;
            this.QuickInfo.SetToolTip(this.progb_audio, "Dauer der Audiodatei");
            this.progb_audio.Visible = false;
            // 
            // pb_delete
            // 
            this.pb_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_delete.Image = global::Soundboard.Properties.Resources.bin;
            this.pb_delete.Location = new System.Drawing.Point(504, 16);
            this.pb_delete.Name = "pb_delete";
            this.pb_delete.Size = new System.Drawing.Size(40, 40);
            this.pb_delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_delete.TabIndex = 2;
            this.pb_delete.TabStop = false;
            this.QuickInfo.SetToolTip(this.pb_delete, "Sound löschen");
            this.pb_delete.MouseEnter += new System.EventHandler(this.pb_delete_MouseEnter);
            this.pb_delete.MouseLeave += new System.EventHandler(this.pb_delete_MouseLeave);
            // 
            // pb_play
            // 
            this.pb_play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_play.Image = global::Soundboard.Properties.Resources.play_button;
            this.pb_play.Location = new System.Drawing.Point(435, 14);
            this.pb_play.Name = "pb_play";
            this.pb_play.Size = new System.Drawing.Size(48, 44);
            this.pb_play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_play.TabIndex = 1;
            this.pb_play.TabStop = false;
            this.QuickInfo.SetToolTip(this.pb_play, "Sound abspielen");
            this.pb_play.MouseEnter += new System.EventHandler(this.pb_play_MouseEnter);
            this.pb_play.MouseLeave += new System.EventHandler(this.pb_play_MouseLeave);
            // 
            // tmr_ProgressTracker
            // 
            this.tmr_ProgressTracker.Interval = 1000;
            this.tmr_ProgressTracker.Tick += new System.EventHandler(this.tmr_ProgressTracker_Tick);
            // 
            // lb_name
            // 
            this.lb_name.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_name.Font = new System.Drawing.Font("Righteous", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(0, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.lb_name.Size = new System.Drawing.Size(357, 68);
            this.lb_name.TabIndex = 6;
            this.lb_name.Text = "Name des tollen Sounds";
            this.lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_DeleteShortcut
            // 
            this.lb_DeleteShortcut.AutoSize = true;
            this.lb_DeleteShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_DeleteShortcut.Font = new System.Drawing.Font("Righteous", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_DeleteShortcut.ForeColor = System.Drawing.Color.Maroon;
            this.lb_DeleteShortcut.Location = new System.Drawing.Point(571, 28);
            this.lb_DeleteShortcut.Name = "lb_DeleteShortcut";
            this.lb_DeleteShortcut.Size = new System.Drawing.Size(20, 21);
            this.lb_DeleteShortcut.TabIndex = 7;
            this.lb_DeleteShortcut.Text = "X";
            this.QuickInfo.SetToolTip(this.lb_DeleteShortcut, "Hotkey löschen");
            this.lb_DeleteShortcut.Visible = false;
            this.lb_DeleteShortcut.Click += new System.EventHandler(this.lb_DeleteShortcut_Click);
            // 
            // ListElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_DeleteShortcut);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.progb_audio);
            this.Controls.Add(this.tb_Shortcut);
            this.Controls.Add(this.pb_delete);
            this.Controls.Add(this.pb_play);
            this.Name = "ListElement";
            this.Size = new System.Drawing.Size(794, 73);
            ((System.ComponentModel.ISupportInitialize)(this.pb_delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_play)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip QuickInfo;
        private System.Windows.Forms.Timer tmr_ProgressTracker;
        public System.Windows.Forms.PictureBox pb_play;
        public System.Windows.Forms.PictureBox pb_delete;
        public System.Windows.Forms.TextBox tb_Shortcut;
        public System.Windows.Forms.ProgressBar progb_audio;
        public System.Windows.Forms.Label lb_name;
        public System.Windows.Forms.Label lb_DeleteShortcut;
    }
}
