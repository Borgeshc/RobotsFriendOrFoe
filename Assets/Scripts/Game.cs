using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject walker;
    public GameObject shooter;

    private void Start()
    {
        walker = GameObject.Find("Man");
        shooter = GameObject.Find("Player");
    }

    private void Update()
    {
        if(walker.GetComponent<AutoMove>().isDead)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
