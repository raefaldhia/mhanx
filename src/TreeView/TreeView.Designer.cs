namespace Mhanxx
{
    partial class TreeView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeView));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.folderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.folderAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.folderAddExistingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderAddNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.folderCut = new System.Windows.Forms.ToolStripMenuItem();
            this.folderCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.folderPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.folderDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.folderRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.OpenFolderinFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fileCut = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.fileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.fileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.folderContextMenuStrip.SuspendLayout();
            this.fileContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "localServer");
            this.imageList.Images.SetKeyName(1, "remoteServer");
            this.imageList.Images.SetKeyName(2, "Project");
            this.imageList.Images.SetKeyName(3, "localFolder");
            this.imageList.Images.SetKeyName(4, "localFolderOpen");
            this.imageList.Images.SetKeyName(5, "localDocument");
            // 
            // folderContextMenuStrip
            // 
            this.folderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderAdd,
            this.toolStripSeparator1,
            this.folderCut,
            this.folderCopy,
            this.folderPaste,
            this.folderDelete,
            this.folderRename,
            this.toolStripSeparator2,
            this.OpenFolderinFileExplorer});
            this.folderContextMenuStrip.Name = "folderContextMenuStrip";
            this.folderContextMenuStrip.Size = new System.Drawing.Size(219, 170);
            // 
            // folderAdd
            // 
            this.folderAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderAddExistingItem,
            this.folderAddNewFolder});
            this.folderAdd.Name = "folderAdd";
            this.folderAdd.Size = new System.Drawing.Size(218, 22);
            this.folderAdd.Text = "Add";
            // 
            // folderAddExistingItem
            // 
            this.folderAddExistingItem.Image = ((System.Drawing.Image)(resources.GetObject("folderAddExistingItem.Image")));
            this.folderAddExistingItem.Name = "folderAddExistingItem";
            this.folderAddExistingItem.Size = new System.Drawing.Size(150, 22);
            this.folderAddExistingItem.Text = "Existing Item...";
            // 
            // folderAddNewFolder
            // 
            this.folderAddNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("folderAddNewFolder.Image")));
            this.folderAddNewFolder.Name = "folderAddNewFolder";
            this.folderAddNewFolder.Size = new System.Drawing.Size(150, 22);
            this.folderAddNewFolder.Text = "New Folder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // folderCut
            // 
            this.folderCut.Image = ((System.Drawing.Image)(resources.GetObject("folderCut.Image")));
            this.folderCut.Name = "folderCut";
            this.folderCut.Size = new System.Drawing.Size(218, 22);
            this.folderCut.Text = "Cut";
            // 
            // folderCopy
            // 
            this.folderCopy.Image = ((System.Drawing.Image)(resources.GetObject("folderCopy.Image")));
            this.folderCopy.Name = "folderCopy";
            this.folderCopy.Size = new System.Drawing.Size(218, 22);
            this.folderCopy.Text = "Copy";
            // 
            // folderPaste
            // 
            this.folderPaste.Enabled = false;
            this.folderPaste.Image = ((System.Drawing.Image)(resources.GetObject("folderPaste.Image")));
            this.folderPaste.Name = "folderPaste";
            this.folderPaste.Size = new System.Drawing.Size(218, 22);
            this.folderPaste.Text = "Paste";
            // 
            // folderDelete
            // 
            this.folderDelete.Image = ((System.Drawing.Image)(resources.GetObject("folderDelete.Image")));
            this.folderDelete.Name = "folderDelete";
            this.folderDelete.Size = new System.Drawing.Size(218, 22);
            this.folderDelete.Text = "Delete";
            // 
            // folderRename
            // 
            this.folderRename.Image = ((System.Drawing.Image)(resources.GetObject("folderRename.Image")));
            this.folderRename.Name = "folderRename";
            this.folderRename.Size = new System.Drawing.Size(218, 22);
            this.folderRename.Text = "Rename";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // OpenFolderinFileExplorer
            // 
            this.OpenFolderinFileExplorer.Image = ((System.Drawing.Image)(resources.GetObject("OpenFolderinFileExplorer.Image")));
            this.OpenFolderinFileExplorer.Name = "OpenFolderinFileExplorer";
            this.OpenFolderinFileExplorer.Size = new System.Drawing.Size(218, 22);
            this.OpenFolderinFileExplorer.Text = "Open Folder in File Explorer";
            // 
            // fileContextMenuStrip
            // 
            this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpen,
            this.toolStripSeparator3,
            this.fileCut,
            this.fileCopy,
            this.fileDelete,
            this.fileRename});
            this.fileContextMenuStrip.Name = "fileContextMenuStrip";
            this.fileContextMenuStrip.Size = new System.Drawing.Size(118, 120);
            // 
            // fileOpen
            // 
            this.fileOpen.Image = ((System.Drawing.Image)(resources.GetObject("fileOpen.Image")));
            this.fileOpen.Name = "fileOpen";
            this.fileOpen.Size = new System.Drawing.Size(117, 22);
            this.fileOpen.Text = "Open";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(114, 6);
            // 
            // fileCut
            // 
            this.fileCut.Image = ((System.Drawing.Image)(resources.GetObject("fileCut.Image")));
            this.fileCut.Name = "fileCut";
            this.fileCut.Size = new System.Drawing.Size(117, 22);
            this.fileCut.Text = "Cut";
            // 
            // fileCopy
            // 
            this.fileCopy.Image = ((System.Drawing.Image)(resources.GetObject("fileCopy.Image")));
            this.fileCopy.Name = "fileCopy";
            this.fileCopy.Size = new System.Drawing.Size(117, 22);
            this.fileCopy.Text = "Copy";
            // 
            // fileDelete
            // 
            this.fileDelete.Image = ((System.Drawing.Image)(resources.GetObject("fileDelete.Image")));
            this.fileDelete.Name = "fileDelete";
            this.fileDelete.Size = new System.Drawing.Size(117, 22);
            this.fileDelete.Text = "Delete";
            // 
            // fileRename
            // 
            this.fileRename.Image = ((System.Drawing.Image)(resources.GetObject("fileRename.Image")));
            this.fileRename.Name = "fileRename";
            this.fileRename.Size = new System.Drawing.Size(117, 22);
            this.fileRename.Text = "Rename";
            // 
            // TreeView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.folderContextMenuStrip.ResumeLayout(false);
            this.fileContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip folderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem folderAdd;
        private System.Windows.Forms.ToolStripMenuItem folderAddExistingItem;
        private System.Windows.Forms.ToolStripMenuItem folderAddNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem folderCut;
        private System.Windows.Forms.ToolStripMenuItem folderCopy;
        private System.Windows.Forms.ToolStripMenuItem folderPaste;
        private System.Windows.Forms.ToolStripMenuItem folderDelete;
        private System.Windows.Forms.ToolStripMenuItem folderRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderinFileExplorer;
        private System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem fileCut;
        private System.Windows.Forms.ToolStripMenuItem fileCopy;
        private System.Windows.Forms.ToolStripMenuItem fileDelete;
        private System.Windows.Forms.ToolStripMenuItem fileRename;
    }
}
