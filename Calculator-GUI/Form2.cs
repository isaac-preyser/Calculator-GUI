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
                case "USD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.USD * Convert.ToDouble(currAmt), 2)); break;
                case "JPY":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.JPY * Convert.ToDouble(currAmt), 2)); break;
                case "CNY":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CNY * Convert.ToDouble(currAmt), 2)); break;
                case "CHF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CHF * Convert.ToDouble(currAmt), 2)); break;
                case "CAD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CAD * Convert.ToDouble(currAmt), 2)); break;
                case "MXN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MXN * Convert.ToDouble(currAmt), 2)); break;
                case "INR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.INR * Convert.ToDouble(currAmt), 2)); break;
                case "BRL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BRL * Convert.ToDouble(currAmt), 2)); break;
                case "RUB":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.RUB * Convert.ToDouble(currAmt), 2)); break;
                case "KRW":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KRW * Convert.ToDouble(currAmt), 2)); break;
                case "IDR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.IDR * Convert.ToDouble(currAmt), 2)); break;
                case "TRY":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TRY * Convert.ToDouble(currAmt), 2)); break;
                case "SAR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SAR * Convert.ToDouble(currAmt), 2)); break;
                case "SEK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SEK * Convert.ToDouble(currAmt), 2)); break;
                case "NGN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NGN * Convert.ToDouble(currAmt), 2)); break;
                case "PLN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PLN * Convert.ToDouble(currAmt), 2)); break;
                case "ARS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ARS * Convert.ToDouble(currAmt), 2)); break;
                case "NOK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NOK * Convert.ToDouble(currAmt), 2)); break;
                case "TWD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TWD * Convert.ToDouble(currAmt), 2)); break;
                case "IRR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.IRR * Convert.ToDouble(currAmt), 2)); break;
                case "AED":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AED * Convert.ToDouble(currAmt), 2)); break;
                case "COP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.COP * Convert.ToDouble(currAmt), 2)); break;
                case "THB":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.THB * Convert.ToDouble(currAmt), 2)); break;
                case "ZAR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ZAR * Convert.ToDouble(currAmt), 2)); break;
                case "DKK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.DKK * Convert.ToDouble(currAmt), 2)); break;
                case "MYR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MYR * Convert.ToDouble(currAmt), 2)); break;
                case "SGD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SGD * Convert.ToDouble(currAmt), 2)); break;
                case "ILS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ILS * Convert.ToDouble(currAmt), 2)); break;
                case "HKD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.HKD * Convert.ToDouble(currAmt), 2)); break;
                case "EGP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.EGP * Convert.ToDouble(currAmt), 2)); break;
                case "PHP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PHP * Convert.ToDouble(currAmt), 2)); break;
                case "CLP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CLP * Convert.ToDouble(currAmt), 2)); break;
                case "PKR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PKR * Convert.ToDouble(currAmt), 2)); break;
                case "IQD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.IQD * Convert.ToDouble(currAmt), 2)); break;
                case "DZD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.DZD * Convert.ToDouble(currAmt), 2)); break;
                case "KZT":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KZT * Convert.ToDouble(currAmt), 2)); break;
                case "QAR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.QAR * Convert.ToDouble(currAmt), 2)); break;
                case "CZK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CZK * Convert.ToDouble(currAmt), 2)); break;
                case "PEN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PEN * Convert.ToDouble(currAmt), 2)); break;
                case "RON":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.RON * Convert.ToDouble(currAmt), 2)); break;
                case "VND":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.VND * Convert.ToDouble(currAmt), 2)); break;
                case "BDT":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BDT * Convert.ToDouble(currAmt), 2)); break;
                case "HUF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.HUF * Convert.ToDouble(currAmt), 2)); break;
                case "UAH":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.UAH * Convert.ToDouble(currAmt), 2)); break;
                case "AOA":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AOA * Convert.ToDouble(currAmt), 2)); break;
                case "MAD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MAD * Convert.ToDouble(currAmt), 2)); break;
                case "OMR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.OMR * Convert.ToDouble(currAmt), 2)); break;
                case "CUC":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CUC * Convert.ToDouble(currAmt), 2)); break;
                case "BYR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BYR * Convert.ToDouble(currAmt), 2)); break;
                case "AZN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AZN * Convert.ToDouble(currAmt), 2)); break;
                case "LKR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LKR * Convert.ToDouble(currAmt), 2)); break;
                case "SDG":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SDG * Convert.ToDouble(currAmt), 2)); break;
                case "SYP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SYP * Convert.ToDouble(currAmt), 2)); break;
                case "MMK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MMK * Convert.ToDouble(currAmt), 2)); break;
                case "DOP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.DOP * Convert.ToDouble(currAmt), 2)); break;
                case "UZS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.UZS * Convert.ToDouble(currAmt), 2)); break;
                case "KES":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KES * Convert.ToDouble(currAmt), 2)); break;
                case "GTQ":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GTQ * Convert.ToDouble(currAmt), 2)); break;
                case "URY":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.URY * Convert.ToDouble(currAmt), 2)); break;
                case "HRV":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.HRV * Convert.ToDouble(currAmt), 2)); break;
                case "MOP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MOP * Convert.ToDouble(currAmt), 2)); break;
                case "ETB":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ETB * Convert.ToDouble(currAmt), 2)); break;
                case "CRC":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CRC * Convert.ToDouble(currAmt), 2)); break;
                case "TZS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TZS * Convert.ToDouble(currAmt), 2)); break;
                case "TMT":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TMT * Convert.ToDouble(currAmt), 2)); break;
                case "TND":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TND * Convert.ToDouble(currAmt), 2)); break;
                case "PAB":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PAB * Convert.ToDouble(currAmt), 2)); break;
                case "LBP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LBP * Convert.ToDouble(currAmt), 2)); break;
                case "RSD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.RSD * Convert.ToDouble(currAmt), 2)); break;
                case "LYD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LYD * Convert.ToDouble(currAmt), 2)); break;
                case "GHS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GHS * Convert.ToDouble(currAmt), 2)); break;
                case "YER":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.YER * Convert.ToDouble(currAmt), 2)); break;
                case "BOB":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BOB * Convert.ToDouble(currAmt), 2)); break;
                case "BHD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BHD * Convert.ToDouble(currAmt), 2)); break;
                case "CDF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CDF * Convert.ToDouble(currAmt), 2)); break;
                case "PYG":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PYG * Convert.ToDouble(currAmt), 2)); break;
                case "UGX":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.UGX * Convert.ToDouble(currAmt), 2)); break;
                case "SVC":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SVC * Convert.ToDouble(currAmt), 2)); break;
                case "TTD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TTD * Convert.ToDouble(currAmt), 2)); break;
                case "AFN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AFN * Convert.ToDouble(currAmt), 2)); break;
                case "NPR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NPR * Convert.ToDouble(currAmt), 2)); break;
                case "HNL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.HNL * Convert.ToDouble(currAmt), 2)); break;
                case "BIH":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BIH * Convert.ToDouble(currAmt), 2)); break;
                case "BND":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BND * Convert.ToDouble(currAmt), 2)); break;
                case "ISK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ISK * Convert.ToDouble(currAmt), 2)); break;
                case "KHR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KHR * Convert.ToDouble(currAmt), 2)); break;
                case "GEL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GEL * Convert.ToDouble(currAmt), 2)); break;
                case "MZN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MZN * Convert.ToDouble(currAmt), 2)); break;
                case "BWP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BWP * Convert.ToDouble(currAmt), 2)); break;
                case "PGK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.PGK * Convert.ToDouble(currAmt), 2)); break;
                case "JMD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.JMD * Convert.ToDouble(currAmt), 2)); break;
                case "XAF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.XAF * Convert.ToDouble(currAmt), 2)); break;
                case "NAD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NAD * Convert.ToDouble(currAmt), 2)); break;
                case "ALL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ALL * Convert.ToDouble(currAmt), 2)); break;
                case "SSP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SSP * Convert.ToDouble(currAmt), 2)); break;
                case "MUR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MUR * Convert.ToDouble(currAmt), 2)); break;
                case "MNT":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MNT * Convert.ToDouble(currAmt), 2)); break;
                case "NIO":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NIO * Convert.ToDouble(currAmt), 2)); break;
                case "LAK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LAK * Convert.ToDouble(currAmt), 2)); break;
                case "MKD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MKD * Convert.ToDouble(currAmt), 2)); break;
                case "AMD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AMD * Convert.ToDouble(currAmt), 2)); break;
                case "MGA":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MGA * Convert.ToDouble(currAmt), 2)); break;
                case "XPF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.XPF * Convert.ToDouble(currAmt), 2)); break;
                case "TJS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.TJS * Convert.ToDouble(currAmt), 2)); break;
                case "HTG":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.HTG * Convert.ToDouble(currAmt), 2)); break;
                case "BSD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BSD * Convert.ToDouble(currAmt), 2)); break;
                case "MDL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MDL * Convert.ToDouble(currAmt), 2)); break;
                case "RWF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.RWF * Convert.ToDouble(currAmt), 2)); break;
                case "KGS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KGS * Convert.ToDouble(currAmt), 2)); break;
                case "GNF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GNF * Convert.ToDouble(currAmt), 2)); break;
                case "SRD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SRD * Convert.ToDouble(currAmt), 2)); break;
                case "SLL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SLL * Convert.ToDouble(currAmt), 2)); break;
                case "XOF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.XOF * Convert.ToDouble(currAmt), 2)); break;
                case "MWK":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MWK * Convert.ToDouble(currAmt), 2)); break;
                case "FJD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.FJD * Convert.ToDouble(currAmt), 2)); break;
                case "ERN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ERN * Convert.ToDouble(currAmt), 2)); break;
                case "SZL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SZL * Convert.ToDouble(currAmt), 2)); break;
                case "GYD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GYD * Convert.ToDouble(currAmt), 2)); break;
                case "BIF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BIF * Convert.ToDouble(currAmt), 2)); break;
                case "KYD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KYD * Convert.ToDouble(currAmt), 2)); break;
                case "MVR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.MVR * Convert.ToDouble(currAmt), 2)); break;
                case "LSL":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LSL * Convert.ToDouble(currAmt), 2)); break;
                case "LRD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LRD * Convert.ToDouble(currAmt), 2)); break;
                case "CVE":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.CVE * Convert.ToDouble(currAmt), 2)); break;
                case "DJF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.DJF * Convert.ToDouble(currAmt), 2)); break;
                case "SCR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SCR * Convert.ToDouble(currAmt), 2)); break;
                case "SOS":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.SOS * Convert.ToDouble(currAmt), 2)); break;
                case "GMD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GMD * Convert.ToDouble(currAmt), 2)); break;
                case "KMF":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.KMF * Convert.ToDouble(currAmt), 2)); break;
                case "STD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.STD * Convert.ToDouble(currAmt), 2)); break;
                case "XRP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.XRP * Convert.ToDouble(currAmt), 2)); break;
                case "AUD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.AUD * Convert.ToDouble(currAmt), 2)); break;
                case "BGN":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BGN * Convert.ToDouble(currAmt), 2)); break;
                case "BTC":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.BTC * Convert.ToDouble(currAmt), 2)); break;
                case "JOD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.JOD * Convert.ToDouble(currAmt), 2)); break;
                case "GBP":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.GBP * Convert.ToDouble(currAmt), 2)); break;
                case "ETH":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.ETH * Convert.ToDouble(currAmt), 2)); break;
                case "EUR":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.EUR * Convert.ToDouble(currAmt), 2)); break;
                case "LTC":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.LTC * Convert.ToDouble(currAmt), 2)); break;
                case "NZD":	testOutput.Text = Convert.ToString(Math.Round(currValues.data.NZD * Convert.ToDouble(currAmt), 2)); break;

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
