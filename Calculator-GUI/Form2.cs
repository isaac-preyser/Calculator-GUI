using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using Newtonsoft.Json;

namespace Calculator_GUI
{ 
    public partial class CurrencyConv : Form
    {


        public CurrencyConv()
        {
            InitializeComponent();
        }

        public void Form2_Load(object sender, EventArgs e)
        {
        

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            //on load, get ready to use api. 
            //this is my first time attempting to use an API, please don't rip me a new one. 

            string[] currency = { "USD", }; //do later- should parse through inital ping to the API, and parse for every currency code, and add it to this array.
            int selectedCurrency = 0;
            string apiKey = "e8ed1000-52ec-11ec-89ee-d986dfcfbb87";
            var client = new RestClient("https://freecurrencyapi.net");
            var request = new RestRequest($"/api/v2/latest?apikey=" + apiKey + "&base_currency=" + currency[selectedCurrency] + "&fields=data", DataFormat.Json);
            var response = client.Get(request);

            RestSharp.Serialization.Json.JsonDeserializer deserial = new RestSharp.Serialization.Json.JsonDeserializer();


            var deserialized = JsonConvert.DeserializeObject<CurrRoot>(response.Content);
        }

        private void openCalc_Click(object sender, EventArgs e)
        {
            CalcWindow form = new CalcWindow();
            this.Hide();
            form.ShowDialog(); //this doesn't end the process, so if a user spammed the button they could end up running out of memory. 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add
        }
    }
    public class CurrQuery
    {
        public string apikey { get; set; }
        public int timestamp { get; set; }
        public string base_currency { get; set; }
    }

    public class CurrData
    {
        public double JPY { get; set; }
        public double CNY { get; set; } //consider rewriting this monstrosity to parse individual datapoints (maybe seek help understanding how to do this..)
        public double CHF { get; set; }//should basically parse the string and int out to grab the right data, and loop through for each pair of things. 
        public double CAD { get; set; }
        public double MXN { get; set; }
        public double INR { get; set; }
        public double BRL { get; set; }
        public double RUB { get; set; }
        public double KRW { get; set; }
        public double IDR { get; set; }
        public double TRY { get; set; }
        public double SAR { get; set; }
        public double SEK { get; set; }
        public double NGN { get; set; }
        public double PLN { get; set; } //this took WAY TOO LONG TO DO
        public double ARS { get; set; }
        public double NOK { get; set; }
        public double TWD { get; set; }
        public double IRR { get; set; }
        public double AED { get; set; }
        public double COP { get; set; }
        public double THB { get; set; }
        public double ZAR { get; set; }
        public double DKK { get; set; }
        public double MYR { get; set; }
        public double SGD { get; set; }
        public double ILS { get; set; }
        public double HKD { get; set; }
        public double EGP { get; set; }
        public double PHP { get; set; }
        public double CLP { get; set; }
        public double PKR { get; set; }
        public double IQD { get; set; }
        public double DZD { get; set; }
        public double KZT { get; set; }
        public double QAR { get; set; }
        public double CZK { get; set; }
        public double PEN { get; set; }
        public double RON { get; set; }
        public double VND { get; set; }
        public double BDT { get; set; }
        public double HUF { get; set; }
        public double UAH { get; set; }
        public double AOA { get; set; }
        public double MAD { get; set; }
        public double OMR { get; set; }
        public double CUC { get; set; }
        public double BYR { get; set; }
        public double AZN { get; set; }
        public double LKR { get; set; }
        public double SDG { get; set; }
        public double SYP { get; set; }
        public double MMK { get; set; }
        public double DOP { get; set; }
        public double UZS { get; set; }
        public double KES { get; set; }
        public double GTQ { get; set; }
        public double URY { get; set; }
        public double HRV { get; set; }
        public double MOP { get; set; }
        public double ETB { get; set; }
        public double CRC { get; set; }
        public double TZS { get; set; }
        public double TMT { get; set; }
        public double TND { get; set; }
        public double PAB { get; set; }
        public double LBP { get; set; }
        public double RSD { get; set; }
        public double LYD { get; set; }
        public double GHS { get; set; }
        public double YER { get; set; }
        public double BOB { get; set; }
        public double BHD { get; set; }
        public double CDF { get; set; }
        public double PYG { get; set; }
        public double UGX { get; set; }
        public double SVC { get; set; }
        public double TTD { get; set; }
        public double AFN { get; set; }
        public double NPR { get; set; }
        public double HNL { get; set; }
        public double BIH { get; set; }
        public double BND { get; set; }
        public double ISK { get; set; }
        public double KHR { get; set; }
        public double GEL { get; set; }
        public double MZN { get; set; }
        public double BWP { get; set; }
        public double PGK { get; set; }
        public double JMD { get; set; }
        public double XAF { get; set; }
        public double NAD { get; set; }
        public double ALL { get; set; }
        public double SSP { get; set; }
        public double MUR { get; set; }
        public double MNT { get; set; }
        public double NIO { get; set; }
        public double LAK { get; set; }
        public double MKD { get; set; }
        public double AMD { get; set; }
        public double MGA { get; set; }
        public double XPF { get; set; }
        public double TJS { get; set; }
        public double HTG { get; set; }
        public double BSD { get; set; }
        public double MDL { get; set; }
        public double RWF { get; set; }
        public double KGS { get; set; }
        public double GNF { get; set; }
        public double SRD { get; set; }
        public double SLL { get; set; }
        public double XOF { get; set; }
        public double MWK { get; set; }
        public double FJD { get; set; }
        public double ERN { get; set; }
        public double SZL { get; set; }
        public double GYD { get; set; }
        public double BIF { get; set; }
        public double KYD { get; set; }
        public double MVR { get; set; }
        public double LSL { get; set; }
        public double LRD { get; set; }
        public double CVE { get; set; }
        public double DJF { get; set; }
        public double SCR { get; set; }
        public double SOS { get; set; }
        public double GMD { get; set; }
        public double KMF { get; set; }
        public double STD { get; set; }
        public double XRP { get; set; }
        public double AUD { get; set; }
        public double BGN { get; set; }
        public double BTC { get; set; }
        public double JOD { get; set; }
        public double GBP { get; set; }
        public double ETH { get; set; }
        public double EUR { get; set; }
        public double LTC { get; set; }
        public double NZD { get; set; }
    }

    public class CurrRoot
    {
        public CurrQuery query { get; set; }
        public CurrData data { get; set; }
    }

}
