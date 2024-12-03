using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PatrolBehaviorPH : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private List<Transform> _patrolLocations;
    [SerializeField] private bool _randomPatrolOrder;
    [SerializeField] private int _waitPatrolTime;

    private int _currentIndex;


    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _currentIndex = 0;
        _navMeshAgent.SetDestination(_patrolLocations[_currentIndex].position);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandlePatrol();
    }

    public void HandlePatrol()
    {
        if (_navMeshAgent.remainingDistance < 1)
        {
            if (_randomPatrolOrder)
            {
                StartCoroutine(RandomPatrol());
            }
            else
            {
                OrderedPatrol();
            }
        }


    }

    IEnumerator OrderedPatrol()
    {
        _currentIndex = (_currentIndex >= _patrolLocations.Count) ? 0 : _currentIndex++;

        yield return new WaitForSeconds(_waitPatrolTime);

        _navMeshAgent.SetDestination(_patrolLocations[_currentIndex].position);
    }

    IEnumerator RandomPatrol()
    {
        int newIndex;
        do
        {
            newIndex = Random.Range(0, _patrolLocations.Count);
            yield return null;
        } while (newIndex == _currentIndex);
        _currentIndex = newIndex;

        yield return new WaitForSeconds(_waitPatrolTime);


        _navMeshAgent.SetDestination(_patrolLocations[_currentIndex].position);

    }

}
