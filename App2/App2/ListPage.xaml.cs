using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace App2
{
    public partial class ListPage : ContentPage
    {
        private ObservableCollection<Contact> _contacts;

        public ListPage()
        {
            InitializeComponent();

            //listView.ItemsSource =
            //    new List<ContactGroup> {

            //        new ContactGroup("P", "P")
            //        {
            //             new Contact { Name = "Piet", ImageUrl="http://lorempixel.com/100/100/people/1" }
            //        },
            //        new ContactGroup("K", "K")
            //        {
            //             new Contact { Name = "Klaas", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk!" }
            //        },
            //        new ContactGroup("Z", "Z")
            //        {
            //             new Contact { Name = "Zaag", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk" }
            //        }
            //    };


            //_contacts =
            //    new ObservableCollection<Contact> {
            //             new Contact { Name = "Piet", ImageUrl="http://lorempixel.com/100/100/people/1" },
            //             new Contact { Name = "Klaas", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk!" },
            //             new Contact { Name = "Zaag", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk" }
            //    };

            listView.ItemsSource = GetContatcs();
            
            //listView.ItemTapped += ListView_ItemTapped;
            //listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var contact = e.SelectedItem as Contact;
            //DisplayAlert("Selected", contact.Name, "Ok");

           // listView.SelectedItem = null;

        }

        ObservableCollection<Contact> GetContatcs()
        {
            _contacts =
              new ObservableCollection<Contact> {
                         new Contact { Name = "Piet", ImageUrl="http://lorempixel.com/100/100/people/1" },
                         new Contact { Name = "Klaas", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk!" },
                         new Contact { Name = "Zaag", ImageUrl="http://lorempixel.com/100/100/people/2", Status="Hey, lets talk" }
              };

            //isnullorwhitespace  =
                //return String.IsNullOrEmpty(value) || value.Trim().Length == 0;
            return _contacts;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //var contact = e.Item as Contact;
            //DisplayAlert("Tapped", contact.Name, "Ok");
        }

        void Call_Clicked(object sender, System.EventArgs e )
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Call", contact.Name, "OK");

        }


        void Delete_Clicked(object sender, System.EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;

            _contacts.Remove(contact);
        }

        void Refresh_Clicked(object sender, System.EventArgs e)
        {
            listView.ItemsSource = GetContatcs();

            //listView.IsRefreshing = false;
            listView.EndRefresh();
        }

    }
}
