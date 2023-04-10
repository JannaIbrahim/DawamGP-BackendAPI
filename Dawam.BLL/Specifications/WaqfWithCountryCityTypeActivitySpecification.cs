using Dawam.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Specifications
{
    public class WaqfWithCountryCityTypeActivitySpecification: BaseSpecification<Waqf>
    {
        public WaqfWithCountryCityTypeActivitySpecification()
        {
            AddIncludes(w => w.WaqfCountry);
            AddIncludes(w => w.WaqfCity);
            AddIncludes(w => w.WaqfType);
            AddIncludes(w => w.WaqfActivity);
            AddIncludes(w => w.WaqfStatus);
            AddIncludes(w => w.InsUser);
            AddIncludes(w => w.ConfirmUser);
            
            
        }

        public WaqfWithCountryCityTypeActivitySpecification(Expression<Func<Waqf, bool>> criteria) : base(criteria)
        {
            AddIncludes(w => w.WaqfCountry);
            AddIncludes(w => w.WaqfCity);
            AddIncludes(w => w.WaqfType);
            AddIncludes(w => w.WaqfActivity);
            AddIncludes(w => w.WaqfStatus);
            AddIncludes(w => w.InsUser);
            AddIncludes(w => w.ConfirmUser);




        }
    }
}
