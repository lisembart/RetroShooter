using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHiding : MonoBehaviour 
{
	[SerializeField] private GameObject weapons;
	public bool weaponHidden;

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.H))
		{
			HideShowWeapon();
		} 
	}

	public void HideShowWeapon()
	{
		if(weaponHidden)
		{
			weaponHidden = false;
			weapons.SetActive(true);
		} else 
		{
			weaponHidden = true;
			weapons.SetActive(false);
		}
	}
}
