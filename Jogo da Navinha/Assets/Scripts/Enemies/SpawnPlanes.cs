using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlanes : MonoBehaviour
{
    [SerializeField] private GameObject plane;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Cooldown spawnCooldown;
    private int enemies;
    [SerializeField] private int maxEnemies;

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (enemies <= maxEnemies)
        {
            if (!spawnCooldown.IsCoolingDown())
            {
                var planeCreep = Instantiate(plane, spawnPoint.position, plane.transform.rotation);
                enemies++;
                planeCreep.transform.position = new Vector3(spawnPoint.position.x, plane.transform.position.y, spawnPoint.position.z);
                spawnCooldown.StartCooldown();
            }
        }

    }
}
