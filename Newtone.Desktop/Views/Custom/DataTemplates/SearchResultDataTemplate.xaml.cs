using Newtone.Core;
using Newtone.Core.Processing;
using Newtone.Desktop.Logic;
using System.Windows;
using System.Windows.Controls;
using YoutubeExplode;

namespace Newtone.Desktop.Views.Custom.DataTemplates
{
    /// <summary>
    /// Logika interakcji dla klasy SearchResultDataTemplate.xaml
    /// </summary>
    public partial class SearchResultDataTemplate : UserControl
    {
        #region Constructors
        public SearchResultDataTemplate()
        {
            InitializeComponent();
        }
        #endregion
        #region Private Methods
        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            TagButton button = (TagButton)sender;
            var menu = ContextMenuBuilder.BuildForSeachResult(button.Value);
            menu.IsOpen = true;
            menu.PlacementTarget = button;
        }
        #endregion
    }
}
