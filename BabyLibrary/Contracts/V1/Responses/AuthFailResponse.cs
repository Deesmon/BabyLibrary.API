using System;
using System.Collections.Generic;

namespace BabyLibrary.Contracts.V1.Responses
{
    /// <summary>
    /// Registration response
    /// Will add e-mail verification, meanwhile for simplicity we return a token.
    /// </summary>
    public class AuthFailedResponse
    {
        /// <summary>
        /// Token
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
