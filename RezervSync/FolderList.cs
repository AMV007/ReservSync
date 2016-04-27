using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using CommonControls;

namespace RezervSync
{
    public partial class FolderList : UserControl
    {
        c_ErrorDataWork ErrorWorkProc = c_ErrorDataWork.Instance;
        BackgroundWorker CalcSizeWorker;
        private List<string> ignoredSystemFolders=new List<string>();

        public List<string> IgnoredSystemFolders
        {
            get
            {
                return ignoredSystemFolders;
            }
            set
            {
                ignoredSystemFolders = value;
            }
        }

        public FolderList()
        {
            InitializeComponent();
            CalcSizeWorker = new BackgroundWorker();
            CalcSizeWorker.DoWork += new DoWorkEventHandler(CalcSizeWorker_DoWork);
            CalcSizeWorker.ProgressChanged += new ProgressChangedEventHandler(CalcSizeWorker_ProgressChanged);
            CalcSizeWorker.WorkerReportsProgress = true;
            CalcSizeWorker.WorkerSupportsCancellation = true;
            CheckForIllegalCrossThreadCalls = false;           
        }

        ~FolderList()
        {
            CalcSizeWorker.CancelAsync();
            while (CalcSizeWorker.IsBusy)
            {                
                Thread.Sleep(100);
                Application.DoEvents();
                CalcSizeWorker.CancelAsync();
            }
        }

        Queue<TreeNode> ViewSizeFolders = new Queue<TreeNode>();
        AutoResetEvent NewFolderAdded = new AutoResetEvent(false);

        public event EventHandler SizeValueChanged=null;

        public struct s_SizeInfo
        {
            public long SizeChecked;
            public long SuzeUnchecked;
            public bool ProcessRunning;
        }

        private void OnSizeValueChanged(s_SizeInfo SizeInfo)
        {
            if (SizeValueChanged != null)
            {
                SizeValueChanged.Invoke(SizeInfo, EventArgs.Empty);
            }
        }

        long GetFilesSizeFromNodeSize(TreeNode Node)
        {
            string[] Temp = Node.ToolTipText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Temp.Length > 0) return long.Parse(Temp[0]);
            return 0;
        }

