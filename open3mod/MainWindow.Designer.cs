﻿using System.Windows.Forms;
using OpenTK.Graphics;

namespace open3mod
{
    partial class MainWindow
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
            _ui.Dispose();
            //_renderer.Dispose(); //duplicited in OnCloseForm

            if (disposing)
            {               
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.wusonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jeepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wustonAnimatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lostEmpireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.scaleOffsetSceneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateNormalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.fullViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoViewsAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twoViewsBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fourViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texturedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cullingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.framerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showVRModelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.showBoundingBoxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showNormalVectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAnimationSkeletonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSceneLightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundAlphaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetBackgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.logViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDynamicSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showCaptureWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSelectRenderer = new System.Windows.Forms.ToolStrip();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFullView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTwoViewsA = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTwoViewsB = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonFourViews = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonWireframe = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowTextures = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowShaded = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUseSceneLights = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowBB = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowNormals = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCulling = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowSkeleton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShowFPS = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowVRModels = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShowSettings = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonTabClose = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatistics = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.linkLabelDonate = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabelWebsite = new System.Windows.Forms.LinkLabel();
            this.renderControl1 = new open3mod.RenderControl();
            this.trackBarBrightness = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            this.toolStripSelectRenderer.SuspendLayout();
            this.tabContextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItemView,
            this.toolsToolStripMenuItem,
            this.setDynamicSourceToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1051, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.toolStripMenuItemReload,
            this.toolStripSeparator2,
            this.recentToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripSeparator3,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OnFileMenuOpen);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "Close all";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.OnFileMenuCloseAll);
            // 
            // toolStripMenuItemReload
            // 
            this.toolStripMenuItemReload.Name = "toolStripMenuItemReload";
            this.toolStripMenuItemReload.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItemReload.Text = "Reload";
            this.toolStripMenuItemReload.Click += new System.EventHandler(this.OnReloadCurrentTab);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.recentToolStripMenuItem.Text = "Recent";
            this.recentToolStripMenuItem.Click += new System.EventHandler(this.OnFileMenuRecent);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wusonToolStripMenuItem,
            this.jeepToolStripMenuItem,
            this.duckToolStripMenuItem,
            this.wustonAnimatedToolStripMenuItem,
            this.lostEmpireToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem4.Text = "Sample scenes";
            // 
            // wusonToolStripMenuItem
            // 
            this.wusonToolStripMenuItem.Name = "wusonToolStripMenuItem";
            this.wusonToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.wusonToolStripMenuItem.Text = "Spider";
            this.wusonToolStripMenuItem.Click += new System.EventHandler(this.wusonToolStripMenuItem_Click);
            // 
            // jeepToolStripMenuItem
            // 
            this.jeepToolStripMenuItem.Name = "jeepToolStripMenuItem";
            this.jeepToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.jeepToolStripMenuItem.Text = "Jeep";
            this.jeepToolStripMenuItem.Click += new System.EventHandler(this.jeepToolStripMenuItem_Click);
            // 
            // duckToolStripMenuItem
            // 
            this.duckToolStripMenuItem.Name = "duckToolStripMenuItem";
            this.duckToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.duckToolStripMenuItem.Text = "Duck";
            this.duckToolStripMenuItem.Click += new System.EventHandler(this.duckToolStripMenuItem_Click);
            // 
            // wustonAnimatedToolStripMenuItem
            // 
            this.wustonAnimatedToolStripMenuItem.Name = "wustonAnimatedToolStripMenuItem";
            this.wustonAnimatedToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.wustonAnimatedToolStripMenuItem.Text = "Wuson (Animated)";
            this.wustonAnimatedToolStripMenuItem.Click += new System.EventHandler(this.wustonAnimatedToolStripMenuItem_Click);
            // 
            // lostEmpireToolStripMenuItem
            // 
            this.lostEmpireToolStripMenuItem.Name = "lostEmpireToolStripMenuItem";
            this.lostEmpireToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.lostEmpireToolStripMenuItem.Text = "Lost Empire";
            this.lostEmpireToolStripMenuItem.Click += new System.EventHandler(this.lostEmpireToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(148, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.OnFileMenuQuit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator13,
            this.scaleOffsetSceneToolStripMenuItem,
            this.generateNormalsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.OnGlobalUndo);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.OnGlobalRedo);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(166, 6);
            // 
            // scaleOffsetSceneToolStripMenuItem
            // 
            this.scaleOffsetSceneToolStripMenuItem.Enabled = false;
            this.scaleOffsetSceneToolStripMenuItem.Name = "scaleOffsetSceneToolStripMenuItem";
            this.scaleOffsetSceneToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.scaleOffsetSceneToolStripMenuItem.Text = "Scale to Fit";
            // 
            // generateNormalsToolStripMenuItem
            // 
            this.generateNormalsToolStripMenuItem.Name = "generateNormalsToolStripMenuItem";
            this.generateNormalsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.generateNormalsToolStripMenuItem.Text = "Generate Normals";
            this.generateNormalsToolStripMenuItem.Click += new System.EventHandler(this.OnGenerateNormals);
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullViewToolStripMenuItem,
            this.twoViewsAToolStripMenuItem,
            this.twoViewsBToolStripMenuItem,
            this.fourViewsToolStripMenuItem,
            this.toolStripSeparator6,
            this.wireframeToolStripMenuItem,
            this.texturedToolStripMenuItem,
            this.lightingToolStripMenuItem,
            this.cullingToolStripMenuItem,
            this.framerateToolStripMenuItem,
            this.showVRModelsToolStripMenuItem,
            this.toolStripSeparator7,
            this.showBoundingBoxesToolStripMenuItem,
            this.showNormalVectorsToolStripMenuItem,
            this.showAnimationSkeletonToolStripMenuItem,
            this.useSceneLightsToolStripMenuItem,
            this.toolStripSeparator14,
            this.backgroundColorToolStripMenuItem,
            this.backgroundAlphaToolStripMenuItem,
            this.resetBackgroundToolStripMenuItem});
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItemView.Text = "View";
            // 
            // fullViewToolStripMenuItem
            // 
            this.fullViewToolStripMenuItem.CheckOnClick = true;
            this.fullViewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fullViewToolStripMenuItem.Image")));
            this.fullViewToolStripMenuItem.Name = "fullViewToolStripMenuItem";
            this.fullViewToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.fullViewToolStripMenuItem.Text = "Single 3D View (no stream)";
            this.fullViewToolStripMenuItem.Click += new System.EventHandler(this.ToggleFullView);
            // 
            // twoViewsAToolStripMenuItem
            // 
            this.twoViewsAToolStripMenuItem.CheckOnClick = true;
            this.twoViewsAToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("twoViewsAToolStripMenuItem.Image")));
            this.twoViewsAToolStripMenuItem.Name = "twoViewsAToolStripMenuItem";
            this.twoViewsAToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.twoViewsAToolStripMenuItem.Text = "Two 3D Views (A streams)";
            this.twoViewsAToolStripMenuItem.Click += new System.EventHandler(this.ToggleTwoViews);
            // 
            // twoViewsBToolStripMenuItem
            // 
            this.twoViewsBToolStripMenuItem.CheckOnClick = true;
            this.twoViewsBToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("twoViewsBToolStripMenuItem.Image")));
            this.twoViewsBToolStripMenuItem.Name = "twoViewsBToolStripMenuItem";
            this.twoViewsBToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.twoViewsBToolStripMenuItem.Text = "Two 3D Views (B streams)";
            this.twoViewsBToolStripMenuItem.Click += new System.EventHandler(this.ToggleTwoViewsHorizontal);
            // 
            // fourViewsToolStripMenuItem
            // 
            this.fourViewsToolStripMenuItem.CheckOnClick = true;
            this.fourViewsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fourViewsToolStripMenuItem.Image")));
            this.fourViewsToolStripMenuItem.Name = "fourViewsToolStripMenuItem";
            this.fourViewsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.fourViewsToolStripMenuItem.Text = "Four 3D Views (A+B streams)";
            this.fourViewsToolStripMenuItem.Click += new System.EventHandler(this.ToggleFourViews);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(223, 6);
            // 
            // wireframeToolStripMenuItem
            // 
            this.wireframeToolStripMenuItem.CheckOnClick = true;
            this.wireframeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("wireframeToolStripMenuItem.Image")));
            this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
            this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.wireframeToolStripMenuItem.Text = "Wireframe";
            this.wireframeToolStripMenuItem.Click += new System.EventHandler(this.ToggleWireframe);
            // 
            // texturedToolStripMenuItem
            // 
            this.texturedToolStripMenuItem.CheckOnClick = true;
            this.texturedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("texturedToolStripMenuItem.Image")));
            this.texturedToolStripMenuItem.Name = "texturedToolStripMenuItem";
            this.texturedToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.texturedToolStripMenuItem.Text = "Textures";
            this.texturedToolStripMenuItem.Click += new System.EventHandler(this.ToggleTextures);
            // 
            // lightingToolStripMenuItem
            // 
            this.lightingToolStripMenuItem.CheckOnClick = true;
            this.lightingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lightingToolStripMenuItem.Image")));
            this.lightingToolStripMenuItem.Name = "lightingToolStripMenuItem";
            this.lightingToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.lightingToolStripMenuItem.Text = "Lighting";
            this.lightingToolStripMenuItem.Click += new System.EventHandler(this.ToggleShading);
            // 
            // cullingToolStripMenuItem
            // 
            this.cullingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cullingToolStripMenuItem.Image")));
            this.cullingToolStripMenuItem.Name = "cullingToolStripMenuItem";
            this.cullingToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.cullingToolStripMenuItem.Text = "Culling";
            this.cullingToolStripMenuItem.Click += new System.EventHandler(this.ToggleCulling);
            // 
            // framerateToolStripMenuItem
            // 
            this.framerateToolStripMenuItem.CheckOnClick = true;
            this.framerateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("framerateToolStripMenuItem.Image")));
            this.framerateToolStripMenuItem.Name = "framerateToolStripMenuItem";
            this.framerateToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.framerateToolStripMenuItem.Text = "Framerate";
            this.framerateToolStripMenuItem.Click += new System.EventHandler(this.ToggleFps);
            // 
            // showVRModelsToolStripMenuItem
            // 
            this.showVRModelsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showVRModelsToolStripMenuItem.Image")));
            this.showVRModelsToolStripMenuItem.Name = "showVRModelsToolStripMenuItem";
            this.showVRModelsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showVRModelsToolStripMenuItem.Text = "VR Models";
            this.showVRModelsToolStripMenuItem.Click += new System.EventHandler(this.ToggleModels);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(223, 6);
            // 
            // showBoundingBoxesToolStripMenuItem
            // 
            this.showBoundingBoxesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showBoundingBoxesToolStripMenuItem.Image")));
            this.showBoundingBoxesToolStripMenuItem.Name = "showBoundingBoxesToolStripMenuItem";
            this.showBoundingBoxesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showBoundingBoxesToolStripMenuItem.Text = "Bounding Boxes";
            this.showBoundingBoxesToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowBb);
            // 
            // showNormalVectorsToolStripMenuItem
            // 
            this.showNormalVectorsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showNormalVectorsToolStripMenuItem.Image")));
            this.showNormalVectorsToolStripMenuItem.Name = "showNormalVectorsToolStripMenuItem";
            this.showNormalVectorsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showNormalVectorsToolStripMenuItem.Text = "Normal Vectors";
            this.showNormalVectorsToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowNormals);
            // 
            // showAnimationSkeletonToolStripMenuItem
            // 
            this.showAnimationSkeletonToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showAnimationSkeletonToolStripMenuItem.Image")));
            this.showAnimationSkeletonToolStripMenuItem.Name = "showAnimationSkeletonToolStripMenuItem";
            this.showAnimationSkeletonToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.showAnimationSkeletonToolStripMenuItem.Text = "Animation Skeleton";
            this.showAnimationSkeletonToolStripMenuItem.Click += new System.EventHandler(this.ToggleShowSkeleton);
            // 
            // useSceneLightsToolStripMenuItem
            // 
            this.useSceneLightsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("useSceneLightsToolStripMenuItem.Image")));
            this.useSceneLightsToolStripMenuItem.Name = "useSceneLightsToolStripMenuItem";
            this.useSceneLightsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.useSceneLightsToolStripMenuItem.Text = "Use Scene Lights";
            this.useSceneLightsToolStripMenuItem.Click += new System.EventHandler(this.ToggleUseSceneLights);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(223, 6);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background Color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.OnChangeBackgroundColor);
            // 
            // backgroundAlphaToolStripMenuItem
            // 
            this.backgroundAlphaToolStripMenuItem.Name = "backgroundAlphaToolStripMenuItem";
            this.backgroundAlphaToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.backgroundAlphaToolStripMenuItem.Text = "Background Alpha";
            this.backgroundAlphaToolStripMenuItem.Click += new System.EventHandler(this.OnChangeBackgroundAlpha);
            // 
            // resetBackgroundToolStripMenuItem
            // 
            this.resetBackgroundToolStripMenuItem.Name = "resetBackgroundToolStripMenuItem";
            this.resetBackgroundToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.resetBackgroundToolStripMenuItem.Text = "Reset Background";
            this.resetBackgroundToolStripMenuItem.Click += new System.EventHandler(this.OnResetBackground);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripSeparator11,
            this.logViewerToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportAllToolStripMenuItem,
            this.toolStripSeparator8,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.ToolsToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Set file associations";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.OnSetFileAssociations);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(173, 6);
            // 
            // logViewerToolStripMenuItem
            // 
            this.logViewerToolStripMenuItem.Name = "logViewerToolStripMenuItem";
            this.logViewerToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.logViewerToolStripMenuItem.Text = "Log Viewer";
            this.logViewerToolStripMenuItem.Click += new System.EventHandler(this.OnShowLogViewer);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.OnExport);
            // 
            // exportAllToolStripMenuItem
            // 
            this.exportAllToolStripMenuItem.Enabled = false;
            this.exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            this.exportAllToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.exportAllToolStripMenuItem.Text = "Export all";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(173, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OnShowSettings);
            // 
            // setDynamicSourceToolStripMenuItem
            // 
            this.setDynamicSourceToolStripMenuItem.Name = "setDynamicSourceToolStripMenuItem";
            this.setDynamicSourceToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.setDynamicSourceToolStripMenuItem.Text = "Find Dynamic Sources";
            this.setDynamicSourceToolStripMenuItem.Click += new System.EventHandler(this.setDynamicSourceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripSeparator10,
            this.aboutToolStripMenuItem,
            this.showCaptureWindowsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem2.Text = "Tip of the Day";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.OnTipOfTheDay);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(197, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // showCaptureWindowsToolStripMenuItem
            // 
            this.showCaptureWindowsToolStripMenuItem.Name = "showCaptureWindowsToolStripMenuItem";
            this.showCaptureWindowsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.showCaptureWindowsToolStripMenuItem.Text = "Show Capture Windows";
            this.showCaptureWindowsToolStripMenuItem.Click += new System.EventHandler(this.ShowCaptureWindows_Click);
            // 
            // toolStripSelectRenderer
            // 
            this.toolStripSelectRenderer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripButton,
            this.toolStripSeparator12,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSeparator4,
            this.toolStripButtonFullView,
            this.toolStripButtonTwoViewsA,
            this.toolStripButtonTwoViewsB,
            this.toolStripButtonFourViews,
            this.toolStripSeparator15,
            this.toolStripSeparator16,
            this.toolStripSeparator,
            this.toolStripButtonWireframe,
            this.toolStripButtonShowTextures,
            this.toolStripButtonShowShaded,
            this.toolStripButtonUseSceneLights,
            this.toolStripSeparator1,
            this.toolStripButtonShowBB,
            this.toolStripButtonShowNormals,
            this.toolStripButtonCulling,
            this.toolStripButtonShowSkeleton,
            this.toolStripSeparator18,
            this.toolStripSeparator17,
            this.toolStripSeparator5,
            this.toolStripButtonShowFPS,
            this.toolStripButtonShowVRModels,
            this.toolStripButtonShowSettings});
            this.toolStripSelectRenderer.Location = new System.Drawing.Point(0, 24);
            this.toolStripSelectRenderer.Name = "toolStripSelectRenderer";
            this.toolStripSelectRenderer.Size = new System.Drawing.Size(1051, 25);
            this.toolStripSelectRenderer.TabIndex = 2;
            this.toolStripSelectRenderer.Text = "toolStrip1";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.ToolTipText = "Open a 3D file";
            this.openToolStripButton.Click += new System.EventHandler(this.OnFileMenuOpen);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUndo.Image")));
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.Click += new System.EventHandler(this.OnGlobalUndo);
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRedo.Image")));
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.Click += new System.EventHandler(this.OnGlobalRedo);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFullView
            // 
            this.toolStripButtonFullView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFullView.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFullView.Image")));
            this.toolStripButtonFullView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFullView.Name = "toolStripButtonFullView";
            this.toolStripButtonFullView.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFullView.Text = "Full View";
            this.toolStripButtonFullView.ToolTipText = "Show full-size 3D view (not streamed)";
            this.toolStripButtonFullView.Click += new System.EventHandler(this.ToggleFullView);
            // 
            // toolStripButtonTwoViewsA
            // 
            this.toolStripButtonTwoViewsA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTwoViewsA.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTwoViewsA.Image")));
            this.toolStripButtonTwoViewsA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTwoViewsA.Name = "toolStripButtonTwoViewsA";
            this.toolStripButtonTwoViewsA.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTwoViewsA.Text = "Two Views";
            this.toolStripButtonTwoViewsA.ToolTipText = "Split into two 3D views showing A streams";
            this.toolStripButtonTwoViewsA.Click += new System.EventHandler(this.ToggleTwoViews);
            // 
            // toolStripButtonTwoViewsB
            // 
            this.toolStripButtonTwoViewsB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonTwoViewsB.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTwoViewsB.Image")));
            this.toolStripButtonTwoViewsB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTwoViewsB.Name = "toolStripButtonTwoViewsB";
            this.toolStripButtonTwoViewsB.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonTwoViewsB.Text = "Two Views";
            this.toolStripButtonTwoViewsB.ToolTipText = "Split into two 3D views showing B streams";
            this.toolStripButtonTwoViewsB.Click += new System.EventHandler(this.ToggleTwoViewsHorizontal);
            // 
            // toolStripButtonFourViews
            // 
            this.toolStripButtonFourViews.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFourViews.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFourViews.Image")));
            this.toolStripButtonFourViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFourViews.Name = "toolStripButtonFourViews";
            this.toolStripButtonFourViews.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFourViews.Text = "Four Views";
            this.toolStripButtonFourViews.ToolTipText = "Split into four 3D views";
            this.toolStripButtonFourViews.Click += new System.EventHandler(this.ToggleFourViews);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonWireframe
            // 
            this.toolStripButtonWireframe.CheckOnClick = true;
            this.toolStripButtonWireframe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonWireframe.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonWireframe.Image")));
            this.toolStripButtonWireframe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonWireframe.Name = "toolStripButtonWireframe";
            this.toolStripButtonWireframe.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonWireframe.Text = "Enable Wireframe Mode";
            this.toolStripButtonWireframe.ToolTipText = "Enable wireframe mode";
            this.toolStripButtonWireframe.Click += new System.EventHandler(this.ToggleWireframe);
            // 
            // toolStripButtonShowTextures
            // 
            this.toolStripButtonShowTextures.CheckOnClick = true;
            this.toolStripButtonShowTextures.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowTextures.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowTextures.Image")));
            this.toolStripButtonShowTextures.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowTextures.Name = "toolStripButtonShowTextures";
            this.toolStripButtonShowTextures.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowTextures.Text = "Enable Textures";
            this.toolStripButtonShowTextures.ToolTipText = "Enable textures in 3D view";
            this.toolStripButtonShowTextures.Click += new System.EventHandler(this.ToggleTextures);
            // 
            // toolStripButtonShowShaded
            // 
            this.toolStripButtonShowShaded.CheckOnClick = true;
            this.toolStripButtonShowShaded.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowShaded.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowShaded.Image")));
            this.toolStripButtonShowShaded.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowShaded.Name = "toolStripButtonShowShaded";
            this.toolStripButtonShowShaded.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowShaded.Text = "Enable Shading";
            this.toolStripButtonShowShaded.ToolTipText = "Enable shading (lighting) in 3D view";
            this.toolStripButtonShowShaded.Click += new System.EventHandler(this.ToggleShading);
            // 
            // toolStripButtonUseSceneLights
            // 
            this.toolStripButtonUseSceneLights.CheckOnClick = true;
            this.toolStripButtonUseSceneLights.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUseSceneLights.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUseSceneLights.Image")));
            this.toolStripButtonUseSceneLights.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUseSceneLights.Name = "toolStripButtonUseSceneLights";
            this.toolStripButtonUseSceneLights.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUseSceneLights.Text = "Use Scene Lights";
            this.toolStripButtonUseSceneLights.ToolTipText = "Use lights from scene";
            this.toolStripButtonUseSceneLights.Click += new System.EventHandler(this.ToggleUseSceneLights);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowBB
            // 
            this.toolStripButtonShowBB.CheckOnClick = true;
            this.toolStripButtonShowBB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowBB.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowBB.Image")));
            this.toolStripButtonShowBB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowBB.Name = "toolStripButtonShowBB";
            this.toolStripButtonShowBB.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowBB.Text = "Show Bounding Boxes";
            this.toolStripButtonShowBB.ToolTipText = "Show axis-aligned bounding boxes for nodes";
            this.toolStripButtonShowBB.Click += new System.EventHandler(this.ToggleShowBb);
            // 
            // toolStripButtonShowNormals
            // 
            this.toolStripButtonShowNormals.CheckOnClick = true;
            this.toolStripButtonShowNormals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowNormals.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowNormals.Image")));
            this.toolStripButtonShowNormals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowNormals.Name = "toolStripButtonShowNormals";
            this.toolStripButtonShowNormals.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowNormals.Text = "Show Normals";
            this.toolStripButtonShowNormals.ToolTipText = "Show geometric normal vectors";
            this.toolStripButtonShowNormals.Click += new System.EventHandler(this.ToggleShowNormals);
            // 
            // toolStripButtonCulling
            // 
            this.toolStripButtonCulling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCulling.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCulling.Image")));
            this.toolStripButtonCulling.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCulling.Name = "toolStripButtonCulling";
            this.toolStripButtonCulling.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCulling.Text = "toolStripButton1";
            this.toolStripButtonCulling.ToolTipText = "Cull back faces";
            this.toolStripButtonCulling.Click += new System.EventHandler(this.ToggleCulling);
            // 
            // toolStripButtonShowSkeleton
            // 
            this.toolStripButtonShowSkeleton.CheckOnClick = true;
            this.toolStripButtonShowSkeleton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowSkeleton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowSkeleton.Image")));
            this.toolStripButtonShowSkeleton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowSkeleton.Name = "toolStripButtonShowSkeleton";
            this.toolStripButtonShowSkeleton.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowSkeleton.Text = "Show Skeleton";
            this.toolStripButtonShowSkeleton.ToolTipText = "Show skeleton joints in 3D view";
            this.toolStripButtonShowSkeleton.Click += new System.EventHandler(this.ToggleShowSkeleton);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonShowFPS
            // 
            this.toolStripButtonShowFPS.CheckOnClick = true;
            this.toolStripButtonShowFPS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowFPS.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowFPS.Image")));
            this.toolStripButtonShowFPS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowFPS.Name = "toolStripButtonShowFPS";
            this.toolStripButtonShowFPS.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowFPS.Text = "Show Frames per Second (FPS)";
            this.toolStripButtonShowFPS.ToolTipText = "Show frames per second (FPS)";
            this.toolStripButtonShowFPS.Click += new System.EventHandler(this.ToggleFps);
            // 
            // toolStripButtonShowVRModels
            // 
            this.toolStripButtonShowVRModels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowVRModels.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowVRModels.Image")));
            this.toolStripButtonShowVRModels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowVRModels.Name = "toolStripButtonShowVRModels";
            this.toolStripButtonShowVRModels.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowVRModels.Text = "Show VR Models";
            this.toolStripButtonShowVRModels.Click += new System.EventHandler(this.ToggleModels);
            // 
            // toolStripButtonShowSettings
            // 
            this.toolStripButtonShowSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShowSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowSettings.Image")));
            this.toolStripButtonShowSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowSettings.Name = "toolStripButtonShowSettings";
            this.toolStripButtonShowSettings.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonShowSettings.Text = "Settings";
            this.toolStripButtonShowSettings.ToolTipText = "Open settings dialog";
            this.toolStripButtonShowSettings.Click += new System.EventHandler(this.OnShowSettings);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1051, 663);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.OnTabSelected);
            this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnShowTabContextMenu);
            // 
            // tabContextMenuStrip
            // 
            this.tabContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem,
            this.closeAllButThisToolStripMenuItem});
            this.tabContextMenuStrip.Name = "tabContextMenuStrip";
            this.tabContextMenuStrip.Size = new System.Drawing.Size(162, 48);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.OnCloseTabFromContextMenu);
            // 
            // closeAllButThisToolStripMenuItem
            // 
            this.closeAllButThisToolStripMenuItem.Name = "closeAllButThisToolStripMenuItem";
            this.closeAllButThisToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.closeAllButThisToolStripMenuItem.Text = "Close all but this";
            this.closeAllButThisToolStripMenuItem.Click += new System.EventHandler(this.OnCloseAllTabsButThisFromContextMenu);
            // 
            // buttonTabClose
            // 
            this.buttonTabClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTabClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.buttonTabClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTabClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTabClose.Location = new System.Drawing.Point(1008, 32);
            this.buttonTabClose.Name = "buttonTabClose";
            this.buttonTabClose.Size = new System.Drawing.Size(28, 24);
            this.buttonTabClose.TabIndex = 4;
            this.buttonTabClose.Text = "X";
            this.buttonTabClose.UseVisualStyleBackColor = true;
            this.buttonTabClose.Click += new System.EventHandler(this.OnCloseTab);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // toolStripStatistics
            // 
            this.toolStripStatistics.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatistics.Name = "toolStripStatistics";
            this.toolStripStatistics.Size = new System.Drawing.Size(0, 17);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatistics,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 712);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1051, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // linkLabelDonate
            // 
            this.linkLabelDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelDonate.AutoSize = true;
            this.linkLabelDonate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDonate.LinkColor = System.Drawing.Color.Red;
            this.linkLabelDonate.Location = new System.Drawing.Point(991, 9);
            this.linkLabelDonate.Name = "linkLabelDonate";
            this.linkLabelDonate.Size = new System.Drawing.Size(48, 13);
            this.linkLabelDonate.TabIndex = 5;
            this.linkLabelDonate.TabStop = true;
            this.linkLabelDonate.Text = "Donate";
            this.linkLabelDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnDonate);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(806, 713);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Brightness";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelWebsite
            // 
            this.linkLabelWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelWebsite.AutoSize = true;
            this.linkLabelWebsite.Location = new System.Drawing.Point(888, 9);
            this.linkLabelWebsite.Name = "linkLabelWebsite";
            this.linkLabelWebsite.Size = new System.Drawing.Size(97, 13);
            this.linkLabelWebsite.TabIndex = 8;
            this.linkLabelWebsite.TabStop = true;
            this.linkLabelWebsite.Text = "Website / Updates";
            this.linkLabelWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelWebsite_LinkClicked);
            // 
            // renderControl1
            // 
            this.renderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renderControl1.BackColor = System.Drawing.Color.Black;
            this.renderControl1.Location = new System.Drawing.Point(359, 327);
            this.renderControl1.Name = "renderControl1";
            this.renderControl1.Size = new System.Drawing.Size(560, 369);
            this.renderControl1.TabIndex = 0;
            this.renderControl1.VSync = true;
            this.renderControl1.Load += new System.EventHandler(this.OnGlLoad);
            this.renderControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrag);
            this.renderControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.renderControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.GlPaint);
            this.renderControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            this.renderControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.renderControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.renderControl1.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.renderControl1.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.renderControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.renderControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.renderControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.OnPreviewKeyDown);
            this.renderControl1.Resize += new System.EventHandler(this.OnGlResize);
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarBrightness.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.trackBarBrightness.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::open3mod.GraphicsSettings.Default, "OutputBrightness", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trackBarBrightness.Location = new System.Drawing.Point(863, 713);
            this.trackBarBrightness.Margin = new System.Windows.Forms.Padding(0);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(188, 45);
            this.trackBarBrightness.TabIndex = 6;
            this.trackBarBrightness.Value = global::open3mod.GraphicsSettings.Default.OutputBrightness;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1051, 734);
            this.Controls.Add(this.linkLabelWebsite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBarBrightness);
            this.Controls.Add(this.linkLabelDonate);
            this.Controls.Add(this.buttonTabClose);
            this.Controls.Add(this.renderControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStripSelectRenderer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open 3D Model Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnCloseForm);
            this.Load += new System.EventHandler(this.OnLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripSelectRenderer.ResumeLayout(false);
            this.toolStripSelectRenderer.PerformLayout();
            this.tabContextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStripSelectRenderer;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem fullViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonWireframe;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowTextures;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowShaded;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowFPS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonFullView;
        private System.Windows.Forms.ToolStripButton toolStripButtonTwoViewsB;
        private System.Windows.Forms.ToolStripButton toolStripButtonFourViews;
        private System.Windows.Forms.ToolStripMenuItem logViewerToolStripMenuItem;
        private RenderControl renderControl1;
        private TabControl tabControl1;
        private ContextMenuStrip tabContextMenuStrip;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripMenuItem closeAllButThisToolStripMenuItem;
        private Button buttonTabClose;
        private OpenFileDialog openFileDialog;
        private ToolStripButton toolStripButtonShowBB;
        private ToolStripButton toolStripButtonShowNormals;
        private ToolStripButton toolStripButtonShowSkeleton;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton toolStripButtonShowSettings;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem exportAllToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatistics;
        private StatusStrip statusStrip;
        private ToolStripMenuItem twoViewsBToolStripMenuItem;
        private ToolStripMenuItem fourViewsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem wireframeToolStripMenuItem;
        private ToolStripMenuItem texturedToolStripMenuItem;
        private ToolStripMenuItem lightingToolStripMenuItem;
        private ToolStripMenuItem framerateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem showBoundingBoxesToolStripMenuItem;
        private ToolStripMenuItem showNormalVectorsToolStripMenuItem;
        private ToolStripMenuItem showAnimationSkeletonToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator10;
        private LinkLabel linkLabelDonate;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator11;
        private TrackBar trackBarBrightness;
        private Label label1;
        private LinkLabel linkLabelWebsite;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem wusonToolStripMenuItem;
        private ToolStripMenuItem wustonAnimatedToolStripMenuItem;
        private ToolStripMenuItem lostEmpireToolStripMenuItem;
        private ToolStripMenuItem jeepToolStripMenuItem;
        private ToolStripMenuItem duckToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripButton toolStripButtonRedo;
        private ToolStripButton toolStripButtonUndo;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem redoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemReload;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem scaleOffsetSceneToolStripMenuItem;
        private ToolStripMenuItem generateNormalsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem backgroundColorToolStripMenuItem;
        private ToolStripMenuItem resetBackgroundToolStripMenuItem;
        private ToolStripButton toolStripButtonTwoViewsA;
        private ToolStripMenuItem twoViewsAToolStripMenuItem;
        private ToolStripButton toolStripButtonCulling;
        private ToolStripMenuItem cullingToolStripMenuItem;
        private ToolStripMenuItem backgroundAlphaToolStripMenuItem;
        private ToolStripButton toolStripButtonShowVRModels;
        private ToolStripMenuItem showVRModelsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem useSceneLightsToolStripMenuItem;
        private ToolStripButton toolStripButtonUseSceneLights;
        private ToolStripMenuItem showCaptureWindowsToolStripMenuItem;
        private ToolStripMenuItem setDynamicSourceToolStripMenuItem;
    }
}

