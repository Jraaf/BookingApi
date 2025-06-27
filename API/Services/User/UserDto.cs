using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.User;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
