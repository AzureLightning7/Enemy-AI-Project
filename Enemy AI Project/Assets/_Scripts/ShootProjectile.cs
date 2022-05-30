using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootProjectile : MonoBehaviour {

	public GameObject projectile;  // what is being shot
	public Transform shootSource;  // where it is being shot from
	public AudioClip rocketFiringSound; 
	public int ammo = 3;   // ammo count
	public Text ammoDisplay;
	public int score = 0;
	public Text scoreDisplay;

	void Start ()
	{
		score = 0;
		scoreDisplay.text = score.ToString();
		ammoDisplay.text = ammo.ToString();
		// DO NOT FIRE HERE!!!!!!!!!
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Fire1") && ammo > 0) // if pressing Shoot
		{
			AudioSource.PlayClipAtPoint(rocketFiringSound, Camera.main.transform.position, 1f);
			print("Fire!!!!!!");  // print to console
			var myProjectile = Instantiate(projectile, shootSource.position, shootSource.rotation);
			ammo--;
			ammoDisplay.text = ammo.ToString();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		// check if toughing ammo
		if(other.tag == "Ammo")
		{
			ammo += 5;
			other.gameObject.SetActive(false); // hide and disable the ammo
			ammoDisplay.text = ammo.ToString();
		}
	}
		public void UpdateScore()
		{
			score += 10;
			scoreDisplay.text = score.ToString();
		}
}
