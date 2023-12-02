using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;

namespace BLL.Services.Impl
{
    public class CabinetService : ICabinetService
    {
            private readonly IUnitOfWork _database;
            private int pageSize = 10;
            public CabinetService(
            IUnitOfWork unitOfWork)
            {
                if (unitOfWork == null)
                {
                    throw new ArgumentNullException(nameof(unitOfWork));
                }
                _database = unitOfWork;
            }
 
            public IEnumerable<CabinetDTO> GetCabinets(int pageNumber)
            {
                var user = SecurityContext.GetUser();
                var userType = user.GetType();
                if (userType != typeof(Specialist)
                && userType != typeof(Controller))
                {
                    throw new MethodAccessException();
                }
                var CommunicationCenterID = user.communicationcenterID;
                var cabinetsEntities =
                _database
                 .Cabinets
                    .Find(z => z.communicationcenterID == CommunicationCenterID, pageNumber, pageSize);

                var mapper =
                new MapperConfiguration(cfg => cfg.CreateMap<Cabinet, CabinetDTO>()).CreateMapper();
                var cabinetDto =
                mapper
                .Map<IEnumerable<Cabinet>, List<CabinetDTO>>(
                cabinetsEntities);
                return cabinetDto;
            }
        }
    }

