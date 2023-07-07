using Dawam.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Interfaces
{
    public interface IWaqfReopsitory
    {
        Task<IReadOnlyList<vw_waqfSearch>> SearshWaqfs(string searshText);
    }
}
