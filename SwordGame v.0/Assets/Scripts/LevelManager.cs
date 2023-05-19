using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    void Awake() {
        if (Instance == null){
            Instance = this; 
            DontDestroyOnLoad(gameObject);              
        }
        else{
            Destroy(gameObject); 
        }
    }

    public async void LoadScene(string sceneName){

        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false; 

        do {
             
        } while (scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true; 
    }
}
