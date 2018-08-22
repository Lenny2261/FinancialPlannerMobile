using FinancialPlannerMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinancialPlannerMobile.ViewModels
{
    class TransactionRefreshViewModel : INotifyPropertyChanged
    {
        int accountId;
        int? filter;
        List<TransactionStatus> transactionStatuses;
        List<TransactionType> transactionTypes;

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
        List<Transactions> _transactionList;
        public List<Transactions> TransactionList
        {
            get { return _transactionList; }
            set
            {
                _transactionList = value;
                OnPropertyChanged(nameof(TransactionList));
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

        public TransactionRefreshViewModel(int accountId, int? filter)
        {
            _transactionList = new List<Transactions>();
            _refreshCommand = new Command(async () => await RefreshList());
            this.accountId = accountId;
            this.filter = filter;

            Task.Run(async () =>
            {
                IsRefreshing = true;
                TransactionList = await PopulateList();
                IsRefreshing = false;
            });

        }

        async Task<List<Transactions>> PopulateList()
        {

            var transactionCore = new TransactionCore();

            _transactionList = await transactionCore.GetTransactions(accountId);
            transactionStatuses = await transactionCore.GetTransactionStatus();
            transactionTypes = await transactionCore.GetTransactionType();
            int voidCheck = 0;

            List<Transactions> filteredTransactions = new List<Transactions>();

            switch (filter)
            {
                case 0:
                    foreach(var item in _transactionList)
                    {
                        foreach(var item2 in transactionTypes)
                        {
                            if(item2.Id == item.TransactionTypeId && item2.Name == "Debit")
                            {
                                foreach (var item3 in transactionStatuses)
                                {
                                    if (item3.Id == item.TransactionStatusId && item3.Name == "Void")
                                    {
                                        voidCheck = 1;
                                    }
                                    else if(item3.Id == item.TransactionStatusId)
                                    {
                                        item.StatusName = item3.Name;
                                    }
                                }

                                if(voidCheck == 1)
                                {
                                    voidCheck = 0;
                                    break;
                                }

                                item.TypeName = item2.Name;
                                filteredTransactions.Add(item);
                            }
                        }
                    }
                    break;
                case 1:
                    foreach (var item in _transactionList)
                    {
                        foreach (var item2 in transactionTypes)
                        {
                            if (item2.Id == item.TransactionTypeId && item2.Name == "Credit")
                            {
                                foreach (var item3 in transactionStatuses)
                                {
                                    if (item3.Id == item.TransactionStatusId && item3.Name == "Void")
                                    {
                                        voidCheck = 1;
                                    }
                                    else if (item3.Id == item.TransactionStatusId)
                                    {
                                        item.StatusName = item3.Name;
                                    }
                                }

                                if (voidCheck == 1)
                                {
                                    voidCheck = 0;
                                    break;
                                }

                                item.TypeName = item2.Name;
                                filteredTransactions.Add(item);
                            }
                        }
                    }
                    break;
                case 2:
                    foreach (var item in _transactionList)
                    {

                        foreach(var item2 in transactionTypes)
                        {
                            if(item2.Id == item.TransactionTypeId)
                            {
                                item.TypeName = item2.Name;
                            }
                        }

                        foreach (var item3 in transactionStatuses)
                        {
                            if (item3.Id == item.TransactionStatusId && item3.Name == "Void")
                            {
                                item.StatusName = item3.Name;
                                filteredTransactions.Add(item);
                            }
                        }
                    }
                    break;
                default:
                    foreach (var item in _transactionList)
                    {

                        foreach (var item2 in transactionTypes)
                        {
                            if (item2.Id == item.TransactionTypeId)
                            {
                                item.TypeName = item2.Name;
                            }
                        }

                        foreach (var item3 in transactionStatuses)
                        {
                            if (item3.Id == item.TransactionStatusId)
                            {
                                item.StatusName = item3.Name;
                            }
                        }
                        filteredTransactions.Add(item);
                    }
                    break;
            }

            return filteredTransactions;
        }

        async Task RefreshList()
        {
            IsRefreshing = true;
            TransactionList = await PopulateList();
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
