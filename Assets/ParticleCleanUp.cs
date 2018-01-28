using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCleanUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine("Countdown");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Countdown()
	{
		yield return new WaitForSeconds(5);
		Destroy(this.gameObject);
	}
}
