using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerAPI.Models.FormModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;

namespace BeerAPI.Commands.User
{
    public class RegisterUserCommand : IRequest<ICommandResult>
    {
        public RegisterForm Editor { get; }
        public ModelStateDictionary ModelState { get; }


        public RegisterUserCommand(ModelStateDictionary modelState, RegisterForm editor, UserManager<string> userManager, SignInManager<string> signInManager)
        {
            ModelState = modelState;
            Editor = editor;
        }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ICommandResult>
        {
            private UserManager<string> _userManager;
            private readonly SignInManager<string> _signInManager;
            public RegisterUserCommandHandler(UserManager<string> userManager, SignInManager<string> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
            
            public async Task<ICommandResult> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
            {
                if (!command.ModelState.IsValid)
                    return new CommandResult();
                var user = new IdentityUser { UserName = command.Editor.EmailAddress, Email = command.Editor.EmailAddress };
                var registrationResult = await _userManager.CreateAsync(user.Email, command.Editor.Password);
                if (registrationResult.Succeeded)
                {
                    /*
                    _logger.LogInformation("User created a new account with password.");
                    */

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Email);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    /*var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);*/

                    /*await _emailSender.SendEmailAsync(form.EmailAddress, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");*/

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                    }

                    await _signInManager.SignInAsync(command.Editor.EmailAddress, isPersistent: false);
                    // do something with return url
                    var result = new CommandResult();
                    return result;
                }
                foreach (var error in registrationResult.Errors)
                {
                    command.ModelState.AddModelError(string.Empty, error.Description);
                    // ModelState.AddModelError(string.Empty, error.Description);
                }
                return new CommandResult();
            }
        }
    }
}