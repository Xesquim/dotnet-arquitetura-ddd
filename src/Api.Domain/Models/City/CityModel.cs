using System;

namespace Api.Domain.Models.City
{
    public class CityModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _ibgeCode;
        public int IbgeCode
        {
            get { return _ibgeCode; }
            set { _ibgeCode = value; }
        }
        
        private Guid _siId;
        public Guid SiId
        {
            get { return _siId; }
            set { _siId = value; }
        }
    }
}