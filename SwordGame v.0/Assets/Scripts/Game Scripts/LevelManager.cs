using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject _loaderCanvas;
    [SerializeField] private GameObject _progressBar;

    void Awake() {
        if (Instance == null){
            Instance = this; 
            DontDestroyOnLoad(gameObject);              
        }
        else{
            Destroy(gameObject); 
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));   
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);

        _loaderCanvas.SetActive(true);

        while(!scene.isDone)
        {
            float progressValue = Mathf.Clamp01(scene.progress / 0.9f);

            _progressBar.GetComponent<Slider>().value = progressValue;

            yield return null; 
        }

        _loaderCanvas.SetActive(false);
    }
}
