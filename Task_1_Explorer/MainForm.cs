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
        private ImageList largeList;
        private ImageList smallList;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.treeView.BeforeExpand += TreeView_BeforeExpand;
            this.treeView.AfterSelect += TreeView_AfterSelect;


            this.FillWithLogicalDisks();


            this.imageList.ColorDepth = ColorDepth.Depth32Bit;

            largeList = this.imageList;
            smallList = this.imageList;
            
            this.listView.SmallImageList = smallList;
            this.listView.LargeImageList = largeList;

            smallList.ImageSize = new Size(24, 24);
            this.listView.View = View.Tile;

            this.listView.Columns.Add("Имя");
            this.listView.Columns.Add("Дата изменения");
            this.listView.Columns.Add("Размер");

            this.listView.FullRowSelect = true;
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
                // Добавляем картинку для папок.
                this.imageList.Images.Add("folder.png", Resources.folder);
                // Чистим listView перед заполнением.
                this.listView.Items.Clear();

                DirectoryInfo nodeDirInfo = new DirectoryInfo(fullPath);
                
                foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
                {
                    this.listView.Items.Add(dir.Name, "folder.png");
                    
                    this.listView.Items[this.listView.Items.Count - 1]
                        .SubItems.Add(dir.LastWriteTime.ToString());
                }

                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    if (this.IsFileTheImage(file) == true)
                    {
                        this.imageList.Images.Add(
                            file.Name, Image.FromFile(file.FullName));
                    }
                    else
                    {
                        this.imageList.Images.Add(
                            file.Name, Icon.ExtractAssociatedIcon(file.FullName));
                    }

                    this.listView.Items.Add(file.Name, file.Name);

                    this.listView.Items[this.listView.Items.Count - 1]
                        .SubItems.Add(file.LastWriteTime.ToString());
                    this.listView.Items[this.listView.Items.Count - 1]
                        .SubItems.Add((file.Length / 1024).ToString() + " КБ");
                }
                
            }
            catch (Exception) { }
        }

        private bool IsFileTheImage(FileInfo file)
        {
            if (file.Extension == ".jpg"
                || file.Extension == ".jpeg"
                || file.Extension == ".png")
            {
                return true;
            }
            else
            {
                return false;
            }
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
            largeList.ImageSize = new Size(64, 64);
            this.listView.LargeImageList = largeList;
            this.listView.View = View.LargeIcon;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallList.ImageSize = new Size(32, 32);
            this.listView.SmallImageList = smallList;
            this.listView.View = View.SmallIcon;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallList.ImageSize = new Size(24, 24);
            this.listView.SmallImageList = smallList;
            this.listView.View = View.Tile;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallList.ImageSize = new Size(16, 16);
            this.listView.SmallImageList = smallList;
            this.listView.View = View.List;

            

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallList.ImageSize = new Size(12, 12);
            this.listView.SmallImageList = smallList;
            this.listView.View = View.Details;


            listView.Columns[0].Width = 200;
            listView.Columns[1].Width = 150;
            listView.Columns[2].Width = 150;

            this.FillListView(this.treeView.SelectedNode.FullPath);
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView.Items.Count != 0)
            {
                this.labelNameFileOrDir.Text = this.listView.SelectedItems[this.listView.SelectedItems.Count - 1].Text;

                //foreach (ListView item in this.listView.SelectedItems)
                //{

                //}
                
            }
        }


    }
}
