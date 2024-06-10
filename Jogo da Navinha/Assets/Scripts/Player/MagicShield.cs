using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float activeTime;
    private bool isShieldActive = false;

    public bool CanUse()
    {
        if (isShieldActive == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public IEnumerator ActivateShield()
    {
        gameObject.SetActive(true);
        isShieldActive = true;
        player.ChangeDamagePossibility();
        Debug.Log("Shield on");

        yield return new WaitForSeconds(activeTime);

        DeactivateShield();
    }

    public void DeactivateShield()
    {
        gameObject.SetActive(false);
        isShieldActive = false;
        player.ChangeDamagePossibility();
        Debug.Log("Shield off");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyProjectile" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
