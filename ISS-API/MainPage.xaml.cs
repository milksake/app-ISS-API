using ISS_API.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ISS_API
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModels();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ((MainPageViewModels)this.BindingContext).SearchCommand.Execute(0);
        }
    }
}
