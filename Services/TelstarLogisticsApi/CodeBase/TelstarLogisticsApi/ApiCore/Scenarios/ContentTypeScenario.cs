using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;
using DbClient.Archives.Interfaces;
using TelstarLogistics.DbClient.Archives.Interfaces;
using TelstarLogistics.DbClient.Setup;
using TelstarLogistics.ExternalApiClient.Archives.Interfaces;

namespace ApiCore.Scenarios
{
    public class ContentTypeScenario : IContentTypeScenario
    {
        private readonly IContentTypeArchive _contentTypeArchive;

        public ContentTypeScenario(IContentTypeArchive contentTypeArchive)
        {
            _contentTypeArchive = contentTypeArchive;
        }

        public ContentTypeDto GetContentTypes()
        {
            return new ContentTypeDto()
            {
                LegalCategories = _contentTypeArchive.GetLegalContentTypes(),
                IllegalCategories = _contentTypeArchive.GetIllegalContentTypes(),
            };
        }
    }
}