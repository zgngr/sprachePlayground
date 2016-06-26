using System.Collections.Generic;

namespace SprachePlayground.Tests
{
    public class Questionnaire
    {
        public Questionnaire(IEnumerable<Section> sections)
        {
            Sections = sections;
        }

        public IEnumerable<Section> Sections { get; private set; }
    }
}