namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            //2.2
            PrintFeetToMeterList(1, 10);

            for (int i = 0; i < 10; i++) {

            }

        }


        //インチからメートルへの対応表を出力
        private static void PrintFeetToMeterList(int start, int end) {
            for (int feet = start; feet <= end; feet++) {
                double meter = InchConverter.ToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }

           // Console.Write("");
        }
       
            
        
    }
    }

    


