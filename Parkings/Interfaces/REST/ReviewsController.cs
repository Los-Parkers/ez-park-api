using ez_park_platform.Parkings.Domain.Model.Aggregates;
using ez_park_platform.Parkings.Domain.Model.Querys;
using ez_park_platform.Parkings.Domain.Services;
using ez_park_platform.Parkings.Interfaces.REST.Resources;
using ez_park_platform.Parkings.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ez_park_platform.Parkings.Domain.Repositories;

namespace ez_park_platform.Parkings.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ReviewsController(
        IReviewCommandService reviewCommandService,
        IReviewQueryService reviewQueryService)
        : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateReview([FromBody] CreateReviewResource resource)
        {
            try
            {
                var command = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(resource);
                Review? review = await reviewCommandService.Handle(command);
                if (review is null)
                {
                    return BadRequest("Failed to create review.");
                }

                ReviewResource reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, reviewResource);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetReviewById(int id)
        {
            Review? review = await reviewQueryService.Handle(new GetReviewByIdQuery(id));
            if (review is null) return NotFound();

            ReviewResource reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
            return Ok(reviewResource);
        }
    }
}