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
    public class AttendenceRecordController : ControllerBase
    {
        private readonly IGenericRepository<AttendenceRecord> _repo;
        private readonly IMapper _mapper;
        public AttendenceRecordController(IGenericRepository<AttendenceRecord> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAllPagedFiltered")]
        public IActionResult GetAllPagedFiltered([FromQuery]AttendenceRecordFiltering attendenceRecordFiltering, [FromQuery] PaginationParameters paginationParameters)
        {
            var attendenceRecords = _repo.GetAllFiltered(a =>
            // فلترة ب Category
            (string.IsNullOrEmpty(attendenceRecordFiltering.Category) || ((AttendenceRecord)(object)a).Category==attendenceRecordFiltering.Category)&&
            // فلترة ب AttendanceType
            (string.IsNullOrEmpty(attendenceRecordFiltering.AttendanceType) || ((AttendenceRecord)(object)a).AttendanceType == attendenceRecordFiltering.AttendanceType) &&
             // فلترة ب FitnessClassID
            (!attendenceRecordFiltering.FitnessClassID.HasValue || ((AttendenceRecord)(object)a).FitnessClassID == attendenceRecordFiltering.FitnessClassID)&&
            // فلترة ب MemberID
            (!attendenceRecordFiltering.MemberID.HasValue || ((AttendenceRecord)(object)a).MemberID == attendenceRecordFiltering.MemberID)
            );

            var totalAttendenceRecords = _repo.GetCount();
            var attendenceRecordsPaged = _repo.GetAllPaged(paginationParameters.PageNumber, paginationParameters.PageSize);
            var result = new PaginationResponse<AttendenceRecordToReturnDTO>
                (
                    data:_mapper.Map<IEnumerable<AttendenceRecord> , IEnumerable<AttendenceRecordToReturnDTO>>(attendenceRecords),
                    totalItems:totalAttendenceRecords,
                    pageNumber:paginationParameters.PageNumber,
                    pageSize:paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetByID(int id)
        {
            var attendenceRecord = _repo.GetByID(id);
            return Ok(attendenceRecord);
        }

        [HttpPost("add")]
        public void Add(AttendenceRecord record)
        {
            _repo.Add(record);
        }

        [HttpPut("update")]
        public void Update(AttendenceRecord record)
        {
            _repo.Update(record);
        }

        [HttpDelete("delete")]
        public void Delete(AttendenceRecord record)
        {
            _repo.Delete(record);
        }
    }
}
