namespace Traversal.CQRS.Commands.DestinationCommand
{
    public class UpdateDestinationCommand
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public float Price { get; set; }
        
        
    }
}
