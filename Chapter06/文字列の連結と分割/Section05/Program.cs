using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {

            var result = String.Join(",",GetWords());
            Console.WriteLine(result);
            
            //var text = GetWords.Split(new[] {','},
            //    StringSplitOptions.RemoveEmptyEntries) ;
            //Console.WriteLine(sb);
        }

        private static IEnumerable<object> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
