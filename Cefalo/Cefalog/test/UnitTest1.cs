using System;
using Xunit;
using Cefalog.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

using static System.Console;

namespace Cefalog.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task TestJSON()
        {
            Story story;
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync("http://localhost:5001/api/json/");
                WriteLine($"response message: ==> {response.Content.ToString()}");

                string storyBody = await response.Content.ReadAsStringAsync();
                WriteLine(storyBody);

                JObject value = JObject.Parse(storyBody);

                story = new Story
                {
                    StoryID = value.GetValue("StoryID").Value<int>(),
                    AuthorID = value.GetValue("AuthorID").Value<string>(),
                    Title = value.GetValue("Title").Value<string>(),
                    Body = value.GetValue("Body").Value<string>(),
                    PostedOn = value.GetValue("PostedOn").Value<DateTime>()
                };

                WriteLine($"STORY\n{story.Title}\n{story.Body}");
                Assert.True(true);
            }
            catch (Exception e)
            {
                Assert.True(false);
                WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
