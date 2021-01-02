using GalaSoft.MvvmLight;
using TravelList.Models.Domain;
using TravelList.Repositories;
using TravelList.Services;
using TravelList.Utils;

namespace TravelList.ViewModels.Settings
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Fields
        private readonly PreferenceRepository _preferenceRepository;
        #endregion

        #region Properties
        public Preference Preference { get; set; }
        #endregion

        #region Constructors
        public SettingsViewModel()
        {
            _preferenceRepository = RepositoryService.PreferenceRepository;
            Preference = _preferenceRepository.Preference;
            Preference.PropertyChanged += (object sender, System.ComponentModel.PropertyChangedEventArgs e) => SetTheme();
        }
        #endregion

        #region Methods
        private void SetTheme()
        {
            _preferenceRepository.UpdatePreference();
        }
        #endregion
    }
}
