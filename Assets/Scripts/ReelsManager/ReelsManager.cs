using UnityEngine;
using System.Collections;


public class ReelsManager : MonoBehaviour
{
    [Header("Reel References")]
    [SerializeField] private ReelController[] reels;

    [Header("Spin Settings")]
    // [SerializeField] private float stopDelay = 1.0f;

    private int[] reelResults;
    // private int completedReels;

    // sounds
    public AudioSource SpinStartSound ;

    private void Awake()
    {
        reelResults = new int[reels.Length];

        foreach (ReelController reel in reels)
        {
            reel.OnReelSpinFinished += OnReelFinished;
        }

        StartSpin();
    }

    private void OnDestroy()
    {
        foreach (ReelController reel in reels)
        {
            if (reel != null)
                reel.OnReelSpinFinished -= OnReelFinished;
        }
    }

    public void StartSpin()
    {
        if (isSpinning || reels.Length == 0)
        {
            return;
        }

        SpinStartSound.Play();   // sound

        foreach (ReelController reel in reels)
        {
            if (reel != null)
            {
                reel.StartSpin();
            }
        }
    }



    private void OnReelFinished(int result)
    {
        // int index = System.Array.IndexOf(reels, reel);

        // if (index < 0)
        //     return;

        // reelResults[index] = result;
        // completedReels++;
    }
}
