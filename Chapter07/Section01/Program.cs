namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 0, 4, 1, 0, 3 };
            var books = Books.GetBooks();

            var priceAverage = books.Average(x => x.Price);
            var pageSum = books.Sum(x => x.Pages);
            var maxprice =books.Max(x => x.Price) ;
            var price = books.Where(x => 500 <= x.Price);
            Console.WriteLine("平均金額：" + priceAverage);
            Console.WriteLine("平均ページ：" + pageSum);
            Console.WriteLine("一番高価な本：" + maxprice);

            Console.WriteLine("500円以上の本");
            foreach (var item in price) {
                Console.WriteLine(item.Title);
            }


            //250ページ以上の本を上位三冊出力
            var page = books.Where(x => x.Pages >= 250).Take(3);
            foreach (var item in page) {
                Console.WriteLine("三冊：" + item.Title);
            }
            
            
            }
        }
    }

