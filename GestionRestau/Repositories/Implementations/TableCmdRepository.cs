using GestionRestau.Models;
using GestionRestau.Models.Context;
using GestionRestau.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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


        public ICollection<TableCmd> GetAllWithServers()
        {
            var tableCmds = _dbContext.TableCmds.Include(tbl => tbl.Serveur)
                //.Where(tbl=>tbl.Serveur.Id==2)// where dans le inner join 
                .ToList(); //Join the Id servers the table server 
            return tableCmds;
        }

        public void Insert(TableCmd tableCmd)
        {
            _dbContext.TableCmds.Add(tableCmd);
        }

        public TableCmd GetById(int Id)
        {

            var serveur = _dbContext.TableCmds.Find(Id);
            _dbContext.Entry(serveur).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return serveur; 
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


        public TableCmd GetByIdWithServeur(int Id)
        {
            return _dbContext.TableCmds.Include(tbl => tbl.Serveur)
                 .FirstOrDefault(tbl => tbl.Id == Id); 
        }

        public void Save() //enregistrement fait dans le DBContext 
        {
            _dbContext.SaveChanges();
        }

      
    }
}
