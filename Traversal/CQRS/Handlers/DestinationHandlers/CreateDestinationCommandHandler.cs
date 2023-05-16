using DataAccessLayer.Concrete;
using EntityLayer.Entityies;
using Traversal.CQRS.Commands.DestinationCommand;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(CreateDestinationCommand createDestinationCommand)
        {
            _context.Destinations.Add(new Destination
            {
                City=createDestinationCommand.City,
                Capacity=createDestinationCommand.Capacity,
                Price=createDestinationCommand.Price,
                DayNight=createDestinationCommand.DayNight,
                Status=true

            });
            _context.SaveChanges();
        }
    }
}
