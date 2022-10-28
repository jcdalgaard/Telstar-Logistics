using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbClient.Archives.Interfaces;
using DbClient.Entitites;
using TelstarLogistics.DbClient.Setup;

namespace DbClient.Archives
{
    public class SegmentPriceArchive : ISegmentPriceArchive
    {
        private readonly DataContext _dataContext;

        public SegmentPriceArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public SegmentPrice GetById(int id)
        {
            var result = _dataContext.SegmentPrice.FirstOrDefault(x => x.ID == id);
            if (result == null)
            {
                throw new HttpRequestException("SegmentPrice Not Found");
            }

            return result;
        }
    }
}
