using System.ComponentModel;

namespace SwaggerAPI.Helper
{
    public enum AppErrorType
    {
        [Description("Success")]
        [Category("200")]
        Success,

        [Description("Invalid Input Data Format")]
        [Category("400")]
        InvalidInputDataFormat,

        [Description("Duplicate Data")]
        [Category("409")]
        DuplicateData,

        [Description("Time Out")]
        [Category("408")]
        TimeOut,

        [Description("User Blocked")]
        [Category("403")]
        UserBlocked,

        [Description("File Over Limit")]
        [Category("400")]
        FileOverLimit,

        [Description("Authentication Fail")]
        [Category("401")]
        AuthenticationFail,

        [Description("Data Not Found.")]
        [Category("Data404")]
        DataNotFound,

        [Description("Precondition Failed")]
        [Category("412")]
        PreconditionFailed,

        [Description("Expectation Failed")]
        [Category("417")]
        ExpectationFailed,

        [Description("Internal Service Error")]
        [Category("500")]
        InternalServiceError,

        [Description("Internal Repositories Error")]
        [Category("500")]
        InternalRepositoriesError,

        [Description("Internal Service Unavailable")]
        [Category("503")]
        InternalServiceUnavailable
    }
}