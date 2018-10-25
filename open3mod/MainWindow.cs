///////////////////////////////////////////////////////////////////////////////////
// Open 3D Model Viewer (open3mod) (v2.0)
// [MainWindow.cs]
// (c) 2012-2015, Open3Mod Contributors
//
// Licensed under the terms and conditions of the 3-clause BSD license. See
// the LICENSE file in the root folder of the repository for the details.
//
// HIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
///////////////////////////////////////////////////////////////////////////////////
#define USE_APP_IDLE


using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

using OpenTK;
using Valve.VR;
#if LEAP
using Leap;
#endif


namespace open3mod
{
    public partial class MainWindow : Form
    {
        bool firstRun = true;
        public const bool useIO = true;

        public static string exePath = "e:\\vr-software\\open3mod-master\\open3mod\\";
        public static string[] recentDataSeparator = new string[] { "::" };
        public static string[] recentItemSeparator = new string[] { ";;" };
        public static NewTek.NDI.Finder NDIFinder;
        NewTek.NDI.Source[] _NDISources;
        NewTek.NDI.Source _selectedNDISource = null;
        public static int mainTiming = 40;
        public static int timeOffset = 0;
        public CapturePreview capturePreview1;
        public CapturePreview capturePreview2;
        public OutputGenerator outputGenerator;

        private readonly UiState _ui;
        private Renderer _renderer;
        private readonly FpsTracker _fps;
        private LogViewer _logViewer;
        private OpenVRInterface _openVRInterface;

        private delegate void DelegateSelectTab(TabPage tab);
        private readonly DelegateSelectTab _delegateSelectTab;
        private delegate void DelegatePopulateInspector(Tab tab);
        private readonly DelegatePopulateInspector _delegatePopulateInspector;

#if LEAP
        private readonly Controller _leapController;
        private readonly LeapListener _leapListener;
#endif

        private readonly bool _initialized;

#if !USE_APP_IDLE
        private System.Windows.Forms.Timer _timer;
#endif


        public delegate void TabAddRemoveHandler (Tab tab, bool add);
        public event TabAddRemoveHandler TabChanged;

        public delegate void TabSelectionChangeHandler(Tab tab);
        public event TabSelectionChangeHandler SelectedTabChanged;
      

        public RenderControl renderControl
        {
            get { return renderControl1; }
        }

        public UiState UiState
        {
            get { return _ui; }
        }

        public FpsTracker Fps
        {
            get { return _fps; }
        }

        public Renderer Renderer
        {
            get { return _renderer; }
        }

        public NewTek.NDI.Source[] NDISources
        {
            get { return _NDISources; }
        }

        public NewTek.NDI.Source NDISource
        {
            get { return _selectedNDISource; }
        }
        public const int MaxRecentItems = 12;



        public MainWindow()
        {

            exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            exePath = exePath.Substring(6);
            string remove = "\\bin\\Debug";
            if (exePath.Substring(exePath.Length - remove.Length) == remove)
                {
                exePath = exePath.Remove(exePath.Length - remove.Length);
            }
            // create delegate used for asynchronous calls 
            _delegateSelectTab = SelectTab;
            _delegatePopulateInspector = PopulateInspector;

             InitializeComponent();
            _captionStub = Text;
            _openVRInterface = new OpenVRInterface();
            OpenVRInterface.fPredictedSecondsToPhotonsFromNow = CoreSettings.CoreSettings.Default.SecondsToPhotons;
            _fps = new FpsTracker();

            // initialize UI state shelf with a default tab
            AddEmptyTab();
            _ui = new UiState(new Tab(_emptyTab, null));

            // sync global UI with UIState
            showVRModelsToolStripMenuItem.Checked = toolStripButtonShowVRModels.Checked = _ui.ShowVRModels;
            framerateToolStripMenuItem.Checked = toolStripButtonShowFPS.Checked = _ui.ShowFps;
            lightingToolStripMenuItem.Checked = toolStripButtonShowShaded.Checked = _ui.RenderLit;
            useSceneLightsToolStripMenuItem.Checked = toolStripButtonUseSceneLights.Checked = _ui.UseSceneLights;
            cullingToolStripMenuItem.Checked = toolStripButtonCulling.Checked = GraphicsSettings.Default.BackFaceCulling;
            texturedToolStripMenuItem.Checked = toolStripButtonShowTextures.Checked = _ui.RenderTextured;
            wireframeToolStripMenuItem.Checked = toolStripButtonWireframe.Checked = _ui.RenderWireframe;
            showNormalVectorsToolStripMenuItem.Checked = toolStripButtonShowNormals.Checked = _ui.ShowNormals;
            showBoundingBoxesToolStripMenuItem.Checked = toolStripButtonShowBB.Checked = _ui.ShowBBs;
            showAnimationSkeletonToolStripMenuItem.Checked = toolStripButtonShowSkeleton.Checked = _ui.ShowSkeleton;

            GraphicsContext[] graphicsContexts = new GraphicsContext[4];
            graphicsContexts[0] = (GraphicsContext)GraphicsContext.CurrentContext;
            if (useIO)
            {
            capturePreview2 = new CapturePreview(this,2);
            capturePreview1 = new CapturePreview(this,1);
            capturePreview1.Location = CoreSettings.CoreSettings.Default.LocationCam1;
            capturePreview2.Location = CoreSettings.CoreSettings.Default.LocationCam2;
            outputGenerator = new OutputGenerator();
            outputGenerator.Location = CoreSettings.CoreSettings.Default.LocationOutput;
            }
            graphicsContexts[0] = (GraphicsContext)GraphicsContext.CurrentContext;
            GraphicsMode gm = new GraphicsMode(new ColorFormat(32), 24, 8, 0);

            // manually register the MouseWheel handler
            renderControl1.MouseWheel += OnMouseMove;

            // intercept all key events sent to children
            KeyPreview = true;
            if (useIO)
            {
                NDIFinder = new NewTek.NDI.Finder(true);
            }
            else
            {
                setDynamicSourceToolStripMenuItem.Text = "Inputs/Outputs are OFF";
            }

#if LEAP
            //LeapMotion Support
            _leapListener = new LeapListener(this as MainWindow);
            _leapController = new Controller(_leapListener);
#endif
            // register listener for tab changes
            tabControl1.SelectedIndexChanged += (object o, EventArgs e) => {
               if (SelectedTabChanged != null)
               {
                   SelectedTabChanged(UiState.TabForId(tabControl1.SelectedTab));
               }
           };

            StartUndoRedoUiStatePollLoop();

            InitRecentList();
            const string installed = "testscenes/scenes/TestCube.fbx";
            string repos;
            repos = "../../../testdata/scenes/PolasVRS-V1.fbx";
            repos = "../../../testdata/scenes/testXYZ.fbx";
            repos = "../../../testdata/scenes/TableTest1mForDae.dae";
            repos = "E:\\vr-software\\Scenes\\PolasVRS-V1.fbx";
            repos = "../../../testdata/scenes/testXYZ.fbx";
            //AddTab(File.Exists(repos) ? repos : installed);
            ProcessPriorityClass Priority = ProcessPriorityClass.High;
            Process MainProcess = Process.GetCurrentProcess();
             MainProcess.PriorityClass = Priority;
            _initialized = true;
            CloseTab(_emptyTab);
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public static NewTek.NDI.Source[] FindNDISources()
        {
            int index = 0;
            NewTek.NDI.Source[] NewNDISources = null;
            for (int i = 0; i < MainWindow.NDIFinder.Sources.Count; i++)
            {
                bool isOwn = false;
                for (int j = 0; j < Renderer.streamName.Length; j++)
                {
                    if (Renderer.streamName[j] == MainWindow.NDIFinder.Sources.ElementAt(i).SourceName) isOwn = true;
                }
                if (!isOwn)
                {
                    if (NewNDISources == null)
                    {
                        NewNDISources = new NewTek.NDI.Source[1];
                    }
                    else
                    {
                        int oldLen = NewNDISources.Length;
                        Array.Resize(ref NewNDISources, oldLen + 1);
                    }
                    NewNDISources[index] = MainWindow.NDIFinder.Sources.ElementAt(i);
                    index++;
                }
            }
            return NewNDISources;
        }


        /// <summary>
        /// Add an "empty" tab if it doesn't exist yet
        /// </summary>

        private void AddEmptyTab()
        {
            // create default tab
            tabControl1.TabPages.Add("empty");
            _emptyTab = tabControl1.TabPages[tabControl1.TabPages.Count-1];
            PopulateUITab(_emptyTab);
            ActivateUiTab(_emptyTab);

            // happens when being called from ctor
            if (_ui != null)
            {
                _ui.AddTab(new Tab(_emptyTab, null));
            }
        }


        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            DelayExecution(TimeSpan.FromSeconds(2),
                MaybeShowTipOfTheDay);

            DelayExecution(TimeSpan.FromSeconds(20),
                MaybeShowDonationDialog);

            if (CoreSettings.CoreSettings.Default.AutoStart && useIO)
            {
                CoreSettings.CoreSettings.Default.Genlock = false;
                CoreSettings.CoreSettings.Default.KeepTimingRight = false;
                int delay = 5;
                DelayExecution(TimeSpan.FromSeconds(delay),
                    capturePreview1.StartCapture);
                //   DelayExecution(TimeSpan.FromSeconds(delay+1),
                //      capturePreview2.StartCapture);
                DelayExecution(TimeSpan.FromSeconds(delay+2),
                    GenlockOn);
                DelayExecution(TimeSpan.FromSeconds(delay+3),
                   outputGenerator.StartRunning);
            }
        }


