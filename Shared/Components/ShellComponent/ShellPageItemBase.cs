using Microsoft.AspNetCore.Components;
using XSqlManager.Shared.Components.ShellComponent;

namespace XSqlManager.Components
{
    public abstract class ShellPageItemBase : ComponentBase, IDisposable
    {
        [CascadingParameter(Name = "ShellComponent")]
        public ShellComponent ShellComponent { get; set; }

        [CascadingParameter(Name = "CanGoBack")]
        public bool CanGoBack { get; set; }
        [CascadingParameter(Name = "Param")]
        public object Param { get; set; }

        [CascadingParameter(Name = "TabRouteName")]
        public string TabRouteName { get; set; }
        [CascadingParameter(Name = "RouteName")]
        public string RouteName { get; set; }

        protected bool ShowForm { get; private set; }
        protected bool ShowPopUpForm { get; private set; }

        protected override void OnInitialized()
        {
            ShellComponent?._addNavigationPage(TabRouteName, RouteName, this);
        }
        public virtual void Dispose()
        {
            ShellComponent?._removeNavigationPage(TabRouteName, RouteName);
        }
        public virtual void CloseForm()
        {
            ShowForm = false;
        }
        public virtual void ClosePopUpForm()
        {
            ShowPopUpForm = false;
        }
        protected virtual void OpenForm()
        {
            ShowForm = true;
        }
        protected virtual void OpenPopUpForm()
        {
            ShowPopUpForm = true;
        }
        public void InvokeStateChange()
        {
            InvokeAsync(StateHasChanged);
        }
        public void GoTo(string pageRouteName, object param = null, bool replace = false)
        {
            CloseForm();
            ClosePopUpForm();
            ShellComponent?.GoTo(pageRouteName, param, replace);
        }
        public void GoTo(string tabRouteName, string pageRouteName, object param = null)
        {
            CloseForm();
            ClosePopUpForm();
            ShellComponent?.GoTo(tabRouteName, pageRouteName, param);
        }
        //true - если действие по возврату выполнено
        internal virtual bool _goBackFromComponent()
        {
            if (ShowForm)
            {
                CloseForm();
                return true;
            }
            else if (ShowPopUpForm)
            {
                ClosePopUpForm();
                return true;
            }
            return false;
        }
        public void GoBack()
        {
            ShellComponent?.GoBack();
        }
    }
}