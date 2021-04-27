using GestionRestau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Interfaces
{
    interface ITableCmdRepository
    {
        public ICollection<TableCmd> GetAll();
        public void Insert(TableCmd tableCmd);
        public TableCmd GetById(int Id);
        public void Update(TableCmd tableCmd);
        public void DelateById(int Id);
        public void Save();
    }
}
