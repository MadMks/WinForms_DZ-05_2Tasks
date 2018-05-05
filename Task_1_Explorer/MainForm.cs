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
            this.treeView.BeforeSelect += TreeView_BeforeSelect;
            this.treeView.BeforeExpand += TreeView_BeforeExpand;

            this.FillWithLogicalDisks();

            this.treeView.NodeMouseClick += TreeView_NodeMouseClick;


            this.listView.LargeImageList = this.imageList;
            this.listView.View = View.Tile;
            //this.listView.StateImageList.Images = 
        }

        private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.listView.Items.Clear();

                foreach (
                    string filePath in Directory.EnumerateFileSystemEntries(e.Node.FullPath)
                    )
                {
                    Icon iconForFile = SystemIcons.WinLogo;

                    ListViewItem listItem = new ListViewItem(Path.GetFileName(filePath));
                    FileInfo fileInfo = new FileInfo(filePath);

                    if (this.imageList.Images.ContainsKey(fileInfo.Extension) == false)
                    {
                        iconForFile = Icon.ExtractAssociatedIcon(filePath);
                        this.imageList.Images.Add(fileInfo.Extension, iconForFile);
                    }

                    listItem.ImageKey = fileInfo.Extension;

                    this.listView.Items.Add(listItem);
                }
            }
            catch (Exception) {}
            
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
                    this.FillChildNodes(driveNode, drive.Name);
                    this.treeView.Nodes.Add(driveNode);
                }
            }
        }


        /// <summary>
        /// Заполняем дочерними папками(узлами), для определенного узла(логического диска).
        /// </summary>
        /// <param name="driveNode">Node логического диска.</param>
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
            catch (Exception ex) {}
        }

        /// <summary>
        /// Обработчик события перед выбором узла.
        /// </summary>
        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            this.FillingNodeBeforeSelectionAndOpening(e);
        }

        /// <summary>
        /// Обработчик события перед раскрытием узла.
        /// </summary>
        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.FillingNodeBeforeSelectionAndOpening(e);
        }

        private void FillingNodeBeforeSelectionAndOpening(TreeViewCancelEventArgs e)
        {
            // Чистка ноды (перд открытием, или при выборе)
            // для удаления старых записей.
            e.Node.Nodes.Clear();

            string[] dirs;

            try
            {
                if (Directory.Exists(e.Node.FullPath) == true)
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);

                    if (dirs.Length > 0)
                    {
                        foreach (string dir in dirs)
                        {
                            TreeNode dirNode = new TreeNode(Path.GetFileName(dir));
                            this.FillChildNodes(dirNode, dir);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }


    }
}
