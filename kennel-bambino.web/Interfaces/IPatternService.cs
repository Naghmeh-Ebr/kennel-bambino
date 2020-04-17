﻿using kennel_bambino.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    interface IPatternService
    {
        #region Add new Pattern 

        Pattern AddPattern(Pattern pattern);
        Task<Pattern> AddPatternAsync(Pattern pattern);

        #endregion

        #region Get Patterns
        IEnumerable<Pattern> GetAllPatterns();
        Task<IEnumerable<Pattern>> GetAllPatternsAsync();

        #endregion

        #region Get Pattern by id 
        Pattern GetPatternById(int patternId);
        Task<Pattern> GetPatternByIdAsync(int patternId);

        #endregion

        #region Update Pattern
        Pattern UpdatePattern(Pattern pattern);
        Task<Pattern> UpdatePatternAsync(Pattern pattern);

        #endregion

        #region Remove Pattern
        void RemovePattern (int patternId);
        Task RemovePatternAsync(int patternId);

        #endregion
    }
}
