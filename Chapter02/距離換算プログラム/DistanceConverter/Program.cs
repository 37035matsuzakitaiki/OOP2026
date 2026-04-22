
namespace DistanceConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 1 && args[0] == "-tom") {
                printFeetToMeterList(1, 20);  //メートルへの変換
            } else if(args.Length >= 1 && args[0] == "-tof")
            {
                printMeterToFeetList(1, 20);               
            } else {
                Console.WriteLine("error");
            }

           
        }

        private static void printMeterToFeetList(int start, int stop)
        {
            //メートルからフィートへの対応表を出力
            for (int meter = 1; meter <= 10; meter++)
            {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
            
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet)
            {
                return feet * 0.3048;
            }
            //メートルからフィートを求める
            static double MeterToFeet(int meter)
            {
                return meter / 0.3048;
            }

        

        static void printFeetToMeterList(int start, int stop)
        {
            //フィートからメートルへの対応表を出力
            for (int feet = 1; feet <= 10; feet++)
            {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
            
        }
    }
}
