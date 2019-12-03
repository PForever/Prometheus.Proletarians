using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.Proletarians.WpfCore.Help
{
    public class BaseVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetSimple<T>(ref T oldValue, T newValue, [CallerMemberName] string name = "")
        {
            if (Equals(oldValue, newValue)) return;
            oldValue = newValue;
            OnPropertyChanged(name);
        }
        protected void Set<T>(ref T oldValue, T newValue, [CallerMemberName] string name = "") where T : IEquatable<T>
        {
            if (oldValue == null && newValue == null || oldValue.Equals(newValue)) return;
            oldValue = newValue;
            OnPropertyChanged(name);
        }
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
