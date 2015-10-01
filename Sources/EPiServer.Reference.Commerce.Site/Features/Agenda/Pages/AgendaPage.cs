using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Reference.Commerce.Site.Infrastructure;
using EPiServer.Reference.Commerce.Site.Features.Campaign.Pages;
using EPiServer.Reference.Commerce.Site.Features.Agenda.Blocks;

namespace EPiServer.Reference.Commerce.Site.Features.Agenda.Pages
{
    [ContentType(DisplayName = "Agenda Page", GUID = "13136204-5db9-4848-a674-524c11a9ea0b", Description = "Page for displaying event agenda", GroupName = GroupNames.Events)]
    public class AgendaPage : PageData
    {
        [Display(Name = "Page Title",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [CultureSpecific]
        public virtual String PageTitle { get; set; }

        [Display(Name = "Main Content Area",
          Description = "This is the main content area",
          GroupName = SystemTabNames.Content,
          Order = 2)]
        [AllowedTypes(typeof(AgendaItemBlock))]
        public virtual ContentArea MainContentArea { get; set; }
  
        [Display( Order = 3,
            GroupName = SystemTabNames.Content
           )]
        public virtual ContentArea SideBar { get; set; }
         
    }
}