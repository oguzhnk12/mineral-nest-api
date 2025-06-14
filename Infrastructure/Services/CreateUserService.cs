using Application.Features.UserFeatures;
using Application.Interfaces;
using Application.Mapping.MappingServices;
using Application.Validators.UserValidators;
using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class CreateUserService : ICreateUserService
    {
        private readonly AppDbContext _context;

        private readonly UserMappingService _mapper;

        private readonly PasswordHasher<User> _passwordHasher;

        public CreateUserService(AppDbContext context, UserMappingService mapper)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<bool> CreateUser(UserCreateRequestDto dto)
        {
            var validator = new UserCreateRequestDtoValidator();
            var validationResult = validator.Validate(dto);
            if (!validationResult.IsValid)
            {
                throw new BadRequestException(validationResult.Errors?.FirstOrDefault()?.ErrorMessage!);
            }
                

            var user = _mapper.MapToUser(dto);

            if (user == null)
            {
                throw new BadRequestException("Geçersiz Kullanıcı Oluşturma Talebi");
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, dto.Password);

            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
