using AutoMapper;
using EducationalMaterialData.Dtos.AuthorDtos;
using EducationalMaterialData.Dtos.ReviewDtos;
using EducationalMaterialData.Models;
using EducationalMaterialData.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace EducationalMaterial.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewController(ILogger<AuthorController> logger, IUnitOfWork context, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = context;
            _mapper = mapper;
        }

        
        /// <summary>
        /// GET api/review
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetReview()
        {
            var review = await _unitOfWork.Review.GetAll();
            if (review != null)
            {
                _logger.LogInformation("GET api/review => OK");
            }
            else
            {
                _logger.LogInformation("GET api/review => NOT OK");
                return NotFound();
            }

            var result = _mapper.Map<IEnumerable<ReviewReadDto>> (review);

            return Ok(result);

        }

        /// <summary>
        /// GET api/review/{reviewId}
        /// </summary>
        /// <param name="directorId"></param>
        /// <returns></returns>
        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetReviewById(int reviewId)
        {
            var Review = await _unitOfWork.Review.GetById(reviewId);
            if (Review != null)
            {
                _logger.LogInformation("GET api/review => OK");
            }
            else
            {
                _logger.LogInformation("GET api/review => NOT OK");
                return NotFound();
            }
            var result = _mapper.Map<ReviewReadDto>(Review);
            return Ok(result);
        }



        /// <summary>
        /// POST api/review
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewCreateDto reviewCreateDto)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("POST api/review => OK");
                var review = _mapper.Map<Review>(reviewCreateDto);
                await _unitOfWork.Review.Create(review);
                await _unitOfWork.Save();
                return Ok();
            }
            else
            {
                _logger.LogInformation("POST api/review => NOT OK");
                return NotFound();
            }
        }

        /// <summary>
        /// POST api/review/{reviewId}
        /// </summary>
        /// <returns></returns>
        [HttpPut("{authorId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, ReviewUpdateDto reviewUpdateDto)
        {
            var review = await _unitOfWork.Review.GetById(reviewId);
            if (review != null)
            {
                var result = _mapper.Map(reviewUpdateDto, review);
                await _unitOfWork.Review.Update(review);
                await _unitOfWork.Save();
                _logger.LogInformation("PUT api/review/{reviewId} => OK", reviewId);
                return Ok();
            }
            else
            {
                _logger.LogInformation("PUT api/review/{reviewId} => NOT OK", review);
                return NoContent();
            }
        }

        /// <summary>
        /// DELETE api/review/{reviewId}
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var review = await _unitOfWork.Review.GetById(reviewId);
            if (review == null)
            {
                _logger.LogInformation("DELETE api/review/{reviewId} => NOT OK", reviewId);
                return NotFound();
            }
            await _unitOfWork.Review.Delete(review);
            await _unitOfWork.Save();

            _logger.LogInformation("DELETE api/review/{reviewId} => OK", reviewId);
            return NoContent();
        }
        
    }
}

