using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Healthcare.Core.DTOs.Auth;
using Healthcare.Infrastructure.Data;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Security.JWT;
using Healthcare.Services.Interfaces;
using Healthcare.Core.Common;
using Healthcare.Core.Enums;
using Healthcare.Core.Exceptions;

namespace Healthcare.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly JwtService _jwtService;
        private readonly HealthcareDbContext _context;

        public AuthService(IGenericRepository<User> userRepo, IGenericRepository<Patient> patientRepo, JwtService jwtService, HealthcareDbContext context)
        {
            _userRepo = userRepo;
            _patientRepo = patientRepo;
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<int> RegisterAsync(RegisterDTO dto)
        {
            if (dto == null || dto.Name == null || dto.Email == null)
                throw new BadRequestException("Invalid data");


            using var transaction = await _context.Database.BeginTransactionAsync();

                var existingUser = await _userRepo.FirstOrDefaultAsync(u => u.Email!.ToLower() == dto.Email.ToLower());



                if (existingUser != null)
                    throw new ConflictException("Email already exists");




                var user = new User
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                    RoleId = (int)UserRole.Patient,
                    CreatedDate = DateTime.UtcNow,
                };
                await _userRepo.AddAsync(user);
                await _userRepo.SaveAsync();
                Console.WriteLine(user.UserId);

            var patient = new Patient
                {
                    UserId = user.UserId,  // 🔥 KEY POINT
                    Name = dto.Name,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Phone = dto.Phone,
                    Address = dto.Address
                };
                await _patientRepo.AddAsync(patient);
                await _patientRepo.SaveAsync();


                await transaction.CommitAsync();


                return user.UserId;
           
        }
  
        public async Task<LoginResponseDTO> LoginAsync(LoginDTO dto)
        {
            if (dto == null)
                throw new BadRequestException("Invalid login data");


            var email = dto.Email.Trim().ToLower();


            var user = await _context.Users
                      .AsNoTracking()
                      .Include(x => x.Role)
                      .FirstOrDefaultAsync(x => x.Email.ToLower() == email);

            if (user == null)
                throw new UnauthorizedException("Invalid email");


            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            
            if (!isValid)
                throw new UnauthorizedException("Invalid credentials");




            var token = _jwtService.GenerateToken(user);
            return new LoginResponseDTO
            {
                Token = token,
                Role = user.Role?.RoleName,
                UserId = user.UserId
            };
        }

      
    }
}
