using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Dtos.Response;
using ContactBook_Shared.Request_Parameter.Common;
using ContactBook_Shared.Request_Parameter.ModelParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_Application.Service.Abstraction
{
    public interface IContactService
    {
        Task<StandardResponse<(IEnumerable<ContactResponseDto> contacts, MetaData pagingData)>> GetAllContacts(ContactRequestInputParameter parameter);
        Task<StandardResponse<ContactResponseDto>> GetContactById(int id);
        Task<StandardResponse<ContactResponseDto>> GetContactByEmail(string email);
        Task<StandardResponse<ContactResponseDto>> UpdateContact(int id, ContactRequestDto contactRequestDto);
        Task<StandardResponse<ContactResponseDto>> DeleteContact(int id);
        Task<StandardResponse<ContactResponseDto>> CreateContact(ContactRequestDto contactRequestDto);

    }
}
