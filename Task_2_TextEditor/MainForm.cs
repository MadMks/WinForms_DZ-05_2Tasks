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
        private string openFilePath;

        private DialogResult dialogResult;
        private string bufferTextBoxText;
        private string bufferStr;

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
                this.dialogResult = this.AskWhetherToSaveTheChanges();

                if (dialogResult == DialogResult.Yes)
                {
                    this.saveToolStripMenuItem_Click(sender, e);
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                this.Text = fileNames[0];

                this.openFilePath = fileNames[0];

                richTextBox.LoadFile(fileNames[0], RichTextBoxStreamType.PlainText);

                if (this.Text[0] == '*')
                {
                    this.Text = this.Text.Substring(1);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если открыт документ не сохраненный
            // то спросить "сохранить ли документ перед открытием другого".
            this.dialogResult = this.AskWhetherToSaveTheChanges();

            if (dialogResult == DialogResult.Yes)
            {
                this.saveToolStripMenuItem_Click(sender, e);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }


            // Открытие.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog.FileName;

                this.openFilePath = openFileDialog.FileName;

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

                    if (this.Text[0] == '*')
                    {
                        this.Text = this.Text.Substring(1);
                    }
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text == "Новый файл" || this.Text == "*Новый файл")
            {
                this.saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(this.openFilePath))
                {
                    writer.Write(this.richTextBox.Text);
                }

                if (this.Text[0] == '*')
                {
                    this.Text = this.Text.Substring(1);
                }
            }
        }

        private void richTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.bufferTextBoxText = this.richTextBox.Text;
        }

        private void richTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.bufferTextBoxText = this.richTextBox.Text;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dialogResult = this.AskWhetherToSaveTheChanges();

            if (dialogResult == DialogResult.Yes)
            {
                this.saveToolStripMenuItem_Click(sender, e);

                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private DialogResult AskWhetherToSaveTheChanges()
        {
            if (this.Text[0] == '*')
            {
                dialogResult = MessageBox.Show("Сохранить изменения в файле "
                    + this.openFilePath + "?", "Сохранить файл",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }

            return dialogResult;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dialogResult = this.AskWhetherToSaveTheChanges();

            if (dialogResult == DialogResult.Yes)
            {
                this.saveToolStripMenuItem_Click(sender, e);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                return;
            }

            this.CreateNewFile();
        }

        private void CreateNewFile()
        {
            // Очистить поле 
            this.richTextBox.Text = "";

            // Изменить название тайтла 
            this.Text = "Новый файл";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.Write(this.richTextBox.Text);
                }

                this.Text = saveFileDialog.FileName;

                this.openFilePath = saveFileDialog.FileName;
            }
        }



        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.richTextBox.SelectedText != "")
            {
                this.bufferStr = this.richTextBox.SelectedText;
                this.richTextBox.SelectedText = "";
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.bufferStr != "")
            {
                this.richTextBox.SelectedText = this.bufferStr;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.bufferStr = this.richTextBox.SelectedText;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox.Text = this.bufferTextBoxText;
        }


        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.Text == "Текстовый редактор")
            {
                this.Text = "*Новый файл";

            }
            else if (this.Text[0] != '*')
            {
                this.Text = "*" + this.Text;
            }
        }
    }
}
