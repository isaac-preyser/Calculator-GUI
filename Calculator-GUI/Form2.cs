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

            string query = deserial.Deserialize<string>(response);


            label1.Text = query;
        }

        private void openCalc_Click(object sender, EventArgs e)
        {
            CalcWindow form = new CalcWindow();
            this.Hide();
            form.ShowDialog(); //this doesn't end the process, so if a user spammed the button they could end up running out of memory. 
        }
    }
}
