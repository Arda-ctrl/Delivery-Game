
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
        public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
    
}
