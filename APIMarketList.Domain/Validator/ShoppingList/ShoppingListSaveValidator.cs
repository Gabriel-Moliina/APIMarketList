using APIMarketList.Domain.DTO.ShoppingList;
using APIMarketList.Domain.DTO.User;
using APIMarketList.Domain.Interface.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIMarketList.Domain.Validator.ShoppingList
{
    public class ShoppingListSaveValidator : AbstractValidator<ShoppingListSaveDTO>
    {
        public ShoppingListSaveValidator()
        {

            RuleFor(a => a.Description)
                   .NotEmpty()
                   .WithMessage("Já existe um usuário cadastrado com este e-mail");
        }

    }
}
