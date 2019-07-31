using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace StateMigration.Models
{
    public class StateMove
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StateToID { get; set; }
        public int StateFromID { get; set; }
        public int MoveNumber { get; set; }

        public State State { get; set; }
    }
}