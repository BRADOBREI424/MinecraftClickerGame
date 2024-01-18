using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenceLoad : MonoBehaviour
{
   public void LoadScence(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
