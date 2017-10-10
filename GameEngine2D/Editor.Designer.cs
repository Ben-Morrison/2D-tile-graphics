namespace GameEngine2D
{
    partial class Editor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Rooms");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Variables");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Objects");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Connected Rooms");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Events");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Triggers");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Variables");
            this.contextMenuRooms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRoomsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContent = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTextures = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRooms = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusMouse = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusCamera = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBrush = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.toolMove = new System.Windows.Forms.ToolStripButton();
            this.toolTexture = new System.Windows.Forms.ToolStripButton();
            this.toolObject = new System.Windows.Forms.ToolStripButton();
            this.toolErase = new System.Windows.Forms.ToolStripButton();
            this.splitRight = new System.Windows.Forms.SplitContainer();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabGlobal = new System.Windows.Forms.TabPage();
            this.treeGlobal = new System.Windows.Forms.TreeView();
            this.tabRoom = new System.Windows.Forms.TabPage();
            this.treeRoom = new System.Windows.Forms.TreeView();
            this.panelRight = new System.Windows.Forms.Panel();
            this.contextMenuRoom = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuRoomRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuRooms.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).BeginInit();
            this.splitRight.Panel1.SuspendLayout();
            this.splitRight.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabGlobal.SuspendLayout();
            this.tabRoom.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.contextMenuRoom.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuRooms
            // 
            this.contextMenuRooms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRoomsAdd});
            this.contextMenuRooms.Name = "contextMenuRooms";
            this.contextMenuRooms.Size = new System.Drawing.Size(132, 26);
            // 
            // contextMenuRoomsAdd
            // 
            this.contextMenuRoomsAdd.Name = "contextMenuRoomsAdd";
            this.contextMenuRoomsAdd.Size = new System.Drawing.Size(131, 22);
            this.contextMenuRoomsAdd.Text = "Add Room";
            this.contextMenuRoomsAdd.Click += new System.EventHandler(this.contextMenuRoomsAdd_Click);
            // 
            // EditorPanel
            // 
            this.EditorPanel.Location = new System.Drawing.Point(0, 49);
            this.EditorPanel.Name = "EditorPanel";
            this.EditorPanel.Size = new System.Drawing.Size(1280, 720);
            this.EditorPanel.TabIndex = 0;
            this.EditorPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditorPanel_MouseDown);
            this.EditorPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EditorPanel_MouseMove);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuContent,
            this.menuRooms,
            this.menuView,
            this.menuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1628, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNew,
            this.menuOpen,
            this.toolStripSeparator,
            this.menuSave,
            this.menuSaveAs,
            this.toolStripSeparator1,
            this.menuClose,
            this.toolStripSeparator2,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuNew
            // 
            this.menuNew.Image = ((System.Drawing.Image)(resources.GetObject("menuNew.Image")));
            this.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuNew.Name = "menuNew";
            this.menuNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuNew.Size = new System.Drawing.Size(146, 22);
            this.menuNew.Text = "&New";
            this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
            // 
            // menuOpen
            // 
            this.menuOpen.Image = ((System.Drawing.Image)(resources.GetObject("menuOpen.Image")));
            this.menuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuOpen.Size = new System.Drawing.Size(146, 22);
            this.menuOpen.Text = "&Open";
            this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // menuSave
            // 
            this.menuSave.Image = ((System.Drawing.Image)(resources.GetObject("menuSave.Image")));
            this.menuSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(146, 22);
            this.menuSave.Text = "&Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(146, 22);
            this.menuSaveAs.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(146, 22);
            this.menuClose.Text = "&Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(146, 22);
            this.menuExit.Text = "E&xit";
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUndo,
            this.menuRedo,
            this.toolStripSeparator3,
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.toolStripSeparator4,
            this.menuSelectAll});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(39, 20);
            this.menuEdit.Text = "&Edit";
            // 
            // menuUndo
            // 
            this.menuUndo.Name = "menuUndo";
            this.menuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.menuUndo.Size = new System.Drawing.Size(144, 22);
            this.menuUndo.Text = "&Undo";
            // 
            // menuRedo
            // 
            this.menuRedo.Name = "menuRedo";
            this.menuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.menuRedo.Size = new System.Drawing.Size(144, 22);
            this.menuRedo.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // menuCut
            // 
            this.menuCut.Image = ((System.Drawing.Image)(resources.GetObject("menuCut.Image")));
            this.menuCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCut.Name = "menuCut";
            this.menuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.menuCut.Size = new System.Drawing.Size(144, 22);
            this.menuCut.Text = "Cu&t";
            // 
            // menuCopy
            // 
            this.menuCopy.Image = ((System.Drawing.Image)(resources.GetObject("menuCopy.Image")));
            this.menuCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCopy.Name = "menuCopy";
            this.menuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.menuCopy.Size = new System.Drawing.Size(144, 22);
            this.menuCopy.Text = "&Copy";
            // 
            // menuPaste
            // 
            this.menuPaste.Image = ((System.Drawing.Image)(resources.GetObject("menuPaste.Image")));
            this.menuPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.menuPaste.Size = new System.Drawing.Size(144, 22);
            this.menuPaste.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // menuSelectAll
            // 
            this.menuSelectAll.Name = "menuSelectAll";
            this.menuSelectAll.Size = new System.Drawing.Size(144, 22);
            this.menuSelectAll.Text = "Select &All";
            // 
            // menuContent
            // 
            this.menuContent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTextures});
            this.menuContent.Name = "menuContent";
            this.menuContent.Size = new System.Drawing.Size(62, 20);
            this.menuContent.Text = "&Content";
            // 
            // menuTextures
            // 
            this.menuTextures.Name = "menuTextures";
            this.menuTextures.Size = new System.Drawing.Size(118, 22);
            this.menuTextures.Text = "Textures";
            this.menuTextures.Click += new System.EventHandler(this.menuTextures_Click);
            // 
            // menuRooms
            // 
            this.menuRooms.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddRoom,
            this.menuRemoveRoom});
            this.menuRooms.Name = "menuRooms";
            this.menuRooms.Size = new System.Drawing.Size(56, 20);
            this.menuRooms.Text = "&Rooms";
            // 
            // menuAddRoom
            // 
            this.menuAddRoom.Name = "menuAddRoom";
            this.menuAddRoom.Size = new System.Drawing.Size(117, 22);
            this.menuAddRoom.Text = "&Add";
            this.menuAddRoom.Click += new System.EventHandler(this.menuAddRoom_Click);
            // 
            // menuRemoveRoom
            // 
            this.menuRemoveRoom.Name = "menuRemoveRoom";
            this.menuRemoveRoom.Size = new System.Drawing.Size(117, 22);
            this.menuRemoveRoom.Text = "&Remove";
            this.menuRemoveRoom.Click += new System.EventHandler(this.menuRemoveRoom_Click);
            // 
            // menuView
            // 
            this.menuView.Name = "menuView";
            this.menuView.Size = new System.Drawing.Size(44, 20);
            this.menuView.Text = "&View";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(116, 22);
            this.menuAbout.Text = "&About...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusMouse,
                this.statusCamera,
                this.statusBrush
            });
            this.statusStrip.Location = new System.Drawing.Point(0, 768);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1628, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusMouse
            // 
            this.statusMouse.Name = "statusMouse";
            this.statusMouse.Size = new System.Drawing.Size(74, 17);
            this.statusMouse.Text = "statusMouse";
            // 
            // statusCamera
            // 
            this.statusCamera.Name = "statusCamera";
            this.statusCamera.Size = new System.Drawing.Size(79, 17);
            this.statusCamera.Text = "statusCamera";
            // 
            // statusBrush
            // 
            this.statusBrush.Name = "statusBrush";
            this.statusBrush.Size = new System.Drawing.Size(68, 17);
            this.statusBrush.Text = "statusBrush";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.toolMove,
            this.toolTexture,
            this.toolObject,
            this.toolErase});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1628, 25);
            this.toolStrip.TabIndex = 11;
            this.toolStrip.Text = "toolStrip";
            // 
            // toolSelect
            // 
            this.toolSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSelect.Image = ((System.Drawing.Image)(resources.GetObject("toolSelect.Image")));
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Size = new System.Drawing.Size(23, 22);
            this.toolSelect.Text = "Select";
            this.toolSelect.Click += new System.EventHandler(this.toolSelect_Click);
            // 
            // toolMove
            // 
            this.toolMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMove.Image = global::GameEngine2D.Properties.Resources.move;
            this.toolMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMove.Name = "toolMove";
            this.toolMove.Size = new System.Drawing.Size(23, 22);
            this.toolMove.Text = "Move";
            this.toolMove.Click += new System.EventHandler(this.toolMove_Click);
            // 
            // toolTexture
            // 
            this.toolTexture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTexture.Image = global::GameEngine2D.Properties.Resources.texture;
            this.toolTexture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTexture.Name = "toolTexture";
            this.toolTexture.Size = new System.Drawing.Size(23, 22);
            this.toolTexture.Text = "Texture";
            this.toolTexture.Click += new System.EventHandler(this.toolTexture_Click);
            // 
            // toolObject
            // 
            this.toolObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolObject.Image = global::GameEngine2D.Properties.Resources._object;
            this.toolObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolObject.Name = "toolObject";
            this.toolObject.Size = new System.Drawing.Size(23, 22);
            this.toolObject.Text = "Object";
            this.toolObject.Click += new System.EventHandler(this.toolObject_Click);
            // 
            // toolErase
            // 
            this.toolErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolErase.Image = global::GameEngine2D.Properties.Resources.erase;
            this.toolErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolErase.Name = "toolErase";
            this.toolErase.Size = new System.Drawing.Size(23, 22);
            this.toolErase.Text = "Erase";
            this.toolErase.Click += new System.EventHandler(this.toolErase_Click);
            // 
            // splitRight
            // 
            this.splitRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitRight.Location = new System.Drawing.Point(0, 0);
            this.splitRight.Name = "splitRight";
            this.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitRight.Panel1
            // 
            this.splitRight.Panel1.Controls.Add(this.tabControl);
            this.splitRight.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitRight.Panel2
            // 
            this.splitRight.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitRight.Size = new System.Drawing.Size(347, 720);
            this.splitRight.SplitterDistance = 360;
            this.splitRight.TabIndex = 12;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabGlobal);
            this.tabControl.Controls.Add(this.tabRoom);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(347, 360);
            this.tabControl.TabIndex = 10;
            // 
            // tabGlobal
            // 
            this.tabGlobal.Controls.Add(this.treeGlobal);
            this.tabGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabGlobal.Name = "tabGlobal";
            this.tabGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobal.Size = new System.Drawing.Size(339, 334);
            this.tabGlobal.TabIndex = 1;
            this.tabGlobal.Text = "Global";
            this.tabGlobal.UseVisualStyleBackColor = true;
            // 
            // treeGlobal
            // 
            this.treeGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeGlobal.Location = new System.Drawing.Point(3, 3);
            this.treeGlobal.Name = "treeGlobal";
            treeNode1.ContextMenuStrip = this.contextMenuRooms;
            treeNode1.Name = "treeGlobalRooms";
            treeNode1.Text = "Rooms";
            treeNode2.Name = "treeGlobalVariables";
            treeNode2.Text = "Variables";
            this.treeGlobal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeGlobal.Size = new System.Drawing.Size(333, 328);
            this.treeGlobal.TabIndex = 10;
            this.treeGlobal.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeGlobal_NodeMouseClick);
            // 
            // tabRoom
            // 
            this.tabRoom.Controls.Add(this.treeRoom);
            this.tabRoom.Location = new System.Drawing.Point(4, 22);
            this.tabRoom.Name = "tabRoom";
            this.tabRoom.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoom.Size = new System.Drawing.Size(339, 334);
            this.tabRoom.TabIndex = 0;
            this.tabRoom.Text = "Current Room";
            this.tabRoom.UseVisualStyleBackColor = true;
            // 
            // treeRoom
            // 
            this.treeRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeRoom.Location = new System.Drawing.Point(3, 3);
            this.treeRoom.Name = "treeRoom";
            treeNode3.Name = "treeRoomObjects";
            treeNode3.Text = "Objects";
            treeNode4.Name = "treeRoomRooms";
            treeNode4.Text = "Connected Rooms";
            treeNode5.Name = "treeRoomEvents";
            treeNode5.Text = "Events";
            treeNode6.Name = "TreeRoomTriggers";
            treeNode6.Text = "Triggers";
            treeNode7.Name = "treeRoomVariables";
            treeNode7.Text = "Variables";
            this.treeRoom.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.treeRoom.Size = new System.Drawing.Size(333, 328);
            this.treeRoom.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRight.Controls.Add(this.splitRight);
            this.panelRight.Location = new System.Drawing.Point(1279, 49);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(347, 720);
            this.panelRight.TabIndex = 13;
            // 
            // contextMenuRoom
            // 
            this.contextMenuRoom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextMenuRoomRemove});
            this.contextMenuRoom.Name = "contextMenuRoom";
            this.contextMenuRoom.Size = new System.Drawing.Size(118, 26);
            this.contextMenuRoom.Text = "Remove";
            // 
            // contextMenuRoomRemove
            // 
            this.contextMenuRoomRemove.Name = "contextMenuRoomRemove";
            this.contextMenuRoomRemove.Size = new System.Drawing.Size(117, 22);
            this.contextMenuRoomRemove.Text = "Remove";
            this.contextMenuRoomRemove.Click += new System.EventHandler(this.contextMenuRoomRemove_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 790);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.EditorPanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Editor";
            this.Text = "Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Editor_FormClosing);
            this.contextMenuRooms.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.splitRight.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitRight)).EndInit();
            this.splitRight.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabGlobal.ResumeLayout(false);
            this.tabRoom.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.contextMenuRoom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel EditorPanel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuNew;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuUndo;
        private System.Windows.Forms.ToolStripMenuItem menuRedo;
        private System.Windows.Forms.ToolStripMenuItem menuCut;
        private System.Windows.Forms.ToolStripMenuItem menuCopy;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripMenuItem menuContent;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripMenuItem menuRooms;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuTextures;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusMouse;
        private System.Windows.Forms.ToolStripStatusLabel statusCamera;
        private System.Windows.Forms.ToolStripStatusLabel statusBrush;
        private System.Windows.Forms.SplitContainer splitRight;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabRoom;
        private System.Windows.Forms.TreeView treeRoom;
        private System.Windows.Forms.TabPage tabGlobal;
        private System.Windows.Forms.TreeView treeGlobal;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuAddRoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuRooms;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRoomsAdd;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveRoom;
        private System.Windows.Forms.ContextMenuStrip contextMenuRoom;
        private System.Windows.Forms.ToolStripMenuItem contextMenuRoomRemove;
        private System.Windows.Forms.ToolStripButton toolSelect;
        private System.Windows.Forms.ToolStripButton toolMove;
        private System.Windows.Forms.ToolStripButton toolTexture;
        private System.Windows.Forms.ToolStripButton toolObject;
        private System.Windows.Forms.ToolStripButton toolErase;
    }
}