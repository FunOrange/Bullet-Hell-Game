using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {
	Spawner spawner;
	public TextAsset spawnList;

	void Start () {
		print(spawnList.text);
	}

	void parseTextFile(TextAsset textFile) {

	}

	public void activate () {

	}

	void spawnSelected (int index, float time) {
		spawner = transform.GetChild(index).GetComponent<Spawner>();
		spawner.spawnAtTime(time);
	}
}
