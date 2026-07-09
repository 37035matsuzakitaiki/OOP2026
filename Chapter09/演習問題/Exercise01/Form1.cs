using System.Globalization;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btButton1_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            tbOut1.Text = today.ToString("yyyy/mm/dd HH:mm");
        }

        private void btButton2_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            tbOut2.Text = today.ToString("yyyy”NMŒŽd“ú HHŽžmm•ªss•b");
        }

        private void btButton3_Click(object sender, EventArgs e) {
            DateTime today = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbOut3.Text = today.ToString($"ggy”N MŒŽ d“ú (dddd)",culture);
        }
    }
}
