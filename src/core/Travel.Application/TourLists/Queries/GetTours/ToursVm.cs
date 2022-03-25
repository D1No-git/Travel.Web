using System.Collections.Generic;
using Travel.Application.Dtos.Tour;

namespace Travel.Application.TourLists.Queries.GetTours
{
    /// <summary>
    /// The preceding code is a View Model for Tours for GetToursQuery.
    /// </summary>
    public class ToursVm
    {
        public IList<TourListDto> Lists { get; set; }
    }
}