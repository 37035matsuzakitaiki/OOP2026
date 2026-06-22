using Section01;    //Section01プロジェクトにあるBookクラスを利用

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };
            #region
            Console.WriteLine("\n7.2.1");
            Exercise1(books);

            Console.WriteLine("\n7.2.2");
            Exercise2(books);

            Console.WriteLine("\n7.2.3");
            Exercise3(books);

            Console.WriteLine("\n7.2.4");
            Exercise4(books);

            Console.WriteLine("\n7.2.5");
            Exercise5(books);

            Console.WriteLine("\n7.2.6");
            Exercise6(books);

            Console.WriteLine("\n7.2.7");
            Exercise7(books);
            #endregion
        }

        private static void Exercise1(List<Book> books) {
            var result = books.Find(x => x.Title.Equals("ワンダフル・C#ライフ"));
            Console.WriteLine(result.Price +":" +  result.Pages); 
        }

        private static void Exercise2(List<Book> books) {
            var result = books.Count(x => x.Title.Contains("C#")); //count一発でできるのはwhere使わない
            Console.WriteLine(result);
        }

        private static void Exercise3(List<Book> books) {
            var pagecounts = books.Where(x => x.Title.Contains("C#")).Average(n=>n.Pages);
            Console.WriteLine(pagecounts);

            //var average = books.Average(b => (b.Title.Contains("C#") ? 1 : 0));
            //Console.WriteLine(average);

        }
            

        private static void Exercise4(List<Book> books) {
            var bookprice = books.FirstOrDefault(x => x.Price >= 4000);
            if (bookprice is not null) {
                Console.WriteLine(bookprice.Title);
            }

        }

        private static void Exercise5(List<Book> books) {
            var maxbook = books.Where(x => x.Price < 4000).Max(x=>x.Pages);
            Console.WriteLine(maxbook);
        }

        private static void Exercise6(List<Book> books) {
            //OrderByDescending　降順
            //回答が複数ある時はforeachかfor文を使わないとエラー起きる
            var s = books.Where(x => x.Pages >= 400).OrderByDescending(x => x.Price);
            foreach (var item in s) {
                Console.WriteLine(item.Title + item.Price);
            }
        }

        private static void Exercise7(List<Book> books) {
            var selected = books
                .Where(x => x.Title.Contains("C#") && x.Pages <= 500)
                .Select(x => x.Title);
            foreach (var item in selected) {
                Console.WriteLine(item);


            }
        }
    }
}
