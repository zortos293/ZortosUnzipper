
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFUnzipper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] arguments = Environment.GetCommandLineArgs();
            string argumentinstring = string.Join(", ", arguments);
            


            if (argumentinstring.EndsWith(@".zip"))
            {

                ZipFile.ExtractToDirectory(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1), Path.GetTempPath() + @"ZortosUnzipper");
                MessageBox.Show("Done File Extracted inside" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Environment.Exit(0);

            }
            if (argumentinstring.EndsWith(".7z"))
            {
                using (var archive = RarArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Done File Extracted inside" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Environment.Exit(0);
            }
            if (argumentinstring.EndsWith(".rar"))
            {
                using (var archive = RarArchive.Open(argumentinstring.Substring(argumentinstring.IndexOf(',') + 1)))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(Path.GetTempPath() + @"ZortosUnzipper", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Done File Extracted inside:" + "\n" + Path.GetTempPath() + @"ZortosUnzipper");
                Environment.Exit(0);
            }

        }
        public void Zortosneededextension()
        {
           
        }
        public static string SelectedFile = "";
        public static string SelectedFolder = "";
        TaskCompletionSource<bool> IsSomethingLoading = new TaskCompletionSource<bool>();
        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            await ShowPopup(new SimpleFileManager.FileSelect());
            ziplocation.Text = SelectedFile;

        }
       

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (ziplocation.Text.EndsWith(".zip"))
            {
                ZipFile.ExtractToDirectory(ziplocation.ToString(), unziplocation.ToString());
                MessageBox.Show("Extracted!");
            }
            if (ziplocation.Text.EndsWith(".7z"))
            {
                using (var archive = RarArchive.Open(ziplocation.Text.ToString()))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(unziplocation.Text.ToString(), new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Extracted!");
            }
            if (ziplocation.Text.EndsWith(".rar"))
            {
                using (var archive = RarArchive.Open(ziplocation.Text.ToString()))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(unziplocation.Text.ToString(), new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
                MessageBox.Show("Extracted!");
            }
        }

        private async void guna2Button5_Click(object sender, EventArgs e)
        {
            await ShowPopup(new SimpleFileManager.Form1());
            unziplocation.Text = SelectedFolder;
        }
        private Task ShowPopup<TPopup>(TPopup popup)
        where TPopup : Form
        {
            var task = new TaskCompletionSource<object>();
            popup.Closed += (s, a) => task.SetResult(null);
            popup.Show();
            popup.Focus();
            return task.Task;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By Zortos V1.0");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coming Soon Stay tuned");
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can use the gui or the command line version \nCommand Line Usage: \n" + @"ZortosUnzipper.exe 'C:\example.zip'");
        }
    }
}
