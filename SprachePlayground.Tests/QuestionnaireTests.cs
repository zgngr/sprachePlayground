using System.Linq;
using Questionnaire;
using Sprache;
using Xunit;

namespace SprachePlayground.Tests
{
    public class QuestionnaireTests
    {
        [Fact]
        public void TextIsAQuoteDelimitedString()
        {
            var input = "\"Hello, world!\"";
            var parsed = QuestionnaireGrammar.QuotedText.End().Parse(input);
            Assert.Equal("Hello, world!", parsed);
        }

        [Fact]
        public void AnIdentifierIsAStringOfNonWhitespaceCharacters()
        {
            var input = "hello";
            var parsed = QuestionnaireGrammar.Identifier.End().Parse(input);
            Assert.Equal("hello", parsed);
        }

        [Fact]
        public void AQuestionIsAnIdFollowedByPromptText()
        {
            var input = "day \"Day of Week\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal("day", parsed.Id);
            Assert.Equal("Day of Week", parsed.Prompt);
        }

        [Fact]
        public void DefaultAnswerTypeIsText()
        {
            var input = "name \"Your Name\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal(AnswerType.Text, parsed.AnswerType);
        }

        [Fact]
        public void HashIndicatesAnswerTypeIsNatural()
        {
            var input = "#bottles \"Number of Bottles\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal(AnswerType.Natural, parsed.AnswerType);
        }

        [Fact]
        public void DollarSignIndicatesAnswerTypeIsNumber()
        {
            var input = "$quantiy \"Quantity\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal(AnswerType.Number, parsed.AnswerType);
        }

        [Fact]
        public void QuestionMarkIndicatesAnswerTypeIsYesNo()
        {
            var input = "?send \"Send Mail\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal(AnswerType.YesNo, parsed.AnswerType);
        }

        [Fact]
        public void PercentIndicatesAnswerTypeIsDate()
        {
            var input = "%when \"When\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.Equal(AnswerType.Date, parsed.AnswerType);
        }

        [Fact]
        public void ASectionIncludesIdTitleAndQuestions()
        {
            var input = TestInputResources.NameAgeSection;
            var parsed = QuestionnaireGrammar.Section.End().Parse(input);
            Assert.Equal("details", parsed.Id);
            Assert.Equal("Personal Details", parsed.Title);
            Assert.Equal(2, parsed.Questions.Count());
        }

        [Fact]
        public void AQuestionnaireIsASequenceOfSteps()
        {
            var input = TestInputResources.TwoStepQuestionnaire;
            var parsed = QuestionnaireGrammar.ParseQuestionnaire(input);
            Assert.Equal(2, parsed.Sections.Count());
        }
    }
}
