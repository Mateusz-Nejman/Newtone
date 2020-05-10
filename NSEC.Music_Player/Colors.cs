using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    public class Colors
    {
        private static ColorsBase ColorsBase = new ColorsDefault();

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

        public static void SetBase(string name)
        {
            ColorsBase = new ColorsDefault();
            if (name == "Light")
                ColorsBase = new ColorsRed();
            else if (name == "Dark")
                ColorsBase = new ColorsDark();
            else
                ColorsBase = new ColorsDefault();
        }
    }

    public class ColorsRed : ColorsBase
    {
        public ColorsRed()
        {
            this.ColorPrimary = Color.FromHex("#9a1f40");
            this.ColorSecondary = Color.FromHex("#d9455f");
            this.TextColor = Color.FromHex("#ffffff");
            this.BadgeColor = Color.FromHex("#ff5200");
            this.ProgressBarColor = Color.FromHex("#0f4c75");
        }
    }

    public class ColorsDark : ColorsBase
    {
        public ColorsDark()
        {
            this.ColorPrimary = Color.FromHex("#121212");
            this.ColorSecondary = Color.FromHex("#1f1f1f");
            this.TextColor = Color.FromHex("#ffffff");
            this.BadgeColor = Color.FromHex("#ff5200");
            this.ProgressBarColor = Color.FromHex("#0f4c75");
        }
    }

    public class ColorsDefault : ColorsBase
    {

    }

    public abstract class ColorsBase
    {
        public Color ColorPrimary = Color.FromHex("#1b262c");
        public Color ColorSecondary = Color.FromHex("#0f4c75");
        public Color TextColor = Color.FromHex("#ffffff");
        public Color BadgeColor = Color.FromHex("#ff5200");
        public Color ProgressBarColor = Color.FromHex("#3282b8");
    }

}