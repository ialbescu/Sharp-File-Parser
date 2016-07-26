using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Sharp_File_Parser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.InitializeComponent();
        }

        private readonly string baseFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void BtnBrowseClick(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = this.baseFolderPath + @"\Paradox Interactive\Stellaris\save games\", 
                Filter = "Stellaris save games (*.sav)|*.sav|All files (*.*)|*.*", 
                FilterIndex = 1, 
                RestoreDirectory = true
            };
            this.OpenFile(openFileDialog1);
        }

        public void ZipToFile(string fileName)
        {
            using (var zip = ZipFile.Open(fileName, ZipArchiveMode.Read))
                foreach (var entry in zip.Entries)
                {
                    var fileOutput = Path.Combine(this.baseFolderPath, entry.Name + ".txt");
                    entry.ExtractToFile(fileOutput, true);
                }
        }

        private static string FillRichText(string aPath)
        {
            return File.ReadAllText(aPath); // nu prea are rost sa faci o metoda pentru ceva atat de simplu, dar asta e o chestie de preferinta
        }

        private void FillFileName(string aPath)
        {
            this.txtFileName.Text = aPath; // nu prea are rost sa faci o metoda pentru ceva atat de simplu, dar asta e o chestie de preferinta
        }

        public void OpenFile(OpenFileDialog openFileDialog1)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                var metaPath = this.baseFolderPath + "\\meta.txt";
                var gamestatePath = this.baseFolderPath + "\\gamestate.txt";
                this.FillFileName(openFileDialog1.FileName);
                this.ZipToFile(openFileDialog1.FileName);

                this.txtMeta.Text += FillRichText(metaPath) + Environment.NewLine;
                this.txtMeta.SelectionStart = this.txtMeta.Text.Length;
                this.txtMeta.ScrollToCaret();

                this.txtGameState.Text = FillRichText(gamestatePath) + Environment.NewLine;
                this.txtGameState.SelectionStart = this.txtGameState.Text.Length;
                this.txtGameState.ScrollToCaret();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: Could not read file from disk.\nReason: " + exception.Message);
            }
        }
    }
}
