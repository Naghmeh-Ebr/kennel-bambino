using kennel_bambino.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kennel_bambino.web.Interfaces
{
    interface IEyeColorService
    {
        #region Add new EyeColor 

        EyeColor AddEyeColor(EyeColor eyeColor);
        Task<EyeColor> AddEyeColorAsync(EyeColor eyeColor);2

        #endregion

        #region Get EyeColor
        IEnumerable<EyeColor> GetAllEyeColors();
        Task<IEnumerable<EyeColor>> GetAllEyeColorsAsync();
        #endregion


        #region Get EyeColor by id 
        EyeColor GetEyeColorById(int eyeColorId);
        Task<EyeColor> GetEyeColorByIdAsync(int eyeColorId);
        #endregion

        #region Update EyeColor
        EyeColor UpdateEyeColor(EyeColor eyeColor);
        Task<EyeColor> UpdateEyeColorAsync(EyeColor eyeColor);
        #endregion

        #region Remove EyeColor
        void RemoveEyeColor(int eyeColorId);
        Task RemoveEyeColorAsync(int eyeColorId);

        #endregion
    }
}
