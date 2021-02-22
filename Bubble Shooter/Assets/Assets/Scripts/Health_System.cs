using System;
public class Health_System 
{
    private int currentHealth;
    private int healthMax;

  //  public event EventHandler OnHealthChanged;

    public Health_System (int healthMax)
    {
        this.healthMax = healthMax;
        currentHealth = healthMax;
    }
    public int GetHealth() { return currentHealth; }

    public float GetHealthPercent()
    {
        return (float)currentHealth / healthMax;
    }

    public int Damage(int damageAmount)
    {
      //  OnHealthChanged?.Invoke(this, EventArgs.Empty);
        return currentHealth -= damageAmount;    
    }
}

