using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void shoot_anim(bool shoot)
    {
        if (shoot == true)
        {
            anim.SetBool("IsShooting", true);
        }
        anim.SetBool("IsShooting", false);
    }
}
