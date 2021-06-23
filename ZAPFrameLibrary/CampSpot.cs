using System;
using System.Collections.Generic;
using System.Text;

namespace ZAPFrameLibrary
{
    public class CampSpot
    {
        private string id;

        public string Id
        {
            get { return id; }
        }

        public CampSpot(string _id)
        {
            id = _id;
        }
    }
}
