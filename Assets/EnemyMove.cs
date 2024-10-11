using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public float range;
    public Transform enemyPosition;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.remainingDistance <= Enemy.stoppingDistance)
        {
            Vector3 point;
            if (RandomPoint(enemyPosition.position, range, out point))
            {
                Enemy.SetDestination(point);
            }

        }
    }
    
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true; 
            }
        }
        result = Vector3.zero;
        return false;
    }
}
