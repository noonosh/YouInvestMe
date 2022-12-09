namespace YouInvestMe.Models
{
    public class ClientIdea
    {
        public int ClientId { get; set; }
        public int IdeaId { get; set; }

        public Client Client { get; private set; }
        public Idea Idea { get; private set;}
    }
}
