using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities
{
    public class Trace : BaseEntity
    {
        public string Url { get; set; }
        public DateTime DateOfAccess { get; set; }
    }
}
