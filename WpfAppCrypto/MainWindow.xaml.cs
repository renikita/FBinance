using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net;

namespace WpfAppCrypto
{
   
    public partial class MainWindow : Window
    {

        public static List<Currency> currencies = new List<Currency>();
        public MainWindow()
        {
            InitializeComponent();

            GetCurrency();

        }
        

        private void GetCurrency()
        {
            string url = "https://api.coincap.io/v2/assets";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            JObject job = JObject.Parse(json: response);

            List<JToken> results = job["data"].Children().ToList();

            foreach (JToken result in results)
            {
                Currency currency = result.ToObject<Currency>();
                MessageBox.Show(result.ToString());
                currencies.Add(currency);
            }

        }

        private void curr_listBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
