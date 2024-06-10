using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float rotateSpeed = 10f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private MagicShield magicShield;
    [SerializeField] private Cooldown shieldCooldown;
    [SerializeField] private bool canTakeDamage;

    private void Start()
    {
        canTakeDamage = true;
    }

    void Update()
    {
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

        transform.Translate(z, 0f, 0f);
        transform.Rotate(0f, y, 0f);

        if (transform.position.z >= 85)
        {
            transform.position = new Vector3(transform.position.x, 6f, 85);
        }
        if (transform.position.z <= -85)
        {
            transform.position = new Vector3(transform.position.x, 6f, -85);
        } 
        if (transform.position.x >= 85)
        {
            transform.position = new Vector3(85, 6f, transform.position.z);
        }
        if (transform.position.x <= -85)
        {
            transform.position = new Vector3(-85, 6f, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (magicShield.CanUse() && !shieldCooldown.IsCoolingDown()) {
                StartCoroutine(magicShield.ActivateShield());
                shieldCooldown.StartCooldown();
            }
            else
            {
                //Something showing that the shield is on cooldown
                Debug.Log("Shield is in cooldown");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyProjectile" && canTakeDamage)
        {
            Destroy(other.gameObject);
            gameManager.ChangeHealth(-1);
            gameManager.RefreshStatus();
        }

        if (other.tag == "Enemy" && canTakeDamage)
        {
            gameManager.ChangeHealth(-2);
            gameManager.RefreshStatus();
        }
    }

    public void ChangeDamagePossibility()
    {
        canTakeDamage = !canTakeDamage;
    }
}
