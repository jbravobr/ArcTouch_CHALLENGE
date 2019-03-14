using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace arcthouchapply.Controls
{
    public partial class Rating : ContentView
    {
        public Rating()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty RatingValueProperty = BindableProperty.Create("RatingValue",
                                                                            typeof(double),
                                                                            typeof(Rating),
                                                                            default(double));
        public double RatingValue
        {
            get { return (double)GetValue(RatingValueProperty); }
            set { SetValue(RatingValueProperty, value); }
        }
    }
}
