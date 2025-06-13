using FluentValidation;
using Application.Features.UserFeatures;

namespace Application.Validators.UserValidators
{
    public class UserCreateRequestDtoValidator : AbstractValidator<UserCreateRequestDto>
    {
        public UserCreateRequestDtoValidator()
        {
            ValidateFirstName();
            ValidateLastName();
            ValidateEmail();
            ValidatePassword();
            ValidatePhoneNumber();
            ValidateAddress();
        }

        private void ValidateFirstName()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı zorunludur.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter olabilir.");
        }

        private void ValidateLastName()
        {
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı zorunludur.")
                .MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olabilir.");
        }

        private void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alanı zorunludur.")
                .EmailAddress().WithMessage("Geçersiz e-posta formatı.")
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");
        }

        private void ValidatePassword()
        {
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı zorunludur.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Şifre en fazla 100 karakter olabilir.");
        }

        private void ValidatePhoneNumber()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası alanı zorunludur.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçersiz telefon numarası formatı.")
                .MaximumLength(15).WithMessage("Telefon numarası en fazla 15 karakter olabilir.");
        }

        private void ValidateAddress()
        {
            RuleFor(x => x.Address)
                .NotNull().WithMessage("Adres alanı zorunludur.")
                .SetValidator(new AddressCreateRequestDtoValidator());
        }
    }
}
