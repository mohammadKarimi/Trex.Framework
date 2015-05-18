using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Test
{
    
    public class Accounts
    {
        public int AccountsId { get; set; }

        public string Username { get; set; }
        public string Name { get; set; }

        public string Family { get; set; }

        public string FullName { get { return string.Format("{0} {1}", this.Name, this.Family); } }

        public string NationalCode { get; set; }

        public string BirthDate { get; set; }

        /// <summary>
        /// فعال یا غیر فعال بودن کاربر
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// آیا کاربر حذف شده
        /// </summary>
        public bool IsDelete { get; set; }

        public byte[] Photo { get; set; }
    }
}
