using kennel_bambino.web.Data;
using kennel_bambino.web.Interfaces;
using kennel_bambino.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Services
{
    public class MessageService : IMessageService
    {
      
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MessageService> _logger;

        public MessageService(ApplicationDbContext context, ILogger<MessageService> logger)
        {
            _context = context;
            _logger = logger;
        }


        /// <summary>
        /// Add New Contact 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        #region Add Contact
        public Contact AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }

        }
       

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            try
            {

                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
        }

        #endregion  Add Contact

        #region Get All Contacts 
        public IEnumerable<Contact> GetAllContacts() => _context.Contacts.ToList();



        public async Task<IEnumerable<Contact>> GetAllContactsAsync() => await _context.Contacts.ToListAsync();

        #endregion Get All Contacts 

        #region Get Contact by Id 
        public Contact GetContactById(int contactId) => _context.Contacts
            .SingleOrDefault(g => g.ContactId == contactId);

        public async Task<Contact> GetContactByIdAsync(int contactId) => await _context.Contacts
            .SingleOrDefaultAsync(g => g.ContactId == contactId);

        #endregion
        #region Remove Contact
        public void RemoveContact(int contactId)
        {
            var contact = GetContactById(contactId);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }

        public async Task RemoveContactAsync(int contactId)
        {
            var contact = await GetContactByIdAsync(contactId);

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
        #endregion Remove Contact

        #region Update Contact
        public Contact UpdateContact(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                _context.SaveChanges();

                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();

                return contact;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion
    }
}
