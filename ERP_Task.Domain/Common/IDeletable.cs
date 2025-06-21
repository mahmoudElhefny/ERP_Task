using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Task.Domain.Common
{
    public interface IDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
