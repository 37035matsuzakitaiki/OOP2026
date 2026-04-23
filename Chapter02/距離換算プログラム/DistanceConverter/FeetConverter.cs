using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public static class FeetConverter {
        private static readonly double raito = 0.3048;   //定数

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / raito;

        }
            //フィートからメートルを求める
            public static double ToMeter(double feet) {
                return feet * 0.3048;
            }
        
    }
}
