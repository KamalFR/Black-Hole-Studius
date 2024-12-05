using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private float _monsterPatrolSpeed;
    public float MonsterPatrolSpeed { get { return _monsterPatrolSpeed; } }
    [SerializeField] private int _waitPatrolTime;
    public int WaitPatrolTime { get { return _waitPatrolTime; } }
    private int _currentPatrolIndex;
    public int CurrentPatrolIndex { get { return _currentPatrolIndex; } set { _currentPatrolIndex = value; } }

    #endregion

    #region Modo Perseguição config
    [Header("Modo Perseguição")]
    [SerializeField] private GameObject _playerGameObjectReference;
    public GameObject PlayerGameObjectReference { get { return _playerGameObjectReference; } }
    [SerializeField] private float _monsterChaseSpeed;
    public float MonsterChaseSpeed { get { return _monsterChaseSpeed; } }

    private bool _enterChase;
    public bool EnterChase { get { return _enterChase; } set { _enterChase = value; } }

    #endregion

    [SerializeField] private AudioClip _PatrolAudioclip;
    private AudioClip _startAudioclip;
    private AudioSource _monsterSourceAudio;
    private bool _changedToPatrolSound;





    // Start is called before the first frame update
    void Start()
    {
        _changedToPatrolSound = false;
        _monsterSourceAudio = GetComponentInChildren<AudioSource>();
        _startAudioclip = _monsterSourceAudio.clip;
        _enterChase = false;
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _currentState = new MonsterStateIdle(this);
    }

    // Update is called once per frame
    void Update()
    {
        _currentState = _currentState.Tick();
        if (_playerGameObjectReference.GetComponent<HealthHandler>().CurrentSanity < GetComponent<ShowMonsterBehavior>().SanityVisible)
        {
            if (!_changedToPatrolSound)
            {
                _monsterSourceAudio.clip = _PatrolAudioclip;
                _monsterSourceAudio.Play();
                _changedToPatrolSound = true;
            }

        }
        else
        {
            if (_changedToPatrolSound)
            {
                _monsterSourceAudio.clip = _startAudioclip;
                _monsterSourceAudio.Play();
                _changedToPatrolSound = false;
            }
        }
    }
}
