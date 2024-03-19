using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIo : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    public float Damage = 30;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _PlayerHealth;
    private EnemyHealth _enemyHealth;

    public bool IsAlive()
    {
        return _enemyHealth.IsAlive();
    }

    // Start is called before the first frame update
    private void Start()
    {
        InitComponetLinks();
        PicNewPatrolPoint();
    }

    // Update is called once per frame
    private void PicNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void InitComponetLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _PlayerHealth = player.GetComponent<PlayerHealth>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void PatrolUpdate()
    {
        if(!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PicNewPatrolPoint();
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void Update()
    {

        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
        PatrolUpdate();
    
    }

    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _PlayerHealth.DealDamage(Damage * Time.deltaTime);
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }  
    }
}
