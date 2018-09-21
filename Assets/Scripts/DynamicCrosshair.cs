using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCrosshair : MonoBehaviour 
{
	public static float spread;

	public const int PISTOL_SHOOTING_SPREAD = 20;
	public const int BLASTER_SHOOTING_SPREAD = 30;
	public const int JUMP_SPREAD = 50;
	public const int WALK_SPREAD = 10;
	public const int RUN_SPREAD = 25;

	[SerializeField] private GameObject crosshair;
	GameObject topPart, bottomPart, leftPart, rightPart;

	float initialPosition;

	void Start () 
	{
		topPart = crosshair.transform.Find("TopPart").gameObject;
		bottomPart = crosshair.transform.Find("BottomPart").gameObject;
		leftPart = crosshair.transform.Find("LeftPart").gameObject;
		rightPart = crosshair.transform.Find("RightPart").gameObject;

		initialPosition = topPart.GetComponent<RectTransform>().localPosition.y;
	}
	

	void Update () 
	{
		if(spread != 0)
		{
			topPart.GetComponent<RectTransform>().localPosition = new Vector3(0,initialPosition + spread, 0);
			bottomPart.GetComponent<RectTransform>().localPosition = new Vector3(0, -(initialPosition + spread), 0);
			leftPart.GetComponent<RectTransform>().localPosition = new Vector3(-(initialPosition + spread), 0, 0);
			rightPart.GetComponent<RectTransform>().localPosition = new Vector3(initialPosition + spread, 0, 0);
			spread -= 2;
		}
	}
}
