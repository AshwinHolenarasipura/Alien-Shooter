using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cannon : Singleton<Cannon>
{
    public Vector2 mouse_pos;
    public Rigidbody2D rb;
    public float maxAngle = 50f;
    public float minAngle = -50f;

    public GameObject dots;
    public int dotAmount ;
    private float m_dotgap;
    public bool m_state;
    GameObject[] m_dotArray;

    // Start is called before the first frame update
    void Start()
    {
        m_state = true;
        rb = GetComponent<Rigidbody2D>();
        m_dotArray = new GameObject[dotAmount];
        m_dotgap = 1f / (float)dotAmount;

        SpawnDots();
    }

    // Update is called once per frame
    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookdir = mouse_pos - rb.position;
        float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);
        rb.rotation = angle;
        // transform.localRotation = Quaternion.Euler(0f, 0f, angle);
        MakeDotActive(m_state);
                
        //      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position)
    }

    void SpawnDots()
    {
        for (int i = 0; i < dotAmount; i++)
        {
            GameObject dot = Instantiate(dots);
            dot.SetActive(false);
            m_dotArray[i] = dot;
        }
    }

    void SetDotPos(Vector3 startpos , Vector3 Endpos)
    {
        for(int i = 0; i< dotAmount; i++)
        {
           // Vector3 _dotPos = m_dotArray[i].transform.position;
            Vector3 _targetpos = Vector2.Lerp(startpos, Endpos , i * m_dotgap);
            m_dotArray[i].transform.position = _targetpos;

        }
    }

    public void MakeDotActive(bool state)
    {
        m_state = state;
        if (state == true)
        {

            for (int i = 0; i < dotAmount; i++)
            {
                m_dotArray[i].SetActive(state);

            }
            SetDotPos(rb.position, mouse_pos);
        }
        else
        {
            for (int i = 0; i < dotAmount; i++)
            {
                m_dotArray[i].SetActive(state);

            }

        }
    }
}
