using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ResetGameScene : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
