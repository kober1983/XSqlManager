using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace XSqlManager.Shared.Components.ShellComponent
{
    public abstract class ShellPageItemBase : ComponentBase
    {
        [CascadingParameter(Name = "ShellComponent")]
        public ShellComponent ShellComponent { get; set; }

        [CascadingParameter(Name = "CanGoBack")]
        public bool CanGoBack { get; set; }
        [CascadingParameter(Name = "Param")]
        public object Param { get; set; }
        public bool ShowForm { get; private set; }
        public bool ShowPopUpForm { get; private set; }

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
        protected virtual bool GoBackWithResult()
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
            else
                return ShellComponent?.GoBack() ?? false;
        }
        public void GoBack()
        {
            GoBackWithResult();
        }
    }
}