﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    bool clicked;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGame()
    {
        if(!clicked)
        {
            clicked = true;
            SceneManager.LoadScene("Game");
        }
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings"); // Could use Text Items instead and enable/disable them
    }

    public void Quit()
    {
        Application.Quit();
    }
}
