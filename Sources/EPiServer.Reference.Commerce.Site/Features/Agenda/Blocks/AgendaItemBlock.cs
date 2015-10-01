using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServer.Reference.Commerce.Site.Features.Agenda.Models;
using EPiServer.Reference.Commerce.Site.Infrastructure.Attributes;
using EPiServer.Reference.Commerce.Site.Infrastructure;

namespace EPiServer.Reference.Commerce.Site.Features.Agenda.Blocks
{
    [ContentType(DisplayName = "Agenda Item", GUID = "8e97a279-6bee-4a19-80cc-2c17f633c749", Description = "Displays the agenda for a single conference item", GroupName = GroupNames.Events)]
    public class AgendaItemBlock : BlockData
    {
    
        [Display(
            Name = "Time",
            Description = "Time the item takes place",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        [Required]
        public virtual DateTime Time { get; set; }

        [Display(
            Name = "Title",
            Description = "Headline for the item",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        [CultureSpecific]
        [Required]
        public virtual string Title { get; set; }

        [Display(
            Name = "Style icon",
            Description = "Style icon for the block",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [BackingType(typeof(PropertyNumber))]
        [EnumAttribute(typeof(ItemStyleIcon))]
        [Required]
        public virtual ItemStyleIcon StyleIcon { get; set; }

        [Display(
            Name = "Style colour",
            Description = "Style colour theme for the block",
            GroupName = SystemTabNames.Content,
            Order = 4)]
        [BackingType(typeof(PropertyNumber))]
        [EnumAttribute(typeof(ItemStyleColour))]
        [Required]
        public virtual ItemStyleColour StyleColour { get; set; }
 

        [Display(
            Description = "Extended description for the item",
            GroupName = SystemTabNames.Content,
            Order = 5)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "Speaker Image",
            Description = "Profile image of the speaker",
            GroupName = SystemTabNames.Content,
            Order = 6)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference SpeakerImage { get; set; }

    }
}