
namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {

            if (args.Length == 3
                && int.TryParse(args[1], out int start) && int.TryParse(args[2], out int end)) {


                if (args[0] == "-tom") {
                    printFeetToMeterList(start, end);  //メートルへの変換
                }
                else if (args.Length >= 1 && args[0] == "-tof") {
                    printMeterToFeetList(start, end);
                }
                else {
                    Console.WriteLine("error");
                }
            }
            else {
                Console.WriteLine("error");
            }

        }


        static void printMeterToFeetList(int start, int stop) {

            //メートルからフィートへの対応表を出力
            for (int meter = start; meter <= stop; meter++) {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }

        }
        static void printFeetToMeterList(int start, int stop) {


            //フィートからメートルへの対応表を出力
            for (int feet = start; feet <= stop; feet++) {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }

        }

    }
}
