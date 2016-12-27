using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public AudioClip hurtSound, deathSound;
	public float health = 1;
	private bool onScreen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		// bullet collision
		if (collider.CompareTag("Bullet")) {
			Bullet bullet = collider.GetComponent<Bullet>();
			bullet.impact();
			hurt (bullet.damage);
		} else if (collider.name == "Active Area") {
			onScreen = true;
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Active Area") {
			Destroy (gameObject);
		}
	}

	void hurt(float damage) {
		health -= damage;
		// AudioSource.PlayClipAtPoint(hurtSound, transform.position);
		if(health <= 0)
			die();
 	}
	void die() {
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		// play death animation
		Destroy (gameObject);
	}
}
