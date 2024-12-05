using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterBehaviour : MonoBehaviour
{
    #region Config Maquina de estados
    [SerializeField] private MONSTER_STATE _stateName;
    public MONSTER_STATE StateName { get { return _stateName; } set { _stateName = value; } }

    private MonsterState _nextState;
    public MonsterState NextState { get { return _nextState; } set { _nextState = value; } }
    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }

    private MonsterState _currentState;
    public MonsterState CurrentState
    {
        get { return _currentState; }
    }
    #endregion

    #region Modo Patrulha config

    [Header("Modo Patrulha")]
    [SerializeField] private List<Transform> _patrolWaypoints;
    public List<Transform> PatrolWaypoints { get { return _patrolWaypoints; } }
    [SerializeField] private int _waitPatrolTime;
    public int WaitPatrolTime { get { return _waitPatrolTime; } }
    private int _currentPatrolIndex;
    public int CurrentPatrolIndex { get { return _currentPatrolIndex; } set { _currentPatrolIndex = value; } }

    #endregion

    #region Modo Perseguição config
    [SerializeField] GameObject _playerGameObjectReference;

    #endregion




    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _currentState = new MonsterStateIdle(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState = _currentState.Tick();
    }
}
