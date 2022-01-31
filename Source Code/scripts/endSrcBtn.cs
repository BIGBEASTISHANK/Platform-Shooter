using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endSrcBtn : MonoBehaviour
{
    public void backToHome(){
        SceneManager.LoadScene(0);
    }

    public void quitGame(){
        Application.Quit();
    }
}
