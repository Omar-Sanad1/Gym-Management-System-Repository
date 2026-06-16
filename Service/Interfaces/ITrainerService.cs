using Core.DTOs;
using Core.Entities;
using Service.Models.TrainersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ITrainerService
    {
        public Task<IEnumerable<TrainerToReturnDTO>> GetAllTrainersAsync();
        public Task<IEnumerable<TrainerToReturnDTO>> GetAllTrainersPagedAsync(int pageNumber, int pageSize);
        public int GetTrainersCount();

        // Filtering
        public IEnumerable<TrainerToReturnDTO> GetAllTrainersFiltered(Func<Trainer, bool> Filter);
        public Task<TrainerToReturnDTO> GetTrainerByIDAsync(int trainerId);
        public Task<TrainerToReturnDTO> UpdateTrainerInformationAsync(int trainerId, UpdateTrainerInformationDTO updateTrainerInformation);
        public Task DeleteTrainerAsync(int trainerId);
    }
}
