using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HACKATHON
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminLogin : ContentPage
    {
        public AdminLogin()
        {
            InitializeComponent();

            // Initialize a default admin user if not already set
            if (!Application.Current.Properties.ContainsKey("AdminUsername"))
            {
                Application.Current.Properties["AdminUsername"] = "admin";
                Application.Current.Properties["AdminPassword"] = "password123"; // Default password
                Application.Current.SavePropertiesAsync();
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string enteredUsername = UsernameEntry.Text;
            string enteredPassword = PasswordEntry.Text;

            // Retrieve stored admin credentials
            string storedUsername = Application.Current.Properties["AdminUsername"] as string;
            string storedPassword = Application.Current.Properties["AdminPassword"] as string;

            // Check if entered username and password match the stored credentials
            if (enteredUsername == storedUsername && enteredPassword == storedPassword)
            {
                await DisplayAlert("Success", "Login successful!", "OK");
                await Navigation.PushAsync(new AdminControlPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password. Please try again.", "OK");
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
