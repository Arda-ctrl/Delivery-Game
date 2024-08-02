using UnityEngine;
using UnityEngine.UI;

public class song : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource; // [SerializeField] olarak tanımlanmış
    public AudioClip[] tracks; // Şarkıları saklayacak dizi
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = musicSource.volume;
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    // Belirli bir şarkıyı çalacak fonksiyon
    public void PlayTrack(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < tracks.Length)
        {
            musicSource.clip = tracks[trackIndex];
            musicSource.Play();
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
