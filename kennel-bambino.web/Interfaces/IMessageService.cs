using kennel_bambino.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    interface IMessageService
    {
        #region Add new Contact 

        Contact AddContact(Contact contact);
        Task<Contact> AddContactAsync(Contact contact);

        #endregion
        #region Get Contact
        IEnumerable<Contact> GetAllContacts();
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        #endregion

        #region Get Contact by id 
        Contact GetContactById(int contactId);
        Task<Contact> GetContactByIdAsync(int contactId);
        #endregion

        #region Update Contact
        Contact UpdateContact(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        #endregion
        #region Remove Contact
        void RemoveContact(int contactId);
        Task RemoveContactAsync(int contactId);

        #endregion


    }
}
