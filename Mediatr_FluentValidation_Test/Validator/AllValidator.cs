using System;
using System.Linq;
using FluentValidation;


using Mediatr_FluentValidation_Test.Model;


namespace Mediatr_FluentValidation_Test.Validator
{
    
    public class CustomerValidator : AbstractValidator<Customers>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.username).NotEmpty().WithMessage("username can't be empty");
            RuleFor(x => x.username).MaximumLength(20).WithMessage("max username lenght is 20");
            RuleFor(x => x.email).NotEmpty().WithMessage("email can't be empty");
            RuleFor(x => x.email).EmailAddress().WithMessage("max username lenght is 20");
            RuleFor(x => x.gender).IsInEnum().WithMessage("gender is one of male or female");
            RuleFor(x => x.gender).NotEmpty().WithMessage("gender can't be empty");
            RuleFor(x => x.birthdate).NotEmpty().WithMessage("birhdate can't be empty");
            RuleFor(x => DateTime.Now.Year - x.birthdate.Year).GreaterThan(18).WithMessage("age must be greater than 18");
        }
    }
    public class CustomerPCValidator : AbstractValidator<Customer_Payment_Card>
    {
        public CustomerPCValidator()
        {
            RuleFor(x => x.name_on_card).NotEmpty().WithMessage("name_on_card can't be empty");
            RuleFor(x => x.name_on_card).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.exp_month).NotEmpty().WithMessage("exp_month can't be empty");
            RuleFor(x => Convert.ToInt32(x.exp_month)).ExclusiveBetween(1, 12).WithMessage("exp_month is bettween 1-12");
            RuleFor(x => x.exp_year).NotEmpty().WithMessage("exp_year can't be empty");
            RuleFor(x => x.credit_card_number).CreditCard().WithMessage("credit_card_number must be type of credit card number");
        }
    }
    public class MerchantValidator : AbstractValidator<Merhcant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.address).NotEmpty().WithMessage("address can't be empty");
            RuleFor(x => x.rating).ExclusiveBetween(1,5).WithMessage("address can't be empty");
        }
    }
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("name can't be empty");
            RuleFor(x => x.name).MaximumLength(50).WithMessage("max name lenght is 50");
            RuleFor(x => x.price).NotEmpty().WithMessage("price can't be empty");
            RuleFor(x => x.price).GreaterThan(1000).WithMessage("price must be greater than 1000");
        }
    }
}
