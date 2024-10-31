using System;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HACKATHON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminControlPage : ContentPage
    {
        private ObservableCollection<Donor> AllDonors;

        public AdminControlPage()
        {
            InitializeComponent();
            LoadDonors();
        }

        private void LoadDonors()
        {
            // Load donors from local storage
            if (Application.Current.Properties.ContainsKey("Donors"))
            {
                var json = Application.Current.Properties["Donors"] as string;
                AllDonors = JsonConvert.DeserializeObject<ObservableCollection<Donor>>(json) ?? new ObservableCollection<Donor>();
            }
            else
            {
                AllDonors = new ObservableCollection<Donor>();
            }

            DonorListView.ItemsSource = AllDonors;
        }

        private async void Update(object sender, EventArgs e)
        {
            var selectedDonor = (Donor)DonorListView.SelectedItem;
            if (selectedDonor != null)
            {
                var donateFoodPage = new DonateFoodPage(selectedDonor);
                await Navigation.PushAsync(donateFoodPage);
            }
        }

        private async void Delete(object sender, EventArgs e)
        {
            var selectedDonor = (Donor)DonorListView.SelectedItem;
            if (selectedDonor != null)
            {
                bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete?", "Yes", "No");
                if (confirm)
                {
                    AllDonors.Remove(selectedDonor);
                    SaveDonors(); // Update local storage
                    LoadDonors(); // Refresh the list
                }
            }
        }

        private void SaveDonors()
        {
            // Convert donor list to JSON and store locally
            var json = JsonConvert.SerializeObject(AllDonors);
            Application.Current.Properties["Donors"] = json;
            Application.Current.SavePropertiesAsync();
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue?.ToLower();
            var filteredDonors = AllDonors.Where(d =>
                d.DonorName.ToLower().Contains(searchText) ||
                d.DonorDetails.ToLower().Contains(searchText)).ToList();

            DonorListView.ItemsSource = string.IsNullOrWhiteSpace(searchText) ? AllDonors : new ObservableCollection<Donor>(filteredDonors);
            NoRecordLabel.IsVisible = !filteredDonors.Any();
        }
        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }

    public class Donor
    {
        public int Id { get; set; }
        public string DonorName { get; set; }
        public string DonorDetails { get; set; }
        public string DonorContact {  get; set; }

        public string DonorAddress { get; set; }
        public string DonorAmount { get; set; }
        public string DonorType { get; set; }
    }
}
