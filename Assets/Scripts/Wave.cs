using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

	Spawner spawner;
	SpawnController spawnController;
	SpawnController.SpawnList spawnList;
	public bool inProgress = false;

	void Awake () {
		// get spawn list
		spawnController = transform.GetComponentInParent<SpawnController>();
		spawnList = spawnController.spawnLists[transform.GetSiblingIndex()];
	}

	public void activate () {
		for (int i=0; i<spawnList.spawnerIndices.Length; i++) {
			spawnSelected(spawnList.spawnerIndices[i], spawnList.times[i]);
		}
	}

	void Update () {
		if (inProgress && allMembersDead()) {
			spawnController.callNextWave();
			inProgress = false;
		}
	}

	void spawnSelected (int index, float time) {
		spawner = transform.GetChild(index).GetComponent<Spawner>();
		spawner.spawnAtTime(time);
	}

	public bool allMembersDead () {
		foreach (Transform spawner in transform) {
			if (spawner.childCount != 0)
				return false;
		} return true;
	}
	public int countMembers () {
		int result = 0;
		foreach (Transform spawner in transform) {
			if (spawner.childCount != 0)
				result++;
		} return result;
	}

}
