using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Messages
{
    /// <summary>
    /// An extension of member that also includes a message for some sort of extra    
    /// </summary>
    public class MessageProduct : Product
    {
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="fName">The member's first name.</param>
        /// <param name="lName">The member's last name.</param>
        /// <param name="mail">The member's e-mail.</param>
        /// <param name="message">The extra description</param>
        public MessageProduct(string fName, string lName, string mail, string message) : base(fName, lName, mail)
        {
            Message = message;
        }
        /// <summary>
        /// A property that includes the message.
        /// </summary>
        public string Message { get; private set; }
    }
}
