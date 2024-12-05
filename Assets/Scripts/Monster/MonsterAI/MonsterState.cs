using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterState
{
    protected MonsterBehaviour _monsterReference;
    protected MONSTER_EVENT _monsterStage;

    public MonsterState(MonsterBehaviour _monsterReference)
    {
        this._monsterReference = _monsterReference;
        _monsterStage = MONSTER_EVENT.ENTER;
    }

    public virtual void Enter()
    {
        _monsterStage = MONSTER_EVENT.UPDATE;
    }

    public virtual void Update()
    {
        _monsterStage = MONSTER_EVENT.UPDATE;
    }

    public virtual void Exit()
    {
        _monsterStage = MONSTER_EVENT.EXIT;
    }

    public MonsterState Tick()
    {
        if (_monsterStage == MONSTER_EVENT.ENTER)
        {
            Enter();
        }
        else if (_monsterStage == MONSTER_EVENT.UPDATE)
        {
            Update();
        }
        else
        {
            Exit();
            return _monsterReference.NextState;
        }

        return this;
    }
}
