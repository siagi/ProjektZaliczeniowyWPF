using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test1.Commands
{
    public class ProductCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action DoWork;

        public ProductCommands(Action work )
        {
            DoWork = work;
        }
            


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork();
        }
    }
}
