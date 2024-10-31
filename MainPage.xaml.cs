using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HACKATHON
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new AdminLogin());
        }
        private void OnDonateFoodClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DonateFoodPage());
        }
        private void OnFindFoodClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindFoodPage());
        }
        private void OnFoodBankMapClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FoodBankMap());
        }
        private void OnAboutFoodInsecurityClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutFood());
        }
    }
}
