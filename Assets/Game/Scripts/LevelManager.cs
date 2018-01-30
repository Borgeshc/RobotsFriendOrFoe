using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	public int sceneToLoad;
    public Image loadBar;

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
                if (GetCurrentScene () + 1 == SceneManager.sceneCountInBuildSettings)
			    sceneToLoad = 0;
		    else
			    sceneToLoad = GetCurrentScene () + 1;

		    StartCoroutine (LoadNextScene ());
        }
    }

	IEnumerator LoadNextScene ()
	{
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
            loadBar.fillAmount = async.progress;
            while (!async.isDone)
            {

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