using Android.App;
using Android.Widget;
using Android.OS;
//using ESRM.Entities.Dto;
using System.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System;
using Java.IO;
using System.Net.Http;
using System.Collections.Generic;
using ESRM.Entities.Dto;
using Android.Content;

namespace ESRM.Mobile.Droid
{
    [Activity(Theme = "@style/Theme.NoTitle", MainLauncher = true, NoHistory = true)]
    //[Activity(Label = "ESRM.Mobile.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        List<TeamDto> _teams;

        private int _teamId = 1;

        private EditText _serverIp;
        private Button _btnTestServer;
        private ListView _listView;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            _serverIp = FindViewById<EditText>(Resource.Id.serverip);
            _btnTestServer = FindViewById<Button>(Resource.Id.btnConnect);
            _listView = FindViewById<ListView>(Resource.Id.listView1);


            _btnTestServer.Click += BtnTestServer_Click;
            _listView.ItemClick += TeamList_ItemClick;

            GetSettings();
        }



        private void BtnTestServer_Click(object sender, EventArgs e)
        {
            string url = _serverIp.Text;
            bool connected = EsrmProxy.ConnectToServer(url);

            if(connected)
            {
                SaveSettings();
                _teams = EsrmProxy.GetTeams();
                ArrayAdapter<TeamDto> ListAdapter = new ArrayAdapter<TeamDto>(this, Android.Resource.Layout.SimpleListItem1);
                foreach (TeamDto t in _teams)
                    ListAdapter.Add(t);
                //ListAdapter.Add(string.Format("{0} - {1}", t.TeamName, t.CurrentDriverName));
                _listView.Adapter = ListAdapter;

            }
            else
            {

            }
        }

        private void TeamList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            _teamId = _teams[e.Position].LaneId;
            Intent newMainActivity = new Intent(this, typeof(RaceDatasActivity));
            newMainActivity.PutExtra("TeamId", _teamId);
            StartActivity(newMainActivity);
        }

        protected void SaveSettings()
        {
            //store
            var prefs = Application.Context.GetSharedPreferences("ESRM", FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString("ServerIP", EsrmProxy.ESRM_SERVER_IP_OR_HOST);
            prefEditor.Commit();

        }

        // Function called from OnCreate
        protected void GetSettings()
        {
            //retreive 
            var prefs = Application.Context.GetSharedPreferences("ESRM", FileCreationMode.Private);
            var esrmUrl = prefs.GetString("ServerIP", null);


            _serverIp.Text = esrmUrl;
            if (!string.IsNullOrEmpty(_serverIp.Text))
                _btnTestServer.PerformClick();

            ////Show a toast
            //RunOnUiThread(() => Toast.MakeText(this, somePref, ToastLength.Long).Show());

        }
    }
}

