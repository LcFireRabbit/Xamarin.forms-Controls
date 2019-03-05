using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Controls.Controls.RotatableImage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RotatableImage : ContentView
    {

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("ImageSource", typeof(ImageSource), typeof(RotatableImage), null);




        public double ImagePalstance
        {
            get { return (double)GetValue(ImagePalstanceProperty); }
            set { SetValue(ImagePalstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePalstance.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty ImagePalstanceProperty =
            BindableProperty.Create("ImagePalstance", typeof(double), typeof(RotatableImage), 0.0,propertyChanged: OnImagePalstanceChanged);

        private static void OnImagePalstanceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            var RTI = bindable as RotatableImage;

            double newValueD = (double)newValue;
            if (newValueD != 0)
            {
                double angle = newValueD / 1000 * 50000;//默认50s一个动画循环播放
                var rotateAnimation = new Animation(v => RTI.RTIamge.Rotation = v, RTI.RTIamge.Rotation % 360, RTI.RTIamge.Rotation % 360 + angle);
                rotateAnimation.Commit(RTI, "RotateAnimation", 0, 50000, Easing.Linear, null, () => true);
            }
            else
            {
                RTI.AbortAnimation("RotateAnimation");
                RTI.RTIamge.Rotation = 0;
            }
        }

        public RotatableImage()
        {
            InitializeComponent();
        }
    }
}