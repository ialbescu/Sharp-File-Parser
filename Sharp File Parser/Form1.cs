using System;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sharp_File_Parser
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.InitializeComponent();
        }

        private readonly string _baseFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = this._baseFolderPath + @"\Paradox Interactive\Stellaris\save games\",
                Filter = "Stellaris save games (*.sav)|*.sav|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            this.OpenFile(openFileDialog1);
        }

        public static string TestRegEx(string text, string keyword)
        {
            // Define a regular expression for repeated words.
            string value = "";
            Regex rx = new Regex(@"" + keyword + "=.*", //"version=\""
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                value = groups[0].Value.Replace(keyword + "=", "");
                //value = groups[0].Value.Replace("version=\"", "");
            }
            return value;
        }

        public void ZipToFile(string fileName)
        {
            using (ZipArchive zip = ZipFile.Open(fileName, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string fileOutput = Path.Combine(this._baseFolderPath, entry.Name + ".txt");
                    entry.ExtractToFile(fileOutput, true);
                }
        }


        public void OpenFile(OpenFileDialog openFileDialog1)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                string metaPath = this._baseFolderPath + @"\meta.txt";
                string gamestatePath = this._baseFolderPath + @"\gamestate.txt";

                this.txtFileName.Text = openFileDialog1.FileName;
                this.ZipToFile(openFileDialog1.FileName);

                this.txtMeta.Text += File.ReadAllText(metaPath) + Environment.NewLine;
                this.txtMeta.SelectionStart = this.txtMeta.Text.Length;
                this.txtMeta.ScrollToCaret();

                this.txtGameState.Text = File.ReadAllText(gamestatePath) + Environment.NewLine;
                this.txtGameState.SelectionStart = this.txtGameState.Text.Length;
                this.txtGameState.ScrollToCaret();

                string meta = File.ReadAllText(metaPath);
                string gamestate = File.ReadAllText(gamestatePath);

                this.txtFileName.Text = TestRegEx(meta, "version");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: Could not read file from disk.\nReason: " + exception.Message);
            }
        }
    }
}
