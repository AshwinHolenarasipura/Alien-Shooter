using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    public class Menu_Manager : MonoBehaviour
    {
        [SerializeField]
        private Main_Menu m_MainMenu;
        [SerializeField]
        private Settings_Menu m_SettingsMenu;
        [SerializeField]
        private Game_Menu m_GameMenu;
        [SerializeField]
        private Pause_Menu m_PauseMenu;
        [SerializeField]
        private Win_Screen m_WinScreen;
        [SerializeField]
        private Achievement_Menu m_AchieventMenu;
        [SerializeField]
        private Shop_Menu m_ShopMenu;

        [SerializeField]
        private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        private static Menu_Manager _instance;

        public static Menu_Manager Instance { get => _instance;}

        private void Awake()
        {
           if(_instance != null) { Destroy(gameObject); }
            else
            {
                _instance = this;
                InitMenus();
                DontDestroyOnLoad(gameObject);
            }
        }
        private void OnDestroy()
        {
           if(_instance == this)
            {
                _instance = null;
            } 
        }

        private void InitMenus()
        {
            if(_menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menus");
                _menuParent = menuParentObject.transform;
            }
            DontDestroyOnLoad(_menuParent.gameObject);

            //  Menu[] menuPrefabs = { m_MainMenu, m_SettingsMenu, m_GameMenu, m_PauseMenu, m_WinScreen};

            System.Type myType = this.GetType();
            BindingFlags myFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;
            FieldInfo[] fields =   myType.GetFields(myFlags);

            // FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic
            //    | BindingFlags.DeclaredOnly);

            foreach (FieldInfo field in fields)
            {
                Menu prefab = field.GetValue(this) as Menu;

                if(prefab != null)
                {
                    //DEFINING FOR OPENING MAIN MENU FIRST
                    Menu menuInstance = Instantiate(prefab, _menuParent);
                    if(prefab != m_MainMenu)
                    {
                        menuInstance.gameObject.SetActive(false);
                    }
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }
        public void OpenMenu(Menu menu_I)
        {
            if(menu_I != null)
            {
                if (_menuStack.Count > 0) {

                    foreach (Menu menu in _menuStack)
                    {
                        menu.gameObject.SetActive(false);
                    }
                }
                menu_I.gameObject.SetActive(true);
               _menuStack.Push(menu_I);
            }
        }

        public void CloseMenu()
        {
            if(_menuStack.Count != 0)
            {
                Menu topMenu = _menuStack.Pop();
                topMenu.gameObject.SetActive(false);
            }
            if(_menuStack.Count > 0)
            {
                Menu NxtMenu = _menuStack.Peek();
                NxtMenu.gameObject.SetActive(true);
            }
        }
    }
}