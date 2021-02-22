using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject HitEffect;
    public int currentHealth;
    private int MaxHealth;

    private Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    public HealthBar healthBar;
    public Health_System hs;

    [SerializeField] private GameObject Gold;


    private void Start()
    {
        MaxHealth = currentHealth;
        hs = new Health_System(MaxHealth);
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("Effect", typeof(Material)) as Material;
        matDefault = sr.material;
    }
    private void Update()
    {
        healthBar.setup(hs);
    }

    public void m_Damage(int damageAmount, string Tag)
    {
        if (Tag != null && currentHealth != 0)
        {
            if (Tag == "Red Bullet" && this.gameObject.tag == "Red Enemy")
            {
                // currentHealth -= damageAmount;
                currentHealth = hs.Damage(damageAmount);
                Check_Health();
            }

            else if (Tag == "Yellow Bullet" && this.gameObject.tag == "Yellow Enemy")
            {
                // currentHealth -= damageAmount;
                currentHealth = hs.Damage(damageAmount);
                Check_Health();

            }

        }
    }

    private void Check_Health()
    {
        if (currentHealth > 0) { }
        {
            sr.material = matWhite;
        }

        if (currentHealth <= 0)
        {
            if (Gold != null)
            {
                GameObject obj = Instantiate(Gold, transform.position, Quaternion.identity);
                obj.GetComponent<collectibles>().Gold_Coin(transform);
            }

            GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(this.gameObject);
            //  GameObject.Find("Gold").GetComponent<collectibles>().Gold_Coin(transform)
        }
        else
        {
            Invoke("ResetMaterial", 0.08f);
        }
    }

    private void ResetMaterial()
    {
        sr.material = matDefault;
    }
}
