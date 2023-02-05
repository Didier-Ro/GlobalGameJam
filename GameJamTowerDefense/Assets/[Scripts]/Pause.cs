using UnityEngine;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        Debug.Log(Time.timeScale);
    }
}
