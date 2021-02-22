using System.Collections;
using TMPro;
using UnityEngine;

namespace LevelManagement
{
    public class Main_Menu : Menu<Main_Menu>
    {
        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private Transition_Fader startTransitionPrefab;

        [SerializeField] TMP_Text Main_coinUIText;

        public void OnPlayPressed()
        {
            StartCoroutine(OnPlayPressedRoutine());
        }

        private IEnumerator OnPlayPressedRoutine()
        {
            Transition_Fader.PlayTransition(startTransitionPrefab);
            Level_Loader.LoadNextLevel();
            yield return new WaitForSeconds(_playDelay);
            Game_Menu.Open();
        }

        public void OnSettingsPressed()
        {
            Settings_Menu.Open();
        }

        public override void OnBackPressed()
        {
            Application.Quit();
        }
        public void OnAchievementsPressed()
        {
            Achievement_Menu.Open();
        }
        public void UpdateCoinCount(int coins)
        {
            if (Main_coinUIText != null) { Main_coinUIText.text = coins.ToString(); }
        }
    }
}
