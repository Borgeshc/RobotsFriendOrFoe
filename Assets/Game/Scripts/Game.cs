using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PostProcessing;

public class Game : MonoBehaviour
{
    public GameObject walker;
    public GameObject shooter;

    public AudioClip deathSoundClip;
    public AudioSource deathSoundSource;

    public PostProcessingProfile pp_Profile;
    private BloomModel.Settings C_bloom;

    public static int wallJumps = 0;
    public static int ducks = 0;
    public static float timeSurvived = 0;
    private int playingDeath = 0;

    private void Start()
    {
        wallJumps = 0;
        ducks = 0;
        timeSurvived = 0;
        walker = GameObject.Find("Man");
        shooter = GameObject.Find("Player");
        BloomModel.Settings C_bloom = pp_Profile.bloom.settings;
        C_bloom.bloom.intensity = 0f;
        C_bloom.bloom.threshold = 0f;
        C_bloom.bloom.softKnee = 1f;
        C_bloom.bloom.radius = 7f;
        pp_Profile.bloom.settings = C_bloom;
    }

    private void Update()
    {
        if (walker.GetComponent<AutoMove>().isDead || shooter.GetComponent<Movement>().isDead)
        {
            if (playingDeath == 0)
            {
                playingDeath = 1;
                playDeath();
            }
            C_bloom.bloom.intensity += 0.5f;
            pp_Profile.bloom.settings = C_bloom;
            if(C_bloom.bloom.intensity >= 8f)
            {
                C_bloom.bloom.softKnee = 1f;
                C_bloom.bloom.radius = 7f;
                pp_Profile.bloom.settings = C_bloom;
                GameOver();
            }
        }
        else
        {
            timeSurvived += Time.deltaTime / 2;
        }
    }

    private void playDeath()
    {
        deathSoundSource.clip = deathSoundClip;
        deathSoundSource.Play();
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
