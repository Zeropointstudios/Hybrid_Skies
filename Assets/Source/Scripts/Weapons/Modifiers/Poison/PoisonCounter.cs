using UnityEngine;
using System.Collections;

public class PoisonCounter : MonoBehaviour {

	public int damage;
	public float rate; //how often in second it does damage
	public float life; //how long poison lasts
	public float timeTilStart; //how long til it starts doing damage

	void OnEnable()
	{
		InvokeRepeating ("DrainEnemyLife", timeTilStart, rate);
		StartCoroutine ("DestroyCounter");
	}

	void DrainEnemyLife()
	{
		print ("doin poison damage");
//		transform.parent.GetComponent<HitPoints> ().doDamage (damage, null);
	}

	void OnDisable() {
		CancelInvoke ("DrainEnemyLife");
		print ("disable poison");
		gameObject.SetActive (false);
	}
	
	IEnumerator DestroyCounter()
	{
		yield return new WaitForSeconds(life);
		CancelInvoke ("DrainEnemyLife");
		print ("deactivate");
		gameObject.SetActive (false);
	}
}
