﻿using SaveDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDomain.Commands
{
    public interface IUpdateSaveCommand
    {
        Task Execute(Save save);
    }
}
