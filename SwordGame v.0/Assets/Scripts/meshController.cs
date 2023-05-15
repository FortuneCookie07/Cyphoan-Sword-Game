using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshController : MonoBehaviour
{
    public void meshEnable()
    {
        GameObject.Find("YoneLeagueSword").GetComponent<MeshCollider>().enabled = true; 
    }

    public void meshDisable()
    {
        GameObject.Find("YoneLeagueSword").GetComponent<MeshCollider>().enabled = false; 
    }
}
