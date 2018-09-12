using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour 
{
	public Transform[] waypoints;
	public int patrolRange;
	public int shootRange;
	public int attackRange = 1;
	public Transform vision;
	public float stayAlertTime;

	public GameObject missile;
	public float missileDamage;
	public float missileSpeed;

	public bool onlyMelee = false;

	public float meleeDamage;
	public float attackDelay;
	public LayerMask raycastMask;

	public bool alertLookingForPlayer = false;
	private Animator enemyAnimator;

	[HideInInspector] public AlertState alertState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public IEnemyAI currentState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public Vector3 lastKnownPosition;

	void Awake()
	{
		alertState = new AlertState(this);
		attackState = new AttackState(this);
		chaseState = new ChaseState(this);
		patrolState = new PatrolState(this);
		navMeshAgent = GetComponent<NavMeshAgent>();
		enemyAnimator = GetComponent<Animator>();
	}

	void Start () 
	{
		currentState = patrolState;
	}
	

	void Update () 
	{
		currentState.UpdateActions();
	}

	private void OnTriggerEnter(Collider otherObj) 
	{
		currentState.OnTriggerEnter(otherObj);
	}

	public void HiddenShot(Vector3 shotPosition)
	{
		Debug.Log("Somebody shoted");
		lastKnownPosition = shotPosition;
		currentState = alertState;
	}
}
