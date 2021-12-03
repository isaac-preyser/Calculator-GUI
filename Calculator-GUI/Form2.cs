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
using Json.Net;
using System.Reflection;

namespace Calculator_GUI
{ 
    public partial class CurrencyConv : Form
    {

        //globals       
        CurrRoot currValues = new CurrRoot();
        decimal currAmt = 0;

        public CurrencyConv()
        {
            InitializeComponent();
            PingApi("USD");
            numericUpDown1.Value = currAmt;

        }


        private void PingApi(string currCode)
        {
            
            string apiKey = "e8ed1000-52ec-11ec-89ee-d986dfcfbb87";
            var client = new RestClient("https://freecurrencyapi.net");
            var request = new RestRequest($"/api/v2/latest?apikey=" + apiKey + "&base_currency=" + currCode +  "&fields=data", DataFormat.Json);
            var response = client.Get(request);

            currValues = JsonConvert.DeserializeObject<CurrRoot>(response.Content);

            Type test = currValues.data.GetType();

            PropertyInfo[] props = test.GetProperties();


            List<string> currency = new List<string>(); //do later- should parse through inital ping to the API, and parse for every currency code, and add it to this array.
            
            foreach (PropertyInfo prop in props)
            {
                currency.Add(Convert.ToString(prop).TrimStart('D', 'o', 'u', 'b', 'l', 'e', ' '));
              
            }

            comboBox1.Items.AddRange(currency.ToArray());
            comboBox2.Items.AddRange(currency.ToArray());

        }
        
        
        public void Form2_Load(object sender, EventArgs e)
        {
            //on load, get ready to use api. 
            //this is my first time attempting to use an API, please don't rip me a new one. 

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
               
                
                
             
            
        }

