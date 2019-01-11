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

        public class ItemModel:BindableBase
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set { SetProperty(ref _isSelected, value); }
            }

            private string _organizationName;
            public string OrganizationName
            {
                get { return _organizationName; }
                set { SetProperty(ref _organizationName, value); }
            }
        }
        private List<ItemModel> _orgList;
        public List<ItemModel> OrgList
        {
            get { return _orgList; }
            set { SetProperty(ref _orgList, value); }
        }

        private DelegateCommand<ItemModel> _navigateCommand;
        public DelegateCommand<ItemModel> NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand<ItemModel>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(ItemModel Item)
        {
            foreach (var temp in OrgList)
            {
                if (temp.OrganizationName == Item.OrganizationName)
                {
                    temp.IsSelected = true;
                }
                else
                {
                    temp.IsSelected = false;
                }
            }
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
            OrgList = new List<ItemModel>
            {
                new ItemModel { IsSelected = false, OrganizationName = "item1" },
                new ItemModel { IsSelected = false, OrganizationName = "item2" },
                new ItemModel { IsSelected = false, OrganizationName = "item3" },
                new ItemModel { IsSelected = false, OrganizationName = "item4" }
            };
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
