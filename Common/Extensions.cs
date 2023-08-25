using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSqlManager
{
    public static class Extensions
    {
        public class BoundingClientRect
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public double Top { get; set; }
            public double Right { get; set; }
            public double Bottom { get; set; }
            public double Left { get; set; }
        }
        public static ValueTask<BoundingClientRect> GetBoundingClientRect(this IJSRuntime self, ElementReference element)
        {
            return self.InvokeAsync<BoundingClientRect>("BlazorExtension.getBoundingClientRect", element);
        }
        public static ValueTask FocusElement(this IJSRuntime self, ElementReference element)
        {
            return self.InvokeVoidAsync("BlazorExtension.focusElement", element);
        }
        public static ValueTask SelectText(this IJSRuntime self, ElementReference element)
        {
            return self.InvokeVoidAsync("BlazorExtension.selectText", element);
        }
    }
}
