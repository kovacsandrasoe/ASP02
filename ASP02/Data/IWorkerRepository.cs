using ASP02.Models;
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
        void Delete(int hashcode);
        WorkerModel GetWorkerByHash(int hashcode);
        void ModifyWorker(WorkerModel model, int oldhash);
    }
}
