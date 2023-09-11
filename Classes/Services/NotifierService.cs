using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager.Classes.Services
{
    public class NotifierService
    {
        public event EventHandler<bool> LoadChanged;
        public event EventHandler<string> ErrorFormShowed;
        public event EventHandler<PlatformGoBackClickedArgs> PlatformGoBackClicked;
        public event EventHandler PlatformSleeped;
        public event EventHandler PlatformResumed;
        public event EventHandler PlatformDisposed;

        public void ShowLoader() => LoadChanged?.Invoke(this, true);
        public void HideLoader() => LoadChanged?.Invoke(this, false);
        public bool OnPlatformGoBackClicked()
        {
            var e = new PlatformGoBackClickedArgs();
            PlatformGoBackClicked?.Invoke(null, e);
            return e.IsGoBack;
        }
        public void OnPlatformSleeped() => PlatformSleeped?.Invoke(this, EventArgs.Empty);
        public void OnPlatformResumed() => PlatformResumed?.Invoke(this, EventArgs.Empty);
        public void OnPlatformDisposed() => PlatformDisposed?.Invoke(this, EventArgs.Empty);

    }
    public class PlatformGoBackClickedArgs
    {
        public bool IsGoBack { get; set; }
    }
}
