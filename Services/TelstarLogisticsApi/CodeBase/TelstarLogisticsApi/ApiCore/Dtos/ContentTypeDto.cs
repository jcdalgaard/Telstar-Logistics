using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCore.Dtos
{
    public class ContentTypeDto
    {
        public List<string> LegalCategories { get; set; }
        public List<string> IllegalCategories { get; set; }
    }
}
