using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image image;
    
	void Start ()
    {
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
        image.CrossFadeColor(Color.clear, 2.0f, false, true);
    }
}
