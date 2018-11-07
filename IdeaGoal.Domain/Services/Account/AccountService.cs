using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using IdeaGoal.Domain.Core.Data.Repo;
using IdeaGoal.Domain.Core.Entities;
using IdeaGoal.Domain.Services.Account.Dto;
using IdeaGoal.Domain.Services.Security;
using IdeaGoal.Domain.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IdeaGoal.Domain.Services.Account
{
    public class AccountService
    {
        public const string AUTH_ENC_KEY = "supersecretpassword";
        private const string AUTH_USER_KEY = "AUTH_USER_XXX";

        private readonly IRepository<User> _userRepository;
        private readonly IEncryptService _encryptService;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;

        public AccountService(
            IRepository<User> userRepository, 
            IEncryptService encryptService,
            ITokenService tokenService, 
            IAuthService authService)
        {
            _userRepository = userRepository;
            _encryptService = encryptService;
            _tokenService = tokenService;
            _authService = authService;
        }

        public LoginResultDto Login(LoginDto input)
        {
            string encPas = _encryptService.Encrypt(input.Password, AUTH_ENC_KEY);
            var user = _userRepository.Table.FirstOrDefault(x =>
                x.Username == input.Username && x.PasswordHash == encPas).ToEntityDto<UserDto>();

            if(user == null)
                throw new AuthenticationException("User not authorized");

            var token = _tokenService.GenerateTokenForUser(user);
            Authorize(token);
            return new LoginResultDto
            {
                Token = token
            };
        }

        public RegisterResultDto Register(RegisterDto input)
        {
            if (_userRepository.Table.Any(x => x.Username == input.Username))
                throw new ValidationException($"User with name '{input.Username}' already registered.");

            if (input.Password != input.RepeatPassword)
                throw new ValidationException("Password mismatch");

            var user = new User { PasswordHash = _encryptService.Encrypt(input.Password, AUTH_ENC_KEY), Username = input.Username };
            _userRepository.Insert(user);

            return new RegisterResultDto
            {
                Token = Login(new LoginDto { Password = input.Password, Username = input.Username }).Token
            };
        }

        // get token and authorize user before every request
        private void Authorize(string token)
        {
            var userId = _tokenService.GetUserID(token);
            var user = _userRepository.Table.FirstOrDefault(x => x.Id == userId);
            if(user == null) throw new Exception("User not found");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Username),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            _authService.SignInAsync(principal).Wait();
        }


        private UserDto _currentUser;
        public UserDto CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    if (_authService.User == null) throw new AuthenticationException();

                    _currentUser = 
                        _userRepository.Table
                            .FirstOrDefault(x => x.Username == _authService.User.Identity.Name)
                            .ToEntityDto<UserDto>();
                }

                return _currentUser;
            }
        }
    }
}
