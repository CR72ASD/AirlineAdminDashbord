﻿using System.Collections.Generic;

namespace AirLine.APIs.Erorrs
{
	public class ApiValidationErrorResponse : ApiResponse
	{
		public IEnumerable<string> Errors { get; set; }
		public ApiValidationErrorResponse() : base(400)
		{

		}
	}
}
