using UnityEngine;

public class HealthBar : MonoBehaviour
{
	private Health_System hs;
    public void setup(Health_System m_hs)
    {
        this.hs = m_hs;
 //       hs.OnHealthChanged += Hs_OnHealthChanged;
    }

    private void Update()
    {
        Find_Bar();
    }

    private void Find_Bar()
    {
        if(transform.Find("Bar") != null)
        {
            transform.Find("Bar").localScale = new Vector3(hs.GetHealthPercent(), 1);
        }
    }
}
