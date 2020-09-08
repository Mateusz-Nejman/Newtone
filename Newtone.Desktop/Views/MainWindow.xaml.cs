using Newtone.Core;
using Newtone.Desktop.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            GlobalData.Current.MediaPlayer.Next();
        }

        private void MediaPrev_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            GlobalData.Current.MediaPlayer.Prev();
        }

        private void MediaPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (GlobalData.Current.MediaSource != null)
            {
                if (GlobalData.Current.MediaPlayer.IsPlaying)
                    GlobalData.Current.MediaPlayer.Pause();
                else
                    GlobalData.Current.MediaPlayer.Play();
            }
        }
        #endregion
    }
}