        private static void GenlockOn()
        {
           CoreSettings.CoreSettings.Default.Genlock = true;
        }

        private static void MaybeShowTipOfTheDay()
        {
            if (CoreSettings.CoreSettings.Default.ShowTipsOnStartup && !useIO)
            {
                var tip = new TipOfTheDayDialog();
                tip.ShowDialog();
            }
        }

        // http://stackoverflow.com/questions/2565166
        public static void DelayExecution(TimeSpan delay, Action action)
        {
            SynchronizationContext context = SynchronizationContext.Current;
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer(
                (_) => {
                    if (timer != null)
                    {
                        timer.Dispose();
                    }
                    context.Post(__ => action(), null);
                }, null, delay, TimeSpan.FromMilliseconds(-1));
        }


        /// <summary>
        /// Initial value for the donation countdown - every time the application is launched,
        /// a counter is decremented. Upon reaching 0, the user is asked to donate.
        /// </summary>
        private const int DonationCounterStart = 1000;


        private static void MaybeShowDonationDialog()
        {
            // first time: init donation countdown
            if (CoreSettings.CoreSettings.Default.DonationUseCountDown == 0)
            {
                CoreSettings.CoreSettings.Default.DonationUseCountDown = DonationCounterStart;
            }

            // -1 means the countdown is disabled, otherwise the dialog is shown when 0 is reached 
            if (CoreSettings.CoreSettings.Default.DonationUseCountDown != -1 &&
                --CoreSettings.CoreSettings.Default.DonationUseCountDown == 0)
            {
                CoreSettings.CoreSettings.Default.DonationUseCountDown = DonationCounterStart;
                var don = new DonationDialog();
                don.ShowDialog();
            }
        }


        private void PopulateUITab(TabPage ui)
        {
            var tui = new TabUiSkeleton();

            tui.Size = ui.ClientSize;
            tui.AutoSize = false;
            tui.Dock = DockStyle.Fill;
            ui.Controls.Add(tui);
        }


        private void ActivateUiTab(TabPage ui)
        {
            ((TabUiSkeleton)ui.Controls[0]).InjectGlControl(renderControl1);
            if (_renderer != null)
            {
                _renderer.TextOverlay.Clear();
            }

            // add postfix to main window title
            if (UiState != null)
            {
                var tab = UiState.TabForId(ui);
                if (tab != null)
                {
                    if (!string.IsNullOrEmpty(tab.File))
                    {
                        Text = _captionStub + "  [" + tab.File + "]";
                    }
                    else
                    {
                        Text = _captionStub;
                    }
                }
            }
        }


        /// <summary>
        /// Open a new tab given a scene file to load. If the specified scene is
        /// already open in a tab, the existing
        /// tab is selected in the UI (if requested) and no tab is added.
        /// </summary>
        /// <param name="file">Source file</param>
        /// <param name="async">Specifies whether the data is loaded asynchr.</param>
        /// <param name="setActive">Specifies whether the newly added tab will
        /// be selected when the loading process is complete.</param>

