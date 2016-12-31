using UnityEngine;
using System.Collections;

public class Bullet_e1 : MonoBehaviour {

	public float speed = 4;

	// Use this for initialization
	void Start () {
		GameObject player = GameObject.Find("Player");
		Vector3 direction = (player.transform.position - transform.position).normalized;
		rigidbody2D.velocity = speed * direction;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
