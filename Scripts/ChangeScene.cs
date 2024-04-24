using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public static int points = 0;
    public static int timer = 180;
    public string scene = "Instruct";

    // Called when the button using this script is pressed    
    public void PlayGame()
    {
        points = 0;
        timer = 180;
        SceneManager.LoadScene(scene);
    }
}
