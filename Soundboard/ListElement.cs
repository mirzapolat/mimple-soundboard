using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;  

namespace Soundboard
{
    public partial class ListElement : UserControl
    {
        private string shortfilename = "";
        public static bool audioplaying = false;

        private string audiopath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mimple Soundboard\Audio\";
        private string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mimple Soundboard\data.db";
        private string audiofile;

        public static WaveOutEvent outputDevice = new WaveOutEvent();
        private AudioFileReader audioFile;

        public ListElement(string name, bool grau)
        {
            InitializeComponent();

            outputDevice = new WaveOutEvent();

            if (!grau) this.BackColor = Color.White;
            else this.BackColor = SystemColors.Control;

            lb_name.Text = name;
            shortfilename = name;
            audiofile = audiopath + shortfilename;

            if (Main._HotkeyList.ContainsKey(shortfilename))
            {
                Keys myKey = Main._HotkeyList[shortfilename];

                if (KeyValues.KeyDescriptions().ContainsKey(myKey))
                    tb_Shortcut.Text = KeyValues.KeyDescriptions()[myKey];

                else tb_Shortcut.Text = myKey.ToString();

                tb_Shortcut.ForeColor = Color.Black;
                lb_DeleteShortcut.Visible = true;
            }

            this.Visible = true;
        }

        private void pb_play_MouseEnter(object sender, EventArgs e)
        {
            if (!Main._audioplaying)
                pb_play.Image = Properties.Resources.play_button_hover;
        }
        private void pb_play_MouseLeave(object sender, EventArgs e)
        {
            if (!Main._audioplaying)
                pb_play.Image = Properties.Resources.play_button;
        }
        private void pb_delete_MouseEnter(object sender, EventArgs e)
        {
            pb_delete.Image = Properties.Resources.bin_hover;
        }
        private void pb_delete_MouseLeave(object sender, EventArgs e)
        {
            pb_delete.Image = Properties.Resources.bin;
        }

        /// <summary>
        /// Plays the Sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_play_Click(object sender, EventArgs e)
        {
            if (Main._currentlyPlaying != shortfilename)
            {
                StopPlaying();
            }
                

            StartStopPlaying();
        }

        private void StartStopPlaying()
        {
            if (audioplaying) StopPlaying();

            if (!audioplaying)
            {
                Main._currentlyPlaying = Path.GetFileName(audiofile);

                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(audiofile);

                outputDevice.Init(audioFile);

                TimeSpan time = new AudioFileReader(audiofile).TotalTime;
                progb_audio.Maximum = Convert.ToInt32(time.TotalSeconds);
                progb_audio.Value = 1;
                progb_audio.Visible = true;

                outputDevice.Volume = Main._soundVolume;

                tmr_ProgressTracker.Start();
                outputDevice.Play();

                pb_play.Image = Properties.Resources.pause;
                audioplaying = true;
            }
            else
            {
                audioplaying = false;
            }
        }

        public void StopPlaying()
        {
            if (outputDevice != null) outputDevice.Stop();

            tmr_ProgressTracker.Stop();
            tmr_ProgressTracker.Enabled = false;

            progb_audio.Value = 0;
            progb_audio.Visible = false;

            if (outputDevice != null)
            {
                outputDevice.Dispose();
                outputDevice = null;
            }
            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }

            pb_play.Image = Properties.Resources.play_button;
        }

        private void tmr_ProgressTracker_Tick(object sender, EventArgs e)
        {
            if (progb_audio.Value != progb_audio.Maximum)
                progb_audio.Value = progb_audio.Value + 1;

            if (outputDevice.PlaybackState != PlaybackState.Playing || shortfilename != Main._currentlyPlaying)
            {
                StopPlaying();
            }
        }

        GlobalKeyboardHook hook = new GlobalKeyboardHook();
        bool hooking = false;

        private void tb_Shortcut_Click(object sender, EventArgs e)
        {
            if (!hooking)
            {
                tb_Shortcut.ForeColor = Color.White;
                tb_Shortcut.BackColor = Color.Maroon;
                lb_name.Focus();

                hook.KeyDown += new KeyEventHandler(setHook_Down);
                foreach (Keys key in Enum.GetValues(typeof(Keys)))
                    hook.HookedKeys.Add(key);

                hook.hook();
                hooking = true;
                lb_DeleteShortcut.Visible = false;
            }
            else lb_name.Focus();
        }

        private void setHook_Down(object sender, KeyEventArgs e)
        {
            string TextToDisplay = e.KeyCode.ToString();
            if (KeyValues.KeyDescriptions().ContainsKey(e.KeyCode))
            {
                TextToDisplay = KeyValues.KeyDescriptions()[e.KeyCode];
            }

            tb_Shortcut.Text = TextToDisplay;
            tb_Shortcut.ForeColor = Color.Black;
            tb_Shortcut.BackColor = Color.White;
            
            hooking = false;
            hook.unhook();

            lb_DeleteShortcut.Visible = true;

            DBAdapter.UpdateOrSetHotkey(dbpath, shortfilename, e.KeyCode.ToString());
            if (Main._HotkeyList.ContainsKey(shortfilename)) Main._HotkeyList.Remove(shortfilename);
            Main._HotkeyList.Add(shortfilename, e.KeyCode);
        }

        private void lb_DeleteShortcut_Click(object sender, EventArgs e)
        {
            tb_Shortcut.Text = "Taste wählen";
            tb_Shortcut.ForeColor = SystemColors.WindowFrame;

            lb_DeleteShortcut.Visible = false;

            DBAdapter.UpdateOrSetHotkey(dbpath, shortfilename, null);
            Main._HotkeyList.Remove(shortfilename);
        }

        public bool CompareName(string name)
        {
            if (shortfilename == name) return true;
            else return false;
        }
    }
}
