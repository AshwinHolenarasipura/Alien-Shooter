using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SampleGame;

namespace LevelManagement
{
    public abstract class Menu<T>:Menu where T: Menu<T>
    {
        private static T _instance;

        public static T Instance { get => _instance;}

        protected virtual void Awake()
        {
            if (_instance != null) {Destroy(gameObject); }
            else
            {
                _instance = (T)this;
            }
        }

        protected virtual void OnDestroy()
        {
                _instance = null;
        }

        public static void Open()
        {
            if(Menu_Manager.Instance != null && Instance != null)
            {
                Menu_Manager.Instance.OpenMenu(Instance);
            }
        }
    }

    [RequireComponent(typeof(Canvas))]  
    public abstract class Menu : MonoBehaviour
    {
        public virtual void OnBackPressed()
        {
            if (Menu_Manager.Instance != null)
            {
                Menu_Manager.Instance.CloseMenu();
            }
        }
    }
}
