using System;
using System.Collections.Generic;

namespace Questionnaire
{
    public class Section
    {
        public Section(string id, string title, IEnumerable<Question> questions)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (title == null) throw new ArgumentNullException("title");
            if (questions == null) throw new ArgumentNullException("questions");

            Id = id;
            Title = title;
            Questions = questions;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }
    }
}