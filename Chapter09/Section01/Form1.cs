using System.Globalization;

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
            DateTime birth = dtpBirth.Value;  //ê∂Ç‹ÇÍÇΩì˙ït
            DateTime today = DateTime.Today;Å@//
            int diff = (today.Year - birth.Year);

            tbOut.Text = ($"Ç†Ç»ÇΩÇÕ{diff}çŒÇ≈Ç∑");
            
            

        }
    }
}