using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models.TrainersModels;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;
        public TrainerController(ITrainerService trainerService)
        { 
            _trainerService = trainerService;
        }

        [HttpGet("GetAllTrainersPagedFiltered")]
        public async Task<IActionResult> GetAllTrainersPagedFiltered([FromQuery] TrainerFiltering trainerFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            // Filtering

            var trainers = _trainerService.GetAllTrainersFiltered(t =>
            (
            // فلترة ب FullName
            (string.IsNullOrEmpty(trainerFiltering.FullName) || ((Trainer)(object)t).FullName == trainerFiltering.FullName) &&
            // فلترة ب BranchID
            (!trainerFiltering.BranchID.HasValue) || ((Trainer)(object)t).BranchID == trainerFiltering.BranchID) &&
            // فلترة ب EmailAddress
            (string.IsNullOrEmpty(trainerFiltering.EmailAddress) || ((Trainer)(object)t).EmailAddress == trainerFiltering.EmailAddress)
            );

            // Sorting

            trainers = trainerFiltering.SortBy?.ToLower() switch
            {
                "fullname" => trainerFiltering.isDescending
                ? trainers.OrderByDescending(t=>t.FullName)
                : trainers.OrderBy(t=>t.FullName),

                "yearsoexperience" => trainerFiltering.isDescending
                ? trainers.OrderByDescending(t=>t.YearsOfExperience)
                : trainers.OrderBy(t=>t.YearsOfExperience),

                _ => trainers.OrderBy(t=>t.ID)
            };

            // Pagination

            var totalTrainers = _trainerService.GetTrainersCount();
            var trainersPaged = await _trainerService.GetAllTrainersPagedAsync(paginationParameters.PageNumber, paginationParameters.PageSize);


            var result = new PaginationResponse<TrainerToReturnDTO>
                (
                    data: trainers,
                    totalItems: totalTrainers,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("GetTrainerByID")]
        public async Task<IActionResult> GetTrainerByIDAsync(int id)
        {
            var trainer = await _trainerService.GetTrainerByIDAsync(id);
            return Ok(trainer);
        }


        [HttpPut("UpdateTrainerInformation")]
        public async Task<IActionResult> UpdateTrainerInformationAsync(int trainerId , UpdateTrainerInformationDTO updateTrainerInformation)
        {
            var updatedTrainer = await _trainerService.UpdateTrainerInformationAsync(trainerId, updateTrainerInformation);
            return Ok(updatedTrainer);
        }

        [HttpDelete("DeleteTrainer")]
        public async Task DeleteTrainerAsync(int trainerId)
        {
            await _trainerService.DeleteTrainerAsync(trainerId);
        }
    }
}
