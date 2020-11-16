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
        #region Properties
        private string FilePath { get; set; }
        private bool IsImage
        {
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

            if (!string.IsNullOrWhiteSpace(artistBox.Text) && !string.IsNullOrWhiteSpace(titleBox.Text))
            {
                string userArtist = artistBox.Text;
                string userTitle = titleBox.Text;

                if (userArtist != null && userTitle != null)
                {
                    if (!GlobalData.Current.AudioTags.ContainsKey(FilePath))
                    {
                        GlobalData.Current.AudioTags.Add(FilePath, new Newtone.Core.Media.MediaSourceTag() { Author = userArtist, Title = userTitle });
                    }

                    GlobalData.Current.AudioTags[FilePath].Author = userArtist;
                    GlobalData.Current.AudioTags[FilePath].Title = userTitle;
                    var newSource = GlobalData.Current.Audios[FilePath].Clone();
                    newSource.Title = userTitle;
                    newSource.Artist = userArtist;

                    if (NewImage != null && NewImage.Length > 0)
                        newSource.Image = NewImage;
                    GlobalLoader.ChangeTrack(GlobalData.Current.Audios[FilePath], newSource);
                    GlobalData.Current.SaveTags();
                    GlobalData.Current.Messenger.Show(Core.Logic.MessageGenerator.EMessageType.Snackbar ,Core.Languages.Localization.Ready);
                }
                AfterEdit = true;
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
                    //Ignore
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsImage)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PNG (*.png)|*.png"
                };
                if (saveFileDialog.ShowDialog(MainWindow.Instance) == true)
                    File.WriteAllBytes(saveFileDialog.FileName + ".png", Image);
            }
        }
        #endregion
    }
}
