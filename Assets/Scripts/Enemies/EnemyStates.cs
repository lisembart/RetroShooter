using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStates : MonoBehaviour 
{
	public Transform[] waypoints;
	public int patrolRange;


	[HideInInspector] public AlertState alertState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public IEnemyAI currentState;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public Transform chaseTarget;

	void Awake()
	{
		alertState = new AlertState(this);
		attackState = new AttackState(this);
		chaseState = new ChaseState(this);
		patrolState = new PatrolState(this);
		navMeshAgent = GetComponent<NavMeshAgent>();
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
}
