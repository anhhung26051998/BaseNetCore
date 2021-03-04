using System;
using System.Collections.Generic;
using System.Text;

namespace XH.BaseProject.Common.Entity
{
  public  interface IAuditingEntity
    {
        public DateTime? CreatedDate { get; set; }

        public Guid? CreatedBy { get; set; } 
        
        public DateTime? ModifiedDate { get; set; }

        public Guid? ModifiedBy { get; set; }
    }

    public class AuditingEntity : IAuditingEntity
    {

        public AuditingEntity()
        {
            this.CreatedDate = DateTime.Now;
        }
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
