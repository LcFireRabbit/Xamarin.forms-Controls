using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controls.Controls
{
    public class CustomRadioButton:View
    {
        #region 创建属性
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create("Checked",typeof(bool),typeof(CustomRadioButton),false);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(CustomRadioButton), "12223");

        public static readonly BindableProperty TextNormalColorProperty =
            BindableProperty.Create("TextNormalColor", typeof(Color),typeof(CustomRadioButton),Color.Black);

        public static readonly BindableProperty TextCheckedColorProperty =
            BindableProperty.Create("TextCheckedColor",typeof(Color),typeof(CustomRadioButton),Color.Black);
        #endregion

        #region 属性字段
        public bool Checked
        {
            get{return (bool)GetValue(CheckedProperty);}
            set
            {
                SetValue(CheckedProperty, value);
                var eventHandler = CheckedChanged;
                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }
        public string Text
        {
            get{return (string)GetValue(TextProperty);}
            set{SetValue(TextProperty, value);}
        }
        public Color TextNormalColor
        {
            get { return (Color)GetValue(TextNormalColorProperty); }
            set { SetValue(TextNormalColorProperty, value); }
        }
        public Color TextCheckedColor
        {
            get { return (Color)GetValue(TextCheckedColorProperty); }
            set { SetValue(TextCheckedColorProperty,value); }
        }
        public new int Id { get; set; }
        #endregion

        #region 事件
        /// <summary>
        /// The checked changed event.
        /// </summary>
        public EventHandler<EventArgs<bool>> CheckedChanged;
        #endregion
    }
}
