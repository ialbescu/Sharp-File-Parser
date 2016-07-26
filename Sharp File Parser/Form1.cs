using System;
using System.Collections.Generic;
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
            InitializeComponent();
        }

        private readonly string _baseFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = _baseFolderPath + @"\Paradox Interactive\Stellaris\save games\",
                Filter = "Stellaris save games (*.sav)|*.sav|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };
            OpenFile(openFileDialog1);
        }

        public static string ReadLineByLine(string path)
        {
            string myLine = "";
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.Peek() >= 0)
                {
                    myLine += ExtractKeyFromLine(sr.ReadLine()) + Environment.NewLine;
                }
            }
            return myLine;
        }

        public static string ExtractKeyFromLine(string text)
        {
            // Define a regular expression for repeated words.
            string myKey = "";
            //string myValue = "";

            // (?<before_equal>\w+)+=(?!{)(?<after_equal>.+)+
            Regex rx = new Regex(@"(?<before_equal>\w+)+=(?!{)(?<after_equal>.+)+",
                RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                myKey = groups[1].Value.Replace("\"", "");
                //myValue = groups[1].Value.Replace("\"", "");
            }
            return myKey;
        }



        public string TestRegEx(string text, string keyword)
        {
            // Define a regular expression for repeated words.
            string value = "";
            Regex rx = new Regex(@"" + keyword + "=.*", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Find matches.
            MatchCollection matches = rx.Matches(text);

            // Report on each match.
            foreach (Match match in matches)
            {
                GroupCollection groups = match.Groups;
                value = groups[0].Value.Replace(keyword + "=", "");
            }
            return value;
        }

        public void ZipToFile(string fileName)
        {
            using (ZipArchive zip = ZipFile.Open(fileName, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    string fileOutput = Path.Combine(_baseFolderPath, entry.Name + ".txt");
                    entry.ExtractToFile(fileOutput, true);
                }
        }


        public void OpenFile(OpenFileDialog openFileDialog1)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                string metaPath = _baseFolderPath + @"\meta.txt";
                string gamestatePath = _baseFolderPath + @"\gamestate.txt";

                txtFileName.Text = openFileDialog1.FileName;
                ZipToFile(openFileDialog1.FileName);

                //this.txtMeta.Text += File.ReadAllText(metaPath) + Environment.NewLine;
                //this.txtMeta.SelectionStart = this.txtMeta.Text.Length;
                //this.txtMeta.ScrollToCaret();

                //this.txtGameState.Text = File.ReadAllText(gamestatePath) + Environment.NewLine;
                //this.txtGameState.SelectionStart = this.txtGameState.Text.Length;
                //this.txtGameState.ScrollToCaret();

                //string meta = File.ReadAllText(metaPath);
                //string gamestate = File.ReadAllText(gamestatePath); am comentat linia până terminăm cu meta



                txtMeta.Text += ReadLineByLine(metaPath) + Environment.NewLine;


            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: Could not read file from disk.\nReason: " + exception.Message);
            }
        }
    }
}
