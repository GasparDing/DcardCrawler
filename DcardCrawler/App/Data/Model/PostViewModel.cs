using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DcardCrawler.App.Data.Model
{
    public class PostViewModel : ListViewModel
    {
        public string Content { get; set; }

        public string SupportedReactions { get; set; }

        public bool HiddenByAuthor { get; set; }

        public bool PersonaSubscriptable { get; set; }

        public string Reacted { get; set; }

        public bool Liked { get; set; }

        public bool Subscribed { get; set; }

        public bool Collected { get; set; }

        public bool PersonaSubscribed { get; set; }

        public bool Read { get; set; }

        public bool NewComment { get; set; }

        public bool CurrentMember { get; set; }
    }
}
