using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCore.Dtos;
using ApiCore.Scenarios.Interfaces;

namespace ApiCore.Scenarios
{
    public class ContentTypeScenario: IContentTypeScenario
    {
        public ContentTypeDto GetContentTypes()
        {
            return new ContentTypeDto()
            {
                LegalCategories = new List<string>()
                {
                    "CategoryA",
                    "CategoryB",
                    "CategoryC"
                },
                IllegalCategories = new List<string>()
                {
                    "CategoryD",
                    "CategoryE"
                }
            };
        }
    }
}