        private void openCalc_Click(object sender, EventArgs e)
        {
            CalcWindow form = new CalcWindow();
            this.Hide();
            form.ShowDialog(); //this doesn't end the process, so if a user spammed the button they could end up running out of memory. 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            //locals
            Type t = currValues.data.GetType();
            PropertyInfo[] props = t.GetProperties();
            bool oneTrue = false;
            bool twoTrue = false;
            PropertyInfo selectedProp1 = props[0];
            PropertyInfo selectedProp2 = props[0];

            //code
            foreach (PropertyInfo p in props)
            {
                if (Convert.ToString(p).TrimStart('D', 'o', 'u', 'b', 'l', 'e', ' ') == Convert.ToString(comboBox1.SelectedItem))
                {
                    selectedProp1 = p;
                    oneTrue = true;
                    if (twoTrue == true && oneTrue == true)
                    {
                        break;
                    }
                    
                }
                if (Convert.ToString(p).TrimStart('D', 'o', 'u', 'b', 'l', 'e', ' ') == Convert.ToString(comboBox2.SelectedItem))
                {
                    selectedProp2 = p;
                    twoTrue = true;
                    if (twoTrue == true && oneTrue == true)
                    {
                        break;
                    }
                }
            }

            PingApi(Convert.ToString(selectedProp1.Name.TrimStart('D', 'o', 'u', 'b', 'l', 'e', ' ')));
            switch(selectedProp2.Name.TrimStart('D', 'o', 'u', 'b', 'l', 'e', ' '))
            {
                case "CAD":
                    testOutput.Text = Convert.ToString(currValues.data.CAD); //it is time to use grep to skip writing all this code. this is a terrible way of doing this
                    break;
               case "USD":
                    testOutput.Text = Convert.ToString(currValues.data.USD); //I LOVE MULTI-CARETED EDITNG ty v much microsoft
                    break;                                                 
               case "JPY":                                                  
                    testOutput.Text = Convert.ToString(currValues.data.JPY);
                    break;
               case "CNY": 
                    testOutput.Text = Convert.ToString(currValues.data.CNY);
                    break;
               case "CHF": 
                    testOutput.Text = Convert.ToString(currValues.data.CHF);
                    break;
               case "MXN": 
                    testOutput.Text = Convert.ToString(currValues.data.MXN);
                    break;
               case "INR": 
                    testOutput.Text = Convert.ToString(currValues.data.INR);
                    break;
               case "BRL": 
                    testOutput.Text = Convert.ToString(currValues.data.BRL);
                    break;
               case "RUB": 
                    testOutput.Text = Convert.ToString(currValues.data.RUB);
                    break;
               case "KRW": 
                    testOutput.Text = Convert.ToString(currValues.data.KRW);
                    break;
               case "IDR": 
                    testOutput.Text = Convert.ToString(currValues.data.IDR);
                    break;
               case "TRY": 
                    testOutput.Text = Convert.ToString(currValues.data.TRY);
                    break;
               case "SAR": 
                    testOutput.Text = Convert.ToString(currValues.data.SAR);
                    break;
               case "SEK": 
                    testOutput.Text = Convert.ToString(currValues.data.SEK);
                    break;
               case "NGN": 
                    testOutput.Text = Convert.ToString(currValues.data.NGN);
                    break;
               case "PLN": 
                    testOutput.Text = Convert.ToString(currValues.data.PLN);
                    break;
               case "ARS": 
                    testOutput.Text = Convert.ToString(currValues.data.ARS);
                    break;
               case "NOK": 
                    testOutput.Text = Convert.ToString(currValues.data.NOK);
                    break;
               case "TWD": 
                    testOutput.Text = Convert.ToString(currValues.data.TWD);
                    break;
               case "IRR": 
                    testOutput.Text = Convert.ToString(currValues.data.IRR);
                    break;
               case "AED": 
                    testOutput.Text = Convert.ToString(currValues.data.AED);
                    break;
               case "COP": 
                    testOutput.Text = Convert.ToString(currValues.data.COP);
                    break;
               case "THB": 
                    testOutput.Text = Convert.ToString(currValues.data.THB);
                    break;
               case "ZAR": 
                    testOutput.Text = Convert.ToString(currValues.data.ZAR);
                    break;
               case "DKK": 
                    testOutput.Text = Convert.ToString(currValues.data.DKK);
                    break;
               case "MYR": 
                    testOutput.Text = Convert.ToString(currValues.data.MYR);
                    break;
               case "SGD": 
                    testOutput.Text = Convert.ToString(currValues.data.SGD);
                    break;
               case "ILS": 
                    testOutput.Text = Convert.ToString(currValues.data.ILS);
                    break;
               case "HKD": 
                    testOutput.Text = Convert.ToString(currValues.data.HKD);
                    break;
               case "EGP": 
                    testOutput.Text = Convert.ToString(currValues.data.EGP);
                    break;
               case "PHP": 
                    testOutput.Text = Convert.ToString(currValues.data.PHP);
                    break;
               case "CLP": 
                    testOutput.Text = Convert.ToString(currValues.data.CLP);
                    break;
               case "PKR": 
                    testOutput.Text = Convert.ToString(currValues.data.PKR);
                    break;
               case "IQD": 
                    testOutput.Text = Convert.ToString(currValues.data.IQD);
                    break;
               case "DZD": 
                    testOutput.Text = Convert.ToString(currValues.data.DZD);
                    break;
               case "KZT": 
                    testOutput.Text = Convert.ToString(currValues.data.KZT);
                    break;
               case "QAR": 
                    testOutput.Text = Convert.ToString(currValues.data.QAR);
                    break;
               case "CZK": 
                    testOutput.Text = Convert.ToString(currValues.data.CZK);
                    break;
               case "PEN": 
                    testOutput.Text = Convert.ToString(currValues.data.PEN);
                    break;
               case "RON": 
                    testOutput.Text = Convert.ToString(currValues.data.RON);
                    break;
               case "VND": 
                    testOutput.Text = Convert.ToString(currValues.data.VND);
                    break;
               case "BDT": 
                    testOutput.Text = Convert.ToString(currValues.data.BDT);
                    break;
               case "HUF": 
                    testOutput.Text = Convert.ToString(currValues.data.HUF);
                    break;
               case "UAH": 
                    testOutput.Text = Convert.ToString(currValues.data.UAH);
                    break;
               case "AOA": 
                    testOutput.Text = Convert.ToString(currValues.data.AOA);
                    break;
               case "MAD": 
                    testOutput.Text = Convert.ToString(currValues.data.MAD);
                    break;
               case "OMR": 
                    testOutput.Text = Convert.ToString(currValues.data.OMR);
                    break;
               case "CUC": 
                    testOutput.Text = Convert.ToString(currValues.data.CUC);
                    break;
               case "BYR": 
                    testOutput.Text = Convert.ToString(currValues.data.BYR);
                    break;
               case "AZN": 
                    testOutput.Text = Convert.ToString(currValues.data.AZN);
                    break;
               case "LKR": 
                    testOutput.Text = Convert.ToString(currValues.data.LKR);
                    break;
               case "SDG": 
                    testOutput.Text = Convert.ToString(currValues.data.SDG);
                    break;
               case "SYP": 
                    testOutput.Text = Convert.ToString(currValues.data.SYP);
                    break;
               case "MMK": 
                    testOutput.Text = Convert.ToString(currValues.data.MMK);
                    break;
               case "DOP": 
                    testOutput.Text = Convert.ToString(currValues.data.DOP);
                    break;
               case "UZS": 
                    testOutput.Text = Convert.ToString(currValues.data.UZS);
                    break;
               case "KES": 
                    testOutput.Text = Convert.ToString(currValues.data.KES);
                    break;
               case "GTQ": 
                    testOutput.Text = Convert.ToString(currValues.data.GTQ);
                    break;
               case "URY": 
                    testOutput.Text = Convert.ToString(currValues.data.URY);
                    break;
               case "HRV": 
                    testOutput.Text = Convert.ToString(currValues.data.HRV);
                    break;
               case "MOP": 
                    testOutput.Text = Convert.ToString(currValues.data.MOP);
                    break;
               case "ETB": 
                    testOutput.Text = Convert.ToString(currValues.data.ETB);
                    break;
               case "CRC": 
                    testOutput.Text = Convert.ToString(currValues.data.CRC);
                    break;
               case "TZS": 
                    testOutput.Text = Convert.ToString(currValues.data.TZS);
                    break;
               case "TMT": 
                    testOutput.Text = Convert.ToString(currValues.data.TMT);
                    break;
               case "TND": 
                    testOutput.Text = Convert.ToString(currValues.data.TND);
                    break;
               case "PAB": 
                    testOutput.Text = Convert.ToString(currValues.data.PAB);
                    break;
               case "LBP": 
                    testOutput.Text = Convert.ToString(currValues.data.LBP);
                    break;
               case "RSD": 
                    testOutput.Text = Convert.ToString(currValues.data.RSD);
                    break;
               case "LYD": 
                    testOutput.Text = Convert.ToString(currValues.data.LYD);
                    break;
               case "GHS": 
                    testOutput.Text = Convert.ToString(currValues.data.GHS);
                    break;
               case "YER": 
                    testOutput.Text = Convert.ToString(currValues.data.YER);
                    break;
               case "BOB": 
                    testOutput.Text = Convert.ToString(currValues.data.BOB);
                    break;
               case "BHD": 
                    testOutput.Text = Convert.ToString(currValues.data.BHD);
                    break;
               case "CDF": 
                    testOutput.Text = Convert.ToString(currValues.data.CDF);
                    break;
               case "PYG": 
                    testOutput.Text = Convert.ToString(currValues.data.PYG);
                    break;
               case "UGX": 
                    testOutput.Text = Convert.ToString(currValues.data.UGX);
                    break;
               case "SVC": 
                    testOutput.Text = Convert.ToString(currValues.data.SVC);
                    break;
               case "TTD": 
                    testOutput.Text = Convert.ToString(currValues.data.TTD);
                    break;
               case "AFN": 
                    testOutput.Text = Convert.ToString(currValues.data.AFN);
                    break;
               case "NPR": 
                    testOutput.Text = Convert.ToString(currValues.data.NPR);
                    break;
               case "HNL": 
                    testOutput.Text = Convert.ToString(currValues.data.HNL);
                    break;
               case "BIH": 
                    testOutput.Text = Convert.ToString(currValues.data.BIH);
                    break;
               case "BND": 
                    testOutput.Text = Convert.ToString(currValues.data.BND);
                    break;
               case "ISK": 
                    testOutput.Text = Convert.ToString(currValues.data.ISK);
                    break;
               case "KHR": 
                    testOutput.Text = Convert.ToString(currValues.data.KHR);
                    break;
               case "GEL": 
                    testOutput.Text = Convert.ToString(currValues.data.GEL);
                    break;
               case "MZN": 
                    testOutput.Text = Convert.ToString(currValues.data.MZN);
                    break;
               case "BWP": 
                    testOutput.Text = Convert.ToString(currValues.data.BWP);
                    break;
               case "PGK": 
                    testOutput.Text = Convert.ToString(currValues.data.PGK);
                    break;
               case "JMD": 
                    testOutput.Text = Convert.ToString(currValues.data.JMD);
                    break;
               case "XAF": 
                    testOutput.Text = Convert.ToString(currValues.data.XAF);
                    break;
               case "NAD": 
                    testOutput.Text = Convert.ToString(currValues.data.NAD);
                    break;
               case "ALL": 
                    testOutput.Text = Convert.ToString(currValues.data.ALL);
                    break;
               case "SSP": 
                    testOutput.Text = Convert.ToString(currValues.data.SSP);
                    break;
               case "MUR": 
                    testOutput.Text = Convert.ToString(currValues.data.MUR);
                    break;
               case "MNT": 
                    testOutput.Text = Convert.ToString(currValues.data.MNT);
                    break;
               case "NIO": 
                    testOutput.Text = Convert.ToString(currValues.data.NIO);
                    break;
               case "LAK": 
                    testOutput.Text = Convert.ToString(currValues.data.LAK);
                    break;
               case "MKD": 
                    testOutput.Text = Convert.ToString(currValues.data.MKD);
                    break;
               case "AMD": 
                    testOutput.Text = Convert.ToString(currValues.data.AMD);
                    break;
               case "MGA": 
                    testOutput.Text = Convert.ToString(currValues.data.MGA);
                    break;
               case "XPF": 
                    testOutput.Text = Convert.ToString(currValues.data.XPF);
                    break;
               case "TJS": 
                    testOutput.Text = Convert.ToString(currValues.data.TJS);
                    break;
               case "HTG": 
                    testOutput.Text = Convert.ToString(currValues.data.HTG);
                    break;
               case "BSD": 
                    testOutput.Text = Convert.ToString(currValues.data.BSD);
                    break;
               case "MDL": 
                    testOutput.Text = Convert.ToString(currValues.data.MDL);
                    break;
               case "RWF": 
                    testOutput.Text = Convert.ToString(currValues.data.RWF);
                    break;
               case "KGS": 
                    testOutput.Text = Convert.ToString(currValues.data.KGS);
                    break;
               case "GNF": 
                    testOutput.Text = Convert.ToString(currValues.data.GNF);
                    break;
               case "SRD": 
                    testOutput.Text = Convert.ToString(currValues.data.SRD);
                    break;
               case "SLL": 
                    testOutput.Text = Convert.ToString(currValues.data.SLL);
                    break;
               case "XOF": 
                    testOutput.Text = Convert.ToString(currValues.data.XOF);
                    break;
               case "MWK": 
                    testOutput.Text = Convert.ToString(currValues.data.MWK);
                    break;
               case "FJD": 
                    testOutput.Text = Convert.ToString(currValues.data.FJD);
                    break;
               case "ERN": 
                    testOutput.Text = Convert.ToString(currValues.data.ERN);
                    break;
               case "SZL": 
                    testOutput.Text = Convert.ToString(currValues.data.SZL);
                    break;
               case "GYD": 
                    testOutput.Text = Convert.ToString(currValues.data.GYD);
                    break;
               case "BIF": 
                    testOutput.Text = Convert.ToString(currValues.data.BIF);
                    break;
               case "KYD": 
                    testOutput.Text = Convert.ToString(currValues.data.KYD);
                    break;
               case "MVR": 
                    testOutput.Text = Convert.ToString(currValues.data.MVR);
                    break;
               case "LSL": 
                    testOutput.Text = Convert.ToString(currValues.data.LSL);
                    break;
               case "LRD": 
                    testOutput.Text = Convert.ToString(currValues.data.LRD);
                    break;
               case "CVE": 
                    testOutput.Text = Convert.ToString(currValues.data.CVE);
                    break;
               case "DJF": 
                    testOutput.Text = Convert.ToString(currValues.data.DJF);
                    break;
               case "SCR": 
                    testOutput.Text = Convert.ToString(currValues.data.SCR);
                    break;
               case "SOS": 
                    testOutput.Text = Convert.ToString(currValues.data.SOS);
                    break;
               case "GMD": 
                    testOutput.Text = Convert.ToString(currValues.data.GMD);
                    break;
               case "KMF": 
                    testOutput.Text = Convert.ToString(currValues.data.KMF);
                    break;
               case "STD": 
                    testOutput.Text = Convert.ToString(currValues.data.STD);
                    break;
               case "XRP": 
                    testOutput.Text = Convert.ToString(currValues.data.XRP);
                    break;
               case "AUD": 
                    testOutput.Text = Convert.ToString(currValues.data.AUD);
                    break;
               case "BGN": 
                    testOutput.Text = Convert.ToString(currValues.data.BGN);
                    break;
               case "BTC": 
                    testOutput.Text = Convert.ToString(currValues.data.BTC);
                    break;
               case "JOD": 
                    testOutput.Text = Convert.ToString(currValues.data.JOD);
                    break;
               case "GBP": 
                    testOutput.Text = Convert.ToString(currValues.data.GBP);
                    break;
               case "ETH": 
                    testOutput.Text = Convert.ToString(currValues.data.ETH);
                    break;
               case "EUR": 
                    testOutput.Text = Convert.ToString(currValues.data.EUR);
                    break;
               case "LTC": 
                    testOutput.Text = Convert.ToString(currValues.data.LTC);
                    break;
               case "NZD": 
                    testOutput.Text = Convert.ToString(currValues.data.NZD);
                    break;

    }
            
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //amt of currency 
            currAmt = numericUpDown1.Value;
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
        public double USD { get; set; }
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
