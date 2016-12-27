using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private GameObject boundary;
	private float cooldown;
	private float speed = 6;

	public GameObject Bullet;
	public float fireRate;

	// Use this for initialization
	void Start () {
		boundary = GameObject.Find ("Player bounds");
	}
	
	// Update is called once per frame
	void Update () {
		// movement
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		transform.position = new Vector3(boundX (), boundY (), 0);

		// fire
		if (Input.GetKey(KeyCode.X) && cooldown <= 0) 
			fire();
		if (cooldown > 0)
			cooldown--;
	}

	float boundX() {
		float min = boundary.transform.position.x - boundary.GetComponent<BoxCollider2D>().size.x/2;
		float max = boundary.transform.position.x + boundary.GetComponent<BoxCollider2D>().size.x/2;
		return Mathf.Clamp (transform.position.x, min, max);
	}
	float boundY() {
		float min = boundary.transform.position.y - boundary.GetComponent<BoxCollider2D>().size.y/2;
		float max = boundary.transform.position.y + boundary.GetComponent<BoxCollider2D>().size.y/2;
		return Mathf.Clamp (transform.position.y, min, max);
	}

	void fire() {
		Vector3 muzzle;
		GameObject bullet;
		for (int i=0; i<transform.childCount; i++) {
			muzzle = transform.GetChild(i).transform.position;
			bullet = Instantiate (Bullet, muzzle, Quaternion.identity) as GameObject;
		}
		cooldown = 100/fireRate;
	}
}
