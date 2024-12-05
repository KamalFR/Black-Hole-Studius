using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateChase : MonsterState
{
    private float _monsterVisibleSanity;

    public MonsterStateChase(MonsterBehaviour _monsterReference) : base(_monsterReference)
    {
        _monsterReference.StateName = MONSTER_STATE.CHASE;
    }

    public override void Enter()
    {
        _monsterReference.NavMeshAgent.isStopped = false;
        _monsterReference.NavMeshAgent.speed = _monsterReference.MonsterChaseSpeed;
        _monsterReference.NavMeshAgent.SetDestination(_monsterReference.PlayerGameObjectReference.transform.position);
        _monsterVisibleSanity = _monsterReference.GetComponent<ShowMonsterBehavior>().SanityVisible;
        base.Enter();
    }

    public override void Update()
    {
        // Caso pego no modo patrulha
        if (_monsterVisibleSanity < _monsterReference.PlayerGameObjectReference.GetComponent<HealthHandler>().CurrentSanity)
        {
            _monsterReference.EnterChase = false;
            _monsterStage = MONSTER_EVENT.EXIT;
            _monsterReference.NextState = new MonsterStatePatrol(_monsterReference);
            return;
        }

        // Caso de Sanidade zerada recuperada
        if (!_monsterReference.EnterChase && 0 < _monsterReference.PlayerGameObjectReference.GetComponent<HealthHandler>().CurrentSanity)
        {
            _monsterStage = MONSTER_EVENT.EXIT;
            _monsterReference.NextState = new MonsterStatePatrol(_monsterReference);
            return;
        }


        _monsterReference.NavMeshAgent.SetDestination(_monsterReference.PlayerGameObjectReference.transform.position);
        base.Update();
    }

    public override void Exit()
    {

        base.Exit();
    }

}
