using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParasitePrefab : MonoBehaviour {

	public Vector3 startV3, endV3;
	public float explosionTime;
	public int TargetLimit;

	List<GameObject> enemies = new List<GameObject>();

	void Start () {
		FindEnemies (startV3, endV3, explosionTime);
	}


	IEnumerator FindEnemies(Vector3 start, Vector3 end, float totalTime) {
		float t = 0;
		do
		{
			collider.transform.localScale = Vector3.Lerp(start, end, t / totalTime);
			yield return null;
			t += Time.deltaTime;
		}

		while (t < totalTime);
		
		collider.transform.localScale = end;
		yield break;
	}
}