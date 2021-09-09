using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("Level01");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
