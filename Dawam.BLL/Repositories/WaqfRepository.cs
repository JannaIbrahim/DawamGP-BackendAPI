using Dawam.BLL.Interfaces;
using Dawam.DAL.Data;
using Dawam.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dawam.BLL.Repositories
{
    public class WaqfRepository : IWaqfReopsitory
    {
        private readonly StoreContext _context;

        public WaqfRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<vw_waqfSearch>> SearshWaqfs(string SearchText)
        {
        //    try
        //    {

                #region Check Arabic Search
                string sSearch = "";
                string c = "";
                //  parameters --> category id to filter with, all items count to skip , all items that will return
                if (SearchText != null)
                {
                    for (int i = 0; i < SearchText.Length; i++)
                    {
                        //Name = Name.Replace("[ا", "[]").Replace("إ", "[اإأ]").Replace("أ", "[اإأ]").Replace("ه", "[ةه]").Replace("ة", "[ةه]").Replace("ى", "[ىي]").Replace("ي", "[يى]");

                        c = SearchText.Substring(i, 1);
                        if (c == "ا")
                            sSearch += "[اإأ]";
                        else if (c == "إ")
                            sSearch += "[اإأ]";
                        else if (c == "أ")
                            sSearch += "[اإأ]";
                        else if (c == "ه")
                            sSearch += "[ةه]";
                        else if (c == "ة")
                            sSearch += "[ةه]";
                        else if (c == "ى")
                            sSearch += "[ى ي]";
                        else if (c == "ي")
                            sSearch += "[ى ي]";
                        else
                            sSearch += c;

                    }
                }
                else
                {
                    sSearch = SearchText;

                }
                #endregion

                //var allItmesCount = await _context.FromSql($"getItemsCountInCategory {catID}").FirstOrDefaultAsync();
                var
                    result = await _context.WaqfSearchSP(sSearch).ToListAsync();

                //if (result != null)
                    return result;

                
            //}
            //catch (Exception ex)
            //{
            //    //or.HasErrors = true;
            //    //or.Message = ex.Message;
            //}
            //return null;
        }

    }
    }

