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

	void Start () 
	{
		player = GameObject.Find("Player");
		playerTransform = player.transform;
	}
	

	void Update () 
	{
		RaycastHit hit;
        if(Physics.Raycast(transform.position, -vision.forward, out hit, viewDistance) && hit.collider.CompareTag("Player"))
        {
			Debug.Log("I see you");
            chaseTarget = hit.transform;
            lastKnownPosition = hit.transform.position;
			Shoot();
        }
	}	

	private void Shoot()
	{
        missile = GameObject.Instantiate(missile, transform.position, Quaternion.identity);
        missile.GetComponent<Missile>().speed = missileSpeed;
        missile.GetComponent<Missile>().damage = missileDamage;
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

}
