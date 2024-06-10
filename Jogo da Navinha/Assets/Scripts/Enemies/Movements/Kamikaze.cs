using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Kamikaze : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Enemy enemy;
    void Start()
    {
        enemy = gameObject.GetComponent<Enemy>();
        player = GameObject.Find("Player").gameObject.transform;
    }

    void Update()
    {
        Vector3 dirPlayer = (new Vector3(player.position.x, transform.position.y, player.position.z) - transform.position).normalized;

        transform.rotation = Quaternion.LookRotation(new Vector3(dirPlayer.x, 0, dirPlayer.z));
        if (Vector3.Distance(player.position, transform.position) > 3f)
        {
            transform.Translate(new Vector3(dirPlayer.x, 0, dirPlayer.z) * Time.deltaTime * enemy.GetSpeed(), Space.World);
        }

        
    }
}
