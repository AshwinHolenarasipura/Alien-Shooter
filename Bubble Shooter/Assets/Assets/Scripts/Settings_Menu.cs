﻿using LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LevelManagement.Data;

namespace LevelManagement
{
    public class Settings_Menu : Menu<Settings_Menu>
    {
        [SerializeField]
        private Slider _masterVolumeSlider;

        [SerializeField]
        private Slider _sfxVolumeSlider;

        [SerializeField]
        private Slider _musicVolumeSlider;

        private static string Master_Volume = "MasterVolume";
        private static string Sfx_Volume = "SfxVolume";
        private static string Music_Volume = "MusicVolume";

        private DataManager _dataManager;

        protected override void Awake()
        {
            base.Awake();
            _dataManager = Object.FindObjectOfType<DataManager>();
 
        }
        private void Start()
        {
            LoadData();
        }

        public void OnMasterVolumeChanged(float volume)
        {
            if(_dataManager != null)
            {
                _dataManager.MasterVolume = volume;
            }
        }

        public void OnSfxVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.SfxVolume = volume;
            }
        }

        public void OnMusicVolumeChanged(float volume)
        {
            if (_dataManager != null)
            {
                _dataManager.MusicVolume = volume;
            }
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            if(_dataManager != null)
            {
                _dataManager.Save();
            }
        }

        public void LoadData()
        {
            if(_dataManager == null || _masterVolumeSlider == null || _sfxVolumeSlider == null
                || _musicVolumeSlider == null)
            {
                return;
            }
            _dataManager.Load();
            _masterVolumeSlider.value = _dataManager.MasterVolume;
            _sfxVolumeSlider.value = _dataManager.SfxVolume;
            _musicVolumeSlider.value = _dataManager.MusicVolume;
        }

    }
}