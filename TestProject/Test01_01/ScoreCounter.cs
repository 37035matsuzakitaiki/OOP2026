namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：
         static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var item in lines) {
                string[] items = item.Split(',');
                var sale = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                sales.Add(sale);
            }
            
            return sales;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            var dicts = new SortedDictionary<string, int>();
            
            foreach (var sale in _score) {

                if (dict.ContainsKey(sale.Subject)) {
                    
                    dict[sale.Subject] += sale.Score;
                } else { 
                    //未登録の場合
                    dict[sale.Subject] = sale.Score;
                }
                   
            }
            return dict;
            





            return dict;
        }
    }
}
