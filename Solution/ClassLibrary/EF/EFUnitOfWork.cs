using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private CommunicationCenterContext db;
        private CommunicationCenterRepository communicationcenterRepository;
        private CabinetRepository cabinetRepository;
        public EFUnitOfWork(DbContextOptions options)
        {
            db = new CommunicationCenterContext();
        }
        public IRepository<CommunicationCenter> CommunicationCenters
        {
            get
            {
                if (communicationcenterRepository == null)
                    communicationcenterRepository = new CommunicationCenterRepository(db);
                return communicationcenterRepository;
            }
        }
        public IRepository<Cabinet> Cabinets
        {
            get
            {
                if (cabinetRepository == null)
                    cabinetRepository = new CabinetRepository(db);
                return cabinetRepository;
            }
        }

        ICommunicationCenterRepository IUnitOfWork.CommunicationCenters => throw new NotImplementedException();

        ICabinetRepository IUnitOfWork.Cabinets => throw new NotImplementedException();

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
