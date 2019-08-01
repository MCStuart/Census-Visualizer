using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;  

// From mySQL to React!
namespace StateMigration.Models
{
    public class MoveStateAccessLayer
    {
        myTestDBContext db = new myTestDBContext();

        public IEnumerable<ExecutionStrategyExtensions> GetAllMoveStates()
        {
            try
            {
                return db.MoveState.ToList();
            }
            catch
            {
                throw;
            }
        }
        // Add new MoveState to record
        public int AddMoveState(MoveState moveState)
        {
            try
            {
                db.MoveState.Add(moveState);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Update records of particular moves
        public int UpdateMoveState(MoveState moveState)
        {
            try
            {
                db.Entry(moveState).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get details of a particular move 
        public MoveState GetMoveData(int id)  
        {  
            try  
            {  
                MoveState moveState = db.MoveState.Find(id);  
                return moveState;  
            }  
            catch  
            {  
                throw;  
            }  
        }  

        //Delete record of particular move 
        public int DeleteMoveState(int id)  
        {  
            try  
            {  
                MoveState moveState = db.MoveState.Find(id);  
                db.MoveState.Remove(moveState);  
                db.SaveChanges();  
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  

        //Get the list of State-to-State Moves. Be Careful with this one. It has 2450 unique data points on init
        public List<States> GetStates()  
        {  
            List<States> listState = new List<States>();  
            listState = (from listState in db.States select listState).ToList();  
            return listState;  
        }  
    }  
}