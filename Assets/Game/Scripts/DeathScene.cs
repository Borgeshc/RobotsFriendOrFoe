using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
    public Animator floatAnim;
    public Rotate rotater;
    public Fade fader;

    Animator anim;
    Transform body;

    private void Start()
    {
        anim = GetComponent<Animator>();
        body = floatAnim.transform;
    }

    public void GrabRobot()
    {
        anim.SetTrigger("Grab");
    }

    public void Grabbed()
    {
        floatAnim.enabled = false;
        rotater.enabled = false;
        body.parent = transform;
     
        print("Grabbed");
    }

    public void Pull()
    {
        anim.SetTrigger("Pull");
        fader.FadeToBlack();

        Destroy(gameObject, 4);
    }
}
