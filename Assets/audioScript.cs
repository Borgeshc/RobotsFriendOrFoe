using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour
{

    public AudioClip[] audioclips;
    public AudioSource audioSource;
    public AudioSource music;
    public int inBetweenPause;
    public float timeToNext = 0f;
    public bool repeat;
    private bool playonce;

    private int randomClip;

    private void Start()
    {
        playonce = true;
    }
    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(speakNow());
        if (music.volume < 0.6f)
        {
            music.volume += 0.05f;
        }
        if (repeat)
        {
            timeToNext += Time.deltaTime;
            if (timeToNext >= inBetweenPause * 2)
            {
                randomClip = Random.Range(0, audioclips.Length);
                audioSource.clip = audioclips[randomClip];
                music.volume = 0.4f;
                audioSource.Play();
                timeToNext = 0f;
            }
        }
        else
        {
            if (playonce)
            {
                randomClip = Random.Range(0, audioclips.Length);
                audioSource.clip = audioclips[randomClip];
                audioSource.Play();
                playonce = false;
            }

        }
    }

}