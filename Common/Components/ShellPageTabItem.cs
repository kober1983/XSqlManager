using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager.Common.Components
{
    public class ShellPageTabItem
    {
        public bool IsRoot;
        public string TabActiveClass;
        public bool IsActive;
        public Stack<string> _stackPages = new Stack<string>();
        public Dictionary<string, object> _hashPages = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public string PageName = "";
        public bool InStack(string pageName)
        {
            return _hashPages.ContainsKey(pageName);
        }
        public void PushPage(string pageName, object param = null, bool replace = false)
        {
            if (replace)
                PopPage();

            PageName = pageName;
            if (_hashPages.ContainsKey(PageName))
            {
                _hashPages[PageName] = param;
            }
            else
            {
                _stackPages.Push(PageName);
                _hashPages.Add(PageName, param);
            }
        }
        public void Clear()
        {
            PageName = "";
            _stackPages.Clear();
            _hashPages.Clear();
        }
        public bool PopPage()
        {
            if (_hashPages.Count > 0)
            {
                var page = _stackPages.Pop();
                _hashPages.Remove(page);
                if (_stackPages.Count > 0)
                    PageName = _stackPages.Peek();
                else
                    PageName = "";
                return true;
            }
            return false;
        }
        public bool HasPages()
        {
            return _stackPages.Count > 0;
        }
    }
}
