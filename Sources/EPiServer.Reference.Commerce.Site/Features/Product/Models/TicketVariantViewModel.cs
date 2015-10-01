using System.Collections.Generic;
using System.Web.Mvc;
using Mediachase.Commerce;
using Mediachase.Commerce.Pricing;

namespace EPiServer.Reference.Commerce.Site.Features.Product.Models
{
    public class TicketVariantViewModel
    {
        public TicketVariant Ticket { get; set; }
        public Money Price { get; set; }
        public Money OriginalPrice { get; set; }
        public IList<string> Images { get; set; }
    }
}