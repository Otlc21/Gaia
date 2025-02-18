using Domain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Client
{
    public class EmailClient : IEmailClient
    {
        public async Task<bool> ResetPassword(string email, int token)
        {
            // TODO
            return true;
        }
    }
}
