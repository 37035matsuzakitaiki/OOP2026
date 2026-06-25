namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            string?  pref, preCaptalLocation;
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
            Console.WriteLine("****メニュー****");
            Console.WriteLine("1:一覧表示" + "2:検索" + "3:終了");
            
                int num =int.Parse(Console.ReadLine());
            switch (num) {
                case 1:
                    foreach (var item in prefOfficeDict) {
                        Console.WriteLine($"都道府県：{item.Key}県庁所在地：{item.Value}");
                    } 
                    break;
                case 2:
                    Console.Write("検索：");
                    foreach (var item in prefOfficeDict) {
                        if (item.Key == Console.ReadLine()) {
                            Console.WriteLine("都道府県" + item.Key +":" + "県庁所在地" + item.Value);
                            break;
                        }
                    }
                    break;
                case 3:

                    break;
            }


            



            

           

        }
    }
}
