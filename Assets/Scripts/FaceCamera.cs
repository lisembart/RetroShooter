using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour 
{
	Vector3 cameraDirection;

	void Update () 
	{
		cameraDirection = Camera.main.transform.forward;
		cameraDirection.y = 0;
		transform.rotation = Quaternion.LookRotation(cameraDirection);
	}
}
