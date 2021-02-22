using LevelManagement.Data;
using SampleGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class Win_Screen : Menu<Win_Screen>
    {
        private float _playDelay = 0.5f;
        private DataManager _dataManager;

        protected override void Awake()
        {
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
        }
        public void OnNextPressed()
        {
            Time.timeScale = 1;
            Level_Loader.LoadMainMenuLevel();
            Main_Menu.Open();
            Main_Menu.Instance.UpdateCoinCount(_dataManager.ScoreCount);
            print("score count from win_screen " + _dataManager.ScoreCount);
        }
    } 
}
