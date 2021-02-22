using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelManagement
{
    public class Level_Loader : MonoBehaviour
    {
        private static int mainMenuIndex = 1;

        public static void LoadLevel(string levelName)
        {
            Scene nextScene = SceneManager.GetSceneByName(levelName);
            if (nextScene.IsValid())
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LevelLoader => Load level error, in levelname");
            }
        }

        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    Main_Menu.Open();
                }
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LevelLoader => Load level error, in levelIndex");
            }
        }

        public static void ReloadLevel()
        {
            LoadLevel(SceneManager.GetActiveScene().name);
        }

        public static void LoadNextLevel()
        {
            int nextsceneIndex = ((SceneManager.GetActiveScene().buildIndex + 1) %
                (SceneManager.sceneCountInBuildSettings));
            LoadLevel(nextsceneIndex);
        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }
    }
} 
