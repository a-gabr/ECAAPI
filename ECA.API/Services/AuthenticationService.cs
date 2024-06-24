using ECA.API.DTO;
using ECA.API.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
namespace ECA.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region P R O P E R T Y
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Jwt _jwt;
        private readonly IComputerUserService _computerUserService;
        private readonly ICustomsDealerService _customsDealerService;
        private readonly IEmployeeService _employeeService;
        private readonly IMailService _mailService;
        private readonly IMasterRepService _masterRepService;
        private readonly ISecurityUserService _securityUserService;
        private readonly ISMSService _smsService;
        #endregion
        #region C O N S T R U T O R
        public AuthenticationService(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IOptions<Jwt> jwt,
            IComputerUserService computerUserService,
            ICustomsDealerService customsDealerService,
            IEmployeeService employeeService,
            IMailService mailService,
            IMasterRepService masterRepService,
            ISecurityUserService securityUserService,
            ISMSService smsService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _computerUserService = computerUserService;
            _customsDealerService = customsDealerService;
            _employeeService = employeeService;
            _mailService = mailService;
            _masterRepService = masterRepService;
            _securityUserService = securityUserService;
            _smsService = smsService;
        }
        #endregion

        public async Task<AuthenticationDto> RegisterAsync(RegisterDto model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null) return new AuthenticationDto { Message = "Email is already registered" };           
            if (await _userManager.FindByNameAsync(model.UserNumber) is not null) return new AuthenticationDto { Message = "Username is already registered" };
            if (UserManagerExtensions.FindByMobileAsync(_userManager, model.Mobile) is not null) return new AuthenticationDto { Message = "Mobile number is already registered" };

            ComputerUser computerUser = new ComputerUser();
            var securityUserExist = await _securityUserService.IsExist(model.UserNumber);
            if (securityUserExist)
            {
                var computerUserExist = await _computerUserService.IsExist(model.UserNumber);
                if (computerUserExist)
                {
                    computerUser = (await _computerUserService.GetUsers(username: model.UserNumber)).FirstOrDefault();
                }
            }
            else
            {
                #region CustomsDealer
                if (model.UserType == 2)
                {
                    try
                    {
                        var cdlrNumber = Convert.ToDecimal(model.UserNumber);
                        var customsDealer = (await _customsDealerService.Get(cdlrNumber: cdlrNumber)).FirstOrDefault();
                        if (customsDealer is not null)
                        {
                            customsDealer.CDLREmailAddress = string.IsNullOrEmpty(customsDealer.CDLREmailAddress) ? model.Email: customsDealer.CDLREmailAddress;
                            customsDealer.CDLRMobileNo = customsDealer.CDLRMobileNo == null ? Convert.ToDecimal(model.Mobile.Substring(1)) : customsDealer.CDLRMobileNo;
                            customsDealer = _customsDealerService.Update(customsDealer);

                            await _securityUserService.Add(new SecurityUsers
                            {
                                name = customsDealer.CDLRNumber.ToString(),
                                description = customsDealer.CDLRArabicName,
                                priority = 0,
                                user_type = 0
                            });
                            computerUser = new ComputerUser
                            {
                                DDBIdentification = customsDealer.DDBIdentification,
                                CDLRIsn = customsDealer.CDLRIsn,
                                name = customsDealer.CDLRNumber.ToString(),
                                UserPassword = model.Password,
                                UserPasswordTypeCode = 2, // ثابتة
                                UserPasswordEndDate = DateTime.Now.AddMonths(6)
                            };
                            computerUser = await _computerUserService.Add(computerUser);
                        }
                        else
                        {
                            return new AuthenticationDto { Message = "Customs user is not found" };
                        }
                    }
                    catch (Exception ex)
                    {
                        return new AuthenticationDto { Message = ex.Message };
                    }
                }
                #endregion
                #region Employee
                else
                {
                    try
                    {
                        var xCode = Convert.ToInt32(model.UserNumber);
                        var employee = (await _employeeService.Get(xCode)).FirstOrDefault();
                        if (employee is null)
                        {
                            var hrEmployee = (await _masterRepService.Get(xCode: model.UserNumber)).FirstOrDefault();
                            if (hrEmployee is not null)
                            {
                                employee = await _employeeService.Add(new Employee
                                {
                                    EMPName = hrEmployee.NAME,
                                    xcode = Convert.ToInt32(hrEmployee.NO)
                                });
                            }
                            else
                            {
                                return new AuthenticationDto { Message = "Customs user is not found" };
                            }
                        }
                        await _securityUserService.Add(new SecurityUsers
                        {
                            name = employee.xcode.ToString(),
                            description = employee.EMPName,
                            priority = 0,
                            user_type = 0
                        });
                        computerUser = new ComputerUser
                        {
                            EMPID = employee.EMPIsn,
                            name = employee.xcode.ToString(),
                            UserPassword = model.Password,
                            UserPasswordTypeCode = 2, // ثابتة
                            UserPasswordEndDate = DateTime.Now.AddMonths(6)
                        };
                        computerUser = await _computerUserService.Add(computerUser);
                    }
                    catch (Exception ex)
                    {
                        return new AuthenticationDto { Message = ex.Message };
                    }
                }
                #endregion
            }
            var user = new ApplicationUser
            {
                UserName = model.UserNumber,
                Email = model.Email,
                ComputerUserId = computerUser.UserId,
                EmailConfirmed = false,
                UserOTP = _mailService.GenerateOtp(),
                PhoneNumber = model.Mobile,
                PhoneNumberConfirmed = false
                //UserActive = false,
            };
            var result = await _userManager.CreateAsync(user, model.Password); // 3shan y3ml hashing lel password
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthenticationDto { Message = errors };
            }
            var fullName = (await _securityUserService.Get(userName: user.UserName)).FirstOrDefault().description;
            var authenticationDto = new AuthenticationDto();
            if (!string.IsNullOrEmpty(model.Mobile) || !string.IsNullOrEmpty(user.Email))
            {
                if (!string.IsNullOrEmpty(model.Mobile))
                {
                    var smsBody = "مرحباً " + fullName + "، الرمز التعريفي الخاص بك للدخول على موقع مصلحة الجمارك المصرية " + user.UserOTP.ToUpper();
                    _smsService.Send(model.Mobile, smsBody);
                    authenticationDto.Mobile = user.UserMobile;
                }
                if (!string.IsNullOrEmpty(user.Email))
                {
                    var filePath = $"{Directory.GetCurrentDirectory()}\\Template\\RegisterEmail.html";
                    var str = new StreamReader(filePath);
                    var mailMessage = str.ReadToEnd();
                    str.Close();
                    mailMessage = mailMessage.Replace("[username]", fullName).Replace("[userOtp]", user.UserOTP.ToUpper());
                    _mailService.SendFromCustomsMailAsync(user.Email, "تسجيل مستخدم جديد", mailMessage);
                    //await _mailService.SendEmailAsync(user.Email, "تسجيل مستخدم جديد", mailMessage);
                    authenticationDto.Email = user.Email;
                }
                return new AuthenticationDto { Email = user.Email, Mobile = user.UserMobile, Message = "Please check your email or mobile to confirm your account" };
            }
            else
            {
                //await _userManager.AddToRoleAsync(user, "User");
                //await _userManager.AddToRoleAsync(user, "PASSENGER-EMPLOYEE"); // role el 7atetha fe gdwl aspnetroles

                var jwtSecurityToken = await CreateJwtToken(user);

                var refreshToken = GenerateRefreshToken();
                user.RefreshTokens?.Add(refreshToken);
                await _userManager.UpdateAsync(user);

                return new AuthenticationDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Mobile = user.PhoneNumber,
                    ExpiresOn = jwtSecurityToken.ValidTo,
                    IsAuthenticated = true,
                    Roles = new List<string> { "User" },
                    Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),                    
                    RefreshToken = refreshToken.Token,
                    RefreshTokenExpiration = refreshToken.ExpiresOn
                };
            }
        }
        public async Task<AuthenticationDto> ActivateAsync(ActivateDto model)
        {

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Otp)) return new AuthenticationDto { Message = "Username and OTP cannot be null" };

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user is null) user = await UserManagerExtensions.FindByMobileAsync(_userManager, model.UserName);
            if (user is null) user = await _userManager.FindByEmailAsync(model.UserName);
            if (user is null) return new AuthenticationDto { Message = "Invalid username" };

            /*
            if (!string.IsNullOrEmpty(model.Email) || !string.IsNullOrEmpty(model.Mobile))
            {
                var userByEmail = new ApplicationUser();
                var userByMobile = new ApplicationUser();
                if (!string.IsNullOrEmpty(model.Email))
                {
                    userByEmail = await _userManager.FindByEmailAsync(model.Email);
                    if (userByEmail is null)
                    {
                        return new AuthenticationDto { Message = "Invalid email address or mobile number" };
                    }
                }
                if (!string.IsNullOrEmpty(model.Mobile))
                {
                    userByMobile = await UserManagerExtensions.FindByMobileAsync(_userManager, model.Mobile);
                    if (userByMobile is null)
                    {
                        return new AuthenticationDto { Message = "Invalid email address or mobile number" };
                    }
                }
                if (userByEmail is not null && userByName != userByEmail)
                {
                    return new AuthenticationDto { Message = "Customs username does not assigned for this email address or mobile number" };
                }
                if (userByMobile is not null && userByName != userByMobile)
                {
                    return new AuthenticationDto { Message = "Customs username does not assigned for this email address or mobile number" };
                }
                if (userByMobile is not null && userByEmail is not null && userByEmail != userByMobile)
                {
                    return new AuthenticationDto { Message = "Customs username does not assigned for this email address or mobile number" };
                }
            }
            */
            if ((bool)user.UserActive)
            {
                return new AuthenticationDto { Message = "Customs user is already activated" };
            }
            if (user.UserOTP.Trim().ToUpper() != model.Otp.Trim().ToUpper())
            {
                return new AuthenticationDto { Message = "OTP is invalid" };
            }
            if (model.UserName == user.Email) user.EmailConfirmed = true;
            if (model.UserName == user.PhoneNumber) user.PhoneNumberConfirmed = true;

            //user.UserActive = true;
            user.UserOTP = string.Empty;
            await _userManager.UpdateAsync(user);

            var jwtSecurityToken = await CreateJwtToken(user);
            var refreshToken = GenerateRefreshToken();
            user.RefreshTokens?.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            return new AuthenticationDto
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                UserName = user.UserName,
                RefreshToken = refreshToken.Token,
                RefreshTokenExpiration = refreshToken.ExpiresOn
            };
        }        

        /// <summary>
        /// User can login by Username || Email address || Mobil Number and return token 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AuthenticationDto> GetTokenAsync(TokenRequestDto model)
        {
            var authModel = new AuthenticationDto();

            var user = await _userManager.FindByNameAsync(model.User);
            if (user is null) user = await UserManagerExtensions.FindByMobileAsync(_userManager, model.User);
            if (user is null) user = await _userManager.FindByEmailAsync(model.User);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Username or Password is incorrect!";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.UserName;
            authModel.UserName = user.UserName;
            authModel.ExpiresOn = jwtSecurityToken.ValidTo;
            authModel.Roles = rolesList.ToList();


            if (user.RefreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken); // insert row in refreshtokentable
                await _userManager.UpdateAsync(user); // savechanges in db
            }

            return authModel;
        }

        public async Task<string> X(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return "Invalid user ID or Role";

            return "";
        }
        public async Task<string> AddRoleAsync(AddRoleDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                return "Invalid user ID or Role";

            if (await _userManager.IsInRoleAsync(user, model.Role))
                return "User already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, model.Role);

            return result.Succeeded ? string.Empty : "Something went wrong";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes).ToLocalTime(),//DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        public async Task<AuthenticationDto> RefreshTokenAsync(string token)
        {
            var authModel = new AuthenticationDto();

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
            {
                // authModel.IsAuthenticated = false;
                authModel.Message = "Invalid token";
                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
            {
                // authModel.IsAuthenticated = false;
                authModel.Message = "Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn = DateTime.UtcNow.ToLocalTime();

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.Email = user.Email;
            authModel.UserName = user.UserName;
            var roles = await _userManager.GetRolesAsync(user);
            authModel.Roles = roles.ToList();
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow.ToLocalTime();

            await _userManager.UpdateAsync(user);

            return true;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10).ToLocalTime(),
                CreatedOn = DateTime.UtcNow.ToLocalTime()
            };
        }
    }
}