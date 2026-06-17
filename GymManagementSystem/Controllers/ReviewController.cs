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
    public class ReviewController : ControllerBase
    {
        private readonly IGenericRepository<Review> _repo;
        private readonly IMapper _mapper;
        public ReviewController(IGenericRepository<Review> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAllPagedFiltered")]
        public IActionResult GetAllPagedFiltered([FromQuery] ReviewFiltering reviewFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            // Filtering

            var reviews = _repo.GetAllFiltered(r =>
            // فلترة ب ReviewDate
            (!reviewFiltering.ReviewDate.HasValue || ((Review)(object)r).ReviewDate == reviewFiltering.ReviewDate)&&
            // فلترة ب FitnessClassID
            (!reviewFiltering.FitnessClassID.HasValue || ((Review)(object)r).FitnessClassID == reviewFiltering.FitnessClassID) &&
            // فلترة ب TrainerID
            (!reviewFiltering.TrainerID.HasValue || ((Review)(object)r).TrainerID == reviewFiltering.TrainerID) &&
            // فلترة ب MemberID
            (!reviewFiltering.MemberID.HasValue || ((Review)(object)r).MemberID == reviewFiltering.MemberID) 
            );

            // Sorting

            reviews = reviewFiltering.SortBy?.ToLower() switch
            {
                "reviewdate" => reviewFiltering.isDescending
                ? reviews.OrderByDescending(r=>r.ReviewDate)
                : reviews.OrderBy(r=>r.ReviewDate),

                "rating" => reviewFiltering.isDescending
                ? reviews.OrderByDescending(r=>r.Rating)
                : reviews.OrderBy(r=>r.Rating),

                _ => reviews.OrderBy(r=>r.ID)
            };


            // Pagination

            var totalreviews = _repo.GetCount();
            var reviewsPaged = _repo.GetAllPaged(paginationParameters.PageNumber, paginationParameters.PageSize);

            var result = new PaginationResponse<ReviewToReturnDTO>
                (
                    data: _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewToReturnDTO>>(reviews),
                    totalItems: totalreviews,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var review = _repo.GetByID(id);
            return Ok(review);
        }

        [HttpPost("add")]
        public void Add(Review review)
        {
            _repo.Add(review);
        }

        [HttpPut("update")]
        public void Update(Review review)
        {
            _repo.Update(review);
        }

        [HttpDelete("delete")]
        public void Delete(Review review)
        {
            _repo.Delete(review);
        }
    }
}
