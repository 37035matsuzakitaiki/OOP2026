
namespace CarReportSystem {
    public class Settings {
        //唯一のSettingオブジェクト
        private static Settings _instance;

        //メイン画面に設定した色情報
        public int MainFormBackColor { get; set; }
        = SystemColors.Control.ToArgb();
        //唯一のオブジェクトを取得する
        public static Settings Instance {
            get { return _instance; }
        }


        //外部からnewできないようにする
        private Settings() { }


       

    }
}
