using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App2
{
    public partial class PictureExercise : ContentPage
    {
        int ImageId { get; set; }

        public PictureExercise()
        {
            InitializeComponent();

            ImageId = 1;
            refreshImage(ImageId);

            left.Clicked += Left_Clicked;
            right.Clicked += Right_Clicked;
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            ImageId += 1;

            if(ImageId > 10)
            {
                ImageId = 1;
            }
            refreshImage(ImageId);
        }

        private void Left_Clicked(object sender, EventArgs e)
        {
            ImageId -= 1;

            if (ImageId < 1)
            {
                ImageId = 10;
            }

            refreshImage(ImageId);
        }

        private void refreshImage(int id)
        {

            var source = new UriImageSource {
                Uri = new Uri("http://lorempixel.com/1920/1080/city/" + id),               
                CachingEnabled = false,
            };
            image.Aspect = Aspect.AspectFit;
            image.Source = source;
            
        }
    }
}
