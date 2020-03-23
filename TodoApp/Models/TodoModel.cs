using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    class TodoModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone;
        public bool IsDone
        {
            get { return _IsDone; }
            set { _IsDone = value; }
        }


        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

    }
}
