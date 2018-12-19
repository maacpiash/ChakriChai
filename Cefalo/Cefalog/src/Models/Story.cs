using System;

namespace Cefalog.Models
{
    public class Story
    {
        public int StoryID { get; set; }
        public string AuthorID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedOn { get; set; }
    }
}
