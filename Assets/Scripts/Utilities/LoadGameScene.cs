using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] private Button _startButon;
    [SerializeField] private Text _text;  

    public void LoadScene(string sceneName)
    {
        TurnOnLoadingSignal();
        StartCoroutine(LoadYourAsyncScene(sceneName));
        //SceneManager.LoadScene("Test"); 
    }

    public void TurnOnLoadingSignal()
    {
        _text.gameObject.SetActive(true);
    }
    
    private IEnumerator LoadYourAsyncScene(string sceneName)
    {

        yield return new WaitForSeconds(3);
        
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            Debug.Log("Empiezo a cargar");
            yield return null;
        }
        
        Debug.Log("Termine de cargar el juego");
        
        asyncLoad.allowSceneActivation = true;
    }
}
