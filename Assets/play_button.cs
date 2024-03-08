using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript1 : MonoBehaviour
{
    public void play_game()
    {
        SceneManager.LoadSceneAsync(1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
