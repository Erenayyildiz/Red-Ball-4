using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    public void LoadLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("SampleScene 2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("SampleScene 3");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene 4");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Level()
    {
        SceneManager.LoadScene("SampleScene 4");
    }

    public void Home()
    {
        SceneManager.LoadScene("SampleScene 1");
    }

    public void LoadGame()
    {
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(delay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextsceneýndex = currentSceneIndex;

        if (nextsceneýndex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceneýndex = 0;
        }
        SceneManager.LoadScene(nextsceneýndex);
    }

}
