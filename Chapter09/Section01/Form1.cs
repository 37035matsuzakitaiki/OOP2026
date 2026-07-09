using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Section01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e) {
            DateTime date = dtpBirth.Value;
            tbOut.Text = date.AddDays((double)nudDay.Value).ToString();

        }

        private void btBirthCalc_Click(object sender, EventArgs e) {
            
            DateTime birth = dtpBirth.Value;  //¶‚Ü‚ê‚½“ú•t
            DateTime today = DateTime.Today; //¡“ú

            
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);

            tbOut.Text = ($"‚ ‚È‚½‚Í{GetAge(birth,today)}Î‚Å‚·");
            //—j“ú
            tbOut3.Text = ($"¶‚Ü‚ê‚½{(birth.Month)}Œ{(birth.Day)}“ú‚Í" +
                $"‘æ{NthWeek(birth)}T‚Ì{dayOfWeek}—j“ú‚Å‚·");
           
            TimeSpan s = birth - today;
            tbOut2.Text = $"¶‚Ü‚ê‚Ä‚©‚ç{s.TotalDays}“ú–Ú‚Å‚·";

            //¡”N‚Ì’a¶“ú‚ğ¶¬‚·‚é
            DateTime thisYearBirthday = new DateTime(today.Year, birth.Month, birth.Day);
            //’a¶“ú‰ß‚¬‚½‚©H
            if (thisYearBirthday> today) {
                
              thisYearBirthday.AddYears(1);
            }
            var span = thisYearBirthday - today;

            if (span.Days == 0) {
                tbOut4.Text = "¡“ú‚Í’a¶“ú‚Å‚·";
            } else {
                tbOut4.Text = $"Ÿ‚Ì’a¶“ú‚Ü‚Å‚ ‚Æ{span.Days}“ú‚Å‚·";
            }

                
           
                

            


        }
        //”N—î‚ğ‹‚ß‚éƒƒ\ƒbƒh
        static int GetAge(DateTime birthday, DateTime targetday) {
            var age = targetday.Year - birthday.Year;
            if (targetday < birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
        static int NthWeek(DateTime date) {
            var firstDay = new DateTime(date.Year, date.Month, 1);
            var firstDayOfWeek = (int)(firstDay.DayOfWeek);
            return (date.Day + firstDayOfWeek - 1) / 7 + 1;
            
        }
    }
}