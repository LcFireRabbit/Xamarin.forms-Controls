using System;
using System.ComponentModel;
using Controls.Controls;
using Controls.iOS.Renderers;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace Controls.iOS.Renderers
{
    public class RadioButtonRenderer:ViewRenderer<CustomRadioButton,RadioButtonView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            BackgroundColor = Element.BackgroundColor.ToUIColor();

            if (Control == null)
            {
                var checkBox = new RadioButtonView(Bounds);
                checkBox.TouchUpInside += (s, args) => Element.Checked = Control.Checked;
                SetNativeControl(checkBox);
            }
            Control.LineBreakMode = UILineBreakMode.CharacterWrap;
            Control.VerticalAlignment = UIControlContentVerticalAlignment.Top;
            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.SetTitleColor(e.NewElement.TextNormalColor.ToUIColor(), UIControlState.Normal);
            Control.SetTitleColor(e.NewElement.TextCheckedColor.ToUIColor(), UIControlState.Selected);
        }

        private void ResizeText()
        {
            var text = Element.Text;


            var bounds = Control.Bounds;

            var width = Control.TitleLabel.Bounds.Width;

            var height = text.StringHeight(Control.Font, width);

            var minHeight = string.Empty.StringHeight(Control.Font, width);

            var requiredLines = Math.Round(height / minHeight, MidpointRounding.AwayFromZero);

            var supportedLines = Math.Round(bounds.Height / minHeight, MidpointRounding.ToEven);

            if (supportedLines != requiredLines)
            {
                bounds.Height += (float)(minHeight * (requiredLines - supportedLines));
                Control.Bounds = bounds;
                Element.HeightRequest = bounds.Height;
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            ResizeText();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
                case "TextColor":
                    Control.SetTitleColor(Element.TextNormalColor.ToUIColor(), UIControlState.Normal);
                    Control.SetTitleColor(Element.TextCheckedColor.ToUIColor(), UIControlState.Selected);
                    break;
                case "Element":
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
                    return;
            }
        }
    }
}