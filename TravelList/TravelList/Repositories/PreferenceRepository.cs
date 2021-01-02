using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelList.Models.Domain;
using TravelList.Services;
using TravelList.Utils;

namespace TravelList.Repositories
{
    public class PreferenceRepository
    {
        #region Properties
        public Preference Preference { get; set; }
        #endregion

        #region Constructors
        public PreferenceRepository()
        {
            GetPreference();
        }
        #endregion

        #region Methods
        public async void GetPreference()
        {
            Preference = await ApiService.GetPreference();
            ThemeUtil.SetTheme(Preference.DarkMode);
        }

        public async void UpdatePreference()
        {
            await ApiService.UpdatePreference(Preference);
            ThemeUtil.SetTheme(Preference.DarkMode);

        }
        #endregion
    }
}
