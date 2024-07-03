using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public EnemyStats stats;
    public float speed = 3f;
    private Vector3 targetPosition;

    void Start()
    {
       
        targetPosition = transform.position;
    }

    void Update()
    {
       
        
        if (stats != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (stats.currentHealth <= 0)
            {
                Destroy(gameObject); 
            }
        }
    }

    public void ChangeMovePosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
    }
}
