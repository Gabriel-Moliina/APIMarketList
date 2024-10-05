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

            RuleFor(a => a.TargetDate)
                   .Must((model, targetDate) =>
                   {
                       return targetDate.Date >= DateTime.UtcNow.Date;
                   })
                   .WithMessage("Não é possível cadastrar uma lista com uma data anterior à atual.");
        }

    }
}
