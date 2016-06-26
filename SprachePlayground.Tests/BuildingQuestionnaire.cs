using System.Linq;
using NUnit.Framework;
using Sprache;

namespace SprachePlayground.Tests
{
    [TestFixture]
    public class BuildingQuestionnaire
    {
        [Test]
        public void TextIsAQuoteDelimitedString()
        {
            var input = "\"Hello, world!\"";
            var parsed = QuestionnaireGrammar.QuotedText.End().Parse(input);
            Assert.AreEqual("Hello, world!", parsed);
        }

        [Test]
        public void AnIdentifierIsAStringOfNonWhitespaceCharacters()
        {
            var input = "hello";
            var parsed = QuestionnaireGrammar.Identifier.End().Parse(input);
            Assert.AreEqual("hello", parsed);
        }

        [Test]
        public void AQuestionIsAnIdFollowedByPromptText()
        {
            var input = "day \"Day of Week\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual("day", parsed.Id);
            Assert.AreEqual("Day of Week", parsed.Prompt);
        }

        [Test]
        public void DefaultAnswerTypeIsText()
        {
            var input = "name \"Your Name\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual(AnswerType.Text, parsed.AnswerType);
        }

        [Test]
        public void HashIndicatesAnswerTypeIsNatural()
        {
            var input = "#bottles \"Number of Bottles\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual(AnswerType.Natural, parsed.AnswerType);
        }

        [Test]
        public void DollarSignIndicatesAnswerTypeIsNumber()
        {
            var input = "$quantiy \"Quantity\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual(AnswerType.Number, parsed.AnswerType);
        }

        [Test]
        public void QuestionMarkIndicatesAnswerTypeIsYesNo()
        {
            var input = "?send \"Send Mail\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual(AnswerType.YesNo, parsed.AnswerType);
        }

        [Test]
        public void PercentIndicatesAnswerTypeIsDate()
        {
            var input = "%when \"When\"";
            var parsed = QuestionnaireGrammar.Question.End().Parse(input);
            Assert.AreEqual(AnswerType.Date, parsed.AnswerType);
        }

        [Test]
        public void ASectionIncludesIdTitleAndQuestions()
        {
            var input = TestInputResources.NameAgeSection;
            var parsed = QuestionnaireGrammar.Section.End().Parse(input);
            Assert.AreEqual("details", parsed.Id);
            Assert.AreEqual("Personal Details", parsed.Title);
            Assert.AreEqual(2, parsed.Questions.Count());
        }

        [Test]
        public void AQuestionnaireIsASequenceOfSteps()
        {
            var input = TestInputResources.TwoStepQuestionnaire;
            var parsed = QuestionnaireGrammar.ParseQuestionnaire(input);
            Assert.AreEqual(2, parsed.Sections.Count());
        }
    }
}