        public void AddTab(string file, bool async = true, bool setActive = true, bool delayStart = false)
        {
            AddRecentItem(file);

            // check whether the scene is already loaded
            for (int j = 0; j < tabControl1.TabPages.Count; ++j)
            {
                var tab = UiState.TabForId(tabControl1.TabPages[j]);
                Debug.Assert(tab != null);

                if(tab.File == file)
                {
                    // if so, activate its tab and return
                    if(setActive)
                    {
                        SelectTab(tabControl1.TabPages[j]);
                    }

                    return;
                }
            }
            
            var key = GenerateTabKey();
            tabControl1.TabPages.Add(key, GenerateTabCaption(file) + LoadingTitlePostfix);

            var ui = tabControl1.TabPages[key];
            ui.ToolTipText = file;
            tabControl1.ShowToolTips = true;

            PopulateUITab(ui);

            var t = new Tab(ui, file);
            UiState.AddTab(t);

            if (TabChanged != null)
            {
                TabChanged(t, true);
            }

            if (async & false)
            //if (async)..well, but also we need to keep the same thread due to OpenGL
            {
                var th = new Thread(() => OpenFile(t, setActive, delayStart)); //if we are starting the app we need to wait for MainWindow
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                OpenFile(t, setActive);
            }

            if (_emptyTab != null)
            {
               CloseTab(_emptyTab);
            }
        }


        /// <summary>
        /// Initially build the Recent-Files menu
        /// </summary>
        private void InitRecentList()
        {
            //ClearRecentList();
            recentToolStripMenuItem.DropDownItems.Clear();
            var v = CoreSettings.CoreSettings.Default.RecentFiles;
            if (v == null)
            {
                v = CoreSettings.CoreSettings.Default.RecentFiles = new StringCollection();
                CoreSettings.CoreSettings.Default.Save();
            }
            foreach (var s in v)
            {
                var path = s;
                var tool = recentToolStripMenuItem.DropDownItems.Add(Path.GetFileName(path));
                tool.Click += (sender, args) => AddTab(path);
                //path is in collection, we show name only
            }
        }

        /// <summary>
        /// Clears Recent Menu
        /// </summary>
        private void ClearRecentList()
        {
            recentToolStripMenuItem.DropDownItems.Clear();
            var v = CoreSettings.CoreSettings.Default.RecentFiles;
            if (v == null)
            {
                v = CoreSettings.CoreSettings.Default.RecentFiles = new StringCollection();
                CoreSettings.CoreSettings.Default.Save();
            }
            CoreSettings.CoreSettings.Default.RecentFiles.Clear();
        }


        /// <summary>
        /// Add a new item to the Recent-Files menu and save it persistently
        /// </summary>
        /// <param name="file"></param>
        private void AddRecentItem(string file)
        {
            if (string.IsNullOrEmpty(file)) return;
            var recent = CoreSettings.CoreSettings.Default.RecentFiles;
            string removedStr = "";
            bool removed = false;
            int i = 0;
            foreach (var s in recent)
            {
                if ((s == file))
                {
                    recentToolStripMenuItem.DropDownItems.RemoveAt(i);
                    removedStr = s;
                    recent.Remove(s);
                    removed = true;
                    break;
                }
                ++i;
            }

            if (!removed && recent.Count == MaxRecentItems)
            {
                recent.RemoveAt(recent.Count - 1);
            }

            if (removed)
            {
                recent.Insert(0, removedStr);
            }
            else
            {
                recent.Insert(0, file);
            }
            CoreSettings.CoreSettings.Default.Save();

            recentToolStripMenuItem.DropDownItems.Insert(0, new ToolStripMenuItem(
                Path.GetFileName(file), 
                null, 
                (sender, args) => AddTab(file)));
        }

        /// <summary>
        /// Add a new item to the Recent-tabs list menu and save it persistently
        /// </summary>
        /// <param name="file"></param>
        private void AddRecentTabsItem(string file, string tabData)
        {
            var recent = CoreSettings.CoreSettings.Default.RecentTabs;
            if (recent == null)
            {
                recent = CoreSettings.CoreSettings.Default.RecentTabs = new StringCollection();
                CoreSettings.CoreSettings.Default.Save();
            }
            if (string.IsNullOrEmpty(file)) return;
            recent.Insert(0, file + tabData);
            CoreSettings.CoreSettings.Default.Save();
        }

        /// <summary>
        /// Generate a suitable caption to display on a scene tab given a
        /// file name. If multiple contains files with the same names,
        /// their captions are disambiguated.
        /// </summary>
        /// <param name="file">Full path to scene file</param>
        /// <returns></returns>
        private string GenerateTabCaption(string file)
        {
            var name = Path.GetFileName(file);
            for (int j = 0; j < tabControl1.TabPages.Count; ++j )
            {
                if (name == tabControl1.TabPages[j].Text)
                {
                    string numberedName = null;
                    for (int i = 2; numberedName == null; ++i)
                    {
                        numberedName = name + " (" + i + ")";
                        for (int k = 0; k < tabControl1.TabPages.Count; ++k)
                        {
                            if (numberedName == tabControl1.TabPages[k].Text)
                            {
                                numberedName = null;
                                break;
                            }
                        }                    
                    }
                    return numberedName;
                }
            }
            return name;
        }


        /// <summary>
        /// Close a given tab in the UI
        /// </summary>
        /// <param name="tab"></param>
        private void CloseTab(TabPage tab)
        {
            Debug.Assert(tab != null);
            if ((tab == tabControl1.SelectedTab)&& (tab != _emptyTab)) CoreSettings.CoreSettings.Default.ViewsStatus = _ui.ActiveTab.getViewsStatusString();//save active status 
            //AddRecentItem(_ui.ActiveTab.File);

            // If this is the last tab, we need to add an empty tab before we remove it
            if (tabControl1.TabCount == 1)
            {
                if (CoreSettings.CoreSettings.Default.ExitOnTabClosing)
                {
                    Application.Exit();
                    return;
                }
                else
                {
                    AddEmptyTab();
                }
            }

            if (tab == tabControl1.SelectedTab)
            {
                // need to select another tab first
                for (var i = 0; i < tabControl1.TabCount; ++i) 
                {
                    if (tabControl1.TabPages[i] == tab)
                    {
                        continue;
                    }
                    SelectTab(tabControl1.TabPages[i]);
                    break;
                }
            }            

            // free all internal data for this scene
            UiState.RemoveTab(tab);

            // and drop the UI tab
            tabControl1.TabPages.Remove(tab);

            if (TabChanged != null)
            {
                TabChanged((Tab)tab.Tag, false);
            }

            if(_emptyTab == tab)
            {
                _emptyTab = null;
            }
        }


