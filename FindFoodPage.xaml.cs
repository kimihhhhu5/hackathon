using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HACKATHON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindFoodPage : ContentPage
    {
        public class FoodResource
        {
            public string Name { get; set; }
            public string Location { get; set; }
        }

        public FindFoodPage()
        {
            InitializeComponent();
            LoadFoodResources();
        }
        private void LoadFoodResources()
        {
            var foodResources = new List<FoodResource>
            {
                new FoodResource { Name = "Fresh Vegetables", Location = "Community Center" },
                new FoodResource { Name = "Canned Goods", Location = "Local Food Bank" },
                new FoodResource { Name = "Bread and Pastries", Location = "Bakery Outlet" }
            };
            var foodListView = this.FindByName<ListView>("FoodListView");

            // Set the ItemsSource for the ListView
            foodListView.ItemsSource = foodResources;
        }
        private void OnConnectClicked(object sender, EventArgs e)
        {
            DisplayAlert("Connect", "Connecting to nearest food bank...", "OK");

        }
        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
        private void OnSearchClicked(object sender, EventArgs e)
        {
            DisplayAlert("Search", "Search functionality not implemented yet.", "OK");
        }



    }
}