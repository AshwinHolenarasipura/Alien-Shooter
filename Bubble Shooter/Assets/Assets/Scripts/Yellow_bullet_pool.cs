﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow_bullet_pool : MonoBehaviour
{
    public static Yellow_bullet_pool y_bulletPoolInstance;

    public GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets;

    private void Awake()
    {
        y_bulletPoolInstance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {

                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
