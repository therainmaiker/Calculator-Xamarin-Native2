using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

           


            //Button TxtNumber1 = 



            EditText TxtNumber1 = FindViewById<EditText>(Resource.Id.TxtNumber1);
            EditText TxtNumber2 = FindViewById<EditText>(Resource.Id.TxtNumber2);
           TextView textResult = FindViewById<TextView>(Resource.Id.textResult);


            // ReSharper disable once PossibleNullReferenceException
           
            FindViewById<Button>(Resource.Id.DivideBtn1).Click += (sender, e) =>

                textResult.Text = (Convert.ToInt64(TxtNumber1.Text) / Convert.ToInt64(TxtNumber2.Text)).ToString();


            FindViewById<Button>(Resource.Id.AddBtn3).Click += (sender, b) =>

              textResult.Text = (Convert.ToInt64(TxtNumber1.Text) + Convert.ToInt64(TxtNumber2.Text)).ToString();

            FindViewById<Button>(Resource.Id.SubtractBtn2).Click += (sender, b) =>

              textResult.Text = (Convert.ToInt64(TxtNumber1.Text) - Convert.ToInt64(TxtNumber2.Text)).ToString();

            FindViewById<Button>(Resource.Id.MultipleBtn4).Click += (sender, b) =>

              textResult.Text = (Convert.ToInt64(TxtNumber1.Text) * Convert.ToInt64(TxtNumber2.Text)).ToString();


        }
        

        


    }
}