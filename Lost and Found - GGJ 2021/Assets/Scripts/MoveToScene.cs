using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveToScene : MonoBehaviour
{
    public string sceneToMoveTo;
    public void moveToScene()
    {
        SceneManager.LoadScene(sceneToMoveTo);
    }
}
