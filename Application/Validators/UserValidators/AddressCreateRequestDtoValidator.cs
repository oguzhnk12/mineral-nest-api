using Application.Features.UserFeatures;
using FluentValidation;

namespace Application.Validators.UserValidators
{
    public class AddressCreateRequestDtoValidator : AbstractValidator<AddressCreateRequestDto>
    {
        public AddressCreateRequestDtoValidator()
        {
            RuleForTitle();
            RuleForStreet();
            RuleForCity();
            RuleForState();
            RuleForPostalCode();
            RuleForCountry();
            RuleForDistrict();
            RuleForFullAddress();
        }

        private void RuleForTitle() =>
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .MaximumLength(100).WithMessage("Başlık alanı en fazla 100 karakter olmalıdır.");

        private void RuleForStreet() =>
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Sokak alanı zorunludur.")
                .MaximumLength(200).WithMessage("Sokak alanı en fazla 200 karakter olmalıdır.");

        private void RuleForCity() =>
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı zorunludur.")
                .MaximumLength(100).WithMessage("Şehir alanı en fazla 100 karakter olmalıdır.");

        private void RuleForState() =>
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("İl alanı zorunludur.")
                .MaximumLength(100).WithMessage("İl alanı en fazla 100 karakter olmalıdır.");

        private void RuleForPostalCode() =>
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Posta kodu alanı zorunludur.")
                .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Posta kodu formatı geçersizdir.")
                .MaximumLength(10).WithMessage("Posta kodu alanı en fazla 10 karakter olmalıdır.");

        private void RuleForCountry() =>
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Ülke alanı zorunludur.")
                .MaximumLength(100).WithMessage("Ülke alanı en fazla 100 karakter olmalıdır.");

        private void RuleForDistrict() =>
            RuleFor(x => x.District)
                .NotEmpty().WithMessage("İlçe alanı zorunludur.")
                .MaximumLength(100).WithMessage("İlçe alanı en fazla 100 karakter olmalıdır.");

        private void RuleForFullAddress() =>
            RuleFor(x => x.FullAddress)
                .NotEmpty().WithMessage("Açık adres alanı zorunludur.")
                .MaximumLength(500).WithMessage("Açık adres alanı en fazla 500 karakter olmalıdır.");
    }
}