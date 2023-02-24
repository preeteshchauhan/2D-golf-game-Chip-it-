using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Sceneloader : MonoBehaviour
{
    

    float time,seconds;
    [SerializeField]
    public Image filledimage;

    void Start()
    {
        seconds = 5;
        Invoke("gameload",5f);
    }
    void Update ()
    {
        if(time<5)
        {
            time += Time.deltaTime;
            filledimage.fillAmount = time/seconds;

            
        }

    }
    
   public void gameload()
   {
    SceneManager.LoadScene(1);
   }

   /*
   public GameObject loadingScreen;
    public Slider loadingbar;
   
    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            loadingbar.value = operation.progress;
            yield return null;
        }
    }*/
}
