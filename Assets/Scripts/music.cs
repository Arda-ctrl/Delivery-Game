using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    private song audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<song>();
    }

    public void SelectTrack(int trackIndex)
    {
        audioManager.PlayTrack(trackIndex);
    }
}
