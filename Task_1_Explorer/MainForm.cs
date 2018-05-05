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
            //TreeNode node;

            //// Записываю в дерево доступные логические диски.
            //foreach (DriveInfo item in DriveInfo.GetDrives())
            //{
            //    if (item.IsReady == true)
            //    {
            //        node = new TreeNode(item.Name);
            //        this.AddFoldersRecursively(node, item.Name, 0);//-
            //        this.treeView.Nodes.Add(node);  
            //    }
            //}

            this.treeView.BeforeExpand += TreeView_BeforeExpand;

            this.FillWithLogicalDisks();
        }


        /// <summary>
        /// Заполняем дерево логическими дисками (доступными).
        /// </summary>
        private void FillWithLogicalDisks()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady == true)
                {
                    TreeNode driveNode = new TreeNode(drive.Name);
                    // TODO заполнить дочерними папками(узлами), для определенного узла.
                    this.FillChildNodes(driveNode, drive.Name);
                    this.treeView.Nodes.Add(driveNode);
                }
            }
        }

        /// <summary>
        /// Заполняем дочерними папками(узлами), для определенного узла.
        /// </summary>
        /// <param name="driveNode">TODO</param>
        /// <param name="path">Путь узла который нужно заполнить дочерними узлами.</param>
        private void FillChildNodes(TreeNode driveNode, string path)
        {
            try
            {
                foreach (string dirPath in Directory.GetDirectories(path))
                {
                    TreeNode dirNode = new TreeNode(Path.GetFileName(dirPath));
                    driveNode.Nodes.Add(dirNode);
                }
            }
            catch (Exception) {}
        }

        /// <summary>
        /// Обработчик события перед раскрытием узла.
        /// </summary>
        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Добавление в treeView имен папок (рекурсивно).
        /// </summary>
        /// <param name="rootNode"></param>
        /// <param name="path"></param>
        //private void AddFoldersRecursively(TreeNode rootNode, string path, int nestingLevel)
        //{
        //    if (nestingLevel > 5)
        //    {
        //        return;
        //    }


        //    TreeNode parentNode;


        //    foreach (string folderFullPath in Directory.GetDirectories(path))
        //    {
        //        nestingLevel++;

        //        DirectoryInfo dirInfo = new DirectoryInfo(folderFullPath);

        //        if (dirInfo.GetType().IsVisible == true)
        //        {

        //            try
        //            {
        //                parentNode = new TreeNode(Path.GetFileName(folderFullPath));

        //                rootNode.Nodes.Add(parentNode);

        //                this.AddFoldersRecursively(parentNode, folderFullPath, nestingLevel);
        //            }
        //            catch {}

        //        }
        //    }


        //}



    }
}
