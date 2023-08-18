using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Dtos.Response;
using ContactBook_Shared.Request_Parameter.Common;
using ContactBook_Shared.Request_Parameter.ModelParameters;
using Microsoft.AspNetCore.Http;

namespace ContactBook_Application.Service.Abstraction
{
    public interface IUserService
    {
        Task<StandardResponse<(IEnumerable<UserResponseDto> users, MetaData pagingData)>> GetAllUsers(UserRequestInputParameter parameter);
        Task<StandardResponse<UserResponseDto>> GetUserById(string id);
        Task<StandardResponse<UserResponseDto>> GetUserByEmail(string email);
        Task<StandardResponse<UserResponseDto>> UpdateUser(string id, UserRequestDto userRequestDto);
        Task<StandardResponse<UserResponseDto>> DeleteUser(string id);
        Task<StandardResponse<UserResponseDto>> CreateUser(UserRequestDto userRequestDto);
        Task<StandardResponse<(bool, string)>> UploadProfileImage(string userId, IFormFile file);

        //Search term will use searching
        /*Task<StandardResponse<UserResponseDto>> UpdateProfilePicUser(UserRequestDto userRequestDto);*/
    }
}
