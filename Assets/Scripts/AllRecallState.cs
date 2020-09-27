using System.Collections.Generic;

namespace Triadium.App
{
    public class AllRecallState
    {
        public bool isLongMemTraining { get; set; }
        public byte maxMemTime { get; set; }
        public byte minPauseTime { get; set; }
        public byte chipsQuantity { get; set; }
        public byte area { get; set; }
        public byte state { get; set; }
        public List<byte> chipRows { get; set; }
        public List<byte> chipCols { get; set; }
        public long startTicks { get; set; }
    }
}