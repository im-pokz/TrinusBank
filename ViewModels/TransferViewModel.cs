using System;
using TrinusBank.Models.Account;
using TrinusBank.Models.Account.Enums;

namespace TrinusBank.ViewModels
{
    public class TransferViewModel : BindableBase
    {
        public Transfers Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged(null);
            }
        }
        private Transfers _model;
        public string Name
        {
            get => Model.Name;
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    OnPropertyChanged();
                }
            }
        }
        public double? Value
        {
            get => Model.Value;
            set
            {
                if (Model.Value != value)
                {
                    Model.Value = (double)value;
                    OnPropertyChanged();
                }
            }
        }
        public DateTime Date
        {
            get => Model.Date;
            set
            {
                if (Model.Date != value)
                {
                    Model.Date = value;
                    OnPropertyChanged();
                }
            }
        }

        public TransferType Type
        {
            get => Model.Type;
            set
            {
                if (Model.Type != value)
                {
                    Model.Type = value;
                    OnPropertyChanged();
                }
            }
        }

        public ActionType Action
        {
            get => Model.Action;
            set
            {
                if (Model.Action != value)
                {
                    Model.Action = value;
                    OnPropertyChanged();
                }
            }
        }

        public TransferViewModel()
        {
            Model = new Transfers();
            Date = DateTime.Now;
        }

        public TransferViewModel(Transfers transfers)
        {
            if (transfers != null)
            {
                Model = transfers;
            }
        }

        /*protected override void OnValidation()
        {
            if (string.IsNullOrWhiteSpace(Name)) ValidationErrors.Add(nameof(Name), "Preencha o nome");
            if (Age == null || Age == 0) ValidationErrors.Add(nameof(Age), "Preencha a idade");
            if (string.IsNullOrWhiteSpace(Ssn)) ValidationErrors.Add(nameof(Ssn), "Preencha o CPF");
        }*/
    }
}