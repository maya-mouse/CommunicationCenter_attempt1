using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class CommunicationCenterRepository
        : BaseRepository<CommunicationCenter>, ICommunicationCenterRepository
    {
        internal CommunicationCenterRepository(CommunicationCenterContext context)
        : base(context)
        { }
    }
}

