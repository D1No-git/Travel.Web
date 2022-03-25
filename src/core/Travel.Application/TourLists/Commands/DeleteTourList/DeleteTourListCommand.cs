using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Exceptions;
using Travel.Application.Common.Interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Commands.DeleteTourList
{
    /// <summary>
    /// The preceding code is a command for deleting TourList, and we are using the 
    /// MediatR package here. The Unit type here is from the MediatR package, which
    /// signals a no return value. Since void is not a valid return type, the Unit type represents
    /// a void type.
    /// </summary>
    public class DeleteTourListCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTourListCommandHandler : IRequestHandler<DeleteTourListCommand>
    {
        private readonly IApplicationDbContext _context;
        public DeleteTourListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTourListCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TourLists
              .Where(l => l.Id == request.Id)
              .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TourList), request.Id);
            }

            _context.TourLists.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}