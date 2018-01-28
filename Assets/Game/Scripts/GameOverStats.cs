using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverStats : MonoBehaviour
{
    public Text jumpedObjects;
    public Text duckedObjects;
    public Text killedObjects;
    public Text timeSurvived;
    public static int totalNumberDead ;

	// Use this for initialization
	void Start ()
    {
        jumpedObjects.text = "" + Game.wallJumps;
        duckedObjects.text = "" + Game.ducks;
        killedObjects.text = "" + totalNumberDead;
        timeSurvived.text = "" + (int) Game.timeSurvived + " Seconds";
        totalNumberDead = 0;
	}
}
