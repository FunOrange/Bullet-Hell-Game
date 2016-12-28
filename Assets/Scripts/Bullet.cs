using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damage;
	public Vector2 initialVelocity;
	public AudioClip fireSound, impactSound;
	private Transform bulletFolder;


	// Use this for initialization
	void Start () {
		bulletFolder = GameObject.Find("Bullets").transform;
		transform.parent = bulletFolder;
		if(initialVelocity != Vector2.zero) {
			rigidbody2D.velocity = initialVelocity;
		}

		AudioSource.PlayClipAtPoint(fireSound, transform.position, 0.7f);
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
