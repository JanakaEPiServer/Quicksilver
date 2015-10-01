using EPiServer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EPiServer.Reference.Commerce.Site.Infrastructure
{
    [GroupDefinitions]
    public class GroupNames
    {
        [Display(GroupName = "Marketing", Order = 2)]
        public const string Marketing = "Marketing";

        [Display(GroupName = "Events", Order = 3)]
        public const string Events = "Events";
    }
}