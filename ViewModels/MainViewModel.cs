using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrinusBank.Views;

namespace TrinusBank.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public ObservableCollection<TransferViewModel> Transfers { get; set; } = new ObservableCollection<TransferViewModel>();
        private TransferViewModel _currentTransfer;
        public TransferViewModel CurrentTranser
        {
            get => _currentTransfer;
            set => Set(ref _currentTransfer, value);
        }
        public double? TotalValue { get => Transfers
                                .Where(i => i.Action == Models.Account.Enums.ActionType.Deposit)
                                .Sum(i => i.Value) - Transfers
                                .Where(i => i.Action == Models.Account.Enums.ActionType.Withdrawal)
                                .Sum(i => i.Value); }
        public ICommand RegisterCommand { get; set; }

        public void Register()
        {
            Transfers.Add(CurrentTranser);
            CurrentTranser = new TransferViewModel();
        }

        public MainViewModel()
        {
            CurrentTranser = new TransferViewModel();
            RegisterCommand = new RelayCommand(Register);
            Transfers.CollectionChanged += Transfers_CollectionChanged;
            Transfers.Add(new TransferViewModel { Name = "Kelvin", Value = 200.50, Date = new DateTime(2021, 10, 07), Type = Models.Account.Enums.TransferType.DOC });
        }

        private void Transfers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(TotalValue));
        }
    }
}
