using ContosoVet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoVet.Models
{
    public class Room : BaseModel
    {

        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }

    }
}
