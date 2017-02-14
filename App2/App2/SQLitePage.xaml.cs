﻿using App2.Models;
using App2.Persistence;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2
{


    public partial class SQLitePage : ContentPage
    {

        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public SQLitePage()
        {
            InitializeComponent();
                        
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();            
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);

            recipesListView.ItemsSource = _recipes;
            
            base.OnAppearing();            
        }


        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            
            await _connection.InsertAsync(recipe);
            
            _recipes.Add(recipe);
        }

        async void OnUpdate(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];

            recipe.Name += " UPDATED";

            await _connection.UpdateAsync(recipe);
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            var recipe = _recipes[0];

            await _connection.DeleteAsync(recipe);

            _recipes.Remove(recipe);
        }
    }
}