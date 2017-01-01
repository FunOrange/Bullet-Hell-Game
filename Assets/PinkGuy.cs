using UnityEngine;
using System.Collections;

public class PinkGuy : MonoBehaviour {

	bool firing = false;
	float cooldown = 0;
	private float fireRate = 50;
	public GameObject projectile;

	// Update is called once per frame
	void Update () {
		if (firing) {
			if (cooldown <= 0) {
				fire();
				cooldown = 100/fireRate;
			} else {
				cooldown--;
			}
		}
	}

	void fire () {
		GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Bullet>().target = GameObject.Find("Player");
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.transform.Equals (transform.parent))
			firing = true;
	}
}
