using DAL.EF;
using DAL.Entities;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using (CommunicationCenterContext db = new CommunicationCenterContext())
            {
                db.Add(new Cabinet() {CabinetID = 1 } );
                db.Add(new Cabinet() { CabinetID = 2 });
                db.Add(new Cabinet() { CabinetID = 3 });
                db.SaveChanges();
                List<Cabinet> cabinets = db.Cabinets.ToList();
                foreach (Cabinet c in cabinets)
                {
                    Console.WriteLine(c.CabinetID);
                }

            }
        }
    }
}