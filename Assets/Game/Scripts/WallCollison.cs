using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollison : MonoBehaviour {
    public enum WallDirection { Left, Right, Top, Bot };
    public WallDirection currWallDirection;

    public WallDirection getWallDirection(){
        return currWallDirection;
    }
   
}
