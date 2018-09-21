using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeRest
{
    public class RestData
    {
        //First ConsumeRest 3rd Sem.
        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private bool _completed;

        public bool Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }

        public RestData()
        {
                
        }

        public RestData(int userId, int id, string title, bool completed)
        {
            _userID = userId;
            _ID = id;
            _title = title;
            _completed = completed;
        }

        public override string ToString()
        {
            return $"{UserID}, {ID}, {Title}, {Completed}.";
        }
    }
}
