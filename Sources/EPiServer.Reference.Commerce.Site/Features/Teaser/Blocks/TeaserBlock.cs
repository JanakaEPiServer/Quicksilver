using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using EPiServer.Reference.Commerce.Site.Infrastructure;

namespace EPiServer.Reference.Commerce.Site.Features.Teaser.Blocks
{
    [ContentType(DisplayName = "Teaser Block", GUID = "17124fde-d9f0-43fa-80d7-932d5ed0037e", Description = "Displays a marketing teaser", GroupName = GroupNames.Marketing)]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Required(AllowEmptyStrings = false)]
        [Display(
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString Description { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Image)]
        [Display(
            Name = "Teaser Image",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual ContentReference MediaImage { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Video URL",
            GroupName = SystemTabNames.Content,
            Order = 4
            )]
        public virtual string MediaURL { get; set; }
    }
}