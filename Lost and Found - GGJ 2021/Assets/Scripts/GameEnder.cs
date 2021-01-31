using System.Collections;
using UnityEngine;


public class GameEnder : MonoBehaviour
{

    public void QuitGame()
    {
#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
