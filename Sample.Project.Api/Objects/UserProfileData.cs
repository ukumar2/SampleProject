using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Project.Api.Objects
{
    public class UserProfileData : UserBaseData
    {
        public string AddressLine1
        { get; set; }
        public string AddressLine2
        { get; set; }
        public string City
        { get; set; }
        public string State
        { get; set; }
        public long Zipcode
        { get; set; }
        public string Country
        { get; set; }
        public string CompanyName
        { get; set; }
        public string WorkPhone
        { get; set; }
        public string CellPhone
        { get; set; }

        public UserProfileData()
        {
            //Constructor
        }
    }
}
