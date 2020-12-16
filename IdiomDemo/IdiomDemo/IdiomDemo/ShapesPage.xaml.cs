using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdiomDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShapesPage : ContentPage
    {
        public ShapesPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}