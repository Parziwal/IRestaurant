using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace IRestaurant.DAL.DTO.Pagination
{
    /// <summary>
    /// Az eredmény listát és annak lapozási adatait tartalmazó osztály.
    /// </summary>
    /// <typeparam name="T">A tartalmazott eredmény lista típusa.</typeparam>
    public class PagedListDto<T>
    {
        /// <summary>
        /// Az oldalak száma.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Az összes elem száma.
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// Az aktuális oldal száma.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Az oldal mérete.
        /// </summary>
        public int PageSize { get; set; }
        public IEnumerable<T> Result { get; set; }

        public PagedListDto() { }
        public PagedListDto(IPagedList<T> pagedList)
        {
            PageCount = pagedList.PageCount;
            TotalItemCount = pagedList.TotalItemCount;
            PageNumber = pagedList.PageNumber;
            PageSize = pagedList.PageSize;
            Result = pagedList;
        }
    }
}
