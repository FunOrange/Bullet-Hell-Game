using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float damage;
	public float speed;
	public Vector2 direction = Vector2.zero;
	public GameObject target = null;
	// enum movementTypes {linear, linearAimed, accelerated, deccelerated};
	public enum movementTypes {linear, linearAimed};
	public movementTypes movement;
	public AudioClip fireSound, impactSound;
	private Transform bulletFolder;

	void Start () {
		bulletFolder = GameObject.Find("Bullets").transform;
		transform.parent = bulletFolder;
		AudioSource.PlayClipAtPoint(fireSound, transform.position, 0.7f);

		// initial velocity
		rigidbody2D.velocity = speed * direction;
		// bullet movement types
		if (movement == movementTypes.linearAimed) {
			direction = target.transform.position - transform.position;
			direction.Normalize();
			rigidbody2D.velocity = speed * direction;
		}
	}

	void Update () {

	}

	public void impact() {
		AudioSource.PlayClipAtPoint(impactSound, transform.position, 0.5f);
		// trigger impact animation
		Destroy (gameObject);
	}
}
