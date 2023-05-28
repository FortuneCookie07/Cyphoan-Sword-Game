using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSelect : MonoBehaviour
{
    public GameObject _swordSelectCanvas;
    public static bool isSelecting = true;
    public static int swordSelection; 

    public void selectWeapon(int swordID)
    {
        swordSelection = swordID; 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _swordSelectCanvas.SetActive(false);
        isSelecting = false;
        SwordManager.swordInit();
    }

    void Start() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
