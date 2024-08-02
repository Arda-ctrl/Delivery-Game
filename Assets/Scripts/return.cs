using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isInMainMenu = false;
    private string previousScene = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInMainMenu)
            {
                ReturnToGame();
            }
            else
            {
                GoToMainMenu();
            }
        }
    }

    public void GoToMainMenu()
    {
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Menu");
        isInMainMenu = true;
    }

    public void ReturnToGame()
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
            isInMainMenu = false;
        }
    }
}
