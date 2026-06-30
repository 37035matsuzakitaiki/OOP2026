using System;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            string? pref, preCaptalLocation;
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");
           　//都道府県の入力
            while (true) {
                Console.Write("都道府県：");
                pref = Console.ReadLine();
                if (pref == null) break;
                Console.Write("県庁所在地：");
                preCaptalLocation = Console.ReadLine();
                if (pref == null) break;

                prefOfficeDict.Add(pref, preCaptalLocation);
                prefOfficeDict[pref] = preCaptalLocation;

            }

            menuPisp();

        }
        private static void menuPisp() {
            while (true) {
                Console.WriteLine("****メニュー****");
                Console.WriteLine("1:一覧表示" + "2:検索" + "3:終了");
                Console.Write(">");
                //メニュー番号を入力させて呼び出し元へ返却
                int num = int.Parse(Console.ReadLine());  //１，２，３を入力し数字に変換

                if (num == 1) {
                    allDisp();
                } else if (num == 2) {
                    searchPrefCaptalLocation();
                }
                if (num == 3) break;
            }
            
            //if (prefOfficeDict.ContainsKey(pref)) {
            //    Console.WriteLine();
            //    if (Console.ReadLine() == "N")continue;
            //}
        }

            
        

        private static void allDisp() {
            //コレクション（prefOfficeDict）の中身をすべて出力
            
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }
        private static void searchPrefCaptalLocation() {
            //検索
            foreach (var item in prefOfficeDict) {
                if (item.Key == Console.ReadLine()) {
                    Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
                }
            }
        }
        
    }
}
