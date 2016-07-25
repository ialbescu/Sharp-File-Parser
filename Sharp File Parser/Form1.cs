using System;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Sharp_File_Parser
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.InitialDirectory = path + "\\Paradox Interactive\\Stellaris\\save games\\";
            openFileDialog1.Filter = "Stellaris save games (*.sav)|*.sav|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            OpenFile(openFileDialog1);
        }

        public void ZIPToFile(string FileName)
        {
            string extractPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (ZipArchive zip = ZipFile.Open(FileName, ZipArchiveMode.Read))
                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    String FileOutput = Path.Combine(extractPath, entry.Name + ".txt");
                    entry.ExtractToFile(FileOutput, true);
                }
        }

        public string FillRichText(string aPath)
        {
            string content = File.ReadAllText(aPath);
            return content;
        }

        public void FillFileName(string aPath)
        {
            txtFileName.Text = aPath;
        }

        public void OpenFile(OpenFileDialog openFileDialog1)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string metaPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\meta.txt";
                    string gamestatePath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\gamestate.txt";
                    FillFileName(openFileDialog1.FileName);                    
                    ZIPToFile(openFileDialog1.FileName);  

                    txtMeta.Text += FillRichText(metaPath) + System.Environment.NewLine;
                    txtMeta.SelectionStart = txtMeta.Text.Length;
                    txtMeta.ScrollToCaret();

                    txtGameState.Text = FillRichText(gamestatePath) + System.Environment.NewLine;
                    txtGameState.SelectionStart = txtGameState.Text.Length;
                    txtGameState.ScrollToCaret();
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error: Could not read file from disk.\nReason: " + ex1.Message);
                }
            }
        }

    }
}
