using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour 
{
	public bool autoFill;
	public List<Transform> weapons;
	public int initialWeapon;
	int selectedWeapon;

	[Header("Weapon Objects")]
	public GameObject pistol;
	public GameObject rocketLauncher;
	public GameObject blaster;

	void Awake() 
	{
		if(autoFill)
		{
			weapons.Clear();
			foreach(Transform weapon in transform)
			{
				weapons.Add(weapon);
			}
		}
	}

	void Start () 
	{
		selectedWeapon = initialWeapon % weapons.Count;
		UpdateWeapon();
	}
	

	void Update () 
	{
		if(Input.GetAxis("Mouse ScrollWheel") > 0)
		{
			selectedWeapon = (selectedWeapon + 1) % weapons.Count;
		}

		if(Input.GetAxis("Mouse ScrollWheel") < 0)
		{
			selectedWeapon = Mathf.Abs(selectedWeapon - 1) & weapons.Count;
		}

		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			selectedWeapon = 0;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2) && weapons.Count > 1)
		{
			selectedWeapon = 1;
		}

		UpdateWeapon();
	}

	void UpdateWeapon()
	{
		for(int i = 0; i < weapons.Count; i++)
		{
			if(i == selectedWeapon)
			{
				weapons[i].gameObject.SetActive(true);
			} else
			{
				weapons[i].gameObject.SetActive(false);
			}
		}
	}

	public void AddWeapon(Items_Weapons weaponType)
	{
		int weaponToAdd = (int)weaponType;
		switch(weaponToAdd)
		{
			case 1:
				if(!weapons.Contains(pistol.transform))
				{
					Debug.Log("Adding pistol");
					weapons[selectedWeapon].gameObject.SetActive(false);
					weapons.Add(pistol.transform);
				} else 
				{
					Debug.Log("I cant add any pistol");
				}
				break; 
			case 2: 
				if(!weapons.Contains(blaster.transform))
				{
					Debug.Log("Adding blaster");
					weapons[selectedWeapon].gameObject.SetActive(false);
					weapons.Add(blaster.transform);
				} else 
				{
					Debug.Log("I cant add any blaster");
				}
				break; 							
			case 5:
				if(!weapons.Contains(rocketLauncher.transform))
				{
					Debug.Log("Adding rocket launcher");
					weapons[selectedWeapon].gameObject.SetActive(false);
					weapons.Add(rocketLauncher.transform);
				} else 
				{
					Debug.Log("I cant add any rocket launcher");
				}
				break;
		}
	}
}
