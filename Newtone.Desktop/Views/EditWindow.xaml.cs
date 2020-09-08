using Microsoft.Win32;
using Newtone.Core;
using Newtone.Core.Loaders;
using Newtone.Core.Media;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Processing;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Newtone.Desktop.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        //TODO Cut files
        #region Properties
        private string FilePath { get; set; }
        private bool IsImage {
            get
            {
                return Image != null && Image.Length > 0;
            }
        }
        private byte[] Image { get; set; }
        public byte[] NewImage { get; private set; }
        public static bool AfterEdit { get; set; }
        #endregion
        #region Constructors
        public EditWindow(string filePath)
        {
            InitializeComponent();

            FilePath = filePath;
            MediaSource source = GlobalData.Current.Audios[filePath];
            artistBox.Text = source.Artist;
            titleBox.Text = source.Title;
            AfterEdit = false;
  
        }
        #endregion
        #region Private Methods
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            if(!string.IsNullOrWhiteSpace(artistBox.Text) && !string.IsNullOrWhiteSpace(titleBox.Text))
            {
                MediaSource newSource = GlobalData.Current.Audios[FilePath].Clone();
                newSource.Title = titleBox.Text;
                newSource.Artist = artistBox.Text;
                if (NewImage != null && NewImage.Length > 0)
                    newSource.Image = NewImage;
                GlobalLoader.ChangeTrack(GlobalData.Current.Audios[FilePath], newSource);
                AfterEdit = true;
                SnackbarBuilder.Show(Core.Languages.Localization.Ready);
                this.Close();
            }
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG (*.png)|*.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ImageSource test = ImageProcessing.FromArray(File.ReadAllBytes(openFileDialog.FileName));

                    NewImage = File.ReadAllBytes(openFileDialog.FileName);

                    image.Source = test;
                }
                catch
                {

                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
           if(IsImage)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG (*.png)|*.png"
                };
                if (saveFileDialog.ShowDialog(MainWindow.Instance) == true)
                    File.WriteAllBytes(saveFileDialog.FileName+".png", Image);
            }
        }
        #endregion
    }
}
