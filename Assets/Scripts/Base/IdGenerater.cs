using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class IdGenerater
    {
        private static readonly long epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

        private static ushort value;

        public static long GenerateId()
        {
            long id = ((DateTime.UtcNow.Ticks - epoch) / 10000000) << 16;
            return ((DateTime.UtcNow.Ticks - epoch) / 10000000) << 16 + ++value;
        }
    }
}
