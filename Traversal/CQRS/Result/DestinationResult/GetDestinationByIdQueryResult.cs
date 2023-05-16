namespace Traversal.CQRS.Result.DestinationResult
{
    public class GetDestinationByIdQueryResult
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public float Price { get; set; }
    }
}
