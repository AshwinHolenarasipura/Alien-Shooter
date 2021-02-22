using UnityEngine;
using UnityEngine.UI;

public class Achievement_Button : MonoBehaviour
{
    [SerializeField] private GameObject achievementList;
    [SerializeField] private Sprite neutral, highlight;
    private Image sprite;
    private static string Daily = "Daily_Category_btn";

    // Start is called before the first frame update
    private void Awake()
    {
        sprite = GetComponent<Image>();
    }

    public void Click()
    {
        if (sprite.sprite == neutral)
        {
            sprite.sprite = highlight;
            achievementList.SetActive(true);
        }
        else
        {
            sprite.sprite = neutral;
            achievementList.SetActive(false);
        }
    }

}
