using Domain.Client;
using Domain.Entity;
using Domain.Repository;
using Domain.Resource;
using Domain.Service;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IEmailClient _emailClient;

        public UserService(IUserRepository repository,
            IStringLocalizer<SharedResources> localizer,
            IEmailClient emailClient)
        {
            _repository = repository;
            _localizer = localizer;
            _emailClient = emailClient;
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<int> Count(User item)
        {
            return await _repository.Count(item);
        }

        public async Task<User> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<User>> Get(User item, int skip = 0, int take = 10)
        {
            return await _repository.Get(item, skip, take);
        }

        public async Task<Guid> Insert(User item)
        {
            return await _repository.Insert(item);
        }

        public async Task Update(User item)
        {
            await _repository.Update(item);
        }

        public async Task<User> Login(string email, string password)
        {
            User user = (await _repository.Get(new User() { Email = email })).FirstOrDefault();
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
                return user;

            throw new ArgumentException(_localizer["Invalid data."]);
        }

        public async Task<(bool sucesso, string mensagem)> Register(string name, string email, string password, string confirmPassword)
        {
            bool sucesso = false;
            string mensagem = _localizer["Invalid data."];

            User user = (await _repository.Get(new User() { Email = email })).FirstOrDefault();
            if (user == null)
            {
                user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password),
                    Profile = "User",
                    CreatedOn = DateTime.Now
                };

                await _repository.Insert(user);

                sucesso = true;
                mensagem = _localizer["Record saved successfully."];
            }

            return (sucesso, mensagem);
        }

        public async Task<(bool sucesso, string mensagem)> ChangePassword(Guid Id, string password, string confirmPassword)
        {
            bool sucesso = false;
            string mensagem = _localizer["Invalid data."];

            User user = await _repository.Get(Id);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
                user.Token = null;
                user.TokenExpiration = null;

                await _repository.Update(user);

                sucesso = true;
                mensagem = _localizer["Record saved successfully."];
            }

            return (sucesso, mensagem);
        }

        public async Task<(bool sucesso, string mensagem)> ForgotPassword(string email)
        {
            bool sucesso = false;
            string mensagem = _localizer["Invalid data."];

            User user = (await _repository.Get(new User() { Email = email })).FirstOrDefault();
            if (user != null)
            {
                user.Token = new Random().Next(100000, 999999);
                user.TokenExpiration = DateTime.Now.AddMinutes(30);

                if (await _emailClient.ResetPassword(user.Email, user.Token.Value))
                {
                    await _repository.Update(user);

                    sucesso = true;
                    mensagem = _localizer["Record saved successfully."];
                }
            }

            return (sucesso, mensagem);
        }

        public async Task<(bool sucesso, string mensagem, Guid id)> ForgotPasswordConfirmation(string email, string token)
        {
            bool sucesso = false;
            string mensagem = _localizer["Invalid data."];
            Guid id = Guid.NewGuid();
            User user = (await _repository.Get(new User() { Email = email })).FirstOrDefault();
            if (user != null)
            {
                if (token.Equals(user.Token) && DateTime.Now < user.TokenExpiration)
                {
                    id = user.Id;
                    sucesso = true;
                    mensagem = _localizer["Record saved successfully."];
                }
            }

            return (sucesso, mensagem, id);
        }
    }
}
