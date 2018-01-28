using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject walker;
    public GameObject shooter;

    public static int wallJumps = 0;
    public static int ducks = 0;
    public static float timeSurvived = 0;

    private void Start()
    {
        wallJumps = 0;
        ducks = 0;
        timeSurvived = 0;
        walker = GameObject.Find("Man");
        shooter = GameObject.Find("Player");
    }

    private void Update()
    {
        if (walker.GetComponent<AutoMove>().isDead || shooter.GetComponent<Movement>().isDead)
        {
            GameOver();
        }
        timeSurvived += Time.deltaTime / 2;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
