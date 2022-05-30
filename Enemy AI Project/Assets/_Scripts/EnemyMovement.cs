using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

	Transform player;   // player position
	UnityEngine.AI.NavMeshAgent nav; // component

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(player.position);
	}

	private void OnCollisionEnter( Collision collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
