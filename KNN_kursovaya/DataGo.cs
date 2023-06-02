using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN_kursovaya
{
    internal class DataGo
    {
        private List<string> datafromcsv = new List<string>();
        private List<string[]> data = new List<string[]>();

        public List<string[]> Data { get => data; }

        public void get_data()
        {
            using (TextFieldParser tfp = new TextFieldParser(@"C:\Users\sasha\RiderProjects\KNN_kursovaya\new.csv"))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData)
                {
                    datafromcsv.Add(tfp.ReadLine());
                }

                foreach (var datas in datafromcsv)
                {
                    string[] wo = datas.Split(",");
                    data.Add(wo);
                }
            }

        }
    }
}
