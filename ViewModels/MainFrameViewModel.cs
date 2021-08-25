using BoxBoost.DataModels;
using BoxBoost.Infrastructure.Commands;
using BoxBoost.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BoxBoost.ViewModels
{
    public class MainFrameViewModel : ViewModel
    {
        #region Controls

        #region listbox

        private ObservableCollection<BoolStringStruct> _TheList;

        public ObservableCollection<BoolStringStruct> TheList
        {
            get => _TheList;
            set => Set(ref _TheList, value);
        }

        public struct BoolStringStruct
        {
            /// <summary>Текст</summary>
            public string _TheText { get; set; }

            /// <summary>Отмечено</summary>
            public bool _IsSelected { get; set; }
        }

        #endregion

        /// <summary>Заголовок</summary>
        private ApplicationPage _CurrentPage = ApplicationPage.MainFrame;

        public ApplicationPage CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }
        #endregion

        #region Команды



        #endregion

        public MainFrameViewModel()
        {
            TheList = new ObservableCollection<BoolStringStruct>();
            TheList.Add(new BoolStringStruct { _IsSelected = true, _TheText = "Some text for item #1" });
            TheList.Add(new BoolStringStruct { _IsSelected = false, _TheText = "Some text for item #2" });
            TheList.Add(new BoolStringStruct { _IsSelected = false, _TheText = "Some text for item #3" });
            TheList.Add(new BoolStringStruct { _IsSelected = false, _TheText = "Some text for item #4" });
            TheList.Add(new BoolStringStruct { _IsSelected = false, _TheText = "Some text for item #5" });
            TheList.Add(new BoolStringStruct { _IsSelected = true, _TheText = "Some text for item #6" });
            TheList.Add(new BoolStringStruct { _IsSelected = false, _TheText = "Some text for item #7" });

            #region Команды



            #endregion

        }
        
    }
}
