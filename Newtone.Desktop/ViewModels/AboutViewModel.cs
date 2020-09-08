using Newtone.Core.Logic;
using Newtone.Core.Models;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Input;

namespace Newtone.Desktop.ViewModels
{
    public class AboutViewModel:PropertyChangedBase
    {
        #region Fields
        private string versionText;
        #endregion
        #region Properties
        public string VersionText
        {
            get => versionText;
            set
            {
                versionText = value;
                OnPropertyChanged(() => VersionText);
            }
        }
        #endregion
        #region Commands
        private ICommand openWWW;
        public ICommand OpenWWW
        {
            get
            {
                if (openWWW == null)
                    openWWW = new ActionCommand(parameter =>
                    {
                        var psi = new ProcessStartInfo
                        {
                            FileName = "https://mateusz-nejman.pl/",
                            UseShellExecute = true
                        };
                        Process.Start(psi);
                    });
                return openWWW;
            }
        }
        #endregion
        #region Constructors
        public AboutViewModel()
        {
            VersionText = "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
        #endregion
    }
}
