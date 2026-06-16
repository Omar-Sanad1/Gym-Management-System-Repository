using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.Interfaces;
using Service.Models.TrainersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TrainerService : ITrainerService
    {
        private readonly GymManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public TrainerService(GymManagementSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TrainerToReturnDTO>> GetAllTrainersAsync()
        {
            var trainers = await _dbContext.Trainers.ToListAsync();

            return _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerToReturnDTO>>(trainers);
        }

        public IEnumerable<TrainerToReturnDTO> GetAllTrainersFiltered(Func<Trainer, bool> Filter)
        {
            var trainersFiltered = _dbContext.Set<Trainer>()
            .Where(Filter)
            .ToList();

            return _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerToReturnDTO>>(trainersFiltered);

        }

        public async Task<IEnumerable<TrainerToReturnDTO>> GetAllTrainersPagedAsync(int pageNumber, int pageSize)
        {
            var trainersPaged = await _dbContext.Set<Trainer>()
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            return _mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerToReturnDTO>>(trainersPaged);

        }

        public async Task<TrainerToReturnDTO> GetTrainerByIDAsync(int trainerId)
        {
            var specifiedTrainer = await _dbContext.Trainers.FirstOrDefaultAsync(t => t.ID == trainerId);
            if (specifiedTrainer is null)
                throw new ValidationException("This trainer isn't exist.");

            return _mapper.Map<Trainer , TrainerToReturnDTO>(specifiedTrainer);
        }

        public int GetTrainersCount()
        {
            return _dbContext.Trainers.Count();
        }

        public async Task DeleteTrainerAsync(int trainerId)
        {
            var specifiedTrainer = await _dbContext.Trainers.FirstOrDefaultAsync(t => t.ID == trainerId);
            if (specifiedTrainer is null)
                throw new ValidationException("This trainer isn't exist.");

            _dbContext.Trainers.Remove(specifiedTrainer);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<TrainerToReturnDTO> UpdateTrainerInformationAsync(int trainerId, UpdateTrainerInformationDTO updateTrainerInformation)
        {
            var specifiedTrainer = await _dbContext.Trainers.FirstOrDefaultAsync(t => t.ID == trainerId);
            if (specifiedTrainer is null)
                throw new ValidationException("This trainer isn't exist.");

            var validEmploymentStatuses = new[] { "Active" , "Inactive" };
            if (!validEmploymentStatuses.Contains(updateTrainerInformation.EmploymentStatus))
                throw new ValidationException("This status isn't valid.Valid statuses (Active , Inactive)");

            specifiedTrainer.FullName = updateTrainerInformation.FullName;
            specifiedTrainer.Specialization = updateTrainerInformation.Specialization;
            specifiedTrainer.YearsOfExperience = updateTrainerInformation.YearsOfExperience;
            specifiedTrainer.PhoneNumber = updateTrainerInformation.PhoneNumber;
            specifiedTrainer.EmailAddress = updateTrainerInformation.EmailAddress;
            specifiedTrainer.Certifications = updateTrainerInformation.Certifications;
            specifiedTrainer.EmploymentDate = updateTrainerInformation.EmploymentDate;
            specifiedTrainer.SalaryInformation = updateTrainerInformation.SalaryInformation;
            specifiedTrainer.BranchID = updateTrainerInformation.BranchID;
            specifiedTrainer.EmploymentStatus = updateTrainerInformation.EmploymentStatus;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Trainer, TrainerToReturnDTO>(specifiedTrainer);
        }
    }
}
