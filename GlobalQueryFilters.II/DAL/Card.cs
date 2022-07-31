using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalQueryFilters.II.DAL
{
    public class Card
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public string CardNumber { get; set; }
        public string ShadowCardNumber { get; set; }
        public string CardReferenceNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountLimit { get; set; }
        public string TenantCode { get; set; }
    }
}
