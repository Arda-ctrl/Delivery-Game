using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Delivery : MonoBehaviour
{
    public Text messageText1; 
    public Text messageText2;
    public Text scoreText; // Skoru gösterecek Text bileşeni
    public float displayDuration = 5f;
    public AudioSource audioSource; // AudioSource referansı
    public AudioClip packageSound;  // Paket alındığında çalacak ses
    public AudioClip customerSound; // Müşteri ile etkileşimde çalacak ses

    private int score = 0; // Başlangıçta skor 0
    bool hasPackage;
    [SerializeField] float time = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasnoPackageColor = new Color32(255, 255, 255, 255);
    
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();      
        if (messageText1 != null) messageText1.gameObject.SetActive(false); // Başlangıçta mesaj gizli  
        if (messageText2 != null) messageText2.gameObject.SetActive(false);    
        
        if (scoreText != null) scoreText.text = "Score: " + score; // Skoru göster
        
        // Eğer audioSource veya audio clip atanmadıysa, hata mesajı göster
        if (audioSource == null)
        {
            Debug.LogError("AudioSource is not assigned.");
        }
        if (packageSound == null)
        {
            Debug.LogError("PackageSound is not assigned.");
        }
        if (customerSound == null)
        {
            Debug.LogError("CustomerSound is not assigned.");
        }
    }

    public void ShowMessage(Text messageText)
    {
        StartCoroutine(ShowMessageCoroutine(messageText));
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "package")
        {
            Debug.Log("keep package");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, time);
            
            // Paket alındıktan sonra mesajı göster ve ses çal
            ShowMessage(messageText1);
            PlayPackageSound();
        }

        if (other.tag == "customer" && hasPackage)
        {
            Debug.Log("You delivered the package");
            spriteRenderer.color = hasnoPackageColor;
            hasPackage = false;
            Destroy(other.gameObject, time);
            ShowMessage(messageText2);
            PlayCustomerSound();
            IncreaseScore();
        }
    }

    private IEnumerator ShowMessageCoroutine(Text messageText)
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true); // Metni görünür yap
            yield return new WaitForSeconds(displayDuration); // Belirli bir süre bekle
            messageText.gameObject.SetActive(false); // Metni gizle
        }
        else
        {
            Debug.LogError("MessageText is not assigned.");
        }
    }

    private void PlayPackageSound()
    {
        if (audioSource != null && packageSound != null)
        {
            audioSource.PlayOneShot(packageSound); // Paket ses dosyasını çal
        }
        else
        {
            Debug.LogError("AudioSource or PackageSound is not assigned.");
        }
    }

    private void PlayCustomerSound()
    {
        if (audioSource != null && customerSound != null)
        {
            audioSource.PlayOneShot(customerSound); // Müşteri ses dosyasını çal
        }
        else
        {
            Debug.LogError("AudioSource or CustomerSound is not assigned.");
        }
    }

    private void IncreaseScore()
    {
        score += 1; // Skoru artır
        if(score==5){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Skoru güncelle
        }
    }
}
