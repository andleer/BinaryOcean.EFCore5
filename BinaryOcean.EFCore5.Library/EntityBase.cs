using System;

namespace BinaryOcean.EFCore5.Library
{
    public class EntityBase
    {
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public byte[] RowVersion { get; set; }
    }
}
