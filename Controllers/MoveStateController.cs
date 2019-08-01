using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using StateMigration.Models;  

namespace StateMigration.Controllers
{  
    public class MoveStateController : Controller  
    {  
        MoveStateAccessLayer objMoveState = new MoveStateAccessLayer();  
        [HttpGet]  
        [Route("api/MoveState/Index")]  
        public IEnumerable<MoveState> Index()  
        {  
            return objMoveState.GetAllMoveState();  
        }  
        [HttpPost]  
        [Route("api/MoveState/Create")]  
        public int Create(MoveState moveState)  
        {  
            return objMoveState.AddMoveState(moveState);  
        }  
        [HttpGet]  
        [Route("api/MoveState/Details/{id}")]  
        public MoveState Details(int id)  
        {  
            return objMoveState.GetMoveState(id);  
        }  
        [HttpPut]  
        [Route("api/MoveState/Edit")]  
        public int Edit(MoveState moveState)  
        {  
            return objMoveState.UpdateMoveState(moveState);  
        }  
        [HttpDelete]  
        [Route("api/MoveState/Delete/{id}")]  
        public int Delete(int id)  
        {  
            return objMoveState.DeleteMoveState(id);  
        }  
        [HttpGet]  
        [Route("api/MoveState/GetCityList")]  
        public IEnumerable<States> Details()  
        {  
            return objMoveState.GetStates();  
        }  
    }  
}