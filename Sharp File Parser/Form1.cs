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
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Stellaris save games (*.sav)|*.sav|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FillRichText(openFileDialog1.FileName);
                }

                catch (Exception ex1)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex1.Message);
                }


                finally
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        myStream.Close();
                    }
                }
            }
        }

        public string FillRichText(string aPath)
        {
            string content = File.ReadAllText(aPath);
            txtFileContent.Text = content;
            return content;
        }
    }
}
