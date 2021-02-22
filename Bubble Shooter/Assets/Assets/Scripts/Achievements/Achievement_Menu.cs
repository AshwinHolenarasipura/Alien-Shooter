using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LevelManagement
{
    public class Achievement_Menu : Menu<Achievement_Menu>
    {
        private static string General = "General";
        private static string Daily = "Daily";
        private Achievement_Button active_button;

        private void Start()
        {
            active_button = GameObject.Find("Achievement_Category_btn").GetComponent<Achievement_Button>();

            GameObject.Find("Achievement_Manager").GetComponent<Achievement_Manager>().
                CreateAchievement(General, "Test Title General", "This is a test description :)", 0);
            GameObject.Find("Achievement_Manager").GetComponent<Achievement_Manager>().
                CreateAchievement(General, "Test Title2 General", "This is a test2 description :)", 0);
            GameObject.Find("Achievement_Manager").GetComponent<Achievement_Manager>().
                CreateAchievement(Daily, "Test Title Daily", "This is a test description :)", 0);

            active_button.Click();
        }
        public void ChangeCategory(GameObject button)
        {
            Achievement_Button m_button = button.GetComponent<Achievement_Button>();
            m_button.Click();
            active_button.Click();
            active_button = m_button;
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }
    }
}
