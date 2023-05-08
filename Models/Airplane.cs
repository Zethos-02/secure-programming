namespace secure_programming.Models
{
    public class Airplane
    {
        // creates the airplane model with relevant properties
        public string AirplaneID { get; private set; }
        public string? Name { get; private set; }
        public int MaxSeat { get; private set; }
        public string? FlightID { get; private set; }
        public string? Assigned { get; private set; }
        public string? AirportOrigin { get; private set; }
        public string? AirportDestination { get; private set; }

        public Airplane()
        {

        }
    }
}
