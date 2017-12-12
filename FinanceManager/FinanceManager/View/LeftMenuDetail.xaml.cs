using FinanceManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftMenuDetail : ContentPage
    {
        public MainPageViewModel Database { get; set; }

        public LeftMenuDetail()
        {
            InitializeComponent();
            
            Database = new MainPageViewModel(this);
            this.BindingContext = Database;
        }
    }
}