using SebastianRezaExamen.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SebastianRezaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if ( string.IsNullOrWhiteSpace(txtUser.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                await DisplayAlert("Alert", "Please insert all fields", "Ok");
                return;
            }

            Student user = new Student
            {
                Username = txtUser.Text,
                Password = txtPassword.Text
            };

            if (txtUser.Text.Equals("estudiante2020") &&
                txtPassword.Text.Equals("uisrael2020"))
            {
                await Navigation.PushAsync(new Registro(user));
            }
            else
            {
                await DisplayAlert("Alert", "User or Password incorrect", "Ok");
                txtUser.Text = txtPassword.Text = string.Empty;
            }
        }
    }
}