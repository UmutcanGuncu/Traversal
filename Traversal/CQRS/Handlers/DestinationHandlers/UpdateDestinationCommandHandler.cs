using DataAccessLayer.Concrete;
using Traversal.CQRS.Commands.DestinationCommand;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand updateDestinationCommand )
        {
            var values = _context.Destinations.Find(updateDestinationCommand.Id);
            values.City = updateDestinationCommand.City;
            values.DayNight= updateDestinationCommand.DayNight;
            values.Price= updateDestinationCommand.Price;
            _context.SaveChanges();
        }
    }
}
