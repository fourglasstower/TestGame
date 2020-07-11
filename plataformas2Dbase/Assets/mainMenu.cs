using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    [SerializeField] private float delay = 1f;

    //function to be called on button click
    public void playGame()
    {
        StartCoroutine(LevelLoad());
    }

    //load level after one sceond delay
    IEnumerator LevelLoad()
    {

        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 

    public void quitGame() {
        Debug.Log("Exiting the game");
        Application.Quit();
    }

}
