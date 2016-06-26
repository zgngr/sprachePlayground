namespace SprachePlayground.Tests
{
    public class Question
    {
        public Question(string id, string prompt, AnswerType at)
        {
            Id = id;
            Prompt = prompt;
            AnswerType = at;
        }

        public string Id { get; private set; }
        public string Prompt { get; private set; }
        public AnswerType AnswerType { get; set; }
    }
}