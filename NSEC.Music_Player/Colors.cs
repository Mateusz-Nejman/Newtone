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

        public static Color ColorThirdary
        {
            get
            {
                return ColorsBase.ColorThirdary;
            }
        }

        public static Color ColorBadge
        {
            get
            {
                return ColorsBase.ColorBadge;
            }
        }

        public static Color TextPrimary
        {
            get
            {
                return ColorsBase.TextPrimary;
            }
        }

        public static Color TextSecondary
        {
            get
            {
                return ColorsBase.TextSecondary;
            }
        }

        public static Color BottomBarBackground
        {
            get
            {
                return ColorsBase.BottomBarBackground;
            }
        }

        public static Color BottomBarUnselected
        {
            get
            {
                return ColorsBase.BottomBarUnselected;
            }
        }

        public static Color BottomBarSelected
        {
            get
            {
                return ColorsBase.BottomBarSelected;
            }
        }

        public static Color ContainerBackground
        {
            get
            {
                return ColorsBase.ContainerBackground;
            }
        }

        public static Color ContainerBackgroundSecond
        {
            get
            {
                return ColorsBase.ContainerBackgroundSecond;
            }
        }

        public static Color ContainerHeaderColor
        {
            get
            {
                return ColorsBase.ContainerHeaderColor;
            }
        }

        public static Color ContainerTextColor
        {
            get
            {
                return ColorsBase.ContainerTextColor;
            }
        }

        public static Color PlayerTextColor
        {
            get
            {
                return ColorsBase.PlayerTextColor;
            }
        }

        public static Color IconColor
        {
            get
            {
                return ColorsBase.IconColor;
            }
        }

        public static void SetBase(string name)
        {
            ColorsBase = new ColorsDefault();
            if (name == "Light")
                ColorsBase = new ColorsLight();
            else if (name == "Dark")
                ColorsBase = new ColorsDark();
            else
                ColorsBase = new ColorsDefault();
        }
    }

    public class ColorsLight : ColorsBase
    {
        public ColorsLight()
        {
            this.ColorPrimary = Color.White;
            this.ColorSecondary = Color.FromHex("#FAFAFA");
            this.ContainerBackground = this.ColorSecondary;

            this.BottomBarBackground = this.ColorPrimary;
            this.BottomBarSelected = Color.FromHex("#cd5900");
            this.BottomBarUnselected = Color.FromHex("#263238");
            this.ContainerHeaderColor = Color.FromHex("#263238");
            this.TextPrimary = Color.Black;
            this.ContainerTextColor = Color.FromHex("#263238");
            this.IconColor = Color.Black;
        }
    }

    public class ColorsDark : ColorsBase
    {
        public ColorsDark()
        {
            this.ColorPrimary = Color.FromHex("#424242");
            this.ColorSecondary = Color.FromHex("#212121");

            this.ContainerBackground = this.ColorSecondary;

            this.BottomBarBackground = this.ColorPrimary;
            this.BottomBarUnselected = this.ColorPrimary;
            this.BottomBarSelected = Color.White;
        }
    }

    public class ColorsDefault : ColorsBase
    {

    }

    public abstract class ColorsBase
    {
        public Color ColorPrimary = Color.FromHex("#0083b4");
        public Color ColorSecondary = Color.FromHex("#006f99");
        public Color ColorThirdary = Color.FromHex("#0c4297");
        public Color ColorBadge = Color.FromHex("#FF6F00");
        public Color TextPrimary = Color.White;
        public Color TextSecondary = Color.FromHex("#FF6F00");

        public Color BottomBarBackground = Color.FromHex("#FAFAFA");
        public Color BottomBarUnselected = Color.FromHex("#263238");
        public Color BottomBarSelected = Color.FromHex("#004a66");

        public Color ContainerBackground = Color.FromHex("#006f99");
        public Color ContainerBackgroundSecond = Color.White;
        public Color ContainerHeaderColor = Color.FromHex("#FAFAFA");
        public Color ContainerTextColor = Color.FromHex("#FAFAFA");

        public Color PlayerTextColor = Color.White;
        public Color IconColor = Color.White;
    }
}