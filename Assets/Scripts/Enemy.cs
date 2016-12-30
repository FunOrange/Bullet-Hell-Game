using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public AudioClip hurtSound, deathSound;
	public float health = 1;
	public float cooldown = 30;
	public GameObject bullet;

	void Update() {
		if (cooldown <= 0) {
			fire();
			cooldown = 50;
		} else
			cooldown--;
	}

	void fire() {
		Instantiate (bullet, transform.position, Quaternion.identity);
	}
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
