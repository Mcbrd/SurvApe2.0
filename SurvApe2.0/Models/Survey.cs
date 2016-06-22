using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SurvApe2._0.Models
{
    public class Survey
    {
       
            public Survey()
            {
                Questions = new List<Question>();
                Responses = new List<Response>();
            }

            public int Id { get; set; }

            public string Name { get; set; }

            public List<Question> Questions { get; set; }

            public List<Response> Responses { get; set; }          

            public string ToJson()
            {
                var js = JsonSerializer.Create(new JsonSerializerSettings());
                var jw = new StringWriter();
                js.Serialize(jw, this);
                return jw.ToString();
            }
        }
    }

