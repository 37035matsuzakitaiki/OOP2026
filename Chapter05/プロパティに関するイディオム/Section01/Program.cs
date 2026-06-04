using System.Collections.Immutable;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var obj = new PasswordPolicy("aaaaa", "bbbbbb");
            //var data = obj.Name;

            var ms = new MySample();
            //変更不可のオブジェクトなので、Add,RemoveATは新たなインスタンスを返す
            var newList = ms.MyList.Add(6).RemoveAt(0);
            ms.MyList.ForEach(n => Console.WriteLine($"{n}"));
            Console.WriteLine();//改行
            newList.ForEach(n => Console.WriteLine($"{n}"));
            Console.WriteLine();

            

           
        }
    }
       class MySample {
        public ImmutableList<int> MyList { get;set; }

        public MySample() {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            MyList = list.ToImmutableList();
        }
    }
   


    class PasswordPolicy {
        //プロパティの初期化
        public int MinimumLength { get; set; } = 8;

        //読み取り専用プロパティ
        public string GivenName { get; init; } = null!;
         
        public string FamilyName { get; init; } = null!;

        public PasswordPolicy(string familyName, string givenName) {
            FamilyName = familyName;
            GivenName = givenName;
        }
    }

}
