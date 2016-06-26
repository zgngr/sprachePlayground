using Sprache;

namespace SprachePlayground.Tests
{
    public class QuestionnaireGrammer
    {
        public static readonly Parser<string> Identifier = Parse.Letter.AtLeastOnce().Text().Token();

        public static readonly Parser<string> QuotedText = (from open in Parse.Char('"')
                                                            from content in Parse.CharExcept('"').Many().Text()
                                                            from close in Parse.Char('"')
                                                            select content).Token();

        public static readonly Parser<Question> Question =
            from id in Identifier
            from prompt in QuotedText
            select new Question(id, prompt);

        public static readonly Parser<Section> Section =
            from id in Identifier
            from title in QuotedText
            from lbracket in Parse.Char('[').Token()
            from questions in Question.Many()
            from rbracket in Parse.Char(']').Token()
            select new Section(id, title, questions);

        public static Parser<Questionnaire> Questionnaire = 
            Section.Many().Select(sections => new Questionnaire(sections)).End();

        public static Parser<AnswerType> AnswerTypeIndicator =
            Parse.Char('#').Return(AnswerType.Natural)
                .Or(Parse.Char('$').Return(AnswerType.Number))
                .Or(Parse.Char('%').Return(AnswerType.Date))
                .Or(Parse.Char('?').Return(AnswerType.YesNo));
    }
}