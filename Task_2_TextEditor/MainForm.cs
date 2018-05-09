using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_TextEditor
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Путь открытого файла.
        /// </summary>
        //private string openFilePath;

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text Files(*.txt)|*.txt||";
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();

            saveFileDialog.Filter = "Text Files(*.txt)|*.txt||";
            saveFileDialog.FilterIndex = 0;


            this.richTextBox.AllowDrop = true;
            this.richTextBox.DragDrop += RichTextBox_DragDrop;
        }


        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileNames = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (fileNames != null)
            {
                richTextBox.LoadFile(fileNames[0], RichTextBoxStreamType.PlainText);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog.FileName;

                if (openFileDialog.FileName == "")
                {
                    return;
                }
                else
                {
                    using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                    {
                        this.richTextBox.Text = reader.ReadToEnd();
                    }

                    //this.openFilePath = openFileDialog.FileName;
                }
                
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(this.richTextBox.Text);
                }
            }
        }


    }
}
