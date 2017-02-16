using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumPad
{
    class Note
    {
        public long Ticks { get; set; }

        public DrumType DrumType { get; set; }

        public Note (long ticks, DrumType drumType)
        {
            Ticks = ticks;
            DrumType = drumType;
        }
    }
}