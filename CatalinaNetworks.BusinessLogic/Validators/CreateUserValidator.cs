﻿using CatalinaNetworks.Core.Models;
using FluentValidation;

namespace CatalinaNetworks.BusinessLogic.Validators
{
    public class CreateUserValidator : AbstractValidator<User>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Id).Empty();
            RuleFor(u => u.Name).NotEmpty().MaximumLength(100);
            RuleFor(u => u.UniqueUrlName).MaximumLength(300);
#pragma warning disable CS8602 // Разыменование вероятной пустой ссылки.
            RuleFor(u => u.Photos.Small).MaximumLength(50);
            RuleFor(u => u.Photos.Large).MaximumLength(50);
            RuleFor(u => u.Photos.UserId).Equal(u => u.Id);
#pragma warning restore CS8602 // Разыменование вероятной пустой ссылки.
        }
    }
}
