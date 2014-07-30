using UnityEngine;
using System.Collections;

public class PoisonCounter : MonoBehaviour {

	public GameObject poisonGraphic;
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
		print ("plow");
	}
	
	IEnumerator DestroyCounter()
	{
		yield return new WaitForSeconds(life);
		Destroy (gameObject);
	}
}
