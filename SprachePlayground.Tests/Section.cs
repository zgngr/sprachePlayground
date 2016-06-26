using System.Collections.Generic;

namespace SprachePlayground.Tests
{
    public class Section
    {
        public Section(string id, string title, IEnumerable<Question> questions)
        {
            Id = id;
            Title = title;
            Questions = questions;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }
    }
}