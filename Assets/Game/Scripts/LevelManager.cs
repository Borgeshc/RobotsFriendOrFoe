using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public int sceneToLoad;
    public Image loadBar;
    public Text loadText;

    bool clicked;

	public void ReloadLevel ()
	{
		SceneManager.LoadScene (GetCurrentScene ());
	}

	public void LoadNextLevel ()
    {
        if (!clicked)
        {
            clicked = true;
            loadText.gameObject.SetActive(true);

            if (GetCurrentScene () + 1 == SceneManager.sceneCountInBuildSettings)
			    sceneToLoad = 0;
		    else
			    sceneToLoad = GetCurrentScene () + 1;

		    StartCoroutine (LoadNextScene ());
        }
    }

	IEnumerator LoadNextScene ()
	{
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        
        while (!operation.isDone)
        {
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			//loadBar.fillAmount = progress;
            loadText.text = (int)(progress * 100)+ "%";
            yield return null;
        }
	}

	public void LoadMainMenu ()
	{
		//SceneManager.LoadScene (0);
		sceneToLoad = 0;
		StartCoroutine (LoadNextScene ());
	}

	int GetCurrentScene ()
	{
		return SceneManager.GetActiveScene ().buildIndex;
	}
}