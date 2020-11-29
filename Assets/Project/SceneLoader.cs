
using System;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private static SceneLoader sInstance;


    //#################
    //##  INTERFACE  ##
    //#################

    //todo load next level funciton
    //todo make this loader handle what level is next?!
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }

    public void ReloadActiveLevel()
    {
        LoadLevel(GetCurrentLevel());
    }

    public int GetCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public static SceneLoader Instance
    {
        get
        {
            if (sInstance == null) sInstance = new SceneLoader();
            return sInstance;
        }
    }

    public void LoadNext()
    {
        LoadLevel(GetCurrentLevel() + 1);
    }
}