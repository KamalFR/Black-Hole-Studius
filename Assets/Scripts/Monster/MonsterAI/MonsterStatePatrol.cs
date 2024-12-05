using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStatePatrol : MonsterState
{
    private float timer;

    public MonsterStatePatrol(MonsterBehaviour _monsterReference) : base(_monsterReference)
    {
        _monsterReference.StateName = MONSTER_STATE.PATROL;
        timer = 0;
    }

    public override void Enter()
    {
        _monsterReference.NavMeshAgent.isStopped = false;
        _monsterReference.CurrentPatrolIndex = 0;
        _monsterReference.NavMeshAgent.SetDestination(_monsterReference.PatrolWaypoints[_monsterReference.CurrentPatrolIndex].position);
        base.Enter();
    }

    public override void Update()
    {
        if (_monsterReference.NavMeshAgent.remainingDistance < 1)
        {
            RandomPatrol();
        }
        base.Update();
    }

    public override void Exit()
    {

        base.Exit();
    }

    public void RandomPatrol()
    {

        timer += Time.deltaTime;

        if (timer >= _monsterReference.WaitPatrolTime)
        {
            int newIndex;
            do
            {
                newIndex = Random.Range(0, _monsterReference.PatrolWaypoints.Count);
            } while (newIndex == _monsterReference.CurrentPatrolIndex);
            _monsterReference.NavMeshAgent.SetDestination(_monsterReference.PatrolWaypoints[newIndex].position);
            _monsterReference.CurrentPatrolIndex = newIndex;
            timer = 0;
        }
    }

}
