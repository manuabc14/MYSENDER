using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MYSENDER.Helpers
{
    public class ContextSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ContextSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set(string key,string value)
        {
            _session.SetString(key, value);
        }

        public string Get(string key)
        {
            var message = _session.GetString(key);
            return message;
        }
    }
}
