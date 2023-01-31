using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserResponseModel
    {
		public string? Id { get; set; }
		public string? AccessToken { get; set; }
		public string? Email { get; set; }
		public List<string>? Role { get; set; }
		public string? TokenType { get; set; }
		public string[]? Errors { get; set; }

	}
}
