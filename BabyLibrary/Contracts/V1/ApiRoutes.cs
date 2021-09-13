using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLibrary.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Books
        {
            public const string GetAll = Base + "/books";
            public const string Create = Base + "/books";
            public const string Get = Base + "/books/{bookId}";
            public const string Update = Base + "/books/{bookId}";
            public const string Delete = Base + "/books/{bookId}";
        }

        public static class Identity
        {
            //Not realy RESTFull
            public const string Login = Base + "/login";
            public const string Register = Base + "/register";
        }
    }
}
