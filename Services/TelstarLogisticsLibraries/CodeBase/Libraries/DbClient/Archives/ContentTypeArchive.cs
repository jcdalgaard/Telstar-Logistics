using DbClient.Archives.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelstarLogistics.DbClient.Setup;

namespace DbClient.Archives
{
    public class ContentTypeArchive : IContentTypeArchive
    {
        private readonly DataContext _dataContext;

        public ContentTypeArchive(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<string> GetIllegalContentTypes()
        {
            return _dataContext.PackageContentType.Where(x => x.IsLegal == false).Select(x => x.Name).ToList();
        }

        public List<string> GetLegalContentTypes()
        {
            return _dataContext.PackageContentType.Where(x => x.IsLegal == true).Select(x => x.Name).ToList();
        }
    }
}