using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2
{
    public partial class FormPage1 : ContentPage
    {
        public FormPage1()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            label1.Text = "Completed";
        }


        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            label1.Text = e.NewTextValue;
        }
    }
}
