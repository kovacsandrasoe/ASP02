using ASP02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ASP02.Data
{
    public class WorkerXMLRepository : IWorkerRepository
    {
        List<WorkerModel> allWorker;
        public WorkerXMLRepository()
        {
            this.allWorker = new List<WorkerModel>();
            //XDocument xdoc = 
        }

        public void Add(WorkerModel model)
        {
            allWorker.Add(model);
        }

        public IEnumerable<WorkerModel> GetAll()
        {
            return allWorker;
        }
    }
}
