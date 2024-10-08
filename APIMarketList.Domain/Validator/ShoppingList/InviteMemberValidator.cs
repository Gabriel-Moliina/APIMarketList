using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.Interface.Repositories;
using FluentValidation;

namespace APIMarketList.Domain.Validator.ShoppingList
{
    public class InviteMemberValidator : AbstractValidator<InviteMemberDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IShoppingListRepository _shoppingListRepository;
        public InviteMemberValidator(IUserRepository userRepository,
            IShoppingListRepository shoppingListRepository)
        {
            _userRepository = userRepository;
            _shoppingListRepository = shoppingListRepository;

            RuleFor(x => x.MemberEmail)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido")
                .MustAsync(async (model, code, cancellationtoken) =>
                {
                    return (await _userRepository.Exists(model.MemberEmail));
                }).WithMessage("O e-mail informado não foi encontrado")
                .MustAsync(async (model, code, cancellationtoken) =>
                {
                    return (await _shoppingListRepository.Exists(model.ShoppingListId));
                }).WithMessage("A lista de compra não foi encontrada");
        }
    }
}
