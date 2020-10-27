using SebastianRezaExamen.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SebastianRezaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private const double SemesterCost = 1800;
        private readonly Student _student;
        public Registro(Student student)
        {
            InitializeComponent();
            _student = student;
            lblUserConected.Text += _student.Username;            
        }

        private async void BtnCalculatePayments_Clicked(object sender, System.EventArgs e)
        {
            double initalAmount = Convert.ToDouble(txtInitalAmount.Text);
            if (initalAmount < 0 ||
                initalAmount > SemesterCost) 
            {
                await DisplayAlert("Alert", $"Initial Amount must be greather than 0 and less than {SemesterCost}", "Ok");
                return;
            }

            double residue = (SemesterCost - initalAmount) / 3;
            double interest = residue * 0.05;
            double monthlyPayment = (residue + interest);
            lblMonthlyPayment.Text = $"{monthlyPayment}";
            _student.TotalPayment = monthlyPayment * 3;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)||
                string.IsNullOrWhiteSpace(txtInitalAmount.Text))
            {
                await DisplayAlert("Alert", $"Please complete all entries", "Ok");
                return;
            }

            if (string.IsNullOrWhiteSpace(lblMonthlyPayment.Text))
            {
                await DisplayAlert("Alert", $"Please Calculate Monthly Payment", "Ok");
                return;
            }
            _student.Name = txtName.Text;
            
            await DisplayAlert("Info", $"Saved Succesfully", "Ok");
            await Navigation.PushAsync(new Resumen(_student));
        }
    }
}