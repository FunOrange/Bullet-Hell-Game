using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	public string[] objectTags;

	void OnTriggerEnter2D (Collider2D collider) {
		if (shouldDelete(collider)) 
			Destroy(collider.gameObject);
	}

	bool shouldDelete(Collider2D collider) {
		foreach (string tag in objectTags) {
			if(collider.CompareTag(tag)) 
				return true;
		}
		return false;
	}
}
