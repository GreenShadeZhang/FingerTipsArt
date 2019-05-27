using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFingertipsArt.Models
{
    public interface IPageList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int PageCount { get; }
        int ItemCount { get; }
    }
    [Serializable]
    public class PageList<T> : List<T>, IPageList<T>
    {
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int ItemCount { get; private set; }
        public int PageCount { get; private set; }

        public PageList(IEnumerable<T> items, int pageIndex, int pageSize)
            : this(items.AsQueryable<T>(), pageIndex, pageSize, -1) { }

        public PageList(IEnumerable<T> items, int pageIndex, int pageSize, int itemCount)
            : this(items.AsQueryable<T>(), pageIndex, pageSize, itemCount) { }

        public PageList(IQueryable<T> items, int pageIndex, int pageSize)
            : this(items, pageIndex, pageSize, -1) { }

        public PageList(IQueryable<T> items, int pageIndex, int pageSize, int itemCount)
        {
            if (pageIndex < 0) throw new ArgumentOutOfRangeException("pageIndex cannot be below 0.");
            if (pageSize < 1) throw new ArgumentOutOfRangeException("pageSize cannot be less than 1.");
            if (items == null) items = new List<T>().AsQueryable();
            PageIndex = pageIndex;
            PageSize = pageSize;
            if (itemCount != -1)
            {
                ItemCount = itemCount;
                AddRange(items.ToList<T>());
            }
            else
            {
                ItemCount = items.Count<T>();
                AddRange(items.Skip(PageIndex * PageSize).Take(PageSize).ToList());
            }
            PageCount = (int)Math.Ceiling((double)ItemCount / (double)PageSize);
        }
    }
}
