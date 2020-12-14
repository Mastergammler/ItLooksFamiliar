using System;
using UnityEngine.SceneManagement;

namespace ItLooksFamiliar.Core
{
    public class SceneLoader
    {
        private static SceneLoader sInstance;

        //#################
        //##  INTERFACE  ##
        //#################

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
        public void LoadNext()
        {
            LoadLevel(GetCurrentLevel() + 1);
        }

        //#################
        //##  ACCESSORS  ##
        //#################

        public static SceneLoader Instance
        {
            get
            {
                if (sInstance == null) sInstance = new SceneLoader();
                return sInstance;
            }
        }
    }
}