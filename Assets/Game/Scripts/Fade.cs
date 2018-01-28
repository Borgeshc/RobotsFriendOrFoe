using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    Image image;
    [HideInInspector]
    public bool droppedOff;
    [HideInInspector]
    public bool fadeOut;

    public float speed = 15f;
    public bool hasSpeed;
    public Fade fade;
    public GameObject nextPanel;

    void Start ()
    {
        image = GetComponent<Image>();
	}
	
	void Update ()
    {
   
        if(hasSpeed && droppedOff)
        {
            image.CrossFadeColor(Color.clear, speed, false, true);
        }
        else if (droppedOff)
        {
            image.CrossFadeColor(Color.clear, 15f, false, true);
        }


        if (fadeOut)
        {
            image.CrossFadeColor(Color.black, 1f, false, true);
        }
    }

    public void SetFade()
    {
        droppedOff = true;
    }

    public void FadeToBlack()
    {
        fadeOut = true;
        StartCoroutine(StartFadeIn());
    }

    IEnumerator StartFadeIn()
    {
        yield return new WaitForSeconds(1);
        nextPanel.SetActive(true);
        fade.SetFade() ;
    }
}
