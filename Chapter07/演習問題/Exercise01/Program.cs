
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            #region
            Console.WriteLine("\n7.1.1");
            Exercise1(numbers);

            Console.WriteLine("\n7.1.2");
            Exercise2(numbers);

            Console.WriteLine("\n7.1.3");
            Exercise3(numbers);

            Console.WriteLine("\n7.1.4");
            Exercise4(numbers);

            Console.WriteLine("\n7.1.5");
            Exercise5(numbers);
        }
        #endregion

        private static void Exercise1(int[] numbers) {
            var max = numbers.Max(x => x);
            Console.WriteLine("最大値：" + max);
        }

        private static void Exercise2(int[] numbers) {
            var result1 = numbers[numbers.Length - 2];
            var result2 = numbers[numbers.Length - 1];

            Console.WriteLine(result1);
            Console.WriteLine(result2);


            //var length = numbers.Where(x => x > 0).TakeLast(2);
            //    //TakeLast(2).ToArray();           
            //    Console.WriteLine("配列の最後から二つの要素：" +
            //      $"{ numbers[0]}:{ numbers[1]}");
        }

        private static void Exercise3(int[] numbers) {
            var num = numbers.Select(x => x.ToString("000"));
            foreach (var item in num) {
                Console.WriteLine(item);
            }
            
        }

        private static void Exercise4(int[] numbers) {
            var result = numbers.OrderBy(x=>x).Take(3);
            foreach (var item in result) {
                Console.WriteLine(item);
            }
            
        }

        private static void Exercise5(int[] numbers) {
            var result = numbers.Distinct().Count(x => x >= 10);                
            Console.WriteLine(result);
        }
    }
}
