using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Desktop.Media;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Newtone.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;

            InitializeGlobalVariables();
            GlobalData.LoadTags();
            Task.Run(async () => await GlobalLoader.Load()).Wait();
            GlobalData.LoadConfig();

            SetContainer(new NormalWindow());
        }

        private void InitializeGlobalVariables()
        {
            GlobalData.Artists = new Dictionary<string, List<string>>();
            GlobalData.Audios = new Dictionary<string, Core.Media.MediaSource>();
            GlobalData.AudioTags = new Dictionary<string, Core.Media.MediaSourceTag>();
            GlobalData.DownloadedIds = new List<string>();
            GlobalData.CurrentPlaylist = new List<Core.Media.MediaSource>();
            GlobalData.CurrentQueue = new List<Core.Media.MediaSource>();
            GlobalData.DataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)+"\\NSEC.Newtone";
            GlobalData.MusicPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\NSEC.Newtone";

            //ConsoleDebug.WriteLine(GlobalData.DataPath);
            //ConsoleDebug.WriteLine(GlobalData.MusicPath);

            Directory.CreateDirectory(GlobalData.DataPath);
            Directory.CreateDirectory(GlobalData.MusicPath);

            GlobalData.History = new List<Core.Models.HistoryModel>();
            GlobalData.LastTracks = new Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];
            GlobalData.MostTracks = new Core.Logic.TrackCounter[GlobalData.MAXTRACKSINLASTLIST];

            GlobalData.PlayerMode = Core.Media.PlayerMode.All;
            GlobalData.Playlists = new Dictionary<string, List<string>>();
            GlobalData.PlaylistType = Core.Media.MediaSource.SourceType.Local;
            GlobalData.MediaPlayer = new Core.Media.CrossPlayer(new DesktopMediaPlayer());
            GlobalData.MediaPlayer.SetPlayerController(new LocalPlayerController());

            GlobalData.ExcludedPaths = new List<string>();
            GlobalData.IncludedPaths = new List<string>()
            {
                GlobalData.MusicPath,
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)
            };
            //GlobalData.MediaPlayer.Load("D:\\chillwagon - @ (trailer).m4a");
            //GlobalData.MediaPlayer.Play();
        }

        private void MediaNext_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GlobalData.MediaPlayer.Next();
        }

        private void MediaPrev_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GlobalData.MediaPlayer.Prev();
        }

        private void MediaPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (GlobalData.MediaSource != null)
            {
                if (GlobalData.MediaPlayer.IsPlaying)
                    GlobalData.MediaPlayer.Pause();
                else
                    GlobalData.MediaPlayer.Play();
            }
        }

        public void SetContainer(UserControl control)
        {
            container.Children.Clear();
            container.Children.Add(control);
        }

        public double[] CalculateSubWindowPosition(double width, double height)//x; y
        {
            double[] ret = new double[] { 0, 0 };

            double halfW = width / 2;
            double halfH = height / 2;

            ret[0] = (Left + (Width / 2)) - halfW;
            ret[1] = (Top + (Height / 2)) - halfH;

            return ret;
        }
    }
}
