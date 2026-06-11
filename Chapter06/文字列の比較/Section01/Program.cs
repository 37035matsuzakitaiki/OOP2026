using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var str1 = "コマンド";
            var str2 = "ｺﾏﾝﾄﾞ";

            var cultureInfo = new CultureInfo("ja-JP");

            if (String.Compare(str1, str2,cultureInfo,
                CompareOptions.IgnoreWidth | CompareOptions.IgnoreCase)==0) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }

        }
    }
}
