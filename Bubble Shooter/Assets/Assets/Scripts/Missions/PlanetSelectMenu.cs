using LevelManagement.Planets;
using UnityEngine;
using UnityEngine.UI;

namespace LevelManagement
{
    public class PlanetSelectMenu : Menu<PlanetSelectMenu>
    {
        #region INSPECTOR
        //  [SerializeField] protected Text _nameText;
        [SerializeField] protected Image _previewImage;
        #endregion

        #region PROTECTED
        protected PlanetSelector _planetSelector;
        protected PlanetSpecs _currentPlanet;
        #endregion

        protected override void Awake()
        {
            base.Awake();
            _planetSelector = GetComponent<PlanetSelector>();
        }
        private void OnEnable()
        {
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            _currentPlanet = _planetSelector.GetCurrentPlanet();
            if (_currentPlanet != null) { _previewImage.sprite = _currentPlanet.Image; } // or => _previewImage.sprite = _currentPlanet?.Image;
            _planetSelector.CheckIfPlanetIsUnlocked();
        }
        public void OnNextPressed()
        {
            _planetSelector.IncrementIndex();
            UpdateInfo();
        }
        public void OnPreviousPressed()
        {
            _planetSelector.DecrementIndex();
            UpdateInfo();
        }
    }
}
