using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Controls.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Dictionary<int, string> _myList;
        public Dictionary<int, string> MyList
        {
            get { return _myList; }
            set { SetProperty(ref _myList, value); }
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { SetProperty(ref _selectedIndex, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            _myList = new Dictionary<int, string>();
            for (int i = 0; i < 20; i++)
            {
                MyList.Add(i, "Item " + i);
            }
        }
        new public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
