using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damage, speed;
	public AudioClip fireSound, impactSound;
	private Transform bulletFolder;


	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find("Bullets").transform;
		transform.parent = bulletFolder;
		move ();

		AudioSource.PlayClipAtPoint(fireSound, transform.position, 0.7f);
	}

	void move () {
		rigidbody2D.velocity = Vector2.up * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void impact() {
		AudioSource.PlayClipAtPoint(impactSound, transform.position, 0.5f);
		// trigger impact animation
		Destroy (gameObject);
	}
}