        /// <summary>
        /// Select a given tab in the UI
        /// </summary>
        /// <param name="tab"></param>
        public void SelectTab(TabPage tab)
        {
            Debug.Assert(tab != null);
            CoreSettings.CoreSettings.Default.ViewsStatus = _ui.ActiveTab.getViewsStatusString();//save previous tab last status 
            Matrix4 oldSingleView = Matrix4.Identity;
            var camIn = UiState.ActiveTab.ActiveCameraControllerForView(Tab.ViewIndex.Index4);
            if (camIn != null) oldSingleView = UiState.ActiveTab.ActiveCameraControllerForView(Tab.ViewIndex.Index4).GetViewNoOffset(); 


            tabControl1.SelectedTab = tab;

            var outer = UiState.TabForId(tab);
            Debug.Assert(outer != null);
            // update internal housekeeping
            UiState.SelectTab(tab);

            _ui.ActiveTab.loadViewsStatusString();

            // update UI check boxes
            var vm = _ui.ActiveTab.ActiveViewMode;
            fullViewToolStripMenuItem.CheckState = toolStripButtonFullView.CheckState = 
                vm == Tab.ViewMode.Single 
                ? CheckState.Checked 
                : CheckState.Unchecked;
            twoViewsAToolStripMenuItem.CheckState = toolStripButtonTwoViewsA.CheckState = 
                vm == Tab.ViewMode.TwoVertical 
                ? CheckState.Checked 
                : CheckState.Unchecked;
            twoViewsBToolStripMenuItem.CheckState = toolStripButtonTwoViewsB.CheckState =
                vm == Tab.ViewMode.TwoHorizontal
                ? CheckState.Checked
                : CheckState.Unchecked;
            fourViewsToolStripMenuItem.CheckState = toolStripButtonFourViews.CheckState = 
                vm == Tab.ViewMode.Four 
                ? CheckState.Checked 
                : CheckState.Unchecked;

            // some other UI housekeeping, this also injects the GL panel into the tab
            ActivateUiTab(tab);
            var camOut = UiState.ActiveTab.ActiveCameraControllerForView(Tab.ViewIndex.Index4);
            if ((camIn != null)&& (camOut != null)) camOut.SetViewNoOffset(oldSingleView);
            var insp = UiForTab(_ui.ActiveTab).GetInspector();
            if (insp != null) insp.SelectPlaybackView();
            string statusText = CoreSettings.CoreSettings.Default.UseSceneLights ? "" : " | Keep right mouse button pressed to move light source";
            if (outer.ActiveScene != null)
            {
                statusText += " | Scene scale: " + outer.ActiveScene.Scale.ToString() + "x ";
                toolStripStatistics.Text = outer.ActiveScene.StatsString + statusText;
            }
            else
            {
                toolStripStatistics.Text = statusText;
            }

        }


        private static int _tabCounter;
        private TabPage _tabContextMenuOwner;
        private TabPage _emptyTab;
        private SettingsDialog _settings;
        private Tab.ViewSeparator _dragSeparator = Tab.ViewSeparator._Max;
        private string _captionStub;
        private NormalVectorGeneratorDialog _normalsDialog;
        private const string LoadingTitlePostfix = " (loading)";
        private const string FailedTitlePostfix = " (failed)";

        private string GenerateTabKey()
        {
            return (++_tabCounter).ToString(CultureInfo.InvariantCulture);
        }


        /// <summary>
        /// Opens a particular 3D model and assigns it to a particular tab.
        /// May be called on a non-GUI-thread.
        /// </summary>
        private void OpenFile(Tab tab, bool setActive, bool delayStart = false)
        {
            try
            {
                if (delayStart) Thread.Sleep(1000);
                tab.ActiveScene = new Scene(tab.File,_renderer);
                CoreSettings.CoreSettings.Default.CountFilesOpened++;
            }
            catch(Exception ex)
            {
                tab.SetFailed(ex.Message);
            }
            var updateTitle = new MethodInvoker(() =>
            {
                var t = (TabPage)tab.Id;
                if (!t.Text.EndsWith(LoadingTitlePostfix))
                {
                    return;
                }
                t.Text = t.Text.Substring(0,t.Text.Length - LoadingTitlePostfix.Length);

                if (tab.State == Tab.TabState.Failed)
                {
                    t.Text = t.Text + FailedTitlePostfix;
                }

            });

            // Must use BeginInvoke() here to make sure it gets executed
            // on the thread hosting the GUI message pump. An exception
            // are potential calls coming from our own c'tor: at this
            // time the window handle is not ready yet and BeginInvoke()
            // is thus not available.
            if (!_initialized)
            {
                if (setActive)
                {
                    SelectTab((TabPage) tab.Id);
                }
                PopulateInspector(tab);
                updateTitle();
            }
            else
            {
                if (setActive)
                {
                    BeginInvoke(_delegateSelectTab, new[] {tab.Id});
                }
                BeginInvoke(_delegatePopulateInspector, new object[] { tab });
                BeginInvoke(updateTitle);
            }
        }


        /// <summary>
        /// Populate the inspector view for a given tab. This can be called
        /// as soon as the scene to be displayed is loaded, i.e. tab.ActiveScene is non-null.
        /// </summary>
        /// <param name="tab"></param>
        public void PopulateInspector(Tab tab)
        {
            var ui = UiForTab(tab);
            Debug.Assert(ui != null);
            var inspector = ui.GetInspector();
            inspector.SetSceneSource(tab.ActiveScene);
        }


        public TabPage TabPageForTab(Tab tab)
        {
            return (TabPage) tab.Id;
        }


        public TabUiSkeleton UiForTab(Tab tab)
        {
            return ((TabUiSkeleton) TabPageForTab(tab).Controls[0]);
        }


        private void ToolsToolStripMenuItemClick(object sender, EventArgs e)
        {

        }


        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            var ab = new About();
            ab.ShowDialog();
        }


        private void OnGlLoad(object sender, EventArgs e)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
            }
            _renderer = new Renderer(this);

#if USE_APP_IDLE
            // register Idle event so we get regular callbacks for drawing
            Application.Idle += ApplicationIdle;
#else
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = mainTiming*4;
            _timer.Tick += ApplicationIdle;
            _timer.Start();

