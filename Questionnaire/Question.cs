using System;

namespace Questionnaire
{
    public class Question
    {
        public Question(string id, string prompt, AnswerType at)
        {
            if (id == null) throw new ArgumentNullException("id");
            if (prompt == null) throw new ArgumentNullException("prompt");

            Id = id;
            Prompt = prompt;
            AnswerType = at;
        }

        public string Id { get; private set; }
        public string Prompt { get; private set; }
        public AnswerType AnswerType { get; set; }
    }
}