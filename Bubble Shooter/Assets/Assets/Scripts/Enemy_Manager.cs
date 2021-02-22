using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : Singleton<Enemy_Manager>
{
    public ScriptableInt maxHealth;
    public DamageType[] vulnerableDamageTypes;
}