#endif
        }

        private void OnGlResize(object sender, EventArgs e)
        {
            if (_renderer == null) // safeguard in case glControl's Load() wasn't fired yet
            {
                return;
            }
            _renderer.Resize();
        }


        private void GlPaint(object sender, PaintEventArgs e)
        {
            if (_renderer == null) // safeguard in case glControl's Load() wasn't fired yet
            {
                return;
            }
            FrameRender();
        }


        private void ApplicationIdle(object sender, EventArgs e)
        {
            if (IsDisposed)
            {
                return;
            }
         //    if (_renderer.timeTrack) Console.WriteLine("Start AppIdle {0}", _renderer._runsw.Elapsed.TotalMilliseconds);
#if USE_APP_IDLE
            while (renderControl1.IsIdle)
#endif
            {
                if (!CoreSettings.CoreSettings.Default.Genlock)
                {
                    FrameUpdate();
                    FrameRender();
                }

                if (firstRun)
                {
                    CloseTab(_emptyTab);
                    firstRun = false;
                    if (CoreSettings.CoreSettings.Default.RecentTabs != null)
                    {
                        for (int i = CoreSettings.CoreSettings.Default.RecentTabs.Count - 1; i >= 0; i--)
                        {
                            var s = CoreSettings.CoreSettings.Default.RecentTabs[i];
                            string[] recentData = s.Split(recentDataSeparator, StringSplitOptions.None);
                            Thread.Sleep(500);
                            AddTab(recentData[0], true, false, true);
                        }
                    }
                }
                _renderer.timeTrack("End App Idle");
            }
        }

        private void FrameLoop(bool videoFrameArrived, int m_number, IntPtr videoData)
        {
            if (!videoFrameArrived) return;
            if (!CoreSettings.CoreSettings.Default.Genlock) return;
            FrameUpdate();
            FrameRender();
        }


        private void FrameUpdate()
        {
            _fps.Update();
            var delta = _fps.LastFrameDelta;

            _renderer.Update(delta);
            foreach(var tab in UiState.Tabs)
            {
                if (tab.ActiveScene != null)
                {
                    tab.ActiveScene.Update(delta, tab != UiState.ActiveTab);
                }
            }
            ProcessKeys();
            OpenVRInterface.ProcessAllButtons();
        }


        private void FrameRender()
        {
            _renderer.Draw(_ui.ActiveTab);
            _renderer.timeTrack("23-EndDraw");
            renderControl1.CopyToOnScreenFramebuffer();
            _renderer.timeTrack("24-Copied");
            renderControl1.SwapBuffers();
            _renderer.timeTrack("25-BuffSwitched");
        }


        private void ToggleFps(object sender, EventArgs e)
        {
            _ui.ShowFps = !_ui.ShowFps;
            framerateToolStripMenuItem.Checked = toolStripButtonShowFPS.Checked = _ui.ShowFps;
        }

        private void ToggleModels(object sender, EventArgs e)
        {
            _ui.ShowVRModels = !_ui.ShowVRModels;
            showVRModelsToolStripMenuItem.Checked = toolStripButtonShowVRModels.Checked = _ui.ShowVRModels;

        }

        private void ToggleUseSceneLights(object sender, EventArgs e)
        {
            _ui.UseSceneLights = !_ui.UseSceneLights;
            useSceneLightsToolStripMenuItem.Checked = toolStripButtonUseSceneLights.Checked = _ui.UseSceneLights; 
        }

        private void ToggleShading(object sender, EventArgs e)
        {
            _ui.RenderLit = !_ui.RenderLit;
            lightingToolStripMenuItem.Checked = toolStripButtonShowShaded.Checked = _ui.RenderLit;
        }


        private void ToggleTextures(object sender, EventArgs e)
        {
            _ui.RenderTextured = !_ui.RenderTextured;
            texturedToolStripMenuItem.Checked = toolStripButtonShowTextures.Checked = _ui.RenderTextured;
        }


        private void ToggleWireframe(object sender, EventArgs e)
        {
            _ui.RenderWireframe = !_ui.RenderWireframe;
            wireframeToolStripMenuItem.Checked = toolStripButtonWireframe.Checked = _ui.RenderWireframe;
        }


        private void ToggleShowBb(object sender, EventArgs e)
        {
            _ui.ShowBBs = !_ui.ShowBBs;
            showBoundingBoxesToolStripMenuItem.Checked = toolStripButtonShowBB.Checked = _ui.ShowBBs;
        }


        private void ToggleShowNormals(object sender, EventArgs e)
        {
            _ui.ShowNormals = !_ui.ShowNormals;
            showNormalVectorsToolStripMenuItem.Checked = toolStripButtonShowNormals.Checked = _ui.ShowNormals;
        }


        private void ToggleShowSkeleton(object sender, EventArgs e)
        {
            _ui.ShowSkeleton = !_ui.ShowSkeleton;
            showAnimationSkeletonToolStripMenuItem.Checked = toolStripButtonShowSkeleton.Checked = _ui.ShowSkeleton;
        }


        private void ToggleCulling(object sender, EventArgs e)
        {
            GraphicsSettings.Default.BackFaceCulling = !GraphicsSettings.Default.BackFaceCulling;
            cullingToolStripMenuItem.Checked = toolStripButtonCulling.Checked = GraphicsSettings.Default.BackFaceCulling;
            if (UiState.ActiveTab.ActiveScene != null)
                UiState.ActiveTab.ActiveScene.RecreateRenderingBackend();
        }


        private void UncheckViewMode()
        {
            toolStripButtonFullView.CheckState = CheckState.Unchecked;
            toolStripButtonTwoViewsA.CheckState = CheckState.Unchecked;
            toolStripButtonTwoViewsB.CheckState = CheckState.Unchecked;
            toolStripButtonFourViews.CheckState = CheckState.Unchecked;

            fullViewToolStripMenuItem.CheckState = CheckState.Unchecked;
            twoViewsAToolStripMenuItem.CheckState = CheckState.Unchecked;
            twoViewsBToolStripMenuItem.CheckState = CheckState.Unchecked;
            fourViewsToolStripMenuItem.CheckState = CheckState.Unchecked;
        }


        private void ToggleFullView(object sender, EventArgs e)
        {
            if (UiState.ActiveTab.ActiveViewMode == Tab.ViewMode.Single)
            {
                return;
            }
            UiState.ActiveTab.ActiveViewMode = Tab.ViewMode.Single;

            UncheckViewMode();
            toolStripButtonFullView.CheckState = CheckState.Checked;     
            fullViewToolStripMenuItem.CheckState = CheckState.Checked;
        }


        private void ToggleTwoViewsHorizontal(object sender, EventArgs e)
        {
            if (UiState.ActiveTab.ActiveViewMode == Tab.ViewMode.TwoHorizontal)
            {
                return;
            }
            UiState.ActiveTab.ActiveViewMode = Tab.ViewMode.TwoHorizontal;

            UncheckViewMode();
            toolStripButtonTwoViewsB.CheckState = CheckState.Checked;
            twoViewsBToolStripMenuItem.CheckState = CheckState.Checked;
        }


        private void ToggleTwoViews(object sender, EventArgs e)
        {
            if (UiState.ActiveTab.ActiveViewMode == Tab.ViewMode.TwoVertical)
            {
                return;
            }
            UiState.ActiveTab.ActiveViewMode = Tab.ViewMode.TwoVertical;

            UncheckViewMode();
            toolStripButtonTwoViewsA.CheckState = CheckState.Checked;
            twoViewsAToolStripMenuItem.CheckState = CheckState.Checked;
        }


        private void ToggleFourViews(object sender, EventArgs e)
        {
            if (UiState.ActiveTab.ActiveViewMode == Tab.ViewMode.Four)
            {
                return;
            }
            UiState.ActiveTab.ActiveViewMode = Tab.ViewMode.Four;

            UncheckViewMode();
            toolStripButtonFourViews.CheckState = CheckState.Checked;
            fourViewsToolStripMenuItem.CheckState = CheckState.Checked;
        }


        private void OnTabSelected(object sender, TabControlEventArgs e)
        {
            var tab = tabControl1.SelectedTab;

            SelectTab(tab);
        }


        private void OnShowTabContextMenu(object sender, MouseEventArgs e)
        {
            // http://social.msdn.microsoft.com/forums/en-US/winforms/thread/e09d081d-a7f5-479d-bd29-44b6d163ebc8
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    // get the tab's rectangle area and check if it contains the mouse cursor
                    Rectangle r = tabControl1.GetTabRect(i);
                    if (r.Contains(e.Location))
                    {
                        // hack: store the owning tab so the event handlers for
                        // the context menu know on whom they operate
                        _tabContextMenuOwner = tabControl1.TabPages[i];
                        tabContextMenuStrip.Show(tabControl1, e.Location);                    
                    }
                }
            }
        }


        private void OnCloseTabFromContextMenu(object sender, EventArgs e)
        {
            Debug.Assert(_tabContextMenuOwner != null);
            CloseTab(_tabContextMenuOwner);
        }


        private void OnCloseAllTabsButThisFromContextMenu(object sender, EventArgs e)
        {
            Debug.Assert(_tabContextMenuOwner != null);
            while (tabControl1.TabCount > 1)
            {
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    if (_tabContextMenuOwner != tabControl1.TabPages[i])
                    {
                        CloseTab(tabControl1.TabPages[i]);
                    }
                }
            }
        }


        private void OnCloseTab(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                CloseTab(tabControl1.SelectedTab);
            }
        }

        string[] names;

        private void OnFileMenuOpen(object sender, EventArgs e)
        {
            var th = new Thread(() => FileMenuOpenAsync()); 
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            th.Join();
            var first = true;
            if (names != null)
            {
                foreach (var name in names)
                {
                    AddTab(name, false, first);
                    first = false;
                }
            }
        }

        private void FileMenuOpenAsync()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                names = openFileDialog.FileNames;
            }
        }


        private void OnFileMenuCloseAll(object sender, EventArgs e)
        {
            while(tabControl1.TabPages.Count > 1)
            {
                CloseTab(tabControl1.TabPages[0]);
            }
            CloseTab(tabControl1.TabPages[0]);
        }


        private void OnFileMenuRecent(object sender, EventArgs e)
        {

        }


        private void OnFileMenuQuit(object sender, EventArgs e)
        {
            Close();
        }


        private void OnCloseForm(object sender, FormClosedEventArgs e)
        {
            if (useIO)
            {
                capturePreview1.Dispose();
                capturePreview2.Dispose();
                outputGenerator.Dispose();
            }

            UiState.Dispose();
            _renderer.Dispose();
        }


        private void OnShowSettings(object sender, EventArgs e)
        {
            if (_settings == null || _settings.IsDisposed)
            {
                _settings = new SettingsDialog {Main = this};
            }

            if(!_settings.Visible)
            {
                _settings.Show();
            }
        }


        public void CloseSettingsDialog()
        {
            Debug.Assert(_settings != null);
            _settings.Close();
            _settings = null;
        }


        private void OnExport(object sender, EventArgs e)
        {
            var exp = new ExportDialog(this);
            exp.Show(this);
        }


        private void OnDrag(object sender, DragEventArgs e)
        {
            // code based on http://www.codeproject.com/Articles/3598/Drag-and-Drop
            try
            {
                var a = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (a != null && a.GetLength(0) > 0)
                {
                    for (int i = 0, count = a.GetLength(0); i < count; ++i)
                    {
                        var s = a.GetValue(i).ToString();

                        // check if the dragged file is a folder. In this case,
                        // we load all applicable files in the folder.

                        // TODO this means, files with no proper file extension
                        // won't load this way.
                        try
                        {
                            FileAttributes attr = File.GetAttributes(s);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                string[] formats;
                                using (var tempImporter = new Assimp.AssimpContext())
                                {
                                    formats = tempImporter.GetSupportedImportFormats();
                                }

                                string[] files = Directory.GetFiles(s);
                                foreach (var file in files)
                                {
                                    var ext = Path.GetExtension(file);
                                    if (ext == null)
                                    {
                                        continue;
                                    }
                                    var lowerExt = ext.ToLower();
                                    if (formats.Any(format => lowerExt == format))
                                    {
                                        AddTab(file);
                                    }
                                }
                                continue;
                            }
                        }
                        // ReSharper disable EmptyGeneralCatchClause
                        catch (Exception)
                        // ReSharper restore EmptyGeneralCatchClause
                        {
                            // ignore this - AddTab() handles the failure
                        }

                        // Call OpenFile asynchronously.
                        // Explorer instance from which file is dropped is not responding
                        // all the time when DragDrop handler is active, so we need to return
                        // immediately (of particular importance if OpenFile shows MessageBox).
                        AddTab(s);
                    }

                    // in the case Explorer overlaps this form
                    Activate();
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Error in DragDrop function: " + ex.Message);
            }
        }


        private void OnDragEnter(object sender, DragEventArgs e)
        {
            // only accept files for drag and drop
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }


        private void OnLoad(object sender, EventArgs e)
        {
            if (CoreSettings.CoreSettings.Default.Maximized)
            {
                WindowState = FormWindowState.Maximized;
                Location = CoreSettings.CoreSettings.Default.Location;
                Size = CoreSettings.CoreSettings.Default.Size;
            }
            else
            {
                var size = CoreSettings.CoreSettings.Default.Size;
                if (size.Width != 0) // first-time run
                {
                    var location = CoreSettings.CoreSettings.Default.Location;
                    // If the saved location is off-screen, show the window at 0|0. This happens in multi-monitor environments
                    // where the monitor holding open3mod is subsequently removed.
                    Location = Screen.AllScreens.FirstOrDefault(scr => scr.Bounds.Contains(location)) != null ? location : Point.Empty;         
                    Size = size;
                }
            }
        }


        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            if (useIO)
            {
                capturePreview1.StopCapture();
                capturePreview2.StopCapture();
                outputGenerator.StopRunning();
                CoreSettings.CoreSettings.Default.LocationCam1 = capturePreview1.Location;
                CoreSettings.CoreSettings.Default.LocationCam2 = capturePreview2.Location;
                CoreSettings.CoreSettings.Default.LocationOutput = outputGenerator.Location;
            }

            CoreSettings.CoreSettings.Default.ViewsStatus = _ui.ActiveTab.getViewsStatusString();//read status 
            //CoreSettings.CoreSettings.Default.RecentTabsOpened = tabControl1.TabPages.Count;
            if (CoreSettings.CoreSettings.Default.RecentTabs != null) CoreSettings.CoreSettings.Default.RecentTabs.Clear();
            for (int i = 0; i< _ui.Tabs.Count;i++)
            {
                AddRecentTabsItem(_ui.Tabs[i].File,"");
            }
            if (WindowState == FormWindowState.Maximized)
            {
                CoreSettings.CoreSettings.Default.Location = RestoreBounds.Location;
                CoreSettings.CoreSettings.Default.Size = RestoreBounds.Size;
                CoreSettings.CoreSettings.Default.Maximized = true;
            }
            else
            {
                CoreSettings.CoreSettings.Default.Location = Location;
                CoreSettings.CoreSettings.Default.Size = Size;
                CoreSettings.CoreSettings.Default.Maximized = false;
            }
            CoreSettings.CoreSettings.Default.SecondsToPhotons = OpenVRInterface.fPredictedSecondsToPhotonsFromNow;
            CoreSettings.CoreSettings.Default.Save();

