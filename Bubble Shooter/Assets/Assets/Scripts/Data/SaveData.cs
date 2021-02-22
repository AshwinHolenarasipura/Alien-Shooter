using System;
using System.Collections;
using System.Collections.Generic;

namespace LevelManagement.Data
{
    [Serializable]
    public class SaveData
    {
        public string playerName;
        private readonly string defaultPlayerName = "Player";

        public float masterVolume;
        public float sfxVolume;
        public float musicVolume;

        public int score_count;
        public bool[] Unlocked_planet;
        public int selected_Index;

        public string hashValue;

        public SaveData()
        {
            playerName = defaultPlayerName;
            masterVolume = 0f;
            sfxVolume = 0f;
            musicVolume = 0f;
            score_count = 0;
            selected_Index = 0;
            hashValue = string.Empty;
        }

    }
}
