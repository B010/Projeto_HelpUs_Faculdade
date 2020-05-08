using System.Collections.Generic;
using System.Web.Mvc;

namespace Util.Dictionary
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<SelectListItem> AsSelectListItem<T>(this IDictionary<T, string> source)
        {
            var selectList = new List<SelectListItem>();

            foreach (var e in source)
                selectList.Add(new SelectListItem { Value = e.Key.ToString(), Text = e.Value });

            return selectList;
        }

    }
}
