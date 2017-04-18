using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Microsoft;

namespace Service
{
    public class EmployeeStatusHistoryExtendService: GenericService<Model.EmployeeStatusHistoryExtend, int>
    {
        public override void Update(EmployeeStatusHistoryExtend entity)
        {
            EmployeeStatusHistory empHistory = new EmployeeStatusHistory()
            {

                EmployeeStatusID = entity.EmployeeStatusID,
                EmployeeID = entity.EmployeeID,

                ModifiedBy = entity.ModifiedBy,
                ModifiedDate = DateTime.Now,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                StatusNote = entity.StatusNote,
                NewStatusID = entity.NewStatusID,
            };

            EmployeeStatusHistoryService serviceHistory = new EmployeeStatusHistoryService();
            serviceHistory.Update(empHistory);
            serviceHistory.SaveChanges();


            EmployeeStatusHistory empHistoryNew = new EmployeeStatusHistory()
            {
                
                CreatedBy = entity.CreatedBy,
                CreatedDate = DateTime.Now,
                ModifiedBy = entity.ModifiedBy,
                ModifiedDate = DateTime.Now,

                EmployeeID = entity.EmployeeID,
                NewStatusID = entity.Status_New, // Change this status id to after rename in database
                EndDate = entity.EndDate_New,
                StartDate = entity.StartDate_New,
                StatusNote = entity.StatusNote_New
            };
            serviceHistory.Create(empHistoryNew);
            serviceHistory.SaveChanges();
        }

        public override int SaveChangesReturnId(EmployeeStatusHistoryExtend entity)
        {
            return base.SaveChangesReturnId(entity);
        }





    }
}
