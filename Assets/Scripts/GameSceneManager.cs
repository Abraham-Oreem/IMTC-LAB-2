using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void LoadSceneByIndex(int i)
    {
        SceneManager.LoadScene(i);
    }
}