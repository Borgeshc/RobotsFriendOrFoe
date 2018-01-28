using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image image;
    [HideInInspector]
    public bool droppedOff;


    void Start ()
    {
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
        if(droppedOff)
        {
            image.CrossFadeColor(Color.clear, 15f, false, true);
        }
    }
}
