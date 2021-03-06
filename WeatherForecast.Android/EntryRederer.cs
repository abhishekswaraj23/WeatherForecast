﻿using System;
using System.Runtime.Remoting.Contexts;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using WeatherForecast.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomeEntryRenderer))]
namespace WeatherForecast.Droid
{
    public class CustomeEntryRenderer : EntryRenderer
    {
        public CustomeEntryRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetBackgroundDrawable(gd);
                this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Gray));
            }
        }
    }
    
}
