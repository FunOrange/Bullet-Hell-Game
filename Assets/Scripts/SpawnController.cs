using UnityEngine;
using System.Collections;

public static class SpawnData {
	static int[] list;

	public static Vector2 staticMethod () {
		return Vector2.zero;
	}
}

public class SpawnController : MonoBehaviour {

	//public spawnList[] spawnLists;

	public SpawnList[] spawnLists;
	float[][] spawnEntries;
	Wave currentWave;
	int waveNumber = 0;

	void Awake () {
		// create spawnlists
		spawnLists = new SpawnList[transform.childCount];

		// spawnlist 1
		spawnEntries = new float[7][];
		spawnEntries[0] = new float[2] {0, 1};
		spawnEntries[1] = new float[2] {1, 2};
		spawnEntries[2] = new float[2] {2, 3};
		spawnEntries[3] = new float[2] {3, 4};
		spawnEntries[4] = new float[2] {4, 5};
		spawnEntries[5] = new float[2] {5, 6};
		spawnEntries[6] = new float[2] {6, 7};
		spawnLists[0] = new SpawnList(getIndexArray(), getTimeArray());

		// spawnlist 2
		spawnEntries = new float[9][];
		spawnEntries[0] = new float[2] {0, 1};
		spawnEntries[1] = new float[2] {1, 2};
		spawnEntries[2] = new float[2] {2, 3};
		spawnEntries[3] = new float[2] {3, 4};
		spawnEntries[4] = new float[2] {4, 5};
		spawnEntries[5] = new float[2] {5, 6};
		spawnEntries[6] = new float[2] {6, 7};
		spawnEntries[7] = new float[2] {7, 1.5f};
		spawnEntries[8] = new float[2] {8, 4.5f};
		spawnLists[1] = new SpawnList(getIndexArray(), getTimeArray());

	}

	void Start() {
		callNextWave();
	}
	#region spawn list code
	int[] getIndexArray () {
		int[] result = new int[spawnEntries.Length];
		for (int i=0; i<spawnEntries.Length; i++) {
			result[i] = (int) spawnEntries[i][0];
		}
		return result;
	}
	float[] getTimeArray () {

		float[] result = new float[spawnEntries.Length];
		for (int i=0; i<spawnEntries.Length; i++) {
			result[i] = spawnEntries[i][1];
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
