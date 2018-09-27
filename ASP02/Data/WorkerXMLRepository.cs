﻿using ASP02.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            XDocument xdoc = XDocument.Load(
                Directory.GetCurrentDirectory() +
                @"\wwwroot\workers.xml");

            foreach (var item in xdoc.Descendants("worker"))
            {
                WorkerModel model = new WorkerModel()
                {
                    Name = item.Element("Name").Value,
                    Job = item.Element("Job").Value,
                    Salary = int.Parse(item.Element("Salary").Value)
                };
                allWorker.Add(model);
            }
        }

        private void SaveRepository()
        {
            XDocument xdoc = new XDocument();
            xdoc.Add(new XElement("workers"));
            foreach (var item in allWorker)
            {
                XElement newelement = new XElement("worker");
                newelement.Add(new XElement("Name", item.Name));
                newelement.Add(new XElement("Job", item.Job));
                newelement.Add(new XElement("Salary", item.Salary));
                xdoc.Element("workers").Add(newelement);
            }
            xdoc.Save(Directory.GetCurrentDirectory() + 
                @"\wwwroot\workers.xml"
                );
        }

        public void Add(WorkerModel model)
        {
            allWorker.Add(model);
            this.SaveRepository();
        }

        public IEnumerable<WorkerModel> GetAll()
        {
            return allWorker;
        }

        public void Delete(int hashcode)
        {
            var q = from x in allWorker
                    where x.GetHashCode() == hashcode
                    select x;
            WorkerModel modelToDelete = q.FirstOrDefault();

            allWorker.Remove(modelToDelete);
            this.SaveRepository();
        }

        public WorkerModel GetWorkerByHash(int hashcode)
        {
            var q = from x in allWorker
                    where x.GetHashCode() == hashcode
                    select x;
            return q.FirstOrDefault();
        }

        public void ModifyWorker(WorkerModel model, int oldhash)
        {
            var q = from x in allWorker
                    where x.GetHashCode() == oldhash
                    select x;
            allWorker.Remove(q.FirstOrDefault());
            allWorker.Add(model);
            this.SaveRepository();
        }
    }
}
