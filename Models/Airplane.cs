namespace secure_programming.Models
{
    public class Airplane
    {
        public string? AirplaneID { get; private set; }
        public string? Name { get; private set; }
        public int MaxSeat { get; private set; }
        public string? FlightID { get; private set; }
        public bool? Assigned { get; private set; }
        public string? AirportOrigin { get; private set; }
        public string? AirportDestination { get; private set; }

        public Airplane()
        {

        }
    }
}
