using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHabit
{
    public class HabitModel
    {
        const string FMT = "MM/dd/yyyy";
        public int id { get; set; }
        public string habitName { get; set; }
        public int progress { get; set; }
        public string startDate { get; }

        public bool minus0 { get; set; }
        public bool minus1 { get; set; }
        public bool minus2 { get; set; }
        public bool minus3 { get; set; }
        public bool minus4 { get; set; }

        public DateTime minus0Date { get; set; }
        public DateTime minus1Date { get; set; }
        public DateTime minus2Date { get; set; }
        public DateTime minus3Date { get; set; }
        public DateTime minus4Date { get; set; }

        public int _minus0 { get; set; }    //Only for DB -- cant really store bool in there
        public int _minus1 { get; set; }
        public int _minus2 { get; set; }
        public int _minus3 { get; set; }
        public int _minus4 { get; set; }

        public string _minus0Date { get; set; }  //Only for DB -- Have store DateTime somehow :)
        public string _minus1Date { get; set; }
        public string _minus2Date { get; set; }
        public string _minus3Date { get; set; }
        public string _minus4Date { get; set; }

        public int quickProgressLevel { get; set; }
        public double progressPercent { get; set; }

        public HabitModel(string name)
        {
            this.habitName = name;
            this.progress = 0;
            this.startDate = DateTime.Today.ToString(FMT);
            minus0 = minus1 = minus2 = minus3 = minus4 = false;
            _minus0 = _minus1 = _minus2 = _minus3 = _minus4 = 0;
            _minus0Date = _minus1Date = _minus2Date = _minus3Date = _minus4Date = " ";
        }
        public HabitModel()   //Only for Dapper. IDN why but it needs a parameterless constructor
        {
            this.habitName = "Sample Name";
            this.progress = 10;
            this.startDate = FMT;
            minus0 = minus1 = minus2 = minus3 = minus4 = false;
            _minus0 = _minus1 = _minus2 = _minus3 = _minus4 = 0;
            _minus0Date = _minus2Date = _minus3Date = _minus4Date = " ";
        }
        public int SumUpProgress()  // Execute every 5 days
        {
            if (minus0)
                progress++;
            if (minus1)
                progress++;
            if (minus2)
                progress++;
            if (minus3)
                progress++;
            if (minus4)
                progress++;

            return progress;
        }
        public void IntoDB()
        {

            if (minus0)
                _minus0 = 1;
            else
            {
                _minus0 = 0;
                _minus0Date = " ";
            }
            if (minus1)
                _minus1 = 1;
            else
            {
                _minus1 = 0;
                _minus1Date = " ";
            }
            if (minus2)
                _minus2 = 1;
            else
            {
                _minus2 = 0;
                _minus2Date = " ";
            }
            if (minus3)
                _minus3 = 1;
            else
            {
                _minus3 = 0;
                _minus3Date = " ";
            }
            if (minus4)
                _minus4 = 1;
            else
            {
                _minus4 = 0;
                _minus4Date = " ";
            }


            var today = DateTime.Now;
            string _today = DateTime.Today.ToString(FMT);

            if (minus0 && _minus0Date == " ")
            {
                _minus0Date = _today;
                minus0Date = today;
            }
            if (minus1 && _minus1Date == " ")
            {
                _minus1Date = _today;
                minus1Date = today;
            }
            if (minus2 && _minus2Date == " ")
            {
                _minus2Date = _today;
                minus2Date = today;
            }
            if (minus3 && _minus3Date == " ")
            {
                _minus3Date = _today;
                minus3Date = today;
            }
            if (minus4 && _minus4Date == " ")
            {
                _minus4Date = _today;
                minus4Date = today;
            }

        }
        public void FromDB()
        {
            if (_minus0Date != " ")
                minus0Date = DateTime.ParseExact(_minus0Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            else
                minus0Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (_minus1Date != " ")
                minus1Date = DateTime.ParseExact(_minus1Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            else
                minus1Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (_minus2Date != " ")
                minus2Date = DateTime.ParseExact(_minus2Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            else
                minus2Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (_minus3Date != " ")
                minus3Date = DateTime.ParseExact(_minus3Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            else
                minus3Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (_minus4Date != " ")
                minus4Date = DateTime.ParseExact(_minus4Date, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            else
                minus4Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);



            if (_minus0 == 1)
                minus0 = true;
            else
            {
                minus0 = false;
                minus0Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_minus1 == 1)
                minus1 = true;
            else
            {
                minus1 = false;
                minus1Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_minus2 == 1)
                minus2 = true;
            else
            {
                minus2 = false;
                minus2Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_minus3 == 1)
                minus3 = true;
            else
            {
                minus3 = false;
                minus3Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_minus4 == 1)
                minus4 = true;
            else
            {
                minus4 = false;
                minus4Date = DateTime.ParseExact("12/01/1000", "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }

            quickProgressLevel = ((int)(progress / 25));

        }
        public void ShiftForxDays(int x)
        {
            for (int i = 0; i < x; i++)
            {
                var temp1 = _minus1;
                var temp2 = _minus2;
                var temp3 = _minus3;

                _minus1 = _minus0;
                _minus0 = 0;
                _minus2 = temp1;
                _minus3 = temp2;
                _minus4 = temp3;

                var temp4 = _minus1Date;
                var temp5 = _minus2Date;
                var temp6 = _minus3Date;

                _minus1Date = _minus0Date;
                _minus0Date = " ";
                _minus2Date = temp4;
                _minus3Date = temp5;
                _minus4Date = temp6;

            }
        }
    }
}