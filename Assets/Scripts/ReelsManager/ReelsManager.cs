using UnityEngine;
using System.Collections;

public class ReelsManager : MonoBehaviour
{
    [Header("Reel References")]
    [SerializeField] private ReelController[] reels;

    [Header("Spin Settings")]
    // [SerializeField] private float stopDelay = 1.0f;

    private int[] reelResults;
    private int completedReels = 0;
    private bool isSpinning = false;

    // sounds
    public AudioSource SpinStartSound ;

    [SerializeField] private AnimationManager animationManager;

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

        isSpinning = true;
    }



    private void OnReelFinished(int result)
    {
        reelResults[completedReels] = result;
        completedReels++;
    }

    private void Update()
    {
        if(completedReels >= 3)
        {
            SpinCompleted();
        }
    }

    private void SpinCompleted()
    {
        isSpinning = false;
        completedReels = 0;
        
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
}
