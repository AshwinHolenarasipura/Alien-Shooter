using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement 
{
    private string name;
    private string description;
    private bool unlocked;
    private int spriteIndex;
    private GameObject achievementRef;

    public Achievement(string _name, string _description,int _spriteIndex, GameObject _achievementRef)
    {
        this.Name = _name;
        this.Description = _description;
        this.Unlocked = false;
        this.SpriteIndex = _spriteIndex;
        this.AchievementRef = _achievementRef;
        LoadAchievement();
    }

    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    public GameObject AchievementRef { get => achievementRef; set => achievementRef = value; }
    public bool Unlocked { get => unlocked; set => unlocked = value; }

    public bool EarnAchievement()
    {
        if (!Unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = Achievement_Manager.Instance.unlockedSprite;
            SaveAchievement(true);
            return true;
        }
        return false;
    }
    public void SaveAchievement(bool value)
    {
        Unlocked = value;
        int temp_points = PlayerPrefs.GetInt("Points");
        PlayerPrefs.SetInt("Points", temp_points += 300);
        PlayerPrefs.SetInt(name, value ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(name) == 1 ? true : false;
        if (unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = Achievement_Manager.Instance.unlockedSprite;
        }
    }
}
