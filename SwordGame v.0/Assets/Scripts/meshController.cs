using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshController : MonoBehaviour
{
    /*
        Eventually we need to change it from GameObject.Find to something more general
    */
    private MeshCollider mesh; 
    public void meshEnable()
    {
        mesh = swordStruct.playerSword.prefab.GetComponent<MeshCollider>();
        mesh.enabled = true; 
    }

    public void meshDisable()
    {
        mesh.enabled = false; 
    }
}
