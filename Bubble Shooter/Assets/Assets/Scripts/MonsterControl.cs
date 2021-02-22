using LevelManagement;
using SampleGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject Target;
    float movSpeed;
    Vector3 DirecToTarget;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        movSpeed = Random.Range(1f, 5f);       
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
         //   MonsterSpawner.spawnAllowed = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.gameObject.SetActive(false);
           if(Game_Manager.Instance != null)
            {
                Game_Manager.Instance.GameOver();
            }
        }      
    }

    void MoveMonster()
    {
        if (Target != null)
        {
            DirecToTarget = (Target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(DirecToTarget.x * movSpeed, DirecToTarget.y * movSpeed);       
        }  
        else
            rb.velocity = Vector3.zero;
    }
}
