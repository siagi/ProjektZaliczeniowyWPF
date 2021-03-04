using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Test1.ViewModels
{
    public static class StaticClass
    {
        private static Action EmptyDelegate = delegate () { };

        public static void updateObj(this UIElement el)
        {
            el.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
