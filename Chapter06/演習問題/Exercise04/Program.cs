using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=太宰治;BestWork=人間失格;Born=1886";
            
            var array = line.Split(new[] { ';', '=' },
                StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var lines in array) {
                count++;
                
                if (count %2 == 0) {
                    Console.WriteLine(lines);
                } else {
                    Console.Write($"{ToJapanese(lines)}:");
                }
                
            }

            //var pair = line.Split(';');
            //foreach (var item in pair) {
            //    var word = item.Split('=');
            //    Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            //}

            
        }
        static string ToJapanese(string key) {
            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数keyは、正しい値ではありません"
            };
            //古い書き方
            //switch (key) {
            //    case "Novelist":　
            //        return "作家";
            //    case "BestWork":
            //        return "代表作";
            //    case "Born":
            //        return "誕生年";
            //    default:
            //        return "引数keyは、正しい値ではありません";
            //}
        }
    }
}
