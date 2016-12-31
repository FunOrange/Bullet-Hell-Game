using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {

	//public spawnList[] spawnLists;

	public SpawnList[] spawnLists;
	float[][] entries;
	Wave currentWave;
	int waveNumber = 0;

	void Awake () {
		// create spawnlists
		spawnLists = new SpawnList[transform.childCount];

		// spawnlist 1
		entries = new float[6][];
		entries[0] = new float[2] {0, 1+0};
		entries[1] = new float[2] {1, 1+0.1f};
		entries[2] = new float[2] {2, 1+0.2f};
		entries[3] = new float[2] {3, 1+0.3f};
		entries[4] = new float[2] {4, 1+0.4f};
		entries[5] = new float[2] {5, 1+0.5f};
		spawnLists[0] = new SpawnList(getIndexArray(), getTimeArray());

		// spawnlist 2
		entries = new float[4][];
		entries[0] = new float[2] {0, 0};
		entries[1] = new float[2] {1, 0.2f};
		entries[2] = new float[2] {2, 0.4f};
		entries[3] = new float[2] {3, 0.6f};
		spawnLists[1] = new SpawnList(getIndexArray(), getTimeArray());

	}

	void Start() {
		callNextWave();
	}
	#region spawn list code
	int[] getIndexArray () {
		int[] result = new int[entries.Length];
		for (int i=0; i<entries.Length; i++) {
			result[i] = (int) entries[i][0];
		}
		return result;
	}
	float[] getTimeArray () {

		float[] result = new float[entries.Length];
		for (int i=0; i<entries.Length; i++) {
			result[i] = entries[i][1];
		}
		return result;
	}

	public class SpawnList {
		public int[] spawnerIndices;
		public float[] times;
		public SpawnList (int[] a, float[] b) {
			spawnerIndices = a;
			times = b;
		}
	}
	#endregion
	public void callNextWave () {
		waveNumber++;
		if (waveNumber <= transform.childCount) {
			currentWave = transform.GetChild(waveNumber-1).GetComponent<Wave>();
			currentWave.activate ();
		} else {
			//win condition
			print ("you win~!");
		}
	}
}
