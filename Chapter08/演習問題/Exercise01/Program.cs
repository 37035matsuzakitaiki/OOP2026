
namespace Exercise01 {
    internal class Program {
        public static object Exercise1text { get; private set; }

        static void Main(string[] args) {
            var text = "Cozy lumox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);
            Console.WriteLine();

        }

        private static void Exercise1(string text) { //問題8.1 
            var dict = new Dictionary<char,int>();
            foreach (char i in text.ToUpper()) {
                if ('A' <= i && i <= 'Z') {
                    if (dict.ContainsKey(i)) {
                        dict[i]++;
                    } else {
                        dict[i] = 1;
                    }
                    
                }
 
            }
            foreach(var item in dict.OrderBy(x => x.Key)) {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }

        }
           
        private static void Exercise2(string text) {
            
        }

     
    }
}
