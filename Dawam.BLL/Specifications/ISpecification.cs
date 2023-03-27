using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Specifications
{
    public interface ISpecification<T>
    {
        public Expression<Func<T,bool>> Criteria { get; set; }
        public List<Expression<Func<T,Object>>> Includes { get; set; }

    }
}
