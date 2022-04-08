using Bootcamp.API.DTOs;
using Bootcamp.API.Models;
using FluentValidation;

namespace Bootcamp.API.Validators
{
    public class ProductRequestDtoValidator : AbstractValidator<ProductRequestDto>
    {
        private readonly IProductRepository _repository;

        public ProductRequestDtoValidator(IProductRepository repository)
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name alanı boş olamaz").NotEmpty().WithMessage("Name alanı boş olamaz");
            RuleFor(x => x.Price).NotNull().WithMessage("Price alanı boş olamaz");
            RuleFor(x => x.Stock).NotNull().WithMessage("Stock alanı boş olamaz");
            _repository = repository;

            RuleFor(x => x.Stock).Must(x =>
            {

                var products = _repository.GetAll();
                if (x.Value > 10 && x.Value < 200)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }).WithMessage("Stok alanı 10 ile 200 arasında bir değer olmalıdır.");
        }
    }
}
