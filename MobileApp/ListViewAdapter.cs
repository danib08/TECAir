using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileApp.Models;

namespace MobileApp
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtLast { get; set; }
        public TextView txtPass { get; set; }
        public TextView txtId{ get; set; }

    }

    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Worker> workerList;

        public ListViewAdapter(Activity activity, List<Worker> workerList)
        {
            this.activity = activity;
            this.workerList = workerList;
        }

        public override int Count
        {
            get { return workerList.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return workerList[position].Workerid;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListViewDataTemplate, parent, false);
            var textName = view.FindViewById<TextView>(Resource.Id.textView1);
            var textLast = view.FindViewById<TextView>(Resource.Id.textView2);
            var textPass = view.FindViewById<TextView>(Resource.Id.textView3);

            textName.Text = workerList[position].Nameworker;
            textLast.Text = workerList[position].Lastnameworker;
            textPass.Text = workerList[position].Passworker;

            return view;
        }
    }
}