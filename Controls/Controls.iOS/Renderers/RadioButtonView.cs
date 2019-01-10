using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Controls.iOS.Renderers
{
    [Register("RadioButtonView")]
    public class RadioButtonView:UIButton
    {
        #region 构造
        public RadioButtonView()
        {
            Initialize();
        }
        public RadioButtonView(CGRect bounds)
            : base(bounds)
        {
            Initialize();
        }
        #endregion

        #region 属性
        public bool Checked
        {
            set { Selected = value; }
            get { return Selected; }
        }

        public string Text
        {
            set { SetTitle(value, UIControlState.Normal); }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        void Initialize()
        {
            AdjustEdgeInsets();
            ApplyStyle();
            //按钮点击事件
            TouchUpInside += (sender, args) => Selected = !Selected;
        }
        /// <summary>
        /// 调整边缘插图
        /// </summary>
        void AdjustEdgeInsets()
        {
            const float inset = 8f;

            HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
            ImageEdgeInsets = new UIEdgeInsets(0f, inset, 0f, 0f);
            TitleEdgeInsets = new UIEdgeInsets(0f, inset * 2, 0f, 0f);
        }
        /// <summary>
        /// 为控件添加状态图片
        /// </summary>
        void ApplyStyle()
        {
            SetImage(UIImage.FromBundle("Images/checked.png"), UIControlState.Selected);
            SetImage(UIImage.FromBundle("Images/unchecked.png"), UIControlState.Normal);
        }
        #endregion
    }
}