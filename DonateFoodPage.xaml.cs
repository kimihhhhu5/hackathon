using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HACKATHON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonateFoodPage : ContentPage
    {
        private Donor _donor;
        private ObservableCollection<Donor> AllDonors;

        public DonateFoodPage(Donor donor = null)
        {
            InitializeComponent();
            _donor = donor;
            LoadDonors();

            if (_donor != null)
            {
                NameEntry.Text = _donor.DonorName;
                DetailsEntry.Text = _donor.DonorDetails;

            }
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
        }

        private void SaveDonors()
        {
            // Convert donor list to JSON and store locally
            var json = JsonConvert.SerializeObject(AllDonors);
            Application.Current.Properties["Donors"] = json;
            Application.Current.SavePropertiesAsync();
        }

        private async void OnSubmitDonationClicked(object sender, EventArgs e)
        {
            if (_donor == null)
            {
                // Insert new donor
                _donor = new Donor
                {
                    Id = AllDonors.Count + 1,
                    DonorName = NameEntry.Text,
                    DonorDetails = DetailsEntry.Text
                };
                AllDonors.Add(_donor);
            }
            else
            {
                // Update existing donor
                _donor.DonorName = NameEntry.Text;
                _donor.DonorDetails = DetailsEntry.Text;
            }

            SaveDonors(); // Save to local storage
            await DisplayAlert("Success", "Your donation has been submitted!", "OK");
            await Navigation.PopAsync();
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
