using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Speedo
{
    public class Gauge : View, IGaugeController
    {
        //review the variable names and make binable
        public Double scaleWidth { get; set; }
        public double value { get; set; }
        public double maxValue { get; set; }
        public double angNeedle { get; set; }
        public double Minimum { get; set; }
        public double Maximum { get; set; }

    }

    
}
