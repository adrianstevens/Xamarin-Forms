using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Radio;

[assembly: ExportEffect (typeof (DisabledOpacityEffectIOS), "DisabledOpacityEffect")]

namespace Radio
{
    public class DisabledOpacityEffectIOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            UIButton button = Control as UIButton;
            if (button == null)
                return;

			button.SetTitleColor(UIColor.FromRGB(0.8f, 0.8f, 0.8f), UIControlState.Disabled);
            ChangeState(button);
        }

        protected override void OnDetached()
        {
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (e.PropertyName == "IsEnabled")
            {
                UIButton button = Control as UIButton;
                if (button != null)
                    ChangeState(button);
            }
        }

        void ChangeState(UIButton button)
        {
            if (!button.Enabled)
                button.Layer.Opacity = 0.5f;
            else
                button.Layer.Opacity = 1f;
        }
    }
}