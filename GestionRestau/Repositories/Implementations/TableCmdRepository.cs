using GestionRestau.Models;
using GestionRestau.Models.Context;
using GestionRestau.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionRestau.Repositories.Implementations
{
    public class TableCmdRepository : ITableCmdRepository
    {
        private readonly ApplicationDbContext _dbContext; //creer noveau object de la class Dependency injection 
        public TableCmdRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<TableCmd> GetAll()
        {
            var tableCmds = _dbContext.TableCmds.ToList();
            return tableCmds;
        }

        public void Insert(TableCmd tableCmd)
        {
            _dbContext.TableCmds.Add(tableCmd);
        }

        public TableCmd GetById(int Id)
        {
            return _dbContext.TableCmds.Find(Id);
        }

        public void Update(TableCmd tableCmd)
        {
            _dbContext.Entry(tableCmd).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void DelateById(int Id)
        {
            var tableCmdToDelate = _dbContext.TableCmds.Find(Id);
            _dbContext.TableCmds.Remove(tableCmdToDelate);
        }

        public void Save() //enregistrement fait dans le DBContext 
        {
            _dbContext.SaveChanges();
        }
    }
}
