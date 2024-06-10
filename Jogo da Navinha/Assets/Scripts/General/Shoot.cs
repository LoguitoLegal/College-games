using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Transform shootPoint2;
    public bool isPlayer;
    public Cooldown coolDown;
    public float speed;
    public float shootAngle;
    private void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            isPlayer = false;
        }
        else if (gameObject.tag == "Player")
        {
            isPlayer = true;
        }
    }

    private void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (!coolDown.IsCoolingDown())
                {
                    ShootProjectilePlayer();
                }
            }
        }
        else
        {
            if (!coolDown.IsCoolingDown())
            {
                ShootProjectile();
            }
        }
    }

    public void ShootProjectile()
    {
        var projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectile.transform.Rotate(shootAngle, 0f, 0f);
        projectile.transform.SetParent(null);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.up * speed);
        coolDown.StartCooldown();
    }

    public void ShootProjectilePlayer()
    {

        var projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        projectile.transform.Rotate(shootAngle, 0f, 0f);
        projectile.transform.SetParent(null);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.up * speed);

        var projectile2 = Instantiate(projectilePrefab, shootPoint2.position, shootPoint2.rotation);
        projectile2.transform.Rotate(-shootAngle, 0f, 0f);
        projectile2.transform.SetParent(null);
        projectile2.GetComponent<Rigidbody>().AddForce(projectile2.transform.up * speed);


        coolDown.StartCooldown();
    }
}
