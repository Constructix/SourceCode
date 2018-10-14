using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI.Models
{
    public class TodoItem
    {

        private int _id;
        private string _name;
        private DateTime _lastUpdated;
        private bool _isComplete;



        public int Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                UpdateLastUpdated();
            }
        }

        public string Name
        {
            get { return _name;}
            set
            {
                _name = value;
                UpdateLastUpdated();
            }
        }

        public bool IsComplete
        {
            get { return _isComplete;}
            set
            {
                _isComplete = value;
                UpdateLastUpdated();
            }
        }

        private void UpdateLastUpdated()
        {
            _lastUpdated = DateTime.Now;
        }

        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
            set { _lastUpdated = value; }
        }

        public TodoItem()
        {
            LastUpdated = DateTime.Now; 
        }
    }
}


