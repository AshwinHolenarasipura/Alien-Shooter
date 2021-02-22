using UnityEngine;

namespace LevelManagement
{
    public class Game_Menu : Menu<Game_Menu>
    {
        public void OnPausePressed()
        {
            Time.timeScale = 0;
            Pause_Menu.Open();
        }
    }
}
