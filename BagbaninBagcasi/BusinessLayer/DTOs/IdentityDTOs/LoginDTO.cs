﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.IdentityDTOs;

public class LoginDTO
{
    public string EmailorUsername { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }

}
