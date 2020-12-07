using System;

namespace BinaryOcean.EFCore5.Library
{
    public class EntityBase
    {
        public DateTime CreatedDateTime { get; set; } 

        public byte[] RowVersion { get; set; }
    }
}
