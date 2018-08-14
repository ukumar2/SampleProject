using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Project.Api.Objects
{
    public class UserBaseData
    {
        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public string EmailAddress
        { get; set; }
        public int DateOfBirthYear
        { get; set; }
        public int DateOfBirthMonth
        { get; set; }
        public int DateOfBirthDay
        { get; set; }
        public DateTime DateCreated
        { get; set; }
        public DateTime DateModified
        { get; set; }


        public UserBaseData()
        {
            this.DateCreated = DateTime.Now;
            this.DateModified = DateTime.Now;
        }
    }
}
