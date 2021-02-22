using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
        }
        public float MasterVolume
        {
            get { return _saveData.masterVolume; }
            set { _saveData.masterVolume = value; }
        }
        public float SfxVolume
        {
            get { return _saveData.sfxVolume; }
            set { _saveData.sfxVolume = value; }
        }
        public float MusicVolume
        {
            get { return _saveData.musicVolume; }
            set { _saveData.musicVolume = value; }
        }
        public int ScoreCount
        {
            get { return _saveData.score_count; }
            set { _saveData.score_count = value; }
        }
        public bool[] UnlockedPlanet
        {
            get { return _saveData.Unlocked_planet; }
            set { _saveData.Unlocked_planet = value; }
        } 
        public int SelectedIndex
        {
            get { return _saveData.selected_Index; }
            set { _saveData.selected_Index = value; }
        }
        public void Save()
        {
            _jsonSaver.Save(_saveData);
        }

        public void Load()
        {
            _jsonSaver.Load(_saveData);
        }
    }
}
