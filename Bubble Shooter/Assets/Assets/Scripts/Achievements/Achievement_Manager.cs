using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Achievement_Manager : Singleton<Achievement_Manager>
{
    [SerializeField] private GameObject achievementPrefab;
    [SerializeField] private GameObject visualAchievement;
    [SerializeField] private GameObject EarnCnvas;


    public Dictionary<string, Achievement> achievements;
    public Sprite unlockedSprite;

    private static string Earn = "EarnCanvas(Clone)";

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        DontDestroyOnLoad(Instantiate(EarnCnvas));
        achievements = new Dictionary<string, Achievement>();


        foreach (GameObject achievementList in GameObject.FindGameObjectsWithTag("Achievement_List"))
        {
            achievementList.SetActive(false);
        }
        //  achievementMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckEarnAchievement("Test Title General");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckEarnAchievement("Test Title2 General");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckEarnAchievement("Test Title Daily");
        }
    }

    public void CheckEarnAchievement(string title)
    {
        if (achievements[title].EarnAchievement())
        {
            GameObject achievement = Instantiate(visualAchievement);
            SetAchievementInfo(Earn, achievement, title);
            StartCoroutine(HideAchievement(achievement));
        }
    }
    public IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(2f);
        Destroy(achievement);
    }
    public void CreateAchievement(string parent, string Title, string description, int spriteIndex)
    {
        GameObject achievement = Instantiate(achievementPrefab);
        Achievement m_achievement = new Achievement(name, description, spriteIndex, achievement);
        achievements.Add(Title, m_achievement);
        SetAchievementInfo(parent, achievement, Title);
    }
    public void SetAchievementInfo(string Parent, GameObject achievement, string Title)
    {
        achievement.transform.SetParent(GameObject.Find(Parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 1);
        achievement.transform.GetChild(0).GetComponent<TMP_Text>().text = Title;
        achievement.transform.GetChild(1).GetComponent<TMP_Text>().text = achievements[Title].Description;
    }
}
