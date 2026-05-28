


using System.Globalization;
using System.Threading.Channels;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            Exercise1();
            Console.WriteLine("--4.2.1--");
            Exercise2();
            Console.WriteLine("\n--4.2.2--");
            Exercise3();
            Console.WriteLine("\n--4.2.3--");

            private static void Exercise1() {
            //if-else文を使用
            var line = Console.ReadLine();
            if (int.TryParse(line, out var num)) {
                if (num < 0) {
                    Console.WriteLine("数値：" + num);
                } else if (num < 100) {
                    Console.WriteLine("数値：" + num * 2);
                } else if (num < 500) {
                    Console.WriteLine("数値：" + num * 3);
                } else if (num >= 500) {
                    Console.WriteLine("数値：" + num);
                }
            } else { Console.WriteLine("入力値に誤りがあります。"); }
          }
        private static void Exercise2() {
            //swith文
            var line = Console.ReadLine();
            if (int.TryParse(line, out var num)) {
                switch (num) {
                    case < 0:
                        Console.WriteLine(num);
                        break;

                    case < 100:
                        Console.WriteLine(num*2);
                        break;

                    case < 500:
                        Console.WriteLine(num*3);
                        break;

                    default:
                        Console.WriteLine(num);
                        break;
                }
            } else { Console.WriteLine("入力値に誤りがあります"); }

        }

        private static void Exercise3() {
            //switch式
            var line = Console.ReadLine();
            if(int.TryParse(line,out var num)) {
                var outNum = num switch {
                    < 0 => num,
                    < 100 => num * 2,
                    < 500 => num * 3,
                     => num
                };
            }
            Console.WriteLine("入力値に誤りがあります");
        }
    }
 }

