namespace GloboTicket.Application.Responses;
/// <summary>
/// BaseResponsse 
/// Created for if i want return maeningful respone for user rather than 
/// return guid in Createion as example.
/// so we can return List of errors and Success or not. 
///
/// </summary>
public class BaseResponse
{

    public bool Success { get; set; }
    public List<string> ErrorList { get; set; } = new List<string>();
    public string Message { get; set; } = string.Empty;


    public BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}
