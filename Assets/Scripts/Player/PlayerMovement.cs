using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour 
{
	[Header("Movement parameters")]
	[SerializeField] private float walkingSpeed = 5f;
	[SerializeField] private float runningSpeed = 15f;
	[SerializeField] private float jumpStrength = 20f;
	
	float forwardMovement;
	float sidewaysMovement;
	float verticalVelocity;

	[Space(10)]
	[SerializeField] private float verticalRotationLimit = 70;
	private float verticalRotation = 0;
	CharacterController characterController;

	void Start () 
	{
		characterController = GetComponent<CharacterController>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	

	void Update () 
	{
		float horizontalRotation = Input.GetAxis("Mouse X");
		transform.Rotate(0, horizontalRotation, 0);

		verticalRotation -= Input.GetAxis("Mouse Y");
		verticalRotation = Mathf.Clamp(verticalRotation,-verticalRotationLimit, verticalRotationLimit);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

		if(characterController.isGrounded)
		{
			forwardMovement = Input.GetAxis("Vertical") * walkingSpeed;
			sidewaysMovement = Input.GetAxis("Horizontal") * walkingSpeed;
			if(Input.GetKey(KeyCode.LeftShift))
			{
				forwardMovement = Input.GetAxis("Vertical") * runningSpeed;
				sidewaysMovement = Input.GetAxis("Horizontal") * runningSpeed;			
			}

			if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
			{
				if(Input.GetKey(KeyCode.LeftShift))
				{
					DynamicCrosshair.spread = DynamicCrosshair.RUN_SPREAD;
				} else 
				{
					DynamicCrosshair.spread = DynamicCrosshair.WALK_SPREAD;
				}
			}

		} else 
		{
			DynamicCrosshair.spread = DynamicCrosshair.JUMP_SPREAD;
		}

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		if(Input.GetButton("Jump") && characterController.isGrounded)
		{
			verticalVelocity = jumpStrength;
		}

		Vector3 playerMovement = new Vector3(sidewaysMovement, verticalVelocity, forwardMovement);
		characterController.Move(transform.rotation * playerMovement * Time.deltaTime);
	}
}
