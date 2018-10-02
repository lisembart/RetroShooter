using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IT_Medpack : Item
{
	[SerializeField] private float healthToAdd;

	public override void PickUp()
	{
		Notifications notifications = FindObjectOfType<Notifications>();
		notifications.SendMessage("CleanNotifications", SendMessageOptions.DontRequireReceiver);
		PlayerHealth player = FindObjectOfType<PlayerHealth>();
		player.SendMessage("AddHealth", healthToAdd, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
