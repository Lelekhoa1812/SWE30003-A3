namespace RIS
{
    // Table include id, size, time (lunch/dinner), and occupied boolean data
    public class Table
    {
        public string Id { get; set; }
        public int Size { get; set; }
        public string Time { get; set; }
        public bool Occupied { get; set; }

        public Table(string id, int size, string time, bool occupied)
        {
            Id = id;
            Size = size;
            Time = time;
            Occupied = occupied;
        }
    }
}
