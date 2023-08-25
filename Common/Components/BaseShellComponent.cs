//using Microsoft.AspNetCore.Components;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace XSqlManager.Common.Components
//{
//    public partial class BaseShellComponent : ComponentBase, IDisposable
//    {
//        [Inject]
//        private INotifierService _nService { get; set; }

//        [Inject]
//        private IPlatformDeviceService _platformDeviceService { get; set; }
//        [Inject]
//        private IStateManager StateManager { get; set; }

//        private const string _selectedClass = "selected";
//        private Dictionary<string, ShellPageTabItem> _tabs;
//        private bool _isOpenForm;
//        public ShellPageTabItem _currentTab;
//        private bool _showBottomPanel = true;
//        protected override void OnInitialized()
//        {
//            base.OnInitialized();
//            _nService.PlatformGoBackClicked += _onBackClicked;
//            _nService.BottomPanelChanged += _bottomPanelChanged;
//            _tabs = new Dictionary<string, ShellPageTabItem>(StringComparer.OrdinalIgnoreCase)
//            {
//                {"home",new ShellPageTabItem(){TabActiveClass=_selectedClass,IsActive=true,IsRoot=true} },{"work",new ShellPageTabItem(){} },{"profile",new ShellPageTabItem(){} }
//            };
//            _currentTab = _tabs["home"];
//        }
//        private void _onBackClicked(object sender, PlatformGoBackClickedArgs e)
//        {
//            e.IsGoBack = GoBack();
//        }

//        private async void _bottomPanelChanged(object sender, bool e)
//        {
//            _showBottomPanel = e;
//            await InvokeAsync(StateHasChanged);
//        }

//        private bool _isHidden(ShellPageTabItem tabItem, string name)
//        {
//            return !tabItem.IsActive || tabItem.PageName != name;
//        }

//        private void _changeTab(string key)
//        {
//            foreach (var k in _tabs)
//            {
//                if (k.Key == key)
//                {
//                    k.Value.IsActive = true;
//                    k.Value.TabActiveClass = _selectedClass;
//                    if (_currentTab == k.Value)
//                    {
//                        _currentTab.Clear();
//                    }
//                    _currentTab = k.Value;
//                }
//                else
//                {
//                    k.Value.IsActive = false;
//                    k.Value.TabActiveClass = "";
//                }
//            }
//        }
//        private bool _goToRoot()
//        {
//            var t = _currentTab;
//            foreach (var k in _tabs.Values)
//            {
//                if (k.IsRoot)
//                {
//                    k.IsActive = true;
//                    k.TabActiveClass = _selectedClass;
//                    _currentTab = k;
//                }
//                else
//                {
//                    k.IsActive = false;
//                    k.TabActiveClass = "";
//                }
//            }
//            return t != _currentTab;
//        }

//        private string _noOverflowStyle() => _isOpenForm ? "no_overflow" : "";

//        NavigationPageBase _withOpenForm;
//        NavigationPageBase _withOpenPopUpForm;
//        public void IsOpenForm(NavigationPageBase withOpenForm)
//        {
//            _isOpenForm = true;
//            _withOpenForm = withOpenForm;
//            //Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//            StateHasChanged();
//        }
//        public void IsCloseForm()
//        {
//            _isOpenForm = false;
//            _withOpenForm = null;
//            //Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//            StateHasChanged();
//        }
//        public void IsOpenPopUpForm(NavigationPageBase withOpenPopUpForm)
//        {
//            _withOpenPopUpForm = withOpenPopUpForm;
//            //Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//            StateHasChanged();
//        }
//        public void IsClosePopUpForm()
//        {
//            _withOpenPopUpForm = null;
//            //Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//            StateHasChanged();
//        }

//        public bool CanGoBack()
//        {
//            return _currentTab.HasPages();
//        }


//        public void GoTo(string page, object param, bool replace = false)
//        {
//            _currentTab.PushPage(page, param, replace);
//            _withOpenForm = null;
//            _withOpenPopUpForm = null;
//            StateHasChanged();//Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//        }
//        public void GoTo(string tabName, string page, object param)
//        {
//            _changeTab(tabName);
//            if (_currentTab.PageName != page)
//            {
//                _currentTab.PushPage(page, param);
//            }
//            _withOpenForm = null;
//            _withOpenPopUpForm = null;
//            StateHasChanged();//Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//        }

//        public bool GoBack()
//        {
//            if (_withOpenPopUpForm != null)
//            {
//                _withOpenPopUpForm.ClosePopUpForm();
//                _withOpenPopUpForm = null;
//            }
//            else if (_withOpenForm != null)
//            {
//                _withOpenForm.CloseForm();
//                _withOpenForm = null;
//            }
//            else if (StateManager.BarcodeShowed)
//            {
//                _nService.HideBarcodeScaner();
//            }
//            else if (StateManager.CapturePhotoShowed)
//            {
//                _nService.HideCapturePhoto();
//            }
//            else if (!_currentTab.PopPage())
//            {
//                if (!_goToRoot())
//                {
//                    StateHasChanged();//Нужен здесь, т.к. событие происходит во внутреннем компоненте, а перерисовтаь надо этот
//                    return false;
//                }
//            }
//            else
//            {
//                _platformDeviceService.ClearCache();
//            }

//            _nService.HideLoader();
//            StateHasChanged();
//            return true;
//        }

//        public void Dispose()
//        {
//            _nService.LoadChanged -= _bottomPanelChanged;
//            _nService.PlatformGoBackClicked -= _onBackClicked;
//        }
//    }
//}

