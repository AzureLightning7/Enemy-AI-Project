using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace UnityStandardAssets.Effects
{
    public class ExplosionPhysicsForce : MonoBehaviour
    {
        public float explosionForce = 4;


        private IEnumerator Start()
        {
            // wait one frame because some explosions instantiate debris which should then
            // be pushed by physics force
            yield return null;

            float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

            float r = 10*multiplier;
            var cols = Physics.OverlapSphere(transform.position, r);
            var rigidbodies = new List<Rigidbody>();
            foreach (var col in cols)
            {
                if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
                {
                    rigidbodies.Add(col.attachedRigidbody);
                }
            }
            foreach (var rb in rigidbodies)
            {
                rb.AddExplosionForce(explosionForce*multiplier, transform.position, r, 1*multiplier, ForceMode.Impulse);
            }

			var myPlayer = GameObject.FindGameObjectWithTag("Player"); // player object
			var myFPS = myPlayer.GetComponent<FirstPersonController>(); // the script attached to Player

			var playerDistance = Vector3.Distance(transform.position, myPlayer.transform.position);
			var kbForce = (Mathf.Max(r - playerDistance, 0) / r) * explosionForce; // amount of force
			var kbDirection = Vector3.Normalize(myPlayer.transform.position - transform.position);

			myFPS.m_MoveDir += kbForce * kbDirection; // Apply knockback to player
        }
    }
}
