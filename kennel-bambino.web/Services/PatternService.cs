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
    public class PatternService : IPatternService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PatternService> _logger;

        public PatternService(ApplicationDbContext context, ILogger<PatternService> logger)
        {
            _context = context;
            _logger = logger;
        }
        #region Add Pattern
        public Pattern AddPattern(Pattern pattern)
        {
            try
            {
                _context.Patterns.Add(pattern);
                _context.SaveChanges();

                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }

        }

        public async Task<Pattern> AddPatternAsync(Pattern pattern)
        {
            try
            {

                await _context.Patterns.AddAsync(pattern);
                await _context.SaveChangesAsync();

                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");
                return null;
            }
        }

        #endregion Add Pattern

        #region Get All Patterns
        public IEnumerable<Pattern> GetAllPatterns() => _context.Patterns.ToList();

        public async Task<IEnumerable<Pattern>> GetAllPatternsAsync() => await _context.Patterns.ToListAsync();

        #endregion Get All Patterns

        #region Get PatternId
        public Pattern GetPatternById (int patternId) => _context.Patterns
            .SingleOrDefault(g => g.PatternId == patternId);

        public async Task<Pattern> GetPatternByIdAsync(int patternId)=> await _context.Patterns
            .SingleOrDefaultAsync(g => g.PatternId == patternId);

        #endregion Get PatternId

        #region Remove Pattern
        public void RemovePattern(int patternId)
        {
            var pattern = GetPatternById(patternId);
            _context.Patterns.Remove(pattern);
            _context.SaveChanges();
        }

        public async Task RemovePatternAsync(int patternId)
        {
            var pattern = await GetPatternByIdAsync(patternId);

            _context.Patterns.Remove(pattern);
            await _context.SaveChangesAsync();
        }
        #endregion Remove Pattern

        #region Update Pattern
        public Pattern UpdatePattern(Pattern pattern)
        {
            try
            {
                _context.Patterns.Update(pattern);
                _context.SaveChanges();

                return pattern;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }

        public async Task<Pattern> UpdatePatternAsync(Pattern pattern)
        {
            try
            {
                _context.Patterns.Update(pattern);
                await _context.SaveChangesAsync();

                return pattern;

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.StackTrace}\n{ex.Message}");

                return null;
            }
        }
        #endregion Update Pattern
    }
}
