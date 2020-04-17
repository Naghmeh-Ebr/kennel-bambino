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
    public class BodyTypeService : IBodyTypeService

{
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BodyTypeService> _logger;

        public BodyTypeService(ApplicationDbContext context, ILogger<BodyTypeService> logger)
        {
            _context = context;
            _logger = logger;
        }
        /// <summary>
        /// Add new bodytype to datebase 
        /// </summary>
        /// <param name="bodyType"></param>
        /// <returns></returns>

        #region Add new BodyType
        public BodyType AddBodyType(BodyType bodyType)
        {

            try
            {
                _context.BodyTypes.Add(bodyType);
                _context.SaveChanges();
                return bodyType;
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
            
        }
        public async Task<BodyType> AddBodyTypeAsync(BodyType bodyType)
        {
            try
            {

                await _context.BodyTypes.AddAsync(bodyType);
                await _context.SaveChangesAsync();

                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
        }
        #endregion

        #region Update data 
        public BodyType UpdateBodyType(BodyType bodyType)
        {
            try
            {
                _context.BodyTypes.Update(bodyType);
                _context.SaveChanges();

                return bodyType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        public async Task<BodyType> UpdateBodyTypeAsync(BodyType bodyType)
        {
            try 
            {
                 _context.BodyTypes.Update(bodyType);
                await _context.SaveChangesAsync();

                return bodyType;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
           
        }
        #endregion

        #region Get All BodyTypes
        public IEnumerable<BodyType> GetAllBodyTypes() => _context.BodyTypes.ToList();


        public async Task<IEnumerable<BodyType>> GetAllBodyTypesAsync() => await _context.BodyTypes.ToListAsync();

        #endregion

        #region Get BodyType By Id
        public BodyType GetBodyTypeById(int bodyTypeId) => _context.BodyTypes
            .SingleOrDefault(g => g.BodyTypeId == bodyTypeId);


        public async Task<BodyType> GetBodyTypeByIdAsync(int bodyTypeId) => await _context.BodyTypes
            .SingleOrDefaultAsync(g => g.BodyTypeId == bodyTypeId);

        #endregion

        #region Remove BodyType
        public void RemoveBodyType(int bodyTypeId)
        {
            var bodyType = GetBodyTypeById(bodyTypeId);
            _context.BodyTypes.Remove(bodyType);
            _context.SaveChanges();
            
        }

        public async Task RemoveBodyTypeAsync(int bodyTypeId)
        {
            var bodyType = await GetBodyTypeByIdAsync(bodyTypeId);

            _context.BodyTypes.Remove(bodyType);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

