using Microsoft.Win32;
using NAudio.Wave;
using Newtone.Core.Logic;
using Newtone.Core.Models;
using Newtone.Desktop.Logic;
using Newtone.Desktop.Models;
using Newtone.Desktop.Views;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class ConvertViewModel : PropertyChangedBase
    {
        #region Fields
        private int filesToConvert;
        private int convertedFiles;
        private ObservableCollection<ListViewTextModel> items;
        private string outputFolder;
        private int convertType;
        private bool isConverting;
        private string currentFile;
        private bool replaceWithExists;
        #endregion
        #region Properties
        public int FilesToConvert
        {
            get => filesToConvert;
            set
            {
                filesToConvert = value;
                OnPropertyChanged();
                OnPropertyChanged(() => Progress);
            }
        }
        public int ConvertedFiles
        {
            get => convertedFiles;
            set
            {
                convertedFiles = value;
                OnPropertyChanged();
                OnPropertyChanged(() => Progress);
            }
        }
        public string Progress
        {
            get => $"{ConvertedFiles} / {FilesToConvert}";
        }
        public ObservableCollection<ListViewTextModel> Items
        {
            get => items;
            set
            {
                items = value;
                OnPropertyChanged();
            }
        }
        public string OutputFolder
        {
            get => outputFolder;
            set
            {
                outputFolder = value;
                OnPropertyChanged();
            }
        }
        public int ConvertType
        {
            get => convertType;
            set
            {
                convertType = value;
                OnPropertyChanged();
            }
        }
        public bool IsConverting
        {
            get => isConverting;
            set
            {
                isConverting = value;
                OnPropertyChanged();
                OnPropertyChanged(() => IsNotConverting);
                OnPropertyChanged(() => SpinnerVisibility);
            }
        }
        public bool IsNotConverting
        {
            get => !isConverting;
        }
        public Visibility SpinnerVisibility
        {
            get => IsConverting ? Visibility.Visible : Visibility.Hidden;
        }
        public string CurrentFile
        {
            get => currentFile;
            set
            {
                currentFile = value;
                OnPropertyChanged();
            }
        }
        public bool ReplaceWithExists
        {
            get => replaceWithExists;
            set
            {
                replaceWithExists = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Commands
        private ICommand selectFiles;
        public ICommand SelectFiles
        {
            get
            {
                if (selectFiles == null)
                    selectFiles = new ActionCommand(parameter =>
                    {
                        OpenFileDialog fileBrowser = new OpenFileDialog
                        {
                            Multiselect = true,
                            Filter = "Audio Files (*.mp3, *.m4a, *.aac, *.wma)|*.mp3;*.m4a;*.aac;*.wma"
                        };
                        if (fileBrowser.ShowDialog() == true)
                        {
                            Items.Clear();
                            foreach(var item in fileBrowser.FileNames)
                            {
                                FileInfo info = new FileInfo(item);
                                Items.Add(new ListViewTextModel() { Text = info.Name, FilePath = item });
                            }
                            FilesToConvert = Items.Count;
                        }
                    });
                return selectFiles;
            }
        }
        private ICommand convert;
        public ICommand Convert
        {
            get
            {
                if (convert == null)
                    convert = new ActionCommand(parameter =>
                    {
                        if (!string.IsNullOrEmpty(OutputFolder))
                        {
                            IsConverting = true;

                            new Task(() =>
                            {
                                if (ReplaceWithExists)
                                    ConvertType = 0;

                                foreach (var file in Items)
                                {
                                    CurrentFile = file.FilePath;
                                    MediaFoundationReader reader = new MediaFoundationReader(file.FilePath);
                                    FileInfo info = new FileInfo(file.FilePath);
                                    string name = info.Name.Replace(info.Extension, "");

                                    try
                                    {
                                        if (ConvertType == 0)
                                            MediaFoundationEncoder.EncodeToMp3(reader, outputFolder + "/" + name + ".mp3");
                                        else if (convertType == 1)
                                            MediaFoundationEncoder.EncodeToAac(reader, outputFolder + "/" + name + ".aac");
                                        else
                                            MediaFoundationEncoder.EncodeToWma(reader, outputFolder + "/" + name + ".wma");
                                    }
                                    catch
                                    {

                                    }

                                    ConvertedFiles++;
                                }

                                CurrentFile = "";
                                IsConverting = false;
                            }).Start();
                        }
                        else
                        {
                            InfoWindow window = new InfoWindow(Core.Languages.Localization.Warning, Core.Languages.Localization.SelectFolder, "OK");
                            window.CenterToMainWindow();
                            window.ShowDialog();
                        }
                    });
                return convert;
            }
        }
        private ICommand selectOutputFolder;
        public ICommand SelectOutputFolder
        {
            get
            {
                if (selectOutputFolder == null)
                    selectOutputFolder = new ActionCommand(parameter =>
                    {
                        SaveFileDialog folderBrowser = new SaveFileDialog
                        {
                            CheckFileExists = false,
                            CheckPathExists = true,
                            Filter = "Directory | directory",
                            ValidateNames = true,
                            FileName = Core.Languages.Localization.SelectFolder
                        };
                        if (folderBrowser.ShowDialog() == true)
                        {

                            if (Directory.Exists(Path.GetDirectoryName(folderBrowser.FileName)))
                                OutputFolder = Path.GetDirectoryName(folderBrowser.FileName);
                            else
                            {
                                InfoWindow window = new InfoWindow(Core.Languages.Localization.Warning, Core.Languages.Localization.FolderExists, "OK");
                                window.CenterToMainWindow();
                                window.ShowDialog();
                            }
                        }
                    });
                return selectOutputFolder;
            }
        }
        #endregion
        #region Constructors
        public ConvertViewModel()
        {
            Items = new ObservableCollection<ListViewTextModel>();
        }
        #endregion
    }
}
