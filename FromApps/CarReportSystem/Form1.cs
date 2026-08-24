using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト  
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        Settings settings = new Settings();


        public Form1() {
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
            listCarReports.Add(carReport);
            SetCbAuthor(cbAuthor.Text);
            SetCbCarName(cbCarName.Text);
            InputItemsAllClear();  //入力項目の全クリア
            dgvRecords.ClearSelection();//セルの選択解除
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
            //using (var reader = XmlReader.Create("settings.xml"))

            if (File.Exists("setting.xml")) {
                try {
                    using (var reader = XmlReader.Create("setting.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        settings = serializer.Deserialize(reader) as Settings;
                        //背景色設定
                        BackColor = Color.FromArgb(settings.MainFormBackColor);
                    }
                }
                catch (Exception ex) {
                    tssIbMessage.Text = "設定ファイル読み込みエラー";
                    MessageBox.Show(ex.Message);//より具体的なエラーを出力
                }
            } else {
                tssIbMessage.Text = "設定ファイルがありません";
            }



        }
        //写真削除
        private void btDeletePicture_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }
        //レコード削除
        private void btDeleteRecord_Click(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow?.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;

            InputItemsAllClear();
            listCarReports.RemoveAt(dgvRecords.CurrentRow.Index);
            dtpDate.Value = carReport.Date;
            cbAuthor.Text = carReport.Author;
            SetRadioButtonMaker(carReport.Maker);
            cbCarName.Text = carReport.CarName;
            tbReport.Text = carReport.Report;
            pbPicture.Image = carReport.Picture;

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
            if ((dgvRecords.CurrentRow is null) || (dgvRecords.CurrentRow.Selected)) {
                //return;
            }
            listCarReports[dgvRecords.CurrentRow.Index].Date = dtpDate.Value.Date;
            listCarReports[dgvRecords.CurrentRow.Index].Author = cbAuthor.Text.Trim();
            listCarReports[dgvRecords.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvRecords.CurrentRow.Index].CarName = cbCarName.Text.Trim();
            //listCarReports[dgvRecords.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvRecords.CurrentRow.Index].Picture = pbPicture.Image;

            SetCbAuthor(cbAuthor.Text.Trim());
            SetCbCarName(cbCarName.Text.Trim());

            dgvRecords.Refresh();   //データグリッドビューの更新
            tsslbMassage.Text = "レポートを修正しました";

        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e) {

            if ((dgvRecords.CurrentRow.DataBoundItem is not CarReport carReport)
                || (!dgvRecords.CurrentRow.Selected)) return;


        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();

        }

        private void 色設定ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {
                BackColor = cdColor.Color;
                //変更された色の情報を保存
                settings.MainFormBackColor = cdColor.Color.ToArgb();
            }

        }


        //フォームが閉じたら呼ばれるイベント
        private void CarReportSystem_FormClosed(object sender, FormClosedEventArgs e) {
            //設定ファイルへ色情報を保存する処理
            //（ファイル名：setting.xml）
            using (var writer = XmlWriter.Create("setting.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }
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
                    using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                        bf.Serialize(fs, listCarReports);
                    }


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
                        listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecords.DataSource = listCarReports;
                    }
                    //コンボボックスの履歴をすべて消す
                    cbAuthor.Items.Clear();
                    cbCarName.Items.Clear();


                    //コンボボックスの履歴を再登録
                    foreach (var report in listCarReports) {
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
        
    }
}

