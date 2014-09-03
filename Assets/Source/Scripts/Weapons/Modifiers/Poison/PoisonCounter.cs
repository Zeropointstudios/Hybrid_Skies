using UnityEngine;
using System.Collections;

public class PoisonCounter : MonoBehaviour {

	public int damage;
	public float rate;
	public float life;
	public float timeTilStart;

	void Start()
	{
		InvokeRepeating ("DrainEnemyLife", timeTilStart, rate);
		StartCoroutine ("DestroyCounter");
	}

	void DrainEnemyLife()
	{
		transform.parent.GetComponent<HitPoints> ().doDamage (damage);
	}
	
	IEnumerator DestroyCounter()
	{
		yield return new WaitForSeconds(life);
		gameObject.SetActive (false);
	}
}
