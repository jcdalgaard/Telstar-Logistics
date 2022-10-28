using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;

namespace ApiCore.Scenarios.Interfaces
{
    public interface IRouteScenario
    {
        public List<TopRouteDto> GetMostPopularRoutes();
        public BestRoutesDto GetRoutes(SearchDto searchDto);
        public void ApplyFees(BestRoutesDto bestRoutesDto, SearchDto searchDto);
    }
}
