using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Entities
{
    public class OfferEntity
    {
        public OfferEntity(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
