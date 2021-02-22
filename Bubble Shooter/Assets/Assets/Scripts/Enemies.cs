using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int BulletDamage = 1;
    private string damageType;

    Health health;

    void Start()
    {
        health = GetComponent<Health>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        damageType = collision.gameObject.tag;

        // If there was a health script attached
        if (health != null && damageType != null)
        {
            // Call the damage function of that script, passing in our bulletdamage variable
            health.m_Damage(BulletDamage, damageType);
        }
    }
}
