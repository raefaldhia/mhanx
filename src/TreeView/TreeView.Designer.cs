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
            this.rootContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rootAddNewProject = new System.Windows.Forms.ToolStripMenuItem();
            this.rootSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.rootOpenFolderinFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.projectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.projectAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.projectAddExistingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectAddNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.projectPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.projectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.projectRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.projectOpenFolderinFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contentFolderAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderAddExistingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderAddNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contentFolderCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFolderRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.contentFolderOpenFolderinFileExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contentFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.contentFileCut = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFileCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contentFileRename = new System.Windows.Forms.ToolStripMenuItem();
            this.rootContextMenuStrip.SuspendLayout();
            this.projectContextMenuStrip.SuspendLayout();
            this.contentFolderContextMenuStrip.SuspendLayout();
            this.contentFileContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootContextMenuStrip
            // 
            this.rootContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rootAddNewProject,
            this.rootSeparator1,
            this.rootOpenFolderinFileExplorer});
            this.rootContextMenuStrip.Name = "rootContextMenuStrip";
            this.rootContextMenuStrip.Size = new System.Drawing.Size(216, 54);
            // 
            // rootAddNewProject
            // 
            this.rootAddNewProject.Name = "rootAddNewProject";
            this.rootAddNewProject.Size = new System.Drawing.Size(215, 22);
            this.rootAddNewProject.Text = "Add New Project";
            // 
            // rootSeparator1
            // 
            this.rootSeparator1.Name = "rootSeparator1";
            this.rootSeparator1.Size = new System.Drawing.Size(212, 6);
            // 
            // rootOpenFolderinFileExplorer
            // 
            this.rootOpenFolderinFileExplorer.Image = ((System.Drawing.Image)(resources.GetObject("rootOpenFolderinFileExplorer.Image")));
            this.rootOpenFolderinFileExplorer.Name = "rootOpenFolderinFileExplorer";
            this.rootOpenFolderinFileExplorer.Size = new System.Drawing.Size(215, 22);
            this.rootOpenFolderinFileExplorer.Text = "Open Folder in FileExplorer";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "localServer");
            this.imageList.Images.SetKeyName(1, "remoteServer");
            this.imageList.Images.SetKeyName(2, "localFolder");
            this.imageList.Images.SetKeyName(3, "localFolderOpen");
            this.imageList.Images.SetKeyName(4, "localDocument");
            this.imageList.Images.SetKeyName(5, "Project");
            // 
            // projectContextMenuStrip
            // 
            this.projectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectAdd,
            this.toolStripSeparator1,
            this.projectPaste,
            this.projectDelete,
            this.projectRename,
            this.toolStripSeparator2,
            this.projectOpenFolderinFileExplorer});
            this.projectContextMenuStrip.Name = "projectContextMenuStrip";
            this.projectContextMenuStrip.Size = new System.Drawing.Size(219, 126);
            // 
            // projectAdd
            // 
            this.projectAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectAddExistingItem,
            this.projectAddNewFolder});
            this.projectAdd.Name = "projectAdd";
            this.projectAdd.Size = new System.Drawing.Size(218, 22);
            this.projectAdd.Text = "Add";
            // 
            // projectAddExistingItem
            // 
            this.projectAddExistingItem.Image = ((System.Drawing.Image)(resources.GetObject("projectAddExistingItem.Image")));
            this.projectAddExistingItem.Name = "projectAddExistingItem";
            this.projectAddExistingItem.Size = new System.Drawing.Size(150, 22);
            this.projectAddExistingItem.Text = "Existing Item...";
            // 
            // projectAddNewFolder
            // 
            this.projectAddNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("projectAddNewFolder.Image")));
            this.projectAddNewFolder.Name = "projectAddNewFolder";
            this.projectAddNewFolder.Size = new System.Drawing.Size(150, 22);
            this.projectAddNewFolder.Text = "New Folder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // projectPaste
            // 
            this.projectPaste.Image = ((System.Drawing.Image)(resources.GetObject("projectPaste.Image")));
            this.projectPaste.Name = "projectPaste";
            this.projectPaste.Size = new System.Drawing.Size(218, 22);
            this.projectPaste.Text = "Paste";
            // 
            // projectDelete
            // 
            this.projectDelete.Image = ((System.Drawing.Image)(resources.GetObject("projectDelete.Image")));
            this.projectDelete.Name = "projectDelete";
            this.projectDelete.Size = new System.Drawing.Size(218, 22);
            this.projectDelete.Text = "Delete";
            // 
            // projectRename
            // 
            this.projectRename.Image = ((System.Drawing.Image)(resources.GetObject("projectRename.Image")));
            this.projectRename.Name = "projectRename";
            this.projectRename.Size = new System.Drawing.Size(218, 22);
            this.projectRename.Text = "Rename";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(215, 6);
            // 
            // projectOpenFolderinFileExplorer
            // 
            this.projectOpenFolderinFileExplorer.Image = ((System.Drawing.Image)(resources.GetObject("projectOpenFolderinFileExplorer.Image")));
            this.projectOpenFolderinFileExplorer.Name = "projectOpenFolderinFileExplorer";
            this.projectOpenFolderinFileExplorer.Size = new System.Drawing.Size(218, 22);
            this.projectOpenFolderinFileExplorer.Text = "Open Folder in File Explorer";
            // 
            // contentFolderContextMenuStrip
            // 
            this.contentFolderContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentFolderAdd,
            this.toolStripSeparator3,
            this.contentFolderCut,
            this.contentFolderCopy,
            this.contentFolderPaste,
            this.contentFolderDelete,
            this.contentFolderRename,
            this.toolStripSeparator4,
            this.contentFolderOpenFolderinFileExplorer});
            this.contentFolderContextMenuStrip.Name = "contentFolderContextMenuStrip";
            this.contentFolderContextMenuStrip.Size = new System.Drawing.Size(219, 170);
            // 
            // contentFolderAdd
            // 
            this.contentFolderAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentFolderAddExistingItem,
            this.contentFolderAddNewFolder});
            this.contentFolderAdd.Name = "contentFolderAdd";
            this.contentFolderAdd.Size = new System.Drawing.Size(218, 22);
            this.contentFolderAdd.Text = "Add";
            // 
            // contentFolderAddExistingItem
            // 
            this.contentFolderAddExistingItem.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderAddExistingItem.Image")));
            this.contentFolderAddExistingItem.Name = "contentFolderAddExistingItem";
            this.contentFolderAddExistingItem.Size = new System.Drawing.Size(150, 22);
            this.contentFolderAddExistingItem.Text = "Existing Item...";
            // 
            // contentFolderAddNewFolder
            // 
            this.contentFolderAddNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderAddNewFolder.Image")));
            this.contentFolderAddNewFolder.Name = "contentFolderAddNewFolder";
            this.contentFolderAddNewFolder.Size = new System.Drawing.Size(150, 22);
            this.contentFolderAddNewFolder.Text = "New Folder";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(215, 6);
            // 
            // contentFolderCut
            // 
            this.contentFolderCut.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderCut.Image")));
            this.contentFolderCut.Name = "contentFolderCut";
            this.contentFolderCut.Size = new System.Drawing.Size(218, 22);
            this.contentFolderCut.Text = "Cut";
            // 
            // contentFolderCopy
            // 
            this.contentFolderCopy.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderCopy.Image")));
            this.contentFolderCopy.Name = "contentFolderCopy";
            this.contentFolderCopy.Size = new System.Drawing.Size(218, 22);
            this.contentFolderCopy.Text = "Copy";
            // 
            // contentFolderPaste
            // 
            this.contentFolderPaste.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderPaste.Image")));
            this.contentFolderPaste.Name = "contentFolderPaste";
            this.contentFolderPaste.Size = new System.Drawing.Size(218, 22);
            this.contentFolderPaste.Text = "Paste";
            // 
            // contentFolderDelete
            // 
            this.contentFolderDelete.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderDelete.Image")));
            this.contentFolderDelete.Name = "contentFolderDelete";
            this.contentFolderDelete.Size = new System.Drawing.Size(218, 22);
            this.contentFolderDelete.Text = "Delete";
            // 
            // contentFolderRename
            // 
            this.contentFolderRename.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderRename.Image")));
            this.contentFolderRename.Name = "contentFolderRename";
            this.contentFolderRename.Size = new System.Drawing.Size(218, 22);
            this.contentFolderRename.Text = "Rename";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(215, 6);
            // 
            // contentFolderOpenFolderinFileExplorer
            // 
            this.contentFolderOpenFolderinFileExplorer.Image = ((System.Drawing.Image)(resources.GetObject("contentFolderOpenFolderinFileExplorer.Image")));
            this.contentFolderOpenFolderinFileExplorer.Name = "contentFolderOpenFolderinFileExplorer";
            this.contentFolderOpenFolderinFileExplorer.Size = new System.Drawing.Size(218, 22);
            this.contentFolderOpenFolderinFileExplorer.Text = "Open Folder in File Explorer";
            // 
            // contentFileContextMenuStrip
            // 
            this.contentFileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentFileOpen,
            this.toolStripSeparator5,
            this.contentFileCut,
            this.contentFileCopy,
            this.contentFileDelete,
            this.contentFileRename});
            this.contentFileContextMenuStrip.Name = "contentFileContextMenuStrip";
            this.contentFileContextMenuStrip.Size = new System.Drawing.Size(118, 120);
            // 
            // contentFileOpen
            // 
            this.contentFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("contentFileOpen.Image")));
            this.contentFileOpen.Name = "contentFileOpen";
            this.contentFileOpen.Size = new System.Drawing.Size(117, 22);
            this.contentFileOpen.Text = "Open";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(114, 6);
            // 
            // contentFileCut
            // 
            this.contentFileCut.Image = ((System.Drawing.Image)(resources.GetObject("contentFileCut.Image")));
            this.contentFileCut.Name = "contentFileCut";
            this.contentFileCut.Size = new System.Drawing.Size(117, 22);
            this.contentFileCut.Text = "Cut";
            // 
            // contentFileCopy
            // 
            this.contentFileCopy.Image = ((System.Drawing.Image)(resources.GetObject("contentFileCopy.Image")));
            this.contentFileCopy.Name = "contentFileCopy";
            this.contentFileCopy.Size = new System.Drawing.Size(117, 22);
            this.contentFileCopy.Text = "Copy";
            // 
            // contentFileDelete
            // 
            this.contentFileDelete.Image = ((System.Drawing.Image)(resources.GetObject("contentFileDelete.Image")));
            this.contentFileDelete.Name = "contentFileDelete";
            this.contentFileDelete.Size = new System.Drawing.Size(117, 22);
            this.contentFileDelete.Text = "Delete";
            // 
            // contentFileRename
            // 
            this.contentFileRename.Image = ((System.Drawing.Image)(resources.GetObject("contentFileRename.Image")));
            this.contentFileRename.Name = "contentFileRename";
            this.contentFileRename.Size = new System.Drawing.Size(117, 22);
            this.contentFileRename.Text = "Rename";
            // 
            // TreeView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.rootContextMenuStrip.ResumeLayout(false);
            this.projectContextMenuStrip.ResumeLayout(false);
            this.contentFolderContextMenuStrip.ResumeLayout(false);
            this.contentFileContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip rootContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem rootAddNewProject;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem rootOpenFolderinFileExplorer;
        private System.Windows.Forms.ToolStripSeparator rootSeparator1;
        private System.Windows.Forms.ContextMenuStrip projectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem projectAdd;
        private System.Windows.Forms.ToolStripMenuItem projectAddExistingItem;
        private System.Windows.Forms.ToolStripMenuItem projectAddNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem projectOpenFolderinFileExplorer;
        private System.Windows.Forms.ToolStripMenuItem projectPaste;
        private System.Windows.Forms.ToolStripMenuItem projectDelete;
        private System.Windows.Forms.ToolStripMenuItem projectRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contentFolderContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contentFolderAdd;
        private System.Windows.Forms.ToolStripMenuItem contentFolderAddExistingItem;
        private System.Windows.Forms.ToolStripMenuItem contentFolderAddNewFolder;
        private System.Windows.Forms.ToolStripMenuItem contentFolderCut;
        private System.Windows.Forms.ToolStripMenuItem contentFolderCopy;
        private System.Windows.Forms.ToolStripMenuItem contentFolderPaste;
        private System.Windows.Forms.ToolStripMenuItem contentFolderDelete;
        private System.Windows.Forms.ToolStripMenuItem contentFolderRename;
        private System.Windows.Forms.ToolStripMenuItem contentFolderOpenFolderinFileExplorer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ContextMenuStrip contentFileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem contentFileOpen;
        private System.Windows.Forms.ToolStripMenuItem contentFileCut;
        private System.Windows.Forms.ToolStripMenuItem contentFileCopy;
        private System.Windows.Forms.ToolStripMenuItem contentFileDelete;
        private System.Windows.Forms.ToolStripMenuItem contentFileRename;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}
