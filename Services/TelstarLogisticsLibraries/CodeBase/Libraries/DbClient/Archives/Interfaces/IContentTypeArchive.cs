using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbClient.Archives.Interfaces
{
    public interface IContentTypeArchive
    {
        List<string> GetLegalContentTypes();

        List<string> GetIllegalContentTypes();
    }
}