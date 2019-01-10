using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Controls.Controls;
using Controls.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly:ExportRenderer(typeof(CustomRadioButton),typeof(RadioButtonRenderer))]
namespace Controls.Droid.Renderers
{
    public class RadioButtonRenderer:ViewRenderer<CustomRadioButton,RadioButton>
    {
        public RadioButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged += ElementOnPropertyChanged;
            }
            if (Control == null)
            {
                var radioButton = new RadioButton(Context);
                radioButton.CheckedChange += CheckedChange;
                radioButton.SetTextColor(Element.TextNormalColor.ToAndroid());
                SetNativeControl(radioButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.SetTextColor(Element.TextNormalColor.ToAndroid());
            Element.PropertyChanged += ElementOnPropertyChanged;
        }

        void CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }

        void ElementOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    if (Control.Checked)
                    {
                        Control.SetTextColor(Element.TextCheckedColor.ToAndroid());
                    }
                    else
                    {
                        Control.SetTextColor(Element.TextNormalColor.ToAndroid());
                    }
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;
                case "TextNormalColor":
                    Control.SetTextColor(Element.TextNormalColor.ToAndroid());
                    break;
            }
        }
    }
}