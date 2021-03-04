
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using XH.BaseProject.Common.Entity;
using XH.BaseProject.Domain.Cars;

namespace XH.BaseProject.Domain.Users
{
    public partial class User : IdentityUser, IAuditingEntity
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

        public IList<Car> Cars { get; set; }
        public User()
        {
            this.Cars = new List<Car>();
        }
    }
}