#if LEAP
            //Cleanup LeapMotion Controller
            _leapController.RemoveListener(_leapListener);
            _leapController.Dispose();
#endif
        }


        // note: the methods below are in MainWindow_Input.cs
        // Windows Forms Designer keeps re-generating them though.

        partial void OnKeyDown(object sender, KeyEventArgs e);
        partial void OnKeyUp(object sender, KeyEventArgs e);
        partial void OnMouseDown(object sender, MouseEventArgs e);
        partial void OnMouseEnter(object sender, EventArgs e);
        partial void OnMouseLeave(object sender, EventArgs e);
        partial void OnMouseMove(object sender, MouseEventArgs e);
        partial void OnMouseUp(object sender, MouseEventArgs e);
        partial void OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e);


        private void OnTipOfTheDay(object sender, EventArgs e)
        {
            var tip = new TipOfTheDayDialog();
            tip.ShowDialog();
        }


        private void OnDonate(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelDonate.LinkVisited = false;
            var donate = new DonationDialog();
            donate.ShowDialog();
        }


        private void OnSetFileAssociations(object sender, EventArgs e)
        {
            using (var imp = new Assimp.AssimpContext())
            {
                var list = imp.GetSupportedImportFormats();

                // do not associate .xml - it is too generic 
                var filteredList = list.Where(s => s != ".xml").ToArray();           

                var listString = string.Join(", ", filteredList);
                if(DialogResult.OK == MessageBox.Show(this, "The following file extensions will be associated with open3mod: " + listString,
                    "Set file associations",
                    MessageBoxButtons.OKCancel))
                {
                    if (!FileAssociations.SetAssociations(list))
                    {
                        MessageBox.Show(this, "Failed to set file extensions","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this, "File extensions have been successfully associated", "open3mod", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.polas.cz/");
        }

        // Hardcoded sample files with paths adjusted for running from
        // the repository (or standalone version), or from the installed
        // version.

        private void wusonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string repos = "../../../testdata/scenes/spider.obj";
            const string installed = "testscenes/spider/spider.obj";
            AddTab(File.Exists(repos) ? repos : installed);
        }

        private void jeepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string repos = "../../../testdata/redist/jeep/jeep1.ms3d";
            const string installed = "testscenes/jeep/jeep1.ms3d";
            AddTab(File.Exists(repos) ? repos : installed);
        }

        private void duckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string repos = "../../../testdata/redist/duck/duck.dae";
            const string installed = "testscenes/duck/duck.dae";
            AddTab(File.Exists(repos) ? repos : installed);
        }

        private void wustonAnimatedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string repos = "../../../testdata/scenes/Testwuson.X";
            const string installed = "testscenes/wuson/Testwuson.X";
            AddTab(File.Exists(repos) ? repos : installed);
        }

        private void lostEmpireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string repos = "../../../testdata/redist/lost-empire/lost_empire.obj";
            const string installed = "testscenes/lost-empire/lost_empire.obj";
            AddTab(File.Exists(repos) ? repos : installed);
        }


        private void StartUndoRedoUiStatePollLoop()
        {
            // Loop to regularly update the "Undo" and "Redo" buttons.
            // This is sub-optimal performance-wise. Ideally, we should get notified from
            // UndoStack if an item is pushed such that Undo or Redo becomes possible.
            // This however introduces a nasty dependency from a (scene-specific) UndoStack
            // back to MainWindow which design-wise I want to avoid.
            DelayExecution(new TimeSpan(0, 0, 0, 0, 100),
                () => {
                    UpdateUndoRedoUiState();
                    StartUndoRedoUiStatePollLoop();
                });
        }

        private void UpdateUndoRedoUiState()
        {
            var scene = UiState.ActiveTab.ActiveScene;
            if (scene == null)
            {
                toolStripButtonUndo.Enabled = undoToolStripMenuItem.Enabled = false;
                toolStripButtonUndo.ToolTipText = undoToolStripMenuItem.Text = "Undo";
                toolStripButtonRedo.Enabled = redoToolStripMenuItem.Enabled = false;
                toolStripButtonRedo.ToolTipText = redoToolStripMenuItem.Text = "Redo";
                return;
            }
            var undo = scene.UndoStack;
            if (undo.CanUndo())
            {
                toolStripButtonUndo.Enabled = undoToolStripMenuItem.Enabled = true;
                toolStripButtonUndo.ToolTipText = undoToolStripMenuItem.Text = "Undo " + undo.GetUndoDescription();
            }
            else
            {
                toolStripButtonUndo.Enabled = undoToolStripMenuItem.Enabled = false;
                toolStripButtonUndo.ToolTipText = undoToolStripMenuItem.Text = "Undo";
            }

            if (undo.CanRedo())
            {
                toolStripButtonRedo.Enabled = redoToolStripMenuItem.Enabled = true;
                toolStripButtonRedo.ToolTipText = redoToolStripMenuItem.Text = "Redo " + undo.GetRedoDescription();
            }
            else
            {
                toolStripButtonRedo.Enabled = redoToolStripMenuItem.Enabled = false;
                toolStripButtonRedo.ToolTipText = redoToolStripMenuItem.Text = "Redo";
            }
        }

        private void OnGlobalUndo(object sender, EventArgs e)
        {
            var scene = UiState.ActiveTab.ActiveScene;
            if (scene == null)
            {
                return;
            }
            var undo = scene.UndoStack;
            if (!undo.CanUndo())
            {
                return;
            }
            undo.Undo();
        }

        private void OnGlobalRedo(object sender, EventArgs e)
        {
            var scene = UiState.ActiveTab.ActiveScene;
            if (scene == null)
            {
                return;
            }
            var undo = scene.UndoStack;
            if (!undo.CanRedo())
            {
                return;
            }
            undo.Redo();
        }

        private void OnReloadCurrentTab(object sender, EventArgs e)
        {
            var activeTab = UiState.ActiveTab;
            if (activeTab.ActiveScene == null)
            {
                return;
            }
            activeTab.ActiveScene = null;
/*            new Thread(
                () => {
                    activeTab.ActiveScene = new Scene(activeTab.File, _renderer);
                    BeginInvoke(new Action(() => PopulateInspector(activeTab)));
                }).Start();
                */
                //if we keep the same OpenGLContext We cannot start new thread,
                    activeTab.ActiveScene = new Scene(activeTab.File, _renderer);
                    BeginInvoke(new Action(() => PopulateInspector(activeTab)));
        }

        private void OnGenerateNormals(object sender, EventArgs e)
        {
            var activeTab = UiState.ActiveTab;
            if (activeTab.ActiveScene == null)
            {
                return;
            }

            var scene = activeTab.ActiveScene;
            if (_normalsDialog != null)
            {
                _normalsDialog.Close();
                _normalsDialog.Dispose();
                _normalsDialog = null;
            }
            _normalsDialog = new NormalVectorGeneratorDialog(scene, scene.Raw.Meshes, TabPageForTab(activeTab).Text + " (all meshes)");
            _normalsDialog.Show(this);
        }

        private void OnChangeBackgroundColor(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.FullOpen = true;
            colorPicker.Color = CoreSettings.CoreSettings.Default.BackgroundColor;
            colorPicker.ShowDialog();
            CoreSettings.CoreSettings.Default.BackgroundColor = colorPicker.Color;
        }

        private void OnResetBackground(object sender, EventArgs e)
        {
            // Keep in sync with CoreSettings.settings.
            CoreSettings.CoreSettings.Default.BackgroundColor = Color.DarkGray;
        }

        private void OnChangeBackgroundAlpha(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.FullOpen = true;
            colorPicker.Color = CoreSettings.CoreSettings.Default.BackgroundAlpha;
            colorPicker.ShowDialog();
            CoreSettings.CoreSettings.Default.BackgroundAlpha = colorPicker.Color;
        }

        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        private void ShowCaptureWindows_Click(object sender, EventArgs e)
        {
            if (useIO)
            {
                capturePreview1.Show();
                capturePreview2.Show();
                outputGenerator.Show();
            }
        }
        [System.ComponentModel.Browsable(false)]

        public void callFrameLoop(int m_number, IntPtr videoData)
        {
            MethodInvoker method = () => FrameLoop(true, m_number, videoData);

            if (_renderer == null) return;
            _renderer.uploadCameraBuffer(m_number, videoData);
            if (m_number == _renderer.syncCamera)
            {
                if (InvokeRequired)
                {
                    Thread.Sleep(5);
                    BeginInvoke(method);//should not be waiting for FrameLoop
                }
                else
                {
                    method();
                }
            }
        }

        public void handleAudio(int m_number, IntPtr audioData)
        {
            if (m_number == _renderer.syncCamera) outputGenerator.addAudioFrame(audioData);
        }

        private void setDynamicSourceToolStripMenuItem_Click(object senderExt, EventArgs e)
        {
            if (MainWindow.useIO)
            {
                setDynamicSourceToolStripMenuItem.Text = "Loooking for Dynamic Sources";
                _NDISources = MainWindow.FindNDISources();
                if (_NDISources == null) return;
                setDynamicSourceToolStripMenuItem.DropDownItems.Clear();
                for (int i = 0; i < _NDISources.Count(); i++)
                {
                    var Name = _NDISources[i].Name;
                    var tool = setDynamicSourceToolStripMenuItem.DropDownItems.Add(Name);
                    tool.Click += (sender, args) => selectDynamicSource(Name);
                }
                if (_NDISources.Count() > 0) setDynamicSourceToolStripMenuItem.Text = "Choose Dynamic Source";
                else setDynamicSourceToolStripMenuItem.Text = "Find Dynamic Sources";
            }
        }

        private void selectDynamicSource(string Name)
        {
            _selectedNDISource = null;
            for (int i = 0; i < _NDISources.Count(); i++)
            {
                if (Name == _NDISources[i].Name)
                {
                    _selectedNDISource = _NDISources[i];
                    _renderer.ConnectNDI(_NDISources[i]);
                }
            }
        }

        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            GraphicsSettings.Default.Save();
        }
    }

}

/* vi: set shiftwidth=4 tabstop=4: */ 