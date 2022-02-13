using RawFeederApp.ViewModels;
using Xamarin.Forms;

namespace RawFeederApp
{
    public partial class Calculate : ContentPage
    {
        public Calculate(RawFeederModel rawFeederModel)
        {
            InitializeComponent();

            rawFeederModel.Calculate();
            BindingContext = rawFeederModel;
        }
    }
}
