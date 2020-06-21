﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NSEC.Music_Player
{
    public class Colors
    {
        #region Fields
        private static ColorsBase ColorsBase = new ColorsDefault();
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
        #region Public Methods
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
        #endregion
    }

    public class ColorsRed : ColorsBase
    {
        #region Constructors
        public ColorsRed()
        {
            this.ColorPrimary = Color.FromHex("#9a1f40");
            this.ColorSecondary = Color.FromHex("#d9455f");
            this.TextColor = Color.FromHex("#ffffff");
            this.BadgeColor = Color.FromHex("#ff5200");
            this.ProgressBarColor = Color.FromHex("#0f4c75");
            this.ColorThirdary = Color.FromHex("#9d2041");
        }
        #endregion
    }

    public class ColorsDark : ColorsBase
    {
        #region Constructors
        public ColorsDark()
        {
            this.ColorPrimary = Color.FromHex("#121212");
            this.ColorSecondary = Color.FromHex("#1f1f1f");
            this.TextColor = Color.FromHex("#ffffff");
            this.BadgeColor = Color.FromHex("#ff5200");
            this.ProgressBarColor = Color.FromHex("#0f4c75");
            this.ColorThirdary = Color.FromHex("#141414");
        }
        #endregion
    }

    public class ColorsDefault : ColorsBase
    {

    }

    public abstract class ColorsBase
    {
        #region Fields
        public Color ColorPrimary = Color.FromHex("#1b262c");
        public Color ColorSecondary = Color.FromHex("#0f4c75");
        public Color TextColor = Color.FromHex("#ffffff");
        public Color BadgeColor = Color.FromHex("#ff5200");
        public Color ProgressBarColor = Color.FromHex("#3282b8");
        public Color ColorThirdary = Color.FromHex("#1c282e");
        #endregion
    }

}