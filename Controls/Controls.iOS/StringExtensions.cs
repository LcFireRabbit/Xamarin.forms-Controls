using System;
using Foundation;
using UIKit;
namespace Controls.iOS
{
    public static class StringExtensions
    {
        public static nfloat StringHeight(this string text, UIFont font, nfloat width)
        {
            var nativeString = new NSString(text);

            var rect = nativeString.GetBoundingRect(
                new CoreGraphics.CGSize(width, float.MaxValue),
                //new System.Drawing.SizeF(width, float.MaxValue),
                NSStringDrawingOptions.UsesLineFragmentOrigin,
                new UIStringAttributes() { Font = font },
                null);

            return rect.Height;
        }
    }
}