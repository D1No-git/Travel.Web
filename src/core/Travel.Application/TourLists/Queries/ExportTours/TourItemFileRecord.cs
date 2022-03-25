using System;
using System.Collections.Generic;
using System.Text;
using Travel.Application.Common.Mappings;
using Travel.Domain.Entities;

namespace Travel.Application.TourLists.Queries.ExportTours
{
    /// <summary>
    /// The CsvFileBuilder file that we will create will need the preceding code to create the 
    /// type of parameter.
    /// </summary>
    public class TourPackageRecord : IMapFrom<TourPackage>
    {
        public string Name { get; set; }
        public string MapLocation { get; set; }
    }
}
