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
        private ImageList large;
        private ImageList small;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.treeView.BeforeExpand += TreeView_BeforeExpand;

            this.FillWithLogicalDisks();

            this.imageList.ColorDepth = ColorDepth.Depth32Bit;

            large = this.imageList;
            small = this.imageList;
            
            // TODO FIX HACK !!!
            this.listView.SmallImageList = small;
            this.listView.LargeImageList = large;
            
            this.listView.View = View.List;


            this.treeView.AfterSelect += TreeView_AfterSelect;


        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.FillListView(e.Node.FullPath);
            
        }

        private void FillListView(string fullPath)
        {
            try
            {
                this.imageList.Images.Clear();  // чтоб не смещались соотношения картинок.
                                                // TODO нужно вручную добавить картинку папки.
                this.imageList.Images.Add("folder.png", Resources.folder);

                this.listView.Items.Clear();
                DirectoryInfo nodeDirInfo = new DirectoryInfo(fullPath);


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
            catch (Exception) { }
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
            this.listView.LargeImageList = large;
            this.listView.View = View.LargeIcon;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            small.ImageSize = new Size(32, 32);
            this.listView.SmallImageList = small;
            this.listView.View = View.SmallIcon;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            small.ImageSize = new Size(20, 20);
            this.listView.SmallImageList = small;
            this.listView.View = View.Tile;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            small.ImageSize = new Size(16, 16);
            this.listView.SmallImageList = small;
            this.listView.View = View.List;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            small.ImageSize = new Size(12, 12);
            this.listView.SmallImageList = small;
            this.listView.View = View.Details;

            this.FillListView(this.treeView.SelectedNode.FullPath);

            this.listView.Columns.Add("Имя");
            listView.Columns[0].Width = 200;
            this.listView.Columns.Add("Дата изменения");
            listView.Columns[1].Width = 100;
            this.listView.Columns.Add("Размер");
            listView.Columns[1].Width = 100;


            int i = 0;
            foreach (ListViewItem item in this.listView.Items)
            {
                //item.SubItems.Add(this.listView.Items[i++].Text.ToString());

                //DirectoryInfo dirInfo = new DirectoryInfo(this.listView.Items[i++].Text.ToString());
                FileInfo fileInfo = new FileInfo(this.listView.Items[i++].Text.ToString());
                //DateTime dt = File.GetLastWriteTime(dirInfo.Name);

                try
                {
                    item.SubItems.Add(fileInfo.Length.ToString());
                }
                catch (Exception)
                {

                    
                }
                
            }

            //for (int i = 0; i < this.listView.Items.Count; i++)
            //{
            //    this.listView
            //}
        }


    }
}
