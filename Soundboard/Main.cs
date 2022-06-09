using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SQLite;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Soundboard
{
    public partial class Main : Form
    {
        string audiopath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mimple Soundboard\Audio\";
        string dbpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Mimple Soundboard\data.db";

        #region Audio Playing Variables
        public static float _soundVolume = 1.0F;
        public static string _currentlyPlaying = "";
        public static bool _audioplaying = false;
        private static WaveOutEvent outputDevice = new WaveOutEvent();
        private static AudioFileReader audioFile;
        public static Dictionary<string, Keys> _HotkeyList;
        #endregion

        private static ListElement currentListElement;
        private static Timer audioProgressBar;
        private static Form MainForm;
        private GlobalKeyboardHook HotkeyHook = new GlobalKeyboardHook();

        public Main()
        {
            InitializeComponent();

            MainForm = this;
            flp_List.HorizontalScroll.Visible = false;
            flp_List.AutoScroll = true;
            _HotkeyList = new Dictionary<string, Keys>();

            // Gets all the sounds from database
            if (!Directory.Exists(audiopath))
                Directory.CreateDirectory(audiopath);

            if (!File.Exists(dbpath))
                DBAdapter.CreateDatabase(dbpath);

            _HotkeyList = DBAdapter.GetAllHotkeys(dbpath);
            act_reload(); // Loads all Sounds

            // Sets the Volume
            if (DBAdapter.GetSetting(dbpath, "volume") != null)
            {
                int savedVolume = Convert.ToInt32(DBAdapter.GetSetting(dbpath, "volume"));
                trackb_Volume.Value = savedVolume / 10;
                outputDevice.Volume = savedVolume / 100F;
                lb_Volume.Text = savedVolume.ToString() + "%";
            }

            // Starts the Keyboard Hook
            HotkeyHook.KeyDown += new KeyEventHandler(HotkeyHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                HotkeyHook.HookedKeys.Add(key);

            HotkeyHook.hook();
        }

        private void HotkeyHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (!checkb_HotkeysAvailable.Checked) return;

            Keys pressedKey = e.KeyCode;

            if (_HotkeyList.ContainsValue(pressedKey))
            {
                string requestedSound = _HotkeyList.FirstOrDefault(x => x.Value == pressedKey).Key;
                ListElement requestedElement = currentListElement;

                foreach (ListElement l in flp_List.Controls)
                {
                    if (l.CompareName(requestedSound))
                        requestedElement = l;
                }

                Play(requestedElement);
            }
        }

        private void act_reload()
        {
            flp_List.Controls.Clear();
            bool grau = true; // damit die Farben abwechselnd sind

            foreach (string name in DBAdapter.GetAllFiles(dbpath))
            {
                ListElement listElement = new ListElement(name, grau);
                listElement.pb_play.Click += new EventHandler(act_ClickOnPlay);
                listElement.pb_delete.Click += new EventHandler(act_ClickOnDelete);

                flp_List.Controls.Add(listElement);
                lb_Starthinweis.Visible = false;

                if (grau) grau = false;
                else grau = true;
            }
        }

        #region Sound Managing

        /// <summary>
        /// Adds a new File to Directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void act_AddFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Wählen sie zuerst die gewünschte Datei aus";
            ofd.Filter = "WAV Dateien (*.wav)|*.wav|MP3 Dateien (*.mp3)|*.mp3|AIFF Dateien (*.aiff)|*.aiff|MP4 Dateien (*.mp4)|*.mp4";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string shortfilename = Path.GetFileName(ofd.FileName);

                if (!File.Exists(audiopath + shortfilename))
                {
                    File.Copy(ofd.FileName, audiopath + shortfilename, true);
                    DBAdapter.AddAudioFile(dbpath, shortfilename);
                    act_reload();
                }

                else MessageBox.Show("Datei mit dem selben Namen bereits vorhanden");
            }
        }

        /// <summary>
        /// Plays the Sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void act_ClickOnPlay(object sender, EventArgs e)
        {
            Play(((ListElement)((PictureBox)sender).Parent));
        }

        private void Play(ListElement listElementWithSound)
        {
            if (_audioplaying && currentListElement != listElementWithSound)
            {
                StopPlaying();
            }
            currentListElement = listElementWithSound;

            string curFile = audiopath + currentListElement.lb_name.Text;
            string curFileName = currentListElement.lb_name.Text;

            if (!_audioplaying)
            {
                _currentlyPlaying = curFileName;

                outputDevice = new WaveOutEvent();
                audioFile = new AudioFileReader(curFile);
                outputDevice.Init(audioFile);

                currentListElement.progb_audio.Maximum = Convert.ToInt32(audioFile.TotalTime.TotalSeconds);
                currentListElement.progb_audio.Value = 1;
                currentListElement.progb_audio.Visible = true;

                audioProgressBar = new Timer();
                audioProgressBar.Interval = 1000;
                audioProgressBar.Tick += new EventHandler(act_AudipProgress_Tick);

                audioProgressBar.Start();
                outputDevice.Play();

                MainForm.Text = "Mimple Soundboard - " + _currentlyPlaying;

                currentListElement.pb_play.Image = Properties.Resources.pause;
                _audioplaying = true;
            }
            else
            {
                audioFile = null;
                StopPlaying();
            }
        }

        /// <summary>
        /// Deletes the Sound
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void act_ClickOnDelete(object sender, EventArgs e)
        {
            ListElement le = ((ListElement)((PictureBox)sender).Parent);
            string curFileName = le.lb_name.Text;

            if (MessageBox.Show("Wollen sie '" + curFileName + "' wirklich löschen? Dieser Vorgang ist nicht rückkehrbar!", "Löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    DBAdapter.DeleteAudioFile(dbpath, curFileName);
                    File.Delete(audiopath + curFileName);
                    le.Visible = false;

                    if (flp_List.Controls.Count == 0)
                    {
                        lb_Starthinweis.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Fehler beim löschen der Datei. Versuchen sie es später erneut.");
                }
            }
        }

        /// <summary>
        /// Manages the Progressbar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void act_AudipProgress_Tick(object sender, EventArgs e)
        {
            if (currentListElement.progb_audio.Value != currentListElement.progb_audio.Maximum)
                currentListElement.progb_audio.Value = currentListElement.progb_audio.Value + 1;

            if (outputDevice.PlaybackState != PlaybackState.Playing)
            {
                StopPlaying();
            }
        }

        /// <summary>
        /// Stops the Sound
        /// </summary>
        private static void StopPlaying()
        {
            outputDevice.Stop();
            audioProgressBar.Stop();

            currentListElement.pb_play.Image = Properties.Resources.play_button;
            currentListElement.progb_audio.Value = 0;
            currentListElement.progb_audio.Visible = false;

            MainForm.Text = "Mimple Soundboard";

            _audioplaying = false;
        }

        #endregion

        #region Volume Managing

        private void trackb_Volume_ValueChanged(object sender, EventArgs e)
        {
            float fl = trackb_Volume.Value * 0.1F;
            outputDevice.Volume = fl;

            int inpercent = trackb_Volume.Value * 10;
            lb_Volume.Text = inpercent.ToString() + "%";
        }

        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBAdapter.UpdateOrSetSetting(dbpath, "volume", (trackb_Volume.Value * 10).ToString());
            HotkeyHook.unhook();
        }

        #region Notify Icon Manager

        private void Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                NotifyShowApp.Visible = true;
                MainNotifyIcon.ShowBalloonTip(1000, "Fenster minimiert!", "Das Fenster wurde in den Infobereich minimert. Du kannst es durch einen Doppelklick auf das Symbol wieder öffnen.", ToolTipIcon.None);
            }
                
        }

        private void notify_ShowWindow(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
            {
                Show();
                NotifyShowApp.Visible = false;
                this.WindowState = FormWindowState.Normal;
            }  
        }

        private void notify_Exit(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
