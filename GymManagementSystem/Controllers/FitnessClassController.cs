using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessClassController : ControllerBase
    {
        private readonly IGenericRepository<FitnessClass> _repo;
        private readonly IMapper _mapper;
        public FitnessClassController(IGenericRepository<FitnessClass> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAllPagedFiltered")]
        public IActionResult GetAllPagedFiltered([FromQuery] FitnessClassFiltering fitnessClassFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            var fitnessClasses = _repo.GetAllFiltered(f =>
            // فلترة ب ClassName
            (string.IsNullOrEmpty(fitnessClassFiltering.ClassName) || ((FitnessClass)(object)f).ClassName == fitnessClassFiltering.ClassName)&&
            // فلترة ب Category
            (string.IsNullOrEmpty(fitnessClassFiltering.Category) || ((FitnessClass)(object)f).Category == fitnessClassFiltering.Category) &&
            // فلترة ب AssignedTrainer
            (string.IsNullOrEmpty(fitnessClassFiltering.AssignedTrainer) || ((FitnessClass)(object)f).AssignedTrainer == fitnessClassFiltering.AssignedTrainer) &&
            // فلترة ب BranchID
            (!fitnessClassFiltering.BranchID.HasValue || ((FitnessClass)(object)f).BranchID == fitnessClassFiltering.BranchID)
            );

            var totalFitnessClasses = _repo.GetCount();
            var fitnessClassesPaged = _repo.GetAllPaged(paginationParameters.PageNumber, paginationParameters.PageSize);
            var result = new PaginationResponse<FitnessClassToReturnDTO>
                (
                    data: _mapper.Map<IEnumerable<FitnessClass>, IEnumerable<FitnessClassToReturnDTO>>(fitnessClasses),
                    totalItems: totalFitnessClasses,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var fitnessClass = _repo.GetByID(id);
            return Ok(fitnessClass);
        }

        [HttpPost("add")]
        public void Add(FitnessClass fitnessClass)
        {
            _repo.Add(fitnessClass);
        }

        [HttpPut("update")]
        public void Update(FitnessClass fitnessClass)
        {
            _repo.Update(fitnessClass);
        }

        [HttpDelete("delete")]
        public void Delete(FitnessClass fitnessClass)
        {
            _repo.Delete(fitnessClass);
        }
    }
}
