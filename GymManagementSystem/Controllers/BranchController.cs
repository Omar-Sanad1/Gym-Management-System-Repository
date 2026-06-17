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
    public class BranchController : ControllerBase
    {
        private readonly IGenericRepository<Branch> _repo;
        private readonly IMapper _mapper;
        public BranchController(IGenericRepository<Branch> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAllPagedFiltered")]
        public IActionResult GetAllPagedFiltered([FromQuery]BranchFiltering branchFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            // Filtering

            var branches = _repo.GetAllFiltered(b =>
            // فلترة ب BranchName
            (string.IsNullOrEmpty(branchFiltering.BranchName) || ((Branch)(object)b).BranchName == branchFiltering.BranchName)&&
            // فلترة ب Location
            (string.IsNullOrEmpty(branchFiltering.Location) || ((Branch)(object)b).Location == branchFiltering.Location)
            );

            // Sorting

            branches = branchFiltering.SortBy?.ToLower() switch
            {
                "branchname" => branchFiltering.isDescending
                ? branches.OrderByDescending(b=>b.BranchName)
                : branches.OrderBy(b=>b.BranchName),

                "operatinghours" => branchFiltering.isDescending
                ? branches.OrderByDescending(b=>b.OperatingHours)
                : branches.OrderBy(b=>b.OperatingHours),

                _ => branches.OrderBy(b=>b.ID)
            };

            // Pagination

            var totalBranches = _repo.GetCount();
            var branchesPaged = _repo.GetAllPaged(paginationParameters.PageNumber, paginationParameters.PageSize);

            var result = new PaginationResponse<BranchToReturnDTO>
                (
                    data: _mapper.Map<IEnumerable<Branch>, IEnumerable<BranchToReturnDTO>>(branches),
                    totalItems: totalBranches,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var branch = _repo.GetByID(id);
            return Ok(branch);
        }

        [HttpPost("add")]
        public void Add(Branch branch)
        {
            _repo.Add(branch);
        }

        [HttpPut("update")]
        public void Update(Branch branch)
        {
            _repo.Update(branch);
        }

        [HttpDelete("delete")]
        public void Delete(Branch branch)
        {
            _repo.Delete(branch);
        }
    }
}
