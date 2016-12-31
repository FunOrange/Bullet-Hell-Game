using UnityEngine;
using System.Collections;

public class ActiveArea : MonoBehaviour {
	void OnTriggerExit2D (Collider2D collider) {
		if (collider.CompareTag("Bullet") || collider.CompareTag("Character")) {
			Destroy(collider.gameObject);
		}
	}
}
