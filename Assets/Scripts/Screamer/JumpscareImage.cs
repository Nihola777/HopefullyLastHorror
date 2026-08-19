using UnityEngine;
using UnityEngine.UI;

public class JumpscareImage : MonoBehaviour
{
    [Header("UI")]
    public GameObject jumpscareImage;   // Fullscreen UI Image

    [Header("Audio")]
    public AudioSource screamSound;
    public AudioSource subBassSound;

    [Header("Settings")]
    public float delay = 0f;
    public float visibleDuration = 0.5f;

    private bool triggered = false;

    void Start()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (triggered || !other.CompareTag("Player"))
            return;

        triggered = true;
        Invoke(nameof(ShowJumpscare), delay);
    }

    void ShowJumpscare()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(true);

        if (screamSound != null)
            screamSound.Play();

        if (subBassSound != null)
            subBassSound.Play();

        if (CameraShake.Instance != null)
            CameraShake.Instance.Shake(0.3f, 0.15f);

        Invoke(nameof(HideJumpscare), visibleDuration);
    }

    void HideJumpscare()
    {
        if (jumpscareImage != null)
            jumpscareImage.SetActive(false);
    }
}