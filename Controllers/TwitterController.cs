using Microsoft.AspNetCore.Mvc;
using Twitter_clone_backend.Data.Interfaces;
using Twitter_clone_backend.Models;
using Twitter_clone_backend.Models.DTO;

namespace Twitter_clone_backend.Controllers
{
    [Controller]
    [Route("api/twitter")]
    public class TwitterController : ControllerBase
    {
        private readonly IRepository _repository;

        public TwitterController(IRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<List<TweetDTO>>> GetAllTweets()
        {
            try
            {
                List<TweetDTO> tweets = await _repository.GetAllTweetsAsync();
                return Ok(tweets);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TweetDTO>> GetTweetById(int id)
        {
            try
            {
                TweetDTO tweet = await _repository.GetTweetByIdAsync(id);
                if (tweet == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(tweet);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> CreateReplyAsync(int id, [FromBody] Tweet Reply)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateReplyAsync(id, Reply);
                    return Ok(Reply);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTweetAsync([FromBody] Tweet tweet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _repository.CreateTweetAsync(tweet);
                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.Id }, tweet);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteTweet(int id)
        {
            try
            {
                bool deleteSuccessfull = await _repository.DeleteTweetAsync(id);

                if (!deleteSuccessfull)
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTweet(int id, [FromBody] Tweet tweet)
        {
            try
            {
                Tweet updateTweet = await _repository.UpdateTweetAsync(id, tweet);
                if(updateTweet == null)
                {
                    return NotFound();
                }
                else
                {
                    return CreatedAtAction(nameof(GetTweetById), new { id = tweet.Id }, tweet);
                }
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
