namespace ParserApp
{
    public class Cor
    {
        public Cor()
        {
            Participant = false;
            Lap = false;
            Points = false;
            Time = false;
            Avs = false;
            Classification = false;
            Note = false;
        }

        public bool Participant { get; set; }
        public bool Lap { get; set; }
        public bool Points { get; set; }
        public bool Time { get; set; }
        public bool Avs { get; set; }
        public bool Classification { get; set; }
        public bool Note { get; set; }
    }
}