        long GetDirsSizeFromNodeSize(TreeNode Node)
        {
            string[] Temp = Node.ToolTipText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Temp.Length > 1) return long.Parse(Temp[1]);
            return 0;
        }

        long GetNodeSize(TreeNode Node)
        {
            long size = 0;
            string[] Temp = Node.ToolTipText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (Temp.Length > 0) size+=long.Parse(Temp[0]);
            if (Temp.Length > 1) size += long.Parse(Temp[1]);
            return size;
        }

        void SetNodeFilesSize(ref TreeNode Node, long FilesSize)
        {
            Node.ToolTipText = FilesSize.ToString() + " " + GetDirsSizeFromNodeSize(Node).ToString();
            Node.Text = ClearSizeString(Node.Text) + " <" + c_CommonFunc.FormatSize(GetNodeSize(Node), 1000) + ">";
        }

        void SetNodeDirSize(ref TreeNode Node, long DirsSize)
        {            
            Node.ToolTipText = GetFilesSizeFromNodeSize(Node).ToString() + " " + DirsSize.ToString();
            Node.Text = ClearSizeString(Node.Text) + " <" + c_CommonFunc.FormatSize(GetNodeSize(Node), 1000) + ">";
        }

        void SetNodeSize(ref TreeNode Node, long FilesSize, long DirsSize)
        {
            Node.ToolTipText = FilesSize.ToString().ToString() + " " + DirsSize.ToString();
            Node.Text = ClearSizeString(Node.Text) + " <" + c_CommonFunc.FormatSize(FilesSize + DirsSize, 1000) + ">";
        }

        void ClearNodeSizeRecheck(TreeNode Node)
        {
            if (!string.IsNullOrEmpty(Node.ToolTipText))
            {
                Node.ToolTipText = Node.ToolTipText.Substring(0, Node.ToolTipText.Length - 2);
            }
        }

        void SetNodeSizeRecheck(TreeNode Node)
        {
            if (!string.IsNullOrEmpty(Node.ToolTipText))
            {
                Node.ToolTipText += " +"; // for size recheck
            }
        }

        bool NeedNodeSizeRecheck(TreeNode Node)
        {
            return Node.ToolTipText.Contains('+');
        }
        

        void CalcSizeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnSizeValueChanged((s_SizeInfo)e.UserState);
        }       

        void CalcSizeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            s_SizeInfo CurrSizeInfo = new s_SizeInfo();
            while (!CalcSizeWorker.CancellationPending)
            {
                if (NewFolderAdded.WaitOne(200, false))
                {
                    while (ViewSizeFolders.Count > 0)
                    {
                        TreeNode CurrNode = ViewSizeFolders.Dequeue();                        
                        try
                        {
                            CurrSizeInfo.ProcessRunning = true;
                            CalcSizeWorker.ReportProgress(0, CurrSizeInfo);
                            if (NeedNodeSizeRecheck(CurrNode))
                            { // only logical size recheck
                                long sizeToAdd = GetNodeSize(CurrNode);
                                if (!CurrNode.Checked) sizeToAdd = -sizeToAdd;
                                ClearNodeSizeRecheck(CurrNode);
                                RecalcNodeSizeUp(CurrNode, sizeToAdd);
                            }
                            else
                            {
                                CalcSizeNode(CurrNode);
                            }
                        }
                        catch (Exception ex)
                        {
                            ErrorWorkProc.ErrorProcess(ex);
                        }
                        finally
                        {
                            CurrSizeInfo.SizeChecked = CalcSizeCheckedForAllNodes(CurrNode.TreeView.Nodes[0]);
                            CurrSizeInfo.ProcessRunning = false;
                            CalcSizeWorker.ReportProgress(0, CurrSizeInfo);
                        }
                    }                    
                }
            }
        }

        long GetFilesSize(DirectoryInfo d)
        {
            long Filesizes = 0;
            if (TestIgnoredSystemFolders(d.Name)) return 0;
            // сначала подсчитываем размер файлов в директории            
            {
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    if (CalcSizeWorker.CancellationPending) return 0;
                    Filesizes += fi.Length;
                }
            }
            return Filesizes;
        }

        void GetDirSizeFull(DirectoryInfo d, ref long FileSize, ref long SubDirSize)
        {
            FileSize = SubDirSize = 0;
            if (TestIgnoredSystemFolders(d.Name)) return;   
            
            // сначала подсчитываем размер файлов в директории            
            FileSize = GetFilesSize(d);

            // потом подсчитываем размер файлов в поддиректориях
            DirectoryInfo[] dis = d.GetDirectories();
            {
                foreach (DirectoryInfo di in dis)
                {
                    if (CalcSizeWorker.CancellationPending) return;
                    long TempFileSize=0, TempDirSize=0;
                    GetDirSizeFull(di, ref TempFileSize, ref TempDirSize);
                    SubDirSize += TempFileSize + TempDirSize;
                }
            }
        }

        void RecalcNodeSizeUp(TreeNode Node, long TreeNodeSizeMinus)
        {            
            if (Node.Parent == null) return;
            TreeNode NodeParent = Node.Parent;
            long DirSize = GetDirsSizeFromNodeSize(NodeParent);
            DirSize += TreeNodeSizeMinus;
            SetNodeDirSize(ref NodeParent, DirSize);
            RecalcNodeSizeUp(NodeParent, TreeNodeSizeMinus);
        }
        
        bool CalcSizeNode(TreeNode Node)
        {
            if (string.IsNullOrEmpty(Node.Text)) return false;
            if (!string.IsNullOrEmpty(Node.ToolTipText)) return true;            
           
            long    NodeFileSize = 0, NodeDirsSize = 0;
           
            if (Node.Nodes.Count > 0 && !string.IsNullOrEmpty(Node.Nodes[0].Text))
            {
                for (int i = 0; i < Node.Nodes.Count; i++)
                {
                    CalcSizeNode(Node.Nodes[i]);
                    if (Node.Nodes[i].Checked != Node.Checked) continue;
                    NodeDirsSize += GetNodeSize(Node.Nodes[i]);                   
                }               
                
                NodeFileSize = GetFilesSize(new DirectoryInfo(ClearSizeString(Node.FullPath)));
            }
            else if (!NeedNodeSizeRecheck(Node))
            {
                GetDirSizeFull(new DirectoryInfo(ClearSizeString(Node.FullPath)), ref NodeFileSize, ref NodeDirsSize);
            }
           
            SetNodeSize(ref Node, NodeFileSize, NodeDirsSize);            
            return true;
        }

        long CalcSizeCheckedForAllNodes(TreeNode Node)
        {
            if (string.IsNullOrEmpty(Node.Text) || !Node.Checked) return 0;

            return GetNodeSize(Node);
        }
        
        public string InitialPath
        {
            set 
            {
                if (string.IsNullOrEmpty(value)) return;
                if (!Directory.Exists(value)) return;

                string IPath = value;
                string[] Dirs = Directory.GetDirectories(IPath);
                if (IPath[IPath.Length - 1] == '\\') IPath = IPath.Substring(0, IPath.Length-1);
                
                treeViewFolders.Nodes.Clear();
                TreeNode TempNode = treeViewFolders.Nodes.Add(IPath);
                TempNode.Checked = true;
                
                if (Dirs.Length > 0)
                {
                    TempNode.Nodes.Add("");
                }                
            }
            get
            {
                if (treeViewFolders.Nodes.Count > 0)
                {
                    return ClearSizeString(treeViewFolders.Nodes[0].Text);
                }
                else return "";
            }
        }

        public string [] UncheckedFolders
        {
            set
            {
                if (value == null) return;
                string ConstInitialPath=InitialPath;
                if(string.IsNullOrEmpty(ConstInitialPath)) return;
               
                for (int i = 0; i < value.Length; i++)
                {
                    string RelativePath = value[i];//.Remove(0, ConstInitialPath.Length);
                    if (string.IsNullOrEmpty(RelativePath)) continue;
                    string[] Parts = RelativePath.Split('\\');
                    TreeNode TempNode = treeViewFolders.Nodes[0];
                    TempNode.Expand();
                    ExpandNode(TempNode);
                    for (int j = 0; j < Parts.Length; j++)
                    {
                        for (int k = 0; k < TempNode.Nodes.Count; k++)
                        {
                            if (ClearSizeString(TempNode.Nodes[k].Text) == Parts[j])
                            {
                                if (j == (Parts.Length - 1))
                                {
                                    TempNode.Nodes[k].Checked = false;
                                }
                                else
                                {
                                    TempNode.Nodes[k].Expand();
                                    ExpandNode(TempNode.Nodes[k]);
                                    TempNode = TempNode.Nodes[k];                                    
                                }
                                break;
                            }
                        }
                    }                    
                }                
            }
            get
            {
                List<string> uncheckedFolders = new List<string>();
                if (treeViewFolders.Nodes.Count > 0)
                {
                    GetUncheckedFolders(treeViewFolders.Nodes[0], ref uncheckedFolders);
                }
                return uncheckedFolders.ToArray();
            }
        }

        void GetUncheckedFolders(TreeNode Node,ref List<string> uncheckedFolders)
        {
            if (string.IsNullOrEmpty(Node.Text)) return;
            if (!Node.Checked)
            {
                uncheckedFolders.Add(ClearSizeString(Node.FullPath).Remove(0, InitialPath.Length));
                return;
            }
            for (int i = 0; i < Node.Nodes.Count; i++)
            {
                GetUncheckedFolders(Node.Nodes[i], ref uncheckedFolders);
            }
        }

        string ClearSizeString(string PathWithSize)
        {            
            if(!PathWithSize.Contains('<')) return PathWithSize;
            int BeginPos = -1;
            int EndPos = -1;
            for (int i = 0; i < PathWithSize.Length; i++)
            {
                if ((BeginPos = PathWithSize.IndexOf('<')) != -1)
                {
                    if ((EndPos = PathWithSize.IndexOf('>')) != -1)
                    {
                        PathWithSize = PathWithSize.Remove(BeginPos-1, EndPos-BeginPos+2);
                    }
                    else PathWithSize = PathWithSize.Substring(0, BeginPos);
                }
                else break;
            }
            return PathWithSize;
        }

        private bool TestIgnoredSystemFolders(string DirName)
        {
            for (int i = 0; i < ignoredSystemFolders.Count; i++)
            {
                if (DirName.Contains(ignoredSystemFolders[i])) return true;
            }
            return false;
        }

        void ExpandNode(TreeNode Node)
        {
            if (Node.Nodes.Count == 0) return;
            if (!string.IsNullOrEmpty(Node.Nodes[0].Text)) return;

            Node.Nodes.Clear();
            string NodeFullPath = ClearSizeString(Node.FullPath);

            // because not get directories from ntfs root
            if (NodeFullPath[NodeFullPath.Length - 1] == ':') NodeFullPath += "\\";

            try
            {
                string[] Dirs = Directory.GetDirectories(NodeFullPath);
                for (int i = 0; i < Dirs.Length; i++)
                {
                    if (string.IsNullOrEmpty(Dirs[i]) ||
                        TestIgnoredSystemFolders(Dirs[i])) continue;

                    int FullPathLen = NodeFullPath.Length + 1;
                    // because incorrect calcilation string length, if last symbol =='\\'
                    if (NodeFullPath[NodeFullPath.Length - 1] == ':' ||
                        NodeFullPath[NodeFullPath.Length - 1] == '\\') FullPathLen -= 1;

                    string NewNodeName = Dirs[i].Substring(FullPathLen, Dirs[i].Length - FullPathLen);
                    TreeNode TempNode = Node.Nodes.Add(NewNodeName);
                    if (calcSize)
                    {
                        AddNodeToCalcSize(TempNode);
                    }
                    TempNode.Checked = Node.Checked;
                    if (Directory.GetDirectories(Dirs[i]).Length > 0)
                    {
                        TempNode.Nodes.Add("");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorWorkProc.ErrorProcess(ex);
            }
        }

        private void treeViewFolders_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {   
            ExpandNode(e.Node);
        }

        void AddNodeToCalcSize(TreeNode Node)
        {
            ViewSizeFolders.Enqueue(Node);
            NewFolderAdded.Set();
        }

        private bool calcSize = false; // need to calc node sizes
        public bool CalcSize
        {            
            set
            {
                calcSize = value;
                if (calcSize)
                {
                    CalcSizeWorker.CancelAsync();
                    while (CalcSizeWorker.IsBusy)
                    {
                        CalcSizeWorker.CancelAsync();
                    }

                    if (treeViewFolders.Nodes.Count > 0)
                    {
                        AddNodeToCalcSize(treeViewFolders.Nodes[0]);
                    }

                    CalcSizeWorker.RunWorkerAsync();
                }
                else
                {
                    CalcSizeWorker.CancelAsync();
                }
            }
            get
            {
                return calcSize;
            }
        }
                
        void CheckNodeDown(TreeNode Node)
        {
            for (int i = 0; i < Node.Nodes.Count; i++)
            {
                if (string.IsNullOrEmpty(Node.Nodes[i].Text)) continue;
                Node.Nodes[i].Checked = Node.Checked;
                CheckNodeDown(Node.Nodes[i]);
            }
        }

        void CheckNodeUp(TreeNode Node)
        {
            if (Node.Checked)
            {
                while (Node.Parent != null)
                {
                    if (!Node.Parent.Checked)
                    {
                        Node.Parent.Checked = true;
                    }
                    Node = Node.Parent;
                }
            }
        }

        public void CheckAll()
        {
            if (treeViewFolders.Nodes.Count > 0)
            {
                treeViewFolders.Nodes[0].Checked = true;
                treeViewFolders_AfterCheck(treeViewFolders, new TreeViewEventArgs(treeViewFolders.Nodes[0], TreeViewAction.ByMouse));
            }
        }

        public void UncheckAll()
        {
            if (treeViewFolders.Nodes.Count > 0)
            {
                treeViewFolders.Nodes[0].Checked = false;
                treeViewFolders_AfterCheck(treeViewFolders, new TreeViewEventArgs(treeViewFolders.Nodes[0], TreeViewAction.ByMouse));
            }
        }

        private void treeViewFolders_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action.ToString() == "Unknown") return;

            SetNodeSizeRecheck(e.Node);
            
            
            CheckNodeDown(e.Node);
            CheckNodeUp(e.Node);
            if (calcSize)
            {
                AddNodeToCalcSize(e.Node);
            }
        }        
    }
}
