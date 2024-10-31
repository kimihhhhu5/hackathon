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
    public partial class GetInvolved : ContentPage
    {
        public GetInvolved()
        {
            InitializeComponent();
        }
        private void OnVolunteerClicked (object sender, EventArgs e)
        {
            DisplayAlert("Volunteer", "Volunteer opportunities will be available soon.", "OK");
        }
        private void OnFundraiseClicked(object sender, EventArgs e)
        {
            DisplayAlert("Fundraise", "Fundraising options will be available soon.", "OK");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Advocate", "Advocacy information will be available soon.", "OK");
        }
        private void OnBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
   
    }
