using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileController : MonoBehaviour {

	private Rigidbody rb;
	public GameObject explosion;  //What shoud be spawned when this hits something
	public float speed;  //How fast this goes
	public float lifeTime;  //how long to wait until removing this (in seconds)
	public float explodeLifeTime;  //how long an explosion should exist (in seconds)
	public AudioClip explodeClip;

	void Start () {
		//shootProjectile =  GameObject.Find("FPSController").GetComponent<ShootProjectile>();
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;  //shoot forward
		Destroy(gameObject,lifeTime);   //remove this after a while
	}
	
	private void OnCollisionEnter( Collision collision ){
		if (collision.collider.tag == "Enemy")
		{
			Destroy(collision.gameObject, 0.5f);
			//shootController.UpdateScore();
		}
		//create an explosion
		GameObject myExplode = Instantiate(explosion,transform.position,Quaternion.identity);
		//remove the explosion after a while, and the projectile immediately
		Destroy(myExplode,explodeLifeTime);
		AudioSource.PlayClipAtPoint(explodeClip, Camera.main.transform.position, 1f);
		Destroy(gameObject);
	}
}
