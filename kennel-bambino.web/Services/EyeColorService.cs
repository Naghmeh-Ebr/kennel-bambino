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
   
    public class EyeColorService : IEyeColorService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EyeColorService> _logger;
        public EyeColorService(ApplicationDbContext context, ILogger<EyeColorService> logger)
        {
            _context = context;
            _logger = logger;
        }
        #region Add Eye Color
        public EyeColor AddEyeColor(EyeColor eyeColor)
        {
            try
            {
                _context.EyeColors.Add(eyeColor);
                _context.SaveChanges();
                return eyeColor;
            }

            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
        }

        public async Task<EyeColor> AddEyeColorAsync(EyeColor eyeColor)
        {
            try
            {

                await _context.EyeColors.AddAsync(eyeColor);
                await _context.SaveChangesAsync();

                return eyeColor;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
        }

        #endregion Add Eye Color
        #region Get All Eye Colors
        public IEnumerable<EyeColor> GetAllEyeColors() => _context.EyeColors.ToList();

        public async Task<IEnumerable<EyeColor>> GetAllEyeColorsAsync() => await _context.EyeColors.ToListAsync();

        #endregion Get All Eye Colors

        #region Get Eye Color By Id
        public EyeColor GetEyeColorById(int eyeColorId) => _context.EyeColors
            .SingleOrDefault(g => g.EyeColorId == eyeColorId);
        

        public async Task<EyeColor> GetEyeColorByIdAsync(int eyeColorId) => await _context.EyeColors
            .SingleOrDefaultAsync(g => g.EyeColorId == eyeColorId);

        #endregion Get Eye Color By Id

        #region Remove EyeColor
        public void RemoveEyeColor(int eyeColorId)
        {
            var eyeColor = GetEyeColorById(eyeColorId);
            _context.EyeColors.Remove(eyeColor);
            _context.SaveChanges();

        }

        public async Task RemoveEyeColorAsync(int eyeColorId)
        {
            var eyeColor = await GetEyeColorByIdAsync(eyeColorId);

            _context.EyeColors.Remove(eyeColor);
            await _context.SaveChangesAsync();
        }
        #endregion Remove EyeColor

        #region Update EyeColor
        public EyeColor UpdateEyeColor(EyeColor eyeColor)
        {
            try
            {
                _context.EyeColors.Update(eyeColor);
                _context.SaveChanges();

                return eyeColor;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<EyeColor> UpdateEyeColorAsync(EyeColor eyeColor)
        {
            try
            {
                _context.EyeColors.Update(eyeColor);
               await _context.SaveChangesAsync();

                return eyeColor;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion Update EyeColor
    }
}
