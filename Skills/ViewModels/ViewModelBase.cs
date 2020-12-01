using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Skills.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName = null) 
        {
            PropertyChanged?.Invoke(this , new PropertyChangedEventArgs(propertyName));
        }

        public virtual  void Initialize(object parameter)
        {
        
        }
    }
}
