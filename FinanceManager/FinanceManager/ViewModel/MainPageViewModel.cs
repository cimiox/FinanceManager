using FinanceManager.Model;
using FinanceManager.Model.Tables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FinanceManager.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string CategoriesFile = "Categories.json";
        private const string BalanceFile = "Balance.json";
        private const string AccumulationFile = "Accumulation.json";

        #region Balance

        private ObservableCollection<Balance> balances = new ObservableCollection<Balance>();
        public ObservableCollection<Balance> Balances
        {
            get { return balances; }
            set
            {
                if (value != null)
                {
                    balances = value;
                    OnPropertyChanged("Balances");
                }
            }
        }

        private double lastBalance;
        public double LastBalance
        {
            get
            {
                return Balances.Sum(x => x.Count);
            }
            set
            {
                lastBalance = value;
                OnPropertyChanged("LastBalance");
            }
        }

        private double balance;
        public double Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        private Currencies currency;
        public Currencies Currency
        {
            get { return currency; }
            set
            {
                currency = value;
                OnPropertyChanged("Currency");
            }
        }


        private Category balanceCategory;
        public Category BalanceCategory
        {
            get { return balanceCategory; }
            set
            {
                balanceCategory = value;
                OnPropertyChanged("BalanceCategory");
            }
        }

        private Balance selectedItem;
        public Balance SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }


        public ICommand AddBalanceCommand { get; set; }

        //TODO: write this
        //public ICommand UpdateBalance { get; set; }
        //public ICommand DeleteBalance { get; set; }

        #endregion Balance
        #region Category

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }

        #endregion Category
        #region Accumulations

        private ObservableCollection<Accumulation> accumulations;
        public ObservableCollection<Accumulation> Accumulations
        {
            get { return accumulations; }
            set
            {
                accumulations = value;
                OnPropertyChanged("Accumuations");
            }
        }
        private Balance check;
        public Balance Check
        {
            get { return check; }
            set { check = value; OnPropertyChanged("Check"); }
        }

        #endregion Accumulations

        public string[] Currencies
        {
            get { return Enum.GetNames(typeof(Currencies)); }
        }

        public bool IsPlusPage { get; set; }

        public ICommand PlusPage { get; set; }
        public ICommand MinusPage { get; set; }
        public ICommand EditBalanceCommand { get; set; }

        public ContentPage MainPage { get; set; }

        private Balance balanceForEdit;

        public Balance BalanceForEdit
        {
            get { return balanceForEdit; }
            set
            {
                balanceForEdit = value;

                if (value != null)
                {
                    EditBalanceCommand.Execute(null);
                }
            }
        }


        public MainPageViewModel(ContentPage main)
        {
            MainPage = main;
            Intialize();
        }

        private async void Intialize()
        {
            AddBalanceCommand = new Command(AddBalance);
            PlusPage = new Command(OpenPlusPage);
            MinusPage = new Command(OpenMinusPage);
            EditBalanceCommand = new Command(EditBalance);

            Balances = JsonConvert.DeserializeObject<ObservableCollection<Balance>>(await DependencyService.Get<IFileWorker>().LoadTextAsync(BalanceFile));
            Categories = JsonConvert.DeserializeObject<ObservableCollection<Category>>(await DependencyService.Get<IFileWorker>().LoadTextAsync(CategoriesFile));

            Balances.CollectionChanged += Balances_CollectionChanged;
            Categories.CollectionChanged += Categories_CollectionChanged;

            LastBalance = Balances.Sum(x => x.Count);
        }

        private async void EditBalance()
        {
            Balance = BalanceForEdit.Count;
            Currency = BalanceForEdit.Currency;
            BalanceCategory = BalanceForEdit.Category;

            var page = Application.Current.MainPage as MasterDetailPage;
            var newEditPage = new View.EditBalancePage();
            newEditPage.Title = "Edit balance";
            newEditPage.BindingContext = this;
            await page.Detail.Navigation.PushAsync(newEditPage);
        }

        private async void OpenPlusPage()
        {
            IsPlusPage = true;
            var page = Application.Current.MainPage as MasterDetailPage;
            var newEditPage = new View.EditBalancePage();
            newEditPage.Title = "Plus balance";
            newEditPage.BindingContext = this;
            await page.Detail.Navigation.PushAsync(newEditPage);
        }

        private async void OpenMinusPage()
        {
            IsPlusPage = false;
            var page = Application.Current.MainPage as MasterDetailPage;
            var newEditPage = new View.EditBalancePage();
            newEditPage.Title = "Minus balance";
            newEditPage.BindingContext = this;
            await page.Detail.Navigation.PushAsync(newEditPage);
        }

        private async void AddBalance()
        {
            if (Balance != 0 && BalanceCategory != null)
            {
                if (BalanceForEdit == null)
                    Balances.Add(new Balance(IsPlusPage ? Balance : -Balance, Currency, BalanceCategory));
                else
                {
                    for (int i = 0; i < Balances.Count; i++)
                    {
                        if (Balances[i] == BalanceForEdit)
                            Balances[i] = new Balance(Balance, Currency, BalanceCategory);
                    }
                }

                Balance = default(double);
                Currency = default(Currencies);
                BalanceCategory = default(Category);
                BalanceForEdit = default(Balance);

                await (Application.Current.MainPage as MasterDetailPage).Detail.Navigation.PopAsync();
            }
        }

        public void Categories_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            DependencyService.Get<IFileWorker>().SaveTextAsync(CategoriesFile, JsonConvert.SerializeObject(Categories));
        }

        private void Balances_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            LastBalance = Balances.Last().Count;
            DependencyService.Get<IFileWorker>().SaveTextAsync(BalanceFile, JsonConvert.SerializeObject(Balances));
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
