using Sprache;

namespace Questionnaire
{
    public class QuestionnaireGrammar
    {
        public static Questionnaire ParseQuestionnaire(string questionnaire)
        {
            return Questionnaire.End().Parse(questionnaire);
        }

        public static Parser<string> QuotedText =
            (from lquot in Parse.Char('"')
             from content in Parse.CharExcept('"').Many().Text()
             from rquot in Parse.Char('"')
             select content).Token();

        public static Parser<string> Identifier = Parse.Letter.AtLeastOnce().Text().Token();

        internal static Parser<AnswerType> AnswerTypeIndicator =
            Parse.Char('#').Return(AnswerType.Natural)
                .Or(Parse.Char('$').Return(AnswerType.Number))
                .Or(Parse.Char('%').Return(AnswerType.Date))
                .Or(Parse.Char('?').Return(AnswerType.YesNo));

        public static Parser<Question> Question =
            from at in AnswerTypeIndicator.Or(Parse.Return(AnswerType.Text))
            from id in Identifier
            from prompt in QuotedText
            select new Question(id, prompt, at);

        public static Parser<Section> Section =
            from id in Identifier
            from title in QuotedText
            from lbracket in Parse.Char('[').Token()
            from questions in Question.AtLeastOnce()
            from rbracket in Parse.Char(']').Token()
            select new Section(id, title, questions);

        internal static Parser<Questionnaire> Questionnaire =
            from sections in Section.AtLeastOnce()
            select new Questionnaire(sections);
    }
}