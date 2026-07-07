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
            
            DateTime birth = dtpBirth.Value;  //生まれた日付
            DateTime today = DateTime.Today; //

            //int diff = (today.Year - birth.Year);
            //if (today< birth.AddYears(diff)) {
            //    diff--;
            //}
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayOfWeek = culture.DateTimeFormat.GetShortestDayName(birth.DayOfWeek);

            tbOut.Text = ($"あなたは{GetAge(birth,today)}歳です");

            tbOut3.Text = ($"生まれた{(birth.Month)}月{(birth.Day)}日は" +
                $"第{NthWeek(birth)}週の{dayOfWeek}曜日です");
           



            TimeSpan s = today.Date - birth.Date;
            tbOut2.Text = $"生まれてから{s.Days}日目です";
            
        }
        //年齢を求めるメソッド
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