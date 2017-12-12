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
    public partial class LeftMenu : MasterDetailPage
    {
        public LeftMenu()
        {
            InitializeComponent();
            var page = new NavigationPage(new LeftMenuMaster());
            page.Title = "Menu";
            Master = page;
        }
    }
}