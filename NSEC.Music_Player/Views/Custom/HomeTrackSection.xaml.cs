using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NSEC.Music_Player.Views.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTrackSection : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
    propertyName: "Title",
    returnType: typeof(string),
    declaringType: typeof(HomeTrackSection),
    defaultValue: "");

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public HomeTrackSection()
        {
            InitializeComponent();
            titleLabel.BindingContext = this;
            AddItem("Title", "Author", "FilePath");
        }

        public void AddItem(string title, string author, string filePath, ImageSource picture = null)
        {
            Container.Children.Add(new HomeTrackSectionItem(title,author,filePath,picture));
        }

        public void Clear()
        {
            Container.Children.Clear();
        }
    }
}