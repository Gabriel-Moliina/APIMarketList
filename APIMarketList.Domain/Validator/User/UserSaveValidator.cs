using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Repositories;
using FluentValidation;

namespace APIMarketList.Domain.Validator.User
{
    public class UserSaveValidator : AbstractValidator<UserSaveDTO>
    {
        private readonly IUserRepository _userRepository;
        public UserSaveValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(a => a.Email)
                   .NotEmpty()
                   .EmailAddress()
                   .WithMessage("Email inválido")
                   .MustAsync(async (model, email, cancellationtoken) =>
                   {
                       return !(await _userRepository.Exists(email));
                   }).WithMessage("Já existe um usuário cadastrado com este e-mail");

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("A senha deve conter mais de 6 dígitos")
                .Must(ValidateUpper)
                .WithMessage("A senha precisa conter ao menos um caractere maiúsculo");
        }

        public bool ValidateUpper(string value)
        {
            return value.Any(char.IsUpper);
        }
    }
}
