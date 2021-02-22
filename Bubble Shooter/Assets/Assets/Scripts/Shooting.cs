using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;

    public float bulletForce = 20f;

    public GameObject r_bullet , y_bullet;

    int index = 1;

    private GameObject pooledBullet;

    public static string BULLET_STRING = "Red Bullet";

    public static string BULLETX_STRING = "Yellow Bullet";

    private Animator anim;


    private void Start()
    {
        pooledBullet = r_bullet;
        anim = GetComponent<Animator>();
        r_bullet.gameObject.SetActive(true);
        y_bullet.gameObject.SetActive(false);
    }
    private void Update()
    {
        Change_bullet();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetButtonDown("Fire1"))
        {
           if(Cannon.Instance.gameObject != null)
            {
                Cannon.Instance.MakeDotActive(false);
                anim.SetBool("isShooting", true);
            }
            Shoot();

        }
        else
            if (Cannon.Instance.gameObject != null)
        {
            Cannon.Instance.MakeDotActive(true);
            anim.SetBool("isShooting", false);
        }
    }

    void Shoot()
    {
        if(pooledBullet.gameObject.tag == BULLET_STRING)
        {
            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = firepoint.position;
            bul.transform.rotation = firepoint.rotation;
            bul.SetActive(true);
            Rigidbody2D rb = bul.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);

        }
        else if (pooledBullet.gameObject.tag == BULLETX_STRING)
        {
            GameObject bul = Yellow_bullet_pool.y_bulletPoolInstance.GetBullet();
            bul.transform.position = firepoint.position;
            bul.transform.rotation = firepoint.rotation;
            bul.SetActive(true);
            Rigidbody2D rb = bul.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);

        }
    }

    public void Change_bullet()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (index)
            {
                case 1:

                    index = 2;
                    pooledBullet = y_bullet;
                    r_bullet.gameObject.SetActive(false);
                    y_bullet.gameObject.SetActive(true);
                    break;

                case 2:

                    index = 1;
                    pooledBullet = r_bullet;
                    r_bullet.gameObject.SetActive(true);
                    y_bullet.gameObject.SetActive(false);
                    break;
            }
        }
    }
}
