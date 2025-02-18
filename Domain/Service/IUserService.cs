using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IUserService
    {
        Task<User> Login(string email, string password);
        Task<(bool sucesso, string mensagem)> Register(string name, string email, string password, string confirmPassword);
        Task<(bool sucesso, string mensagem)> ForgotPassword(string email);
        Task<(bool sucesso, string mensagem, Guid id)> ForgotPasswordConfirmation(string email, string token);
        Task<(bool sucesso, string mensagem)> ChangePassword(Guid id, string password, string confirmPassword);

        Task<int> Count(User item);
        Task<User> Get(Guid id);
        Task<List<User>> Get(User item, int skip = 0, int take = 10);
        Task<Guid> Insert(User item);
        Task Update(User item);
        Task Delete(Guid id);
    }
}
