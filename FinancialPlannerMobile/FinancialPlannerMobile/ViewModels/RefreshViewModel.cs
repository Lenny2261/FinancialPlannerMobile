using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialPlannerMobile 
{
    class RefreshViewModel : INotifyPropertyChanged
    {
        //Command _refreshCommand;

        //public RefreshViewModel()
        //{
        //    _refreshCommand = new Command(RefreshList);
        //}

        //public Command RefreshCommand
        //{
        //    get
        //    {
        //        return _refreshCommand;
        //    }
        //}

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        //Our list of objects!
        List<Account> _accountList;
        public List<Account> AccountList
        {
            get { return _accountList; }
            set
            {
                _accountList = value;
                OnPropertyChanged(nameof(AccountList));
            }
        }

        //Refresh command
        Command _refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return _refreshCommand;
            }
        }

        public RefreshViewModel()
        {
            _accountList = new List<Account>();
            _refreshCommand = new Command(async () => await RefreshList());

            Task.Run(async () =>
            {
                IsRefreshing = true;
                AccountList = await PopulateList();
                IsRefreshing = false;
            });

        }

        async Task<List<Account>> PopulateList()
        {

            var accountCore = new AccountCore();

            _accountList = await accountCore.GetAccounts();

            return _accountList;
        }

        async Task RefreshList()
        {
            IsRefreshing = true;
            AccountList = await PopulateList();
            IsRefreshing = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
