using BoxBoost.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxBoost.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /// <summary>Заголовок</summary>
        private string _Title = "test";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        /// <summary> Статус операции </summary>
        private string _Status = "Ready";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
    }
}
