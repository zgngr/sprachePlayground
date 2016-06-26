using System;
using System.Collections.Generic;

namespace Questionnaire
{
    public class Questionnaire
    {
        public Questionnaire(IEnumerable<Section> sections)
        {
            if (sections == null) throw new ArgumentNullException("sections");

            Sections = sections;
        }

        public IEnumerable<Section> Sections { get; private set; }
    }
}