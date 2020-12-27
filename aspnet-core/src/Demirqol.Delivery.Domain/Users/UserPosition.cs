using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Demirqol.Delivery.Users
{
    public class UserPosition:Entity<Guid>
    {
        public UserPosition()
        {

        }

        public UserPosition(Guid id):base(id)
        {

        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
