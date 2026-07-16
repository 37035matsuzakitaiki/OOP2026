using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class CarReportSystem : Form {

        //カーレポート管理用リスト  
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public CarReportSystem() {
            InitializeComponent();
            dgvRecords.DataSource = listCarReports;
        }
        //追加buttonイベントハンドラ
        private void btAddRecord_Click(object sender, EventArgs e) {

            tsslbMessage.Text = string.Empty;
            /***********************/
            //ここに、記録者と車名が未入力だった場合の処理を記述する

            //if (cbCarName.Text == string.Empty||cbAuthor.Text == string.Empty) {
            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            } else {
                tsslbMessage.Text = "入力されました";

            }

            /************************/

            var carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,

            };
            listCarReports.Add(carReport);

            ImputItemsAllClear();  //入力項目の全クリア

        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
                return MakerGroup.日産;
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
            if (rbImport.Checked)
                return MakerGroup.その他;

            return MakerGroup.その他;


        }

        private void btOpenPicture_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btNewInput_Click(object sender, EventArgs e) {

            Button bt = (Button)sender;

            ImputItemsAllClear();
        }

        private void ImputItemsAllClear() {
            cbAuthor.Text = string.Empty;
            cbCarName.Text = string.Empty;
            dtpDate.Value = DateTime.Today;
            rbOther.Checked = true;
            tbReport.Text = string.Empty;
            pbPicture = null;
        }

        private void dgvRecords_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvRecords.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecords.CurrentRow.Cells["Author"].Value;
            cbCarName.Text = (string)dgvRecords.CurrentRow.Cells["Name"].Value;
            pbPicture.Image = (Image)dgvRecords.CurrentRow.Cells["Image"].Value;

        }

        private void dgvRecords_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}

