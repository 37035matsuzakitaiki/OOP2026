namespace Section01 {
    internal class Program {

        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };
                              //↓Countにすると文字個数を表示できる
            var exists = cities.Exists(s => 6 <= s.Length 
            && s.Contains('o')
            &&s.EndsWith('n'));
            Console.WriteLine(exists);

            var lowerList = cities.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));

        }


    }

}