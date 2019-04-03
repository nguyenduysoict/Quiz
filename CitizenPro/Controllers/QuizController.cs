using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CitizenPro.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace CitizenPro.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {

        #region RESTful conventions methods

        /// <summary>
        /// GET api/quiz/{id}
        /// </summary>
        /// <param name="id"> The id with the existing quiz </param>
        /// <returns>Quiz with the given id </returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // Create a sample quiz to match the given request
            var quiz = new QuizViewModel()
            {
                Id = id,
                Title = String.Format("Sample quiz with id {0}", id),
                Description = "Fake quiz",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };

            // Output the fake result in Json Format

            return new JsonResult(
                quiz,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpPut]

        public IActionResult Put(AnswerViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Edit the Answer with the given {id}
        /// </summary>
        /// <param name="m">The AnswerViewModel containing the data to update</param>

        [HttpPost]

        public IActionResult Post(AnswerViewModel m)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Deletes the Answer with the given {id} from the Database
        /// </summary>
        /// <param name="id">The ID of an existing Answer</param>

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Attribute-based routing methods


        // GET api/quiz/latest/{num}
        [HttpGet("Latest/{num?}")]
        public IActionResult Latest(int num = 10)
        {
            var sampleQuizzes = new List<QuizViewModel>();
            // add a first sample quiz
            sampleQuizzes.Add(new QuizViewModel()
            {
                Id = 1,
                Title = "Which Shingeki No Kyojin character are you?",
                Description = "Anime-related personality test",
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            });
            // add a bunch of other sample quizzes
            for (int i = 2; i <= num; i++)
            {
                sampleQuizzes.Add(new QuizViewModel()
                {
                    Id = i,
                    Title = String.Format("Sample Quiz {0}", i),
                    Description = "This is a sample quiz",
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                });
            }
            // output the result in JSON format
            return new JsonResult(
                sampleQuizzes,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        #endregion

        /// <summary>
        /// GET: api/quiz/ByTitle
        /// Retrieves the {num} Quizzes sorted by Title
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>

        [HttpGet("byTitle/{num?}")]

        public IActionResult ByTitle (int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(sampleQuizzes.OrderBy(testc=> testc.Title),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }

        [HttpGet("random/{num?}")]

        public IActionResult Random (int num = 10)
        {
            var sampleQuizzes = ((JsonResult)Latest(num)).Value as List<QuizViewModel>;

            return new JsonResult(sampleQuizzes.OrderBy(t => Guid.NewGuid()),
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                });
        }
    }
}