using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using RePlay_Activity_Common;
using RePlay_Exercises;
using System;

namespace RePlay_Activity_TrafficRacer
{
	[Activity(Label = "RePlay_Activity_TrafficRacer"
		, AlwaysRetainTaskState = true
		, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
		, ScreenOrientation = ScreenOrientation.UserLandscape
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]
	public class Activity1 : RePlay_Game_Activity
	{
        #region OnCreate/OnResume

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            //Go full screen
            StartImmersiveMode();

            //Parse the intent data
            var game_launch_parameters = ParseIntentData();

            //Instantiate the game
            var g = new TrafficGame(game_launch_parameters);
            
            //Display and run the game
            SubscribeToGameEvents(g);
            AddGameToView(g);
            ShowSplashScreen();
            SetContentView(MainGameLayout);

            g.Run();
        }

        // Restart immersive mode
        protected override void OnResume()
        {
            base.OnResume();
            
            StartImmersiveMode();
        }
        
        #endregion
    }
}

