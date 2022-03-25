using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Common.Interfaces;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    /// <summary>
    /// First query, which is a request for reading data, and a query 
    /// handler, which will resolve what the query needs. Again, the controller is responsible for 
    /// sending or dispatching the queries to the relevant handlers.
    /// The following is a block of code for ExportToursQuery and its handler.You will see
    /// later how the controller will use ExportToursQuery as an argument in the mediator's Send method:
    /// </summary>
    public class ExportToursQuery : IRequest<ExportToursVm>
    {
        public int ListId { get; set; }
    }

    public class ExportToursQueryHandler : IRequestHandler<ExportToursQuery, ExportToursVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportToursQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportToursVm> Handle(ExportToursQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportToursVm();

            var records = await _context.TourPackages
                .Where(t => t.ListId == request.ListId)
                .ProjectTo<TourPackageRecord>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildTourPackagesFile(records);
            vm.ContentType = "text/csv";
            vm.FileName = "TourPackages.csv";

            return await Task.FromResult(vm);
        }
    }
}
