namespace Sample0413
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("表示回数：");
            string? inputNum = Console.ReadLine(); //入力

            int count = int.Parse(inputNum); //整数への変換

            int i = 0;
            while (i < count)
            {
                i++;
                if ((i + 1) % 2 == 0)
                {
                    Console.Write((i + 1) + ":");
                    Console.WriteLine("群馬県太田市");//画面出力 }
                }

            }
        }
    }
}
