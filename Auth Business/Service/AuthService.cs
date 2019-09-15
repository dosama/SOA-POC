using System;
using System.Text;
using System.Threading.Tasks;
using Auth_Business.Models;
using AutoMapper;
using Data.Repositories.Users;

namespace Auth_Business.Service
{
    class AuthService:IAuthService
    {
        private readonly IUsersRepository _users;
        private readonly IMapper _mapper;

        public AuthService(IUsersRepository users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                if(request == null)
                    throw new Exception("Invalid Request Parameters!");

                var isValidUser = await _users.ValidateUserCredintials(request.UserName, request.Password);

                if (isValidUser)
                {
                    var loggedInUser = await _users.GetUserByUserName(request.UserName);
                     
                    return new LoginResponse(){IsAuthenticated = true, UserDetails = _mapper.Map<UserDetails>(loggedInUser) };

                }
                return new LoginResponse() { IsAuthenticated = false, UserDetails = null };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
