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

namespace Task_1_Explorer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            TreeNode node;

            // Записываю в дерево доступные логические диски.
            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                if (item.IsReady == true)
                {
                    node = new TreeNode(item.Name);

                    this.treeView.Nodes.Add(node);  
                }
            }

            // Запускаем рекурсивное добавление папок в каждом диске.
            foreach (TreeNode rootNode in this.treeView.Nodes)
            {
                this.AddFoldersRecursively(rootNode, rootNode.FullPath, 0);
            }

        }

        /// <summary>
        /// Добавление в treeView имен папок (рекурсивно).
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="path"></param>
        private void AddFoldersRecursively(TreeNode rootNode, string path, int nestingLevel)
        {
            if (nestingLevel > 5)
            {
                return;
            }


            TreeNode parentNode;


            foreach (string folderFullPath in Directory.GetDirectories(path))
            {
                nestingLevel++;

                DirectoryInfo dirInfo = new DirectoryInfo(folderFullPath);

                if (dirInfo.GetType().IsVisible == true)
                {

                    try
                    {
                        parentNode = new TreeNode(Path.GetFileName(folderFullPath));

                        rootNode.Nodes.Add(parentNode);

                        this.AddFoldersRecursively(parentNode, folderFullPath, nestingLevel);
                    }
                    catch {}
                    
                }
            }


        }



    }
}
