using LevelManagement.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace LevelManagement.Planets
{
    public class PlanetSelector : MonoBehaviour
    {
        [SerializeField]
        protected PlanetList _planetlist;
        [SerializeField]
        protected Button play_btn;
        [SerializeField]
        protected Button Locked_btn;
        [SerializeField] protected TMP_Text Main_FuelUIText;

        private int coins_unlock;
        protected int _currentIndex = 0;
        private DataManager _dataManager;

        private void Awake()
        {
            _dataManager = Object.FindObjectOfType<DataManager>();
        }
        public int CurrentIndex => _currentIndex;

        public void ClampIndex()
        {
            if (_planetlist.TotalPlanets == 0)
            {
                Debug.LogWarning("Mission Selector ClampIndex : missing");
                return;
            }
            if (_currentIndex >= _planetlist.TotalPlanets)
            {
                _currentIndex = 0;
            }
            if (_currentIndex < 0)
            {
                _currentIndex = (_planetlist.TotalPlanets - 1);
            }
        }

        public void SetIndex(int index)
        {
            _currentIndex = index;
            ClampIndex();
        }

        public void IncrementIndex()
        {
            SetIndex(_currentIndex + 1);
        }

        public void DecrementIndex()
        {
            SetIndex(_currentIndex - 1);
        }

        public PlanetSpecs GetPlanets(int index)
        {
            return _planetlist.GetPlanets(index);
        }

        public PlanetSpecs GetCurrentPlanet()
        {
            return _planetlist.GetPlanets(_currentIndex);
        }
        public void CheckIfPlanetIsUnlocked()
        {
            bool ys = _planetlist.GetPlanets(_currentIndex).Planet_Unlocked;
            coins_unlock = _planetlist.GetPlanets(_currentIndex).Coins_needed_to_unlock;
            if (ys == false)
            {
                play_btn.gameObject.SetActive(false);
                Locked_btn.gameObject.SetActive(true);
                Main_FuelUIText.text = coins_unlock.ToString();
            }
            else
            {
                play_btn.gameObject.SetActive(true);
                Locked_btn.gameObject.SetActive(false);
            }
        }
        public void Unlock_btn_pressed()
        {
            coins_unlock = _planetlist.GetPlanets(_currentIndex).Coins_needed_to_unlock;
            if (_dataManager.ScoreCount >= coins_unlock)
            {
                play_btn.gameObject.SetActive(true);
                Locked_btn.gameObject.SetActive(false);
                print("Unlocked success");
            }
            else
            {
                print("Not Enough Coins");
            }
        }
    }
}
