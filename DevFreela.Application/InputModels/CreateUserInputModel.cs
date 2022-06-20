﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public string FullName { get; private set; }
        public string Password { get; set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Role { get; private set; }
    }
}
