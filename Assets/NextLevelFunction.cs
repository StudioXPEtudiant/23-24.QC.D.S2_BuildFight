using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelFunction : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
