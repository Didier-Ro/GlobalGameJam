using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }
}
