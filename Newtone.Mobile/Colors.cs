using Xamarin.Forms;

namespace Newtone.Mobile
{
    public class Colors
    {
        #region Fields
        private static readonly ColorsBase ColorsBase = new ColorsBase();
        #endregion
        #region Properties
        public static Color ColorPrimary
        {
            get
            {
                return ColorsBase.ColorPrimary;
            }
        }

        public static Color ColorSecondary
        {
            get
            {
                return ColorsBase.ColorSecondary;
            }
        }

        public static Color ColorThirdary
        {
            get
            {
                return ColorsBase.ColorThirdary;
            }
        }

        public static Color TextColor
        {
            get
            {
                return ColorsBase.TextColor;
            }
        }

        public static Color BadgeColor
        {
            get
            {
                return ColorsBase.BadgeColor;
            }
        }

        public static Color ProgressBarColor
        {
            get
            {
                return ColorsBase.ProgressBarColor;
            }
        }
        #endregion
    }
    public class ColorsBase
    {
        #region Fields
        public Color ColorPrimary = Color.FromHex("#121212");
        public Color ColorSecondary = Color.FromHex("#1f1f1f");
        public Color TextColor = Color.FromHex("#ffffff");
        public Color BadgeColor = Color.FromHex("#ff5200");
        public Color ProgressBarColor = Color.FromHex("#0f4c75");
        public Color ColorThirdary = Color.FromHex("#141414");
        #endregion
    }

}