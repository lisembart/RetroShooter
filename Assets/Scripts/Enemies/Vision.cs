using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour 
{
	Transform player;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	

	void Update () 
	{
		transform.LookAt(player);
	}
}
