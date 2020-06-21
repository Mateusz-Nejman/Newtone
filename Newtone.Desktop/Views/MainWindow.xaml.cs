using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Logic;
using Newtone.Core.Media;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Media;
using Newtone.Desktop.Processing;
using Newtone.Desktop.ViewModels;
using Newtone.Desktop.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using static Newtone.Desktop.ViewModels.MainViewModel;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Properties
        public static MainWindow Instance { get; set; }
        public static Dispatcher MainDispatcher { get; private set; }
        private MainViewModel ViewModel { get; set; }
        #endregion
        #region Events & Delegates
        public delegate void TopBarButtonClickedEventHandler(object sender, TitleBarButtonEventArgs e);
        public event TopBarButtonClickedEventHandler TopBarButtonClicked;
        #endregion
        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            MainDispatcher = Dispatcher;
            ViewModel = DataContext as MainViewModel;

            SetContainer(new NormalWindow());
            this.MouseDown += MainWindow_MouseDown;
            this.StateChanged += MainWindow_StateChanged;
            TopBarButtonClicked += MainWindow_TopBarButtonClicked;
            

        }
        #endregion
        #region Public Methods
        public void TopBarClick(TitleBarButton button)
        {
            TopBarButtonClicked?.Invoke(this, new TitleBarButtonEventArgs { ButtonIndex = button });
        }
        public void SnackbarShow(string text)
        {
            ViewModel?.ShowSnackbar(text);
        }
        public void SetContainer(UserControl control)
        {
            ViewModel?.SetContainer(this, control);
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
        #endregion
        #region Private Methods
        private void MainWindow_TopBarButtonClicked(object sender, TitleBarButtonEventArgs e)
        {
            ViewModel?.TopBarButtonClicked(sender, e);
        }

        private void MainWindow_StateChanged(object sender, EventArgs e)
        {
            ViewModel?.StateChanged(this);
        }

        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.ChangedButton == MouseButton.Left)
                if (e.ClickCount == 2)
                {
                    var mp = Mouse.GetPosition(this);
                    if(new Rect(0,0,Width,ViewModel?.IsNormalWindow == true ? 60 : 32).Contains(mp))
                    {
                        if (this.WindowState == WindowState.Maximized)
                        {
                            this.WindowState = WindowState.Normal;
                        }
                        else
                        {
                            this.WindowState = WindowState.Maximized;
                        }
                    }
                    
                }
                else
                    this.DragMove();
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
        #endregion
    }
}
