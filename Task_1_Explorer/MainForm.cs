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

            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                if (item.IsReady == true)
                {
                    node = new TreeNode(item.Name);

                    this.treeView.Nodes.Add(node);


                    
                }
            }

            foreach (TreeNode rootNode in this.treeView.Nodes)
            {
                this.AddFoldersRecursively(rootNode, rootNode.FullPath);
            }

            //TreeNode node1 = new TreeNode("1");



            //this.treeView.Nodes.Add(node1);
            ////

            //foreach (TreeNode item in this.treeView.Nodes)
            //{

            //}
        }

        private void AddFoldersRecursively(TreeNode rootNode, string path)
        {
            //TreeNode parentNode = new TreeNode();
            TreeNode parentNode;


            foreach (string folderFullPath in Directory.GetDirectories(path))
            {
                //parentNode.Text = ;
                DirectoryInfo dirInfo = new DirectoryInfo(folderFullPath);
                //parentNode.Text = dirInfo.Name;
                //if (Directory.Exists(folderFullPath) == true)
                //{
                    parentNode = new TreeNode(Path.GetFileName(folderFullPath));

                    rootNode.Nodes.Add(parentNode);

                    this.AddFoldersRecursively(parentNode, folderFullPath);
                //}
            }

            //foreach (TreeNode item1 in nodes)
            //{
            //    foreach (string item2 in Directory.EnumerateDirectories(item1.FullPath))
            //    {
            //        node = new TreeNode(item2);

            //        item1.Nodes.Add(node);
            //    }

            //    foreach (TreeNode item4 in item1.Nodes)
            //    {
            //        foreach (string item3 in Directory.EnumerateDirectories(item4.FullPath))
            //        {
            //            node = new TreeNode(item3);

            //            item4.Nodes.Add(node);
            //        }
            //    }
                
            //}
        }
    }
}
