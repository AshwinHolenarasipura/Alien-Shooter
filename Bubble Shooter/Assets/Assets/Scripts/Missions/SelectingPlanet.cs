using LevelManagement;
using LevelManagement.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Planet_Selector
{
    public class SelectingPlanet : MonoBehaviour
    {
        public GameObject[] available_Planets;
        private DataManager _dataManager;

        private int currentIndex;

        [SerializeField]
        protected Button play_btn;
        [SerializeField]
        protected Button Locked_btn;
        [SerializeField] protected TMP_Text Main_FuelUIText;

        private static string amount = "100";

        private bool[] planets;

        // Start is called before the first frame update
        void Start()
        {
            _dataManager = Object.FindObjectOfType<DataManager>();
            currentIndex = _dataManager.SelectedIndex;
            planets = _dataManager.UnlockedPlanet;
        }
        public void NextPlanet()
        {
            available_Planets[currentIndex].SetActive(false);

            if (currentIndex + 1 == available_Planets.Length)
            {
                currentIndex = 0;

            }
            else
            {
                currentIndex++;
            }

            available_Planets[currentIndex].SetActive(true);

            CheckIfPlanetIsUnlocked();
        }
        public void PreviousPlanet()
        {
            available_Planets[currentIndex].SetActive(false);

            if (currentIndex - 1 < 0)
            {
                currentIndex = available_Planets.Length - 1;

            }
            else
            {
                currentIndex--;
            }

            available_Planets[currentIndex].SetActive(true);

            CheckIfPlanetIsUnlocked();
        }
        void CheckIfPlanetIsUnlocked()
        {
            if (_dataManager.UnlockedPlanet[currentIndex])
            {
                // if the planet is unlocked

                play_btn.gameObject.SetActive(true);
                Locked_btn.gameObject.SetActive(false);

            }
            else
            {
                // if the planet is LOCKED
                play_btn.gameObject.SetActive(false);
                Locked_btn.gameObject.SetActive(true);
                Main_FuelUIText.text = amount;
            }
        }
        public void SelectPlanet()
        {
            if (!_dataManager.UnlockedPlanet[currentIndex])
            {
                // IF THE planet IS NOT UNLOCKED - MEANING HE IS LOCKED
                // UNLOCK planet IF YOU HAVE ENOUGH STAR COUINS

                if (_dataManager.ScoreCount >= 100)
                {
                    print("Before score count in selecting planet " + _dataManager.ScoreCount);
                    _dataManager.ScoreCount -= 100;
                    print("After deduction score count in selecting planet " + _dataManager.ScoreCount);
                    Main_Menu.Instance.UpdateCoinCount(_dataManager.ScoreCount);

                    play_btn.gameObject.SetActive(true);
                    Locked_btn.gameObject.SetActive(false);

                    _dataManager.UnlockedPlanet[currentIndex] = true;

                    //  Game_Manager.Instance.selected_Index = currentIndex;
                    //  Game_Manager.Instance.planetUnlocked = planets;

                    // Game_Manager.Instance.OnPlanetUnlocked(planets);
                    //  Game_Manager.Instance.OnSelectedIndexValue(currentIndex);
                    _dataManager.Save();

                }

                else
                {
                    print("NOT ENOUGH STAR POINTS TO UNLOCK THE PLAYER");
                }
            }
        }
    }
}

