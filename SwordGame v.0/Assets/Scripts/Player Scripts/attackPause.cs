using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackPause : MonoBehaviour
{
    public static bool isAnimation = false;
    void pausePlayer()
    {
        isAnimation = true;
    }
    void playPlayer()
    {
        isAnimation = false; 
    }
}
