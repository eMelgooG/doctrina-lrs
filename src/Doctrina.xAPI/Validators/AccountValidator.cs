﻿using FluentValidation;

namespace Doctrina.xAPI.Validators
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.HomePage).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}