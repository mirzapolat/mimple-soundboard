namespace Soundboard
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NoityAddSound = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifySeperator = new System.Windows.Forms.ToolStripSeparator();
            this.NotifyShowApp = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_BottomBar = new System.Windows.Forms.Panel();
            this.lb_Volume = new System.Windows.Forms.Label();
            this.trackb_Volume = new System.Windows.Forms.TrackBar();
            this.btn_Add = new System.Windows.Forms.Button();
            this.flp_List = new System.Windows.Forms.FlowLayoutPanel();
            this.tmr_AudioProgress = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lb_Starthinweis = new System.Windows.Forms.Label();
            this.checkb_HotkeysAvailable = new System.Windows.Forms.CheckBox();
            this.NotifyAppExit = new System.Windows.Forms.ToolStripMenuItem();
            this.NotifyIconMenuStrip.SuspendLayout();
            this.pnl_BottomBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackb_Volume)).BeginInit();
            this.SuspendLayout();
            // 
            // MainNotifyIcon
            // 
            this.MainNotifyIcon.ContextMenuStrip = this.NotifyIconMenuStrip;
            resources.ApplyResources(this.MainNotifyIcon, "MainNotifyIcon");
            this.MainNotifyIcon.DoubleClick += new System.EventHandler(this.notify_ShowWindow);
            // 
            // NotifyIconMenuStrip
            // 
            this.NotifyIconMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NoityAddSound,
            this.NotifySeperator,
            this.NotifyShowApp,
            this.NotifyAppExit});
            this.NotifyIconMenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.NotifyIconMenuStrip.Name = "NotifyIconMenuStrip";
            this.NotifyIconMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            resources.ApplyResources(this.NotifyIconMenuStrip, "NotifyIconMenuStrip");
            // 
            // NoityAddSound
            // 
            this.NoityAddSound.Name = "NoityAddSound";
            resources.ApplyResources(this.NoityAddSound, "NoityAddSound");
            this.NoityAddSound.Click += new System.EventHandler(this.act_AddFile);
            // 
            // NotifySeperator
            // 
            this.NotifySeperator.Name = "NotifySeperator";
            resources.ApplyResources(this.NotifySeperator, "NotifySeperator");
            // 
            // NotifyShowApp
            // 
            this.NotifyShowApp.Name = "NotifyShowApp";
            resources.ApplyResources(this.NotifyShowApp, "NotifyShowApp");
            this.NotifyShowApp.Click += new System.EventHandler(this.notify_ShowWindow);
            // 
            // pnl_BottomBar
            // 
            this.pnl_BottomBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.pnl_BottomBar.Controls.Add(this.checkb_HotkeysAvailable);
            this.pnl_BottomBar.Controls.Add(this.lb_Volume);
            this.pnl_BottomBar.Controls.Add(this.trackb_Volume);
            this.pnl_BottomBar.Controls.Add(this.btn_Add);
            resources.ApplyResources(this.pnl_BottomBar, "pnl_BottomBar");
            this.pnl_BottomBar.Name = "pnl_BottomBar";
            // 
            // lb_Volume
            // 
            resources.ApplyResources(this.lb_Volume, "lb_Volume");
            this.lb_Volume.ForeColor = System.Drawing.Color.White;
            this.lb_Volume.Name = "lb_Volume";
            // 
            // trackb_Volume
            // 
            resources.ApplyResources(this.trackb_Volume, "trackb_Volume");
            this.trackb_Volume.LargeChange = 1;
            this.trackb_Volume.Name = "trackb_Volume";
            this.trackb_Volume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackb_Volume.Value = 10;
            this.trackb_Volume.ValueChanged += new System.EventHandler(this.trackb_Volume_ValueChanged);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btn_Add, "btn_Add");
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.act_AddFile);
            // 
            // flp_List
            // 
            this.flp_List.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.flp_List, "flp_List");
            this.flp_List.Name = "flp_List";
            // 
            // tmr_AudioProgress
            // 
            this.tmr_AudioProgress.Interval = 1000;
            // 
            // lb_Starthinweis
            // 
            this.lb_Starthinweis.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.lb_Starthinweis, "lb_Starthinweis");
            this.lb_Starthinweis.Name = "lb_Starthinweis";
            // 
            // checkb_HotkeysAvailable
            // 
            resources.ApplyResources(this.checkb_HotkeysAvailable, "checkb_HotkeysAvailable");
            this.checkb_HotkeysAvailable.Checked = true;
            this.checkb_HotkeysAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkb_HotkeysAvailable.ForeColor = System.Drawing.Color.White;
            this.checkb_HotkeysAvailable.Name = "checkb_HotkeysAvailable";
            this.checkb_HotkeysAvailable.UseVisualStyleBackColor = true;
            // 
            // NotifyAppExit
            // 
            this.NotifyAppExit.Image = global::Soundboard.Properties.Resources.close;
            this.NotifyAppExit.Name = "NotifyAppExit";
            resources.ApplyResources(this.NotifyAppExit, "NotifyAppExit");
            this.NotifyAppExit.Click += new System.EventHandler(this.notify_Exit);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.Controls.Add(this.lb_Starthinweis);
            this.Controls.Add(this.flp_List);
            this.Controls.Add(this.pnl_BottomBar);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.NotifyIconMenuStrip.ResumeLayout(false);
            this.pnl_BottomBar.ResumeLayout(false);
            this.pnl_BottomBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackb_Volume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon MainNotifyIcon;
        private System.Windows.Forms.Panel pnl_BottomBar;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.FlowLayoutPanel flp_List;
        private System.Windows.Forms.Timer tmr_AudioProgress;
        private System.Windows.Forms.TrackBar trackb_Volume;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lb_Starthinweis;
        private System.Windows.Forms.Label lb_Volume;
        private System.Windows.Forms.ContextMenuStrip NotifyIconMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem NoityAddSound;
        private System.Windows.Forms.ToolStripSeparator NotifySeperator;
        private System.Windows.Forms.ToolStripMenuItem NotifyShowApp;
        private System.Windows.Forms.ToolStripMenuItem NotifyAppExit;
        private System.Windows.Forms.CheckBox checkb_HotkeysAvailable;
    }
}