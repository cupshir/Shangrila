using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShangriLa.Models
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool IsComplete { get; set; }
        public List<GamePlayer> GamePlayers { get; set; }
    }
}