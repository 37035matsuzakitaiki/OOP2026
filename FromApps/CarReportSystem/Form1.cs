using SQLiteProductSample;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト  
        private readonly BindingList<CarReport> _carreports = new();
        
        private readonly CarReportRepository _repository= new();

        //Settings Settings = Settings.Instance;



        public Form1() {
            InitializeComponent();
            dgvRecords.DataSource = _carreports;
            ReloadCarReports();

            
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
            }
            /************************/


            var carReport = new CarReport {
                Date = dtpDate.Value.Date,
                Author = cbAuthor.Text.Trim(),
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text.Trim(),
                Report = tbReport.Text,
                Picture = pbPicture.Image,

            };
            //入力履歴を登録
            _repository.Add(carReport);
            ReloadCarReports();

           
        }

        private MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked)
                return MakerGroup.トヨタ;
            if (rbNissan.Checked)
            if (rbHonda.Checked)
                return MakerGroup.ホンダ;
            if (rbSubaru.Checked)
                return MakerGroup.スバル;
                return MakerGroup.日産;
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
            InputItemsAllClear();
        }

        private void InputItemsAllClear() {
            dtpDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            rbOther.Checked = true;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;


            dgvRecords.ClearSelection();//セルの選択解除
        }



        private void SetRadioButtonMaker(MakerGroup targetMaker) {
            switch (targetMaker) {
                case MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                default:
                    rbOther.Checked = true;
                    break;

            }

        }


        //記録者の入力履歴をコンボボックスへ登録
        private void SetCbAuthor(string author) {
            //使用するキーワード
            //Contains Add Items cbAuthor

            //未登録なら登録
            if (!cbAuthor.Items.Contains(author)) {
                cbAuthor.Items.Add(author);
            }
        }

        //車名の入力履歴をコンボボックスへ登録（重複なし）
        private void SetCbCarName(string carName) {
            if (!cbAuthor.Items.Contains(carName)) {
                cbCarName.Items.Add(carName);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {

            
                try {
                    Settings.Instance.Load();
                        //背景色設定
                        BackColor = Color.FromArgb(Settings.Instance.MainFormBackColor);
                }
                catch (Exception ex) {
                    tssIbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
                tssIbMessage.Text = "設定ファイルがありません";
            }
     
        private void InputItemsUpdate() {
            if (dgvRecords.CurrentRow is null
                || !dgvRecords.CurrentRow.Selected)
                InputItemsAllClear();
        }
        //写真削除
        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        //レコード削除
        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;
                
            //削除したいインデックスを指定してリストから削除
            if(dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport1) {
                tssIbMessage.Text = "削除するレポートを選択してください。";
                return;
            }

            try {
                _repository.Delete(carReport.Id);
                ReloadCarReports();
                InputItemsAllClear();
            }
            catch (Exception ex) {
                ShowError("削除エラー", ex);
            }


        }

        private void btModifyRecord_Click(object sender, EventArgs e) {

            if (dgvRecords.SelectedRows.Count == 0) {
                tsslbMassage.Text = "修正するレポートを選択してください";
                return;
            }

            if (String.IsNullOrWhiteSpace(cbAuthor.Text) || String.IsNullOrWhiteSpace(cbCarName.Text)) {
                tsslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }

            //選択されているインデックスを取得
            if (dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport1) {
                tssIbMessage.Text = "修正するレポートを選択してください。";
                return;
            }
            _carreports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value.Date;
            _carreports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            _carreports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
            _carreports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            _carreports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            _carreports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh();   //データグリッドビューの更新
            tsslbMassage.Text = "レポートを修正しました";

            
            try {
                
                _repository.Update(carReport1);
                ReloadCarReports();
                InputItemsAllClear();
                tssIbMessage.Text= "商品を修正しました。";
                
            }
            catch (Exception ex) {
                ShowError("修正エラー", ex);
            }


        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;

            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

            InputItemsUpdate();//データグリッドビューを更新したら呼ぶメソッド
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();

        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //変更された色の情報を保存
                Settings.Instance.MainFormBackColor = cdColor.Color.ToArgb();
            }

        }


        //フォームが閉じたら呼ばれるイベント
        private void CarReportSystem_FormClosed(object sender, FormClosedEventArgs e) {

            Settings.Instance.Save();

        }

        private void 開くToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //バイナリ形式でシリアル化
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    //using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                    //    bf.Serialize(fs, _carreports);
                    //}


                }
                catch (Exception ex) {
                    tssIbMessage.Text = "ファイル書き出しエラー";
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void reportOpenFile() {
            if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //逆シリアル化でバイナリ形式を取り込む
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011
                    using (FileStream fs = File.Open(
                        ofdReportFileOpen.FileName, //ファイル名
                        FileMode.Open, //ファイルモード
                        FileAccess.Read //ファイルアクセス
                        )) {
                        //_carreports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecords.DataSource = _carreports;
                    }
                    //コンボボックスの履歴をすべて消す
                    cbAuthor.Items.Clear();
                    cbCarName.Items.Clear();


                    //コンボボックスの履歴を再登録
                    foreach (var report in _carreports) {
                        SetCbAuthor(report.Author);
                        SetCbCarName(report.CarName);
                    }

                }
                catch (Exception ex) {
                    tssIbMessage.Text = "ファイル呼び出しエラー";
                    MessageBox.Show(ex.Message);

                }
            }
        }
        //sqlite read carreports
        private void ReloadCarReports() {
            _carreports.Clear();
            //コンボボックスの履歴を削除
            cbAuthor.Items.Clear();
            cbCarName.Items.Clear();
            foreach (var carReport in _repository.GetAll()) {
                _carreports.Add(carReport);
                //コンボボックスに入力履歴を登録
                SetCbAuthor(carReport.Author);
                SetCbCarName(carReport.CarName);
            }
            dgvRecords.ClearSelection();
        }



        //エラー表示
        private void ShowError(string title, Exception ex) {
            tssIbMessage.Text = title;
            MessageBox.Show(
                ex.Message,
                title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

    }
}

