using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource walking, sprinting, swordswoosh;

    void Update()
    {
          if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            if (Input.GetKey(KeyCode.LeftShift))
            {
                walking.enabled = false;
                sprinting.enabled = true;
            }
            else
            {
                walking.enabled = true;
                sprinting.enabled = false;
            }
        }
        else
        {
            walking.enabled = false;
            sprinting.enabled = false;
        }

    }
}
