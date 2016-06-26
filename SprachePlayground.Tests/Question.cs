namespace SprachePlayground.Tests
{
    public class Question
    {
        public Question(string id, string prompt)
        {
            Id = id;
            Prompt = prompt;
        }

        public string Id { get; private set; }
        public string Prompt { get; private set; }
    }
}