using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Delivery : MonoBehaviour
{
    public Text messageText1; 
    public Text messageText2;
    public float displayDuration = 5f;
    bool hasPackage;
    [SerializeField] float time = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] Color32 hasnoPackageColor = new Color32(255, 255, 255, 255);
    public AudioSource audioSource; // AudioSource referansı
    public AudioClip packageSound;
     public AudioClip customerSound;
    
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();      
        if (messageText1 != null) messageText1.gameObject.SetActive(false); // Başlangıçta mesaj gizli  
        if (messageText2 != null) messageText2.gameObject.SetActive(false);    
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
            PlayPackageSound();
            // Paket alındıktan sonra mesajı göster
            ShowMessage(messageText1);
        }

        if (other.tag == "customer" && hasPackage)
        {
            Debug.Log("You delivered the package");
            spriteRenderer.color = hasnoPackageColor;
            hasPackage = false;
            ShowMessage(messageText2);
            PlayCustomerSound();
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
            audioSource.PlayOneShot(packageSound); // Ses dosyasını çal
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is not assigned.");
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
}
