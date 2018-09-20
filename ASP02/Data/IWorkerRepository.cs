﻿using ASP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP02.Data
{
    public interface IWorkerRepository
    {
        void Add(WorkerModel model);
        IEnumerable<WorkerModel> GetAll();
    }
}