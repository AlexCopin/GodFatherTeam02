using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    public void loadLevel()
    {
        SceneManager.LoadScene("Level01");
    }
}
