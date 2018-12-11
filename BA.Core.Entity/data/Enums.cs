
namespace BA.Core.Entity.data
{
    public enum ItemRequestStatus
    {
        PENDING = 1,
        UNDER_PROCESS = 2,
        APPROVED = 3,
        PARTIALY_APPROVED = 4,
        NO_NEED_APPROVAL = 5,
        REJECTED = 6,
        CANCELLED =7
    }


    public enum RequestStatus
    {
        FOR_APPROVAL= 1,
        UNDER_PROCESS = 2,
        DONE = 3,

    }


    public enum PatientType
    {
        IN_PATIENT = 1,
        OUT_PATIENT = 2
    }


    public enum RequestTyype
    {
        ADMISSION = 1,
        PRE_ADMISSION = 2,
        CONSULTATION = 3
    }
}
