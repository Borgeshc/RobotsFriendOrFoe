using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float scrollSpeed;
	float offset;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		offset += (Time.deltaTime*scrollSpeed)/10f;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offset,0));
	}
}
