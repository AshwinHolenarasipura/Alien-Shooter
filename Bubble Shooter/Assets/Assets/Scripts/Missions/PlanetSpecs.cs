using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LevelManagement.Planets
{
    [Serializable]
    public class PlanetSpecs 
    {
        #region  INSPECTOR
        [SerializeField]  protected string _name;
        [SerializeField] [Multiline]protected string _scenename;
        [SerializeField] protected string _id;
        [SerializeField] protected Sprite _image;
        [SerializeField] protected bool _planet_unlocked;
        [SerializeField] protected int _Coins_needed_to_unlock;
        #endregion

        #region  PROPERTIES
        public string Name => _name;
        public string SceneName => _scenename;
        public string Id => _id;
        public Sprite Image => _image;
        public bool Planet_Unlocked => _planet_unlocked;
        public int Coins_needed_to_unlock => _Coins_needed_to_unlock;
        #endregion



    }
}
