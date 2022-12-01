using System;

namespace YouInvestMe.Models
{
    public class Idea
    {
        public int IdeaId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }

    }

}