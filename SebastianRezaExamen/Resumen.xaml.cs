using SebastianRezaExamen.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SebastianRezaExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resumen : ContentPage
    {
        public Resumen(Student student)
        {
            InitializeComponent();
            lblUserConected.Text += student.Username;
            lblName.Text += student.Name;
            lblTotalPayment.Text += $" ${student.TotalPayment.ToString()}";
        }
    }
}