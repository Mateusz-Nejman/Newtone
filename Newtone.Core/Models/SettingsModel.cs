namespace Newtone.Core.Models
{
    public class SettingsModel:PropertyChangedBase
    {
        #region Fields
        private string name;
        private string description;
        #endregion
        #region Properties
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
