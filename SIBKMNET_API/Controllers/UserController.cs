﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIBKMNET_API.Context;
using SIBKMNET_API.Models;
using SIBKMNET_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MyContext myContext;

        public UserController(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //get
        [HttpGet]
        public ActionResult Get()
        {
            myContext.Users.ToList();
            //var data = myContext.Users.ToList();
            return Ok(new { status = 200, message = "data has been obtained" });
        }

        //get by id
        [HttpGet("id")]
        public ActionResult Get(int id)
        {
            myContext.Users.ToList();
            return Ok(new {status = 200, message = "data by id has been obtained" });
        }

        //post (insert) -> masih fail, cara mappingnya gmn ya
        [HttpPost]
        public ActionResult Post(ViewModels.UserVM userVM)
        {
            User user = new User(userVM);
            var data = myContext.Users.Add(user);
            var result = myContext.SaveChanges();
            if (result > 0)
                return Ok(new { status = 200, message = "data has been successfully inserted" });
            return BadRequest(new { status = 400, message = "insert data failed" });

        }
        //put (update)
        //delete
    }
}
