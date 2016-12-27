using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject enemy;

	void OnDrawGizmos() {
		Gizmos.DrawWireSphere(transform.position, 0.5f);
	}

	public void spawn() {
		GameObject mob = Instantiate (enemy, transform.position, Quaternion.identity) as GameObject;
		mob.transform.parent = transform;
	}
}
