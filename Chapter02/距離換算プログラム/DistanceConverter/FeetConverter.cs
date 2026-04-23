using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public class FeetConverter {
        private const double raito = 0.3048;   //定数

        //メートルからフィートを求める
        public double FromMeter(double meter) {
            return meter / raito;

        }
            //フィートからメートルを求める
            public double ToMeter(double feet) {
                return feet * raito;
            }
        
    }
}
