using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Prism.Mvvm;
namespace Resource
{
    public class BaseModel : BindableBase, INotifyDataErrorInfo
    {
        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return _errors.Values;
            if (_errors.ContainsKey(propertyName)) return _errors[propertyName];
            return null;
        }
        public void AddError(string propertyName,string mesageError) 
        {
            if (!_errors.ContainsKey(propertyName)) _errors.Add(propertyName, new List<string>());
            if (!_errors[propertyName].Contains(mesageError)) _errors[propertyName].Add(mesageError);
            ErrorsChanged?.Invoke(this,new DataErrorsChangedEventArgs(propertyName));
        }

        public void RemoveError(string propertyName, string mesageError) 
        {
            if (string.IsNullOrEmpty(mesageError)) 
            {
                _errors.Remove(propertyName);
            }
            if (_errors[propertyName].Contains(mesageError))
            {
                _errors[propertyName].Remove(mesageError);
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
