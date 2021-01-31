using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    void reloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
