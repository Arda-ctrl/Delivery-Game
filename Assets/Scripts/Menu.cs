using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button returnButton; // Buton referansı
    [SerializeField] private AudioSource musicSource; // Müzik referansı
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
           // returnButton.gameObject.SetActive(!string.IsNullOrEmpty(gameManager.previousScene));
        }
        else
        {
            returnButton.gameObject.SetActive(false); // GameManager bulunamazsa butonu gizle
        }

        // Müzik kontrolü
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); // Oyun sahnesinin adı
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager != null)
            {
                gameManager.ReturnToGame();
            }
        }
    }
}
