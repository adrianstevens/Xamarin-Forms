using System;

namespace DrumPad
{
    public class Preferences
    {
        public static Preferences Intstance
        {
            get {
                if (instance == null)
                    instance = new Preferences();
                return instance; }
        }
        static Preferences instance;

        public event EventHandler<ColorSchemeType> ColorSchemeUpdated;

        private Preferences()
        {
        }

        public ColorScheme ColorScheme
        {
            get { return colorScheme; }
            set { colorScheme = value; UpdateResources(); }
        }
        ColorScheme colorScheme;

        void UpdateResources ()
        {
            App.UpdateThemeColors(colorScheme);

            ColorSchemeUpdated?.Invoke(null, colorScheme.SchemeType);
        }
    }
}