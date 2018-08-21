using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {

        SceneManager.LoadScene("Level1");

    }

    public void Level1()
    {

        SceneManager.LoadScene("Level1");

    }

    public void Level2()
    {

        SceneManager.LoadScene("Level2");

    }

    public void Level3()
    {

        SceneManager.LoadScene("Level3");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
