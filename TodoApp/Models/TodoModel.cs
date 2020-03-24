using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace TodoApp.Models
{
    class TodoModel : INotifyPropertyChanged

    {
        [JsonProperty(PropertyName = "creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone;

        [JsonProperty(PropertyName = "isDone")]
        public bool IsDone
        {
            get { return _IsDone; }
            set
            {
                if (_IsDone == value)
                    return;
                _IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }


        private string _text;

        [JsonProperty(PropertyName = "text")]
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
