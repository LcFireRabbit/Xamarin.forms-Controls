
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
            BindableProperty.Create("ImagePalstance", typeof(double), typeof(RotatableImage), 0.0, propertyChanged: OnImagePalstanceChanged);

        private static void OnImagePalstanceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null)
                return;
            var RTI = bindable as RotatableImage;


            double newValueD = (double)newValue;
            if (newValueD != 0)
            {
                var durationTime = 800 + (1 - newValueD) * 1000;

                var rotateAnimation = new Animation(v => RTI.RTImage.Rotation = v, RTI.RTImage.Rotation, RTI.RTImage.Rotation + 360);

                rotateAnimation.Commit(RTI, "RotateAnimation", 16, (uint)durationTime, Easing.Linear, null, () => true);
            }
            else
            {
                RTI.AbortAnimation("RotateAnimation");
                RTI.RTImage.Rotation = 0;
            }
        }

        public RotatableImage()
        {
            InitializeComponent();
        }
    }
}