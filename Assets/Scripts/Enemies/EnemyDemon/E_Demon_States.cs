using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Demon_States : MonoBehaviour 
{
	private GameObject player;
	private Transform playerTransform;
	[SerializeField] private float fieldOfView;
	[SerializeField] private float viewDistance;
	private Transform chaseTarget;
	private Vector3 lastKnownPosition;
	public Transform vision;
	public GameObject missile;
	public float missileDamage;
	public float missileSpeed;
	bool shoot = false;
	bool canShoot = true;
	private Enemy enemy;
	public float timeBetweenShots;

	void Start () 
	{
		player = GameObject.Find("Player");
		playerTransform = player.transform;
		enemy = GetComponent<Enemy>();
	}
	

	void Update () 
	{
		if(enemy.GetCurrentHealth() > 0)
		{
			RaycastHit hit;
        	if(Physics.Raycast(transform.position, -vision.forward, out hit, viewDistance) && hit.collider.CompareTag("Player"))
        	{
				Debug.Log("I see you");
            	chaseTarget = hit.transform;
            	lastKnownPosition = hit.transform.position;
				shoot = true;
				Shoot();
        	} else 
			{
				shoot = false;
			}			
		} else 
		{
			Death();
		}

	}

	public bool IsShooting()
	{
		return shoot;
	}	

	private void Shoot()
	{
		if(canShoot)
		{
        	missile = GameObject.Instantiate(missile, transform.position, Quaternion.identity);
			canShoot = false;
       		missile.GetComponent<Missile>().speed = missileSpeed;
        	missile.GetComponent<Missile>().damage = missileDamage;
			StartCoroutine("TimerToShoot");
		} 
	}

	IEnumerator TimerToShoot()
	{
		yield return new WaitForSeconds(timeBetweenShots);
		canShoot = true;
	}

	private void OnDrawGizmos() 
	{
		if(playerTransform == null)
		{
			return;
		}

		Debug.DrawLine(transform.position, playerTransform.position, Color.red);

		Vector3 frontRayPoint = transform.position + (transform.forward * viewDistance);

		Vector3 leftRayPoint = frontRayPoint;
		leftRayPoint.x += fieldOfView * 0.5f;

		Vector3 rightRayPoint = frontRayPoint;
		rightRayPoint.x -= fieldOfView * 0.5f;

		Debug.DrawLine(transform.position, frontRayPoint, Color.green);
		Debug.DrawLine(transform.position, leftRayPoint, Color.green);
		Debug.DrawLine(transform.position, rightRayPoint, Color.green);
	}

	private void Death()
	{
		//Here you have to turn off colliders, or make them smaller
	}	

}
