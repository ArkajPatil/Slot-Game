using UnityEngine;
using System.Collections;

public class ReelsManager : MonoBehaviour
{
    [Header("Reel References")]
    [SerializeField] private ReelController[] reels;

    [Header("Spin Settings")]

    private int[] reelResults;
    private int spinCompletedReels = 0;
    private int resetCompletedReels = 0;
    private bool isSpinning = false;
    private GameManager gameManager;

    // sounds
    public AudioSource SpinStartSound ;

    [SerializeField] private AnimationManager animationManager;

    private void Awake()
    {
        reelResults = new int[reels.Length];

        foreach (ReelController reel in reels)
        {
            reel.OnReelSpinFinished += OnReelFinished;
            reel.OnResetReelFinished += OnResetReelFinished;
        }

        GameManager.OnSpinStarted += StartSpin;
        

    }

    private void OnDestroy()
    {
        foreach (ReelController reel in reels)
        {
            if (reel != null)
            {
                reel.OnReelSpinFinished -= OnReelFinished;
                reel.OnResetReelFinished -= OnResetReelFinished;
            }
        }

        GameManager.OnSpinStarted -= StartSpin;
    }

    private void OnReelFinished(int result)
    {
        reelResults[spinCompletedReels] = result;
        spinCompletedReels++;
    }

    private void OnResetReelFinished()
    {
        resetCompletedReels++;

        if(resetCompletedReels == 3)
        {
            animationManager.ReelsReseted();
        }
    }

    private void Update()
    {
        if(spinCompletedReels == 3 && isSpinning)
        {
            SpinCompleted();
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

        isSpinning = true;
    }

    private void SpinCompleted()
    {
        isSpinning = false;
        spinCompletedReels = 0;
        
        // evaluating results
        if(ResultEvaluator.IsWinningCombination(reelResults))
        {
            animationManager.ShowGameWonAnimation();
        }
        else
        {
            animationManager.ShowGameLoseAnimation();
        }
    }

    public void ResetReels()
    {
        resetCompletedReels = 0;
        foreach (ReelController reel in reels)
        {
            if (reel != null)
            {
                reel.ResetReel();
            }
        }
    }
}
