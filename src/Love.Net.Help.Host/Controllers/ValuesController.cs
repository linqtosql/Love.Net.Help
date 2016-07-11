using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Love.Net.Help.Host
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public UserKind Post([FromBody]UserCreateModel user)
        {
            return UserKind.FromTest;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public enum UserKind {
        /// <summary>
        /// From API
        /// </summary>
        FromApi,
        /// <summary>
        /// From web
        /// </summary>
        FromWeb,
        /// <summary>
        /// From test
        /// </summary>
        FromTest,
    }

    public class UserCreateModel {
        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 类型.
        /// </summary>
        public UserKind UserKind { get; set; }
    }
}
