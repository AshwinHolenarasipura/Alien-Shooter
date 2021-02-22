using LevelManagement;
using LevelManagement.Data;
using UnityEngine;

namespace SampleGame
{
    public class Game_Manager : MonoBehaviour
    {
        [SerializeField]
        private int mainMenuIndex = 1;

        private DataManager _dataManager;
        private SaveData save_data;

        [HideInInspector]
        public int m_score_count, selected_Index;

        [HideInInspector]
        public bool[] planetUnlocked;

        private static Game_Manager _instance;

        // public bool IsGameOver { get => _IsGameOver; }

        public static Game_Manager Instance { get => _instance; }

        private void Awake()
        {
            if (_instance != null) { Destroy(gameObject); }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            _dataManager = Object.FindObjectOfType<DataManager>();
        }
        private void Start()
        {
            planetUnlocked = new bool[3];
            planetUnlocked[0] = true;
            for(int i = 0; i < planetUnlocked.Length; i++)
            {
                if (planetUnlocked[0])
                {
                    OnPlanetUnlocked(planetUnlocked);
                }
                else
                {
                    planetUnlocked[i] = false;
                    OnPlanetUnlocked(planetUnlocked);
                }
            }
            
            LoadData();
            Main_Menu.Instance.UpdateCoinCount(m_score_count);
        }
        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }
        public void GameOver()
        {
            Time.timeScale = 0;
            if (_dataManager != null)
            {
                _dataManager.Save();
            }
            Win_Screen.Open();
        }
        public void OnScoreCountChange(int score)
        {
            print("score received in the game manager : " + score);
            if (_dataManager != null)
            {
                if (score >= 0)
                {
                    score += _dataManager.ScoreCount;
                    print("score after calculation : " + score);
                    _dataManager.ScoreCount = score;
                }
            }
        }
        public void OnPlanetUnlocked(bool[] value)
        {
            if (_dataManager != null)
            {
                print("planet unlocked is" + value);
                _dataManager.UnlockedPlanet = value;
            }
        }
        public void OnSelectedIndexValue(int index)
        {
            if(_dataManager != null)
            {
                _dataManager.SelectedIndex = index;
            }
        }
        public void LoadData()
        {
            if (_dataManager != null)
            {
                _dataManager.Load();
                m_score_count = _dataManager.ScoreCount;
                planetUnlocked = _dataManager.UnlockedPlanet;
                selected_Index = _dataManager.SelectedIndex;
            }
        }
    }
}
