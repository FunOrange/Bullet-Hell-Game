using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public AudioClip hurtSound, deathSound;
	public float health = 1;


	void OnTriggerEnter2D (Collider2D collider) {
		// bullet collision
		if (collider.CompareTag("Bullet")) {
			Bullet bullet = collider.GetComponent<Bullet>();
			bullet.impact();
			hurt (bullet.damage);
		}
	}

	void hurt(float damage) {
		health -= damage;
		if(health <= 0)
			die();
 	}
	void die() {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		// play death animation
		Destroy (gameObject);
	}
}
