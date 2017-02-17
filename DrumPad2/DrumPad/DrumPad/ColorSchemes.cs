using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DrumPad
{
    public enum ColorSchemeType
    {
        Orange,
        Black,
        Blue,
        Sand,
        Pink,
        Primary,
        count
    }

    public static class ColorSchemes
    {
        public static IList<ColorScheme> Schemes { get; private set; }

        static ColorSchemes()
        {
            Schemes = new ObservableCollection<ColorScheme>
            {
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Orange,
                    Name = "Orange",
                    Square = "Orange.png",
                    Logo = "OrangeLogo.png",
                    MainColor = 0xF05A56,
                    HighlightColor = 0xFCFBEE,
                    ButtonColor = 0x97958E,
                    BackgroundColor = 0x29B7BD,
                },
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Black,
                    Name = "Black",
                    Square = "Black.png",
                    Logo = "BlackLogo.png",
                    MainColor = 0x6BF9FC,
                    HighlightColor = 0xF6F6F6,
                    ButtonColor = 0x646464,
                    BackgroundColor = 0x0B0B0B,
                },
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Blue,
                    Name = "Blue",
                    Square = "Blue.png",
                    Logo = "BlueLogo.png",
                    MainColor = 0x162040,
                    HighlightColor = 0x94D6BA,
                    ButtonColor = 0x7E4883,
                    BackgroundColor = 0x01999D,
                },
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Sand,
                    Name = "Sand",
                    Square = "Sand.png",
                    Logo = "SandLogo.png",
                    MainColor = 0x88AD78,
                    HighlightColor = 0xECDAA7,
                    ButtonColor = 0x39758C,
                    BackgroundColor = 0xC96161,
                },
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Pink,
                    Name = "Pink",
                    Square = "Pink.png",
                    Logo = "PinkLogo.png",
                    MainColor = 0xED0876,
                    HighlightColor = 0xDCD9CF,
                    ButtonColor = 0x39B449,
                    BackgroundColor = 0xFFCC0A,
                },
                new ColorScheme()
                {
                    SchemeType = ColorSchemeType.Primary,
                    Name = "Primary Colors",
                    Square = "Primary.png",
                    Logo = "PrimaryLogo.png",
                    MainColor = 0x00A8DE,
                    HighlightColor = 0xEB2C3B,
                    ButtonColor = 0x00A055,
                    BackgroundColor = 0xFDE92B,
                },
            };
        }
    }

    public class ColorScheme
    {
        public ColorSchemeType SchemeType { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Square { get; set; }
        public int MainColor { get; set; }
        public int HighlightColor { get; set; }
        public int ButtonColor { get; set; }
        public int BackgroundColor { get; set; }
    }
}