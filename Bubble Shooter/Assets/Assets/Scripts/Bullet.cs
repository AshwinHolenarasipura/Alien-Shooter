using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject Target;

    private Camera_Shake shaker;

    private void OnEnable()
    {
        Invoke("m_destroy", 0.48f);
    }

    private void Start()
    {
        Target = GameObject.Find("cannon_new");
        shaker = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Camera_Shake>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Target != null)
        {
            if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Red Bullet"
                || collision.gameObject.tag != "Player" && collision.gameObject.tag != "Yellow Bullet")
            {
                shaker.ShakeIt();
                gameObject.SetActive(false);
            }
        }
    }
    void m_destroy()
    {
        gameObject.SetActive(false);

    }

    private void OnDisable()
    {
        CancelInvoke(); 

    }
} 
