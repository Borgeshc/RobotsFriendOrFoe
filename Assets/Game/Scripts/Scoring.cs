using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Game.wallJumps++;
        }

        else if (other.gameObject.tag == "Duckable")
        {
            Game.ducks++;
        }
    }
}
