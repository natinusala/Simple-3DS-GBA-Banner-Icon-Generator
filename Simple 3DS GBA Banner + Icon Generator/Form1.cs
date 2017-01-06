using DamienG.Security.Cryptography;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Simple_3DS_GBA_Banner___Icon_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string romFile;

        private void romButton_Click(object sender, EventArgs e)
        {
            DialogResult result = romBrowseDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                romButton.Enabled = false;
                saveButton.Enabled = false;
                aboutButton.Enabled = false;
                identifiedLabel.Text = "n/a";
                iconBox.Image = null;
                banner1Box.Image = null;
                banner2Box.Image = null;

                romFile = romBrowseDialog.FileName;
                backgroundWorker.RunWorkerAsync();
            }
        }

        private void UpdateStatus(string status)
        {
            statusLabel.Invoke((MethodInvoker)delegate
            {
                statusLabel.Text = status;
            });
        }

        private static readonly string DATABASE = Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.Nintendo___Game_Boy_Advance_Parent_Clone__20160714_184042_;
        private static readonly string TITLE_URL = "https://raw.githubusercontent.com/libretro/libretro-thumbnails/master/Nintendo%20-%20Game%20Boy%20Advance/Named_Titles/";

        string iconFile;
        string banner1File;
        string banner2File;

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetManifestResourceNames()[1]);
            UpdateStatus("loading database...");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(DATABASE);
            XmlNode root = doc.DocumentElement;

            UpdateStatus("calculating game hashes...");
            FileStream romStream = File.OpenRead(romFile);
            string crc32 = GetCRC32(romStream).ToUpper();
            romStream.Close();

            UpdateStatus("identifying game...");
            XmlNodeList list = root.SelectNodes("//game[rom/@crc = '" + crc32 + "']");

            if (list.Count == 0)
            {
                //Non trouvé 
                failure("The game was not found in the ROMs database.");
            }
            else if (list.Count == 1)
            {
                //Trouvé 
                string gameName = list[0].Attributes["name"].Value;
                string encodedGameName = Uri.EscapeUriString(gameName);

                UpdateStatus("downloading image...");
                string titleFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
                try
                {
                    new WebClient().DownloadFile(TITLE_URL + encodedGameName + ".png", titleFile);
                }
                catch (Exception ex)
                {
                    failure("The game was not found in the thumbnails database.\n\nIdentified game name : " + gameName);
                    return;
                }

                UpdateStatus("creating images...");

                //icon
                iconFile = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
                System.IO.MemoryStream iconBaseStream = new System.IO.MemoryStream();
                Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.icon_base.Save(iconBaseStream, System.Drawing.Imaging.ImageFormat.Png);
                using (ImageFactory imageFactory = new ImageFactory())
                {
                    imageFactory
                        .Load(iconBaseStream.ToArray())
                        .Overlay(new ImageLayer() { Image = Image.FromFile(titleFile) })
                        .Overlay(new ImageLayer(){ Image = Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.icon_frame})
                        .Format(new PngFormat())
                        .Save(iconFile);
                }
                iconBaseStream.Close();

                //banner1
                banner1File = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
                System.IO.MemoryStream banner1BaseStream = new System.IO.MemoryStream();
                Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.banner1_base.Save(banner1BaseStream, System.Drawing.Imaging.ImageFormat.Png);
                using (ImageFactory imageFactory = new ImageFactory())
                {
                    imageFactory
                        .Load(banner1BaseStream.ToArray())
                        .Overlay(new ImageLayer()
                        {
                            Image = Image.FromFile(titleFile),
                            Position = new Point(5, 25),
                            Size = new Size(117, 79)
                        })
                        .Overlay(new ImageLayer() { Image = Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.banner1_frame })
                        .Format(new PngFormat())
                        .Save(banner1File);
                }
                banner1BaseStream.Close();

                //banner2
                string croppedGameName = gameName.Substring(0, gameName.IndexOf('('));
                banner2File = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
                System.IO.MemoryStream banner2BaseStream = new System.IO.MemoryStream();
                Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.banner2_base.Save(banner2BaseStream, System.Drawing.Imaging.ImageFormat.Png);
                using (ImageFactory imageFactory = new ImageFactory())
                {
                    PrivateFontCollection privateFontCollection = new PrivateFontCollection();
                    privateFontCollection.AddFontFile("SCE-PS3-RD-R-LATIN.TTF");

                    int y = 25;
                    if (croppedGameName.Length > 50)
                        y = 10;
                    else if (croppedGameName.Length > 25)
                        y = 15;

                    imageFactory
                        .Load(banner2BaseStream.ToArray())
                        .Crop(new Rectangle(0, 0, 256-8, 64))
                        .Watermark(new TextLayer()
                        {
                            FontFamily = privateFontCollection.Families[0],
                            Text = croppedGameName,
                            DropShadow = false,
                            FontSize = 12,
                            Position = new Point(100, y)
                        })
                        .Resize(new ResizeLayer(new Size(256, 64))
                        {
                            ResizeMode = ResizeMode.BoxPad, 
                            AnchorPosition = AnchorPosition.Left,
                        })
                        .Overlay(new ImageLayer()
                        {
                            Image = Simple_3DS_GBA_Banner___Icon_Generator.Properties.Resources.banner2_tail,
                            Position = new Point(256-8, 0)
                        })
                        .Format(new PngFormat())
                        .Save(banner2File);
                }
                banner2BaseStream.Close();

                UpdateStatus("images generated, waiting for a save folder...");
                identifiedLabel.Invoke((MethodInvoker)delegate
                {
                    identifiedLabel.Text = gameName;
                });
                romButton.Invoke((MethodInvoker)delegate
                {
                    romButton.Enabled = true;
                });
                saveButton.Invoke((MethodInvoker)delegate
                {
                    saveButton.Enabled = true;
                });
                aboutButton.Invoke((MethodInvoker)delegate
                {
                    aboutButton.Enabled = true;
                });
                iconBox.Invoke((MethodInvoker)delegate
                {
                    iconBox.ImageLocation = iconFile;
                });
                banner1Box.Invoke((MethodInvoker)delegate
                {
                    banner1Box.ImageLocation = banner1File;
                });
                banner2Box.Invoke((MethodInvoker)delegate
                {
                    banner2Box.ImageLocation = banner2File;
                });
            }
            else
            {
                //Plusieurs trouvés 
                //TODO MD5 || sha1
                failure("More than one game was found for this ROM file. This shouldn't happen, you may want to contact natinusala on GBAtemp forums.");
            }
        }

        void failure(string message)
        {
            UpdateStatus("waiting for ROM...");
            this.Invoke((Func<DialogResult>)(() => MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)));
            romButton.Invoke((MethodInvoker)delegate
            {
                romButton.Enabled = true;
            });
        }

        public static string GetCRC32(Stream fs)
        {
            Crc32 crc32 = new Crc32();
            String hash = String.Empty;

            foreach (byte b in crc32.ComputeHash(fs)) hash += b.ToString("x2").ToLower();

            return hash;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveImagesDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string baseDir = saveImagesDialog.SelectedPath + "\\" + CleanFileName(identifiedLabel.Text);

                File.Copy(iconFile, baseDir + "_icon.png", true);
                File.Copy(banner1File, baseDir + "_banner1.png", true);
                File.Copy(banner2File, baseDir +  "_banner2.png", true);

                MessageBox.Show("Images saved successfully !\n\n" + baseDir + "_icon.png\n" + baseDir + "_banner1.png\n" + baseDir + "_banner2.png", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UpdateStatus("waiting for ROM...");
                saveButton.Enabled = false;
                identifiedLabel.Text = "n/a";
                iconBox.Image = null;
                banner1Box.Image = null;
                banner2Box.Image = null;
            }
        }

        private static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Simple 3DS GBA Banner + Icon Generator v1.0\nSoftware made by natinusala for the GBAtemp community.\n\nUses the games database from the no-intro's dat-o-matic\nImages downloaded from libretro's thumbnails database", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
