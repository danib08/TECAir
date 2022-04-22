using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using MobileApp.Models;

namespace MobileApp.Adapters
{
    class FlightAdapter : BaseAdapter<Flight>
    {
        public List<Flight> fList;
        private Context context;

        public FlightAdapter(Context context, List<Flight> fList)
        {
            this.fList = fList;
            this.context = context;
        }

        public override Flight this[int position]
        {
            get
            {
                return fList[position];
            }
        }
        public override int Count
        {
            get
            {
                return fList.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            try
            {
                if (row == null)
                {
                    row = LayoutInflater.From(context).Inflate(Resource.Layout.listview_row, null, false);
                }

                TextView txtFlightNum = row.FindViewById<TextView>(Resource.Id.editTextNum);
                TextView txtPrice = row.FindViewById<TextView>(Resource.Id.editTextPrice);

                txtFlightNum.Text = "Vuelo #" + fList[position].Flightid;
                txtPrice.Text = "$" + fList[position].Price.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return row;
        }
    }
}