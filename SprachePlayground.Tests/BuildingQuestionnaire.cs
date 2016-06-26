﻿using System.Linq;
using NUnit.Framework;
using Sprache;
using SprachePlayground.Tests.Properties;

namespace SprachePlayground.Tests
{
    [TestFixture]
    public class BuildingQuestionnaire
    {
        [Test]
        public void AnIdentifierIsASequenceOfCharacters()
        {
            var id = QuestionnaireGrammer.Identifier.Parse("name");

            Assert.AreEqual("name", id);
        }

        [Test]
        public void AnIdentifierDoesNotIncludeSpace()
        {
            var parsed = QuestionnaireGrammer.Identifier.Parse("a b");

            Assert.AreEqual("a", parsed);
        }

        [Test]
        public void QuotedTextReturnsAValueBetweenQuotes()
        {
            var input = "\"this is text\"";

            var content = QuestionnaireGrammer.QuotedText.Parse(input);

            Assert.AreEqual("this is text", content);
        }

        [Test]
        public void AQuestionIsAnIdentifierFollowedByAPrompt()
        {
            var input = "name \"Full Name\"";

            var question = QuestionnaireGrammer.Question.Parse(input);

            Assert.AreEqual("name", question.Id);
            Assert.AreEqual("Full Name", question.Prompt);
        }

        [Test]
        public void Smoke()
        {
            var input = Resources.questions;

            var questionnaire = QuestionnaireGrammer.Questionnaire.Parse(input);

            Assert.AreEqual(2, questionnaire.Sections.Count());
        }
    }
}
