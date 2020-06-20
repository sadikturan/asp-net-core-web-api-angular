using System;
using System.Collections.Generic;
using ServerApp.Models;

namespace ServerApp.DTO
{
    public class UserForListDTO
    {
        public int Id { get; set; }
      public string Name { get; set; }
      public string UserName { get; set; }
      public string Gender { get; set; }
      public int Age { get; set; }
      public DateTime Created { get; set; }
      public DateTime LastActive { get; set; }
      public string City { get; set; }
      public string Country { get; set; }
      public ImagesForDetails Image { get; set; }
    }
}