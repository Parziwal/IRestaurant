using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRestaurant.DAL.DTO
{
    public class RoleDto
    {
        public string Name { get; }

        public RoleDto(string roleName)
        {
            this.Name = roleName;
        }
    }
}
