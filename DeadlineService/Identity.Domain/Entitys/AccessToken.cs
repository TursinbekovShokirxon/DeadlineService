using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entitys
{
	public class AccessToken
	{
		public int Id { get; set; }
		public DateTime ExpiresTime { get; set; }
		public string Value { get; set; }
		public int UserId { get; set; }
	}
}
