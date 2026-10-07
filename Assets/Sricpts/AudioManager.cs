using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Paddle Hit Sounds")]
    [SerializeField] private AudioClip[] paddleHitSounds;

    [Header("Winner Sound")]
    [SerializeField] private AudioClip winnerSound;

    private AudioSource sfxSource;

    private bool isSoundOn = true;

    private void Awake()
    {
        // SFX AudioSource
        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;
    }

    // ==========================================
    // PADDLE HIT SOUND
    // ==========================================

    public void PlayPaddleHitSound()
    {
        if (!isSoundOn)
            return;

        if (paddleHitSounds == null || paddleHitSounds.Length == 0)
            return;

        int randomIndex = Random.Range(0, paddleHitSounds.Length);

        sfxSource.PlayOneShot(paddleHitSounds[randomIndex]);
    }

    // ==========================================
    // WINNER SOUND
    // ==========================================

    public void PlayWinnerSound()
    {
        if (!isSoundOn)
            return;

        if (winnerSound != null)
        {
            sfxSource.PlayOneShot(winnerSound);
        }
    }

    // ==========================================
    // SOUND TOGGLE
    // ==========================================

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        sfxSource.mute = !isSoundOn;
    }
}