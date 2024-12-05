using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MonsterStateIdle : MonsterState
{
    private float timer;
    public MonsterStateIdle(MonsterBehaviour _monsterReference) : base(_monsterReference)
    {
        _monsterReference.StateName = MONSTER_STATE.IDLE;
    }

    public override void Enter()
    {
        _monsterReference.NavMeshAgent.isStopped = true;
        timer = 0;
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0;
            _monsterStage = MONSTER_EVENT.EXIT;
            _monsterReference.NextState = new MonsterStatePatrol(_monsterReference);
        }
    }

    public override void Exit()
    {

        base.Exit();
    }

}
