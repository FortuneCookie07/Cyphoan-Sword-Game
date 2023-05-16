using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameLimit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int RefreshRate;
    void Start()
    {
        Application.targetFrameRate = RefreshRate; 
    }
}
