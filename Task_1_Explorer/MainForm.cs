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
using Task_1_Explorer.Properties;

namespace Task_1_Explorer
{
    public partial class MainForm : Form
    {
        ImageList large;
        ImageList small;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //this.treeView.BeforeSelect += TreeView_BeforeSelect;
            this.treeView.BeforeExpand += TreeView_BeforeExpand;

            this.FillWithLogicalDisks();

            large = this.imageList;
            
            small = this.imageList;

            
            // TODO FIX HACK !!!
            this.listView.SmallImageList = small;
            this.listView.LargeImageList = large;

            large.ImageSize = new Size(64, 64);
            small.ImageSize = new Size(32, 32);
            //this.listView.View = View.SmallIcon;
            this.listView.View = View.List;
            //this.listView.StateImageList.Images = 


            //////this.treeView.SelectedNode = this.treeView.Nodes[0];
            this.treeView.AfterSelect += TreeView_AfterSelect;

        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                this.imageList.Images.Clear();  // чтоб не смещались соотношения картинок.
                                                // TODO нужно вручную добавить картинку папки.
                this.imageList.Images.Add("folder.png", Resources.folder);

                this.listView.Items.Clear();
                DirectoryInfo nodeDirInfo = new DirectoryInfo(e.Node.FullPath);


                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(dir.Name);
                    this.listView.Items.Add(dirInfo.Name, "folder.png");
                }

                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    FileInfo fileInfo = new FileInfo(file.Name);
                    this.imageList.Images.Add(file.Name, Icon.ExtractAssociatedIcon(file.FullName));
                    this.listView.Items.Add(file.Name, file.Name);
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
        //private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        //{
        //    //this.FillingNodeBeforeSelectionAndOpening(e);
        //    // HACK убрать - чтоб при сворачивании показывало диск в котором были.
        //}

        /// <summary>
        /// Обработчик события перед раскрытием узла.
        /// </summary>
        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.FillingNodeBeforeSelection(e);
        }

        private void FillingNodeBeforeSelection(TreeViewCancelEventArgs e)
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

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            large.ImageSize = new Size(64, 64);
            this.listView.LargeImageList.ImageSize = new Size(64, 64);
            this.listView.View = View.LargeIcon;
            
            //this.listView.LargeImageList.Images.Clear();
            //this.listView.LargeImageList = this.imageList;
            

        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView.View = View.SmallIcon;
            //this.listView.SmallImageList.ImageSize = new Size(32, 32);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView.View = View.Tile;
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.listView.View = View.Details;
        }
    }
}
