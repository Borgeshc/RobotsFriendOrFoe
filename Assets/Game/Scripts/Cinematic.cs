using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    public GameObject decoy;
    public GameObject man;
    public Fade fader;

    Animator anim;
    Animator manimator;

    void Start()
    {
        anim = GetComponent<Animator>();
        manimator = man.GetComponentInChildren<Animator>();
    }

	public void ClawInPosition()
    {
        anim.SetBool("Open", true);
        fader.droppedOff = true;
    }

    public void ClawOpen()
    {
        StartCoroutine(TogglePlayer());
    }

    IEnumerator TogglePlayer()
    {
        yield return new WaitForSeconds(.5f);

        decoy.SetActive(false);
        man.SetActive(true);
        manimator.SetTrigger("Run");
    }

}
