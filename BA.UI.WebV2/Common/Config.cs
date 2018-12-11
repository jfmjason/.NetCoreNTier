using BA.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.UI.WebV2.Common
{
    public static class Config
    {
        public static List<PatientType> GetPatientTypeSeed()
        {

            return new List<PatientType>() {
                new PatientType(){
                    Name ="In-Paient", Active = true, Code ="IP", CreatedDate =DateTime.Now, CreatedById = 1
                }, 
                new PatientType(){
                    Name ="Out-Paient", Active = true, Code ="OP", CreatedDate =DateTime.Now, CreatedById = 1
                }
            };
        }

        public static List<ApprovalRequestItemStatus> GetApprovalRequestItemStatusSeed()
        {
            return new List<ApprovalRequestItemStatus>() {
                new ApprovalRequestItemStatus(){
                    Name ="PENDING", Active = true, Code ="PEN", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="UNDER PROCESS", Active = true, Code ="UP", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="APPROVED", Active = true, Code ="AP", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="PARTIALY APPROVED", Active = true, Code ="PA", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="NO NEED APPROVAL", Active = true, Code ="NNA", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="REJECTED", Active = true, Code ="REJ", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestItemStatus(){
                    Name ="CANCELLED", Active = true, Code ="CAN", CreatedDate =DateTime.Now, CreatedById = 1
                }
            };
        }

        public static List<ApprovalRequestStatus> GetApprovalRequestStatusSeed()
        {
            return new List<ApprovalRequestStatus>() {
                new ApprovalRequestStatus(){
                    Name ="FOR APPROVAL", Active = true, Code ="FA", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestStatus(){
                    Name ="UNDER PROCESS", Active = true, Code ="UP", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestStatus(){
                    Name ="DONE", Active = true, Code ="DN", CreatedDate =DateTime.Now, CreatedById = 1
                }
            };
        }

        public static List<ApprovalRequestType> GetApprovalRequestTypeSeed()
        {
            return new List<ApprovalRequestType>() {
                new ApprovalRequestType(){
                    Name ="Admission", Active = true, Code ="AD", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestType(){
                    Name ="Pre-admission", Active = true, Code ="PRE", CreatedDate =DateTime.Now, CreatedById = 1
                },
                new ApprovalRequestType(){
                    Name ="Consultation", Active = true, Code ="CO", CreatedDate =DateTime.Now, CreatedById = 1
                }
            };
        }

    }
}
