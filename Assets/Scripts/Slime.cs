using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour {
	public float cooldown = 30;
	public GameObject bullet;

	// Update is called once per frame
	void Update() {
		if (cooldown <= 0) {
			fire();
			cooldown = 50;
		} else
			cooldown--;
	}
	
	void fire() {
		GameObject newBullet = Instantiate (bullet, transform.position, Quaternion.identity) as GameObject;
		newBullet.GetComponent<Bullet>().target = GameObject.Find("Player");
	}
}
