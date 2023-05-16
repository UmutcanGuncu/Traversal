namespace Traversal.CQRS.Commands.DestinationCommand
{
    public class CreateDestinationCommand
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public float Price { get; set; }
        public int Capacity { get; set; }
        
    }
}
