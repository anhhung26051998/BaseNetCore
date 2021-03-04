using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using XH.BaseProject.Common.Entity;
using XH.BaseProject.Domain.Users;

namespace XH.BaseProject.Domain.Cars
{
   public partial class Car: AuditingEntity
    {
        [Key]
        public Guid Id { get; set; }

        public  string Name { get; set; }

        public string Lisense_Plate { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
    }
}
