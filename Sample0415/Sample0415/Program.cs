namespace Sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            int[] t = new int[10];
            int sum = 0;
            //入力
            for (int i = 0; i < t.Length; i++)
            {
                Console.Write("array[" + i + "]=");
                t[i] = int.Parse(Console.ReadLine());
            }
            //集計（配列の値を集計）
            //for (int i = 0; i < t.Length; i++)
            //{
            //    sum += t[i];
            //}


            //出力


            for (int i = 0; i < t.Length; i++)
            {
                Console.Write("array[" + i + "]:");
                astOut(t[i]);
                Console.WriteLine();
            }
            Console.WriteLine("合計値：" + t.Where(n=>n%2 ==0).Sum());

        }
        static void astOut(int num)
        {
            for (int j = 0; j < num; j++) { Console.Write("*"); }
        }
    }
}
