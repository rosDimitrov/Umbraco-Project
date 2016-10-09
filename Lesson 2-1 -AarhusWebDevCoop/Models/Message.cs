using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson_2_1__AarhusWebDevCoop.Models
{
    public class Message
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserMessage { get; set; }
    }
}