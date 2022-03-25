using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.Generic;
using Travel.Application.Common.Mappings;
using Travel.Domain.Entities;

namespace Travel.Application.Dtos.Tour
{
    public class TourListDto : IMapFrom<TourList>
    {
        /// <summary>
        /// The preceding code is a Data Transfer Object, or DTO, for TourList.
        /// </summary>
        public TourListDto()
        {
            Items = new List<TourPackageDto>();
        }

        public IList<TourPackageDto> Items { get; set; }
        public int Id { get; set; }
        public string City { get; set; }
        public string About { get; set; }
    }
}
