using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSwordImage : MonoBehaviour
{
    public GameObject swordPrefab; 
    public void getImage(GameObject prefab)
    {
        if(prefab && gameObject)
        {
            Image imageComponent = gameObject.GetComponent<Image>(); 
            if(imageComponent)
            {
                Sprite prefabSprite = prefab.GetComponent<SpriteRenderer>().sprite;
                if(prefabSprite)
                    imageComponent.sprite = prefabSprite; 
            }
        }
        else
            Debug.Log("Error");
    }

    void Start() 
    {
        getImage(swordPrefab);
    }
}
