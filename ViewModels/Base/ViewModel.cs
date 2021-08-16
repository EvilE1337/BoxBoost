using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BoxBoost.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // CallerMemberName - получаем имя метода откуда вызвали
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false; // если значение поля уже имеет значение - выходим
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
