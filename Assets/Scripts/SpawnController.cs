using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
	private GameObject[] spawners;
	private float cooldown = 0;

	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
	}
	
	void Update () {
		if(cooldown <= 0) {
			spawners[0].GetComponent<Spawner>().spawn();
			cooldown = 100;
		} else 
			cooldown--;
	}
}
