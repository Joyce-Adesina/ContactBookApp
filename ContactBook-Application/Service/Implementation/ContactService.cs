using AutoMapper;
using ContactBook_Application.Service.Abstraction;
using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Dtos.Response;
using ContactBook_Domain.Model.Models;
using ContactBook_Infrastructure.UnitOfWork.Abstraction;
using Microsoft.Extensions.Logging;

namespace ContactBook_Application.Service.Implementation
{
    public class ContactService: IContactService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<StandardReponse<ContactResponseDto>> CreateContact(ContactRequestDto contactRequestDto)
        {
            var contact = _mapper.Map<Contact>(contactRequestDto);
            await _unitOfWork.ContactRepository.CreateAsync(contact);
            await _unitOfWork.SaveAsync();
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardReponse<ContactResponseDto>.Success("Successfully created new contact", contactDto, 201);
        }

        public async Task<StandardReponse<ContactResponseDto>> DeleteContact(int id)
        {
            _logger.LogInformation($"Checking if contact with id {id} exists");
            var contact = await _unitOfWork.ContactRepository.GetContactById(id);
            if (contact is null)
            {
                _logger.LogError("Contact not found in the database. Aborting delete");
                return StandardReponse<ContactResponseDto>.Failed("Contact not found in the database");
            }
            _unitOfWork.ContactRepository.Delete(contact);
            await _unitOfWork.SaveAsync();
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardReponse<ContactResponseDto>.Success($"Successfully deleted a user {contact.FirstName}", contactDto, 200);
        }

        public async Task<StandardReponse<IEnumerable<ContactResponseDto>>> GetAllContacts()
        {
            var contacts = await _unitOfWork.ContactRepository.GetAllContacts();
            var contactsDtos = _mapper.Map<IEnumerable<ContactResponseDto>>(contacts);
            return StandardReponse<IEnumerable<ContactResponseDto>>.Success("Successfully retrieved all contacts", contactsDtos, 200);
        }

        public async Task<StandardReponse<ContactResponseDto>> GetContactByEmail(string email)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactByEmail(email);
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardReponse<ContactResponseDto>.Success("Successfully retrieved a contact", contactDto, 200);
        }

        public async Task<StandardReponse<ContactResponseDto>> GetContactById(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetContactById(id);
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardReponse<ContactResponseDto>.Success("Successfully retrieved a contact", contactDto, 200);
        }

        public async Task<StandardReponse<ContactResponseDto>> UpdateContact(int id, ContactRequestDto contactRequestDto)
        {
            var contactExists = await _unitOfWork.ContactRepository.GetContactById(id);
            if (contactExists is null)
            {
                _logger.LogError("Contact not found in the database. Aborting update");
                return StandardReponse<ContactResponseDto>.Failed("Contact not found in the database");
            }
            var contact = _mapper.Map<Contact>(contactRequestDto);
            _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.SaveAsync();
            var contactDto = _mapper.Map<ContactResponseDto>(contact);
            return StandardReponse<ContactResponseDto>.Success($"Successfully deleted a user {contact.FirstName}", contactDto, 200);
        }
    }
}
    
    
