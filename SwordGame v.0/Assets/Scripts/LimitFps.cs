using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFps : MonoBehaviour
{
    // Start is called before the first frame update
    public int frameRate = 240; 
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }
}
