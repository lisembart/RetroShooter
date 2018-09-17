using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class StaticBillboardChange : MonoBehaviour 
{
	Sprite[] sprites;
	AnimationClip[] animations;
	bool isAnimated;
	
	Animator animator;
	SpriteRenderer spriteRenderer;

	float angle;

	void Awake ()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	

	void Update ()
	{
		angle = GetAngle();
	}

	float GetAngle()
	{
		return 0f;
	}
}
