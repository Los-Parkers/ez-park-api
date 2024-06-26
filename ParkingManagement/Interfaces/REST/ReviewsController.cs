﻿using ez_park_platform.ParkingManagement.Domain.Model.Entities;
using ez_park_platform.ParkingManagement.Domain.Model.Querys;
using ez_park_platform.ParkingManagement.Domain.Services;
using ez_park_platform.ParkingManagement.Interfaces.REST.Resources;
using ez_park_platform.ParkingManagement.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using ez_park_platform.ParkingManagement.Domain.Repositories;

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
        
        [HttpGet]
        public async Task<ActionResult> GetAllReviews()
        {
            IEnumerable<Review> reviews = await reviewQueryService.Handle(new GetAllReviewsQuery());
            IEnumerable<ReviewResource> reviewResource =
                reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(reviewResource);
        }
        
        [HttpGet("userid/{userId}")]
        public async Task<ActionResult> GetReviewByUserId(int userId)
        {
            try
            {
                List<Review> reviews = await reviewQueryService.Handle(new GetReviewsByUserIdQuery(userId));
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound($"No reviews found for user ID {userId}");
                }

                List<ReviewResource> reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity).ToList();
                return Ok(reviewResources);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("parkingid/{parkingId}")]
        public async Task<ActionResult> GetReviewByParkingId(int parkingId)
        {
            try
            {
                List<Review> reviews = await reviewQueryService.Handle(new GetReviewsByParkingIdQuery(parkingId));
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound($"No reviews found for parking ID {parkingId}");
                }

                List<ReviewResource> reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity).ToList();
                return Ok(reviewResources);
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