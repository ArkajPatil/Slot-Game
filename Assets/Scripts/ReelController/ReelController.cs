
using UnityEngine;
using System;

public class ReelController : MonoBehaviour
{
    [Header("Reel Settings")]
    [SerializeField] private float spinSpeed = 2000f;
    [SerializeField] private float loopDistance = 500f;
    
    private RectTransform symbols;

    private bool isSpinning = false;
    private int spinnedIndex = -1;
    private float loopOffset = 40f;
    private float[] symbolPositions = {500.0f, 125.0f, 250.0f, 375.0f};
    private float deceleration;

    // result event
    public event Action<int> OnReelSpinFinished;

        public AudioSource SpinStartSound ;
        public AudioSource SpinTickSound ;

    private void Awake()
    {
        symbols = GetComponent<RectTransform>();
        StartSpin();
    }

    private void Update()
    {
        if (isSpinning)
        {
            Spin();
        }
    }

    private void Spin()
    {
        // Move the complete symbol strip upward.
        Vector2 position = symbols.anchoredPosition;
        position.y += spinSpeed * Time.deltaTime;

        // Preserve movement even if a frame overshoots the loop point.
        if(position.y >= loopDistance + loopOffset)
        {
            position.y -= loopDistance;
        }

        symbols.anchoredPosition = position;

        //  tick sound - once each time a new symbol slot is pass
        int slot = Mathf.FloorToInt((position.y - loopOffset) / 125f);
        if (slot != lastSlot)
        {
            lastSlot = slot;
            SpinTickSound.PlayOneShot(SpinTickSound.clip, 0.4f);
        }


        // reduce spining speed
        if(spinSpeed > 1.0f)
        {
            spinSpeed -= deceleration * Time.deltaTime;
        }
        else 
        {
            symbols.anchoredPosition += Vector2.down * 3.1f;
            StopSpin();
        }


    }

private int lastSlot;


    public void StartSpin()
    {
        // chose random index
        int randomIndex = UnityEngine.Random.Range(0, 4);
        spinnedIndex = randomIndex;
        float targetPosition = symbolPositions[randomIndex];

        // calculate deceleration
        deceleration = (2000*2000) / (2*(loopDistance*4 + targetPosition));

        isSpinning = true;
        SpinStartSound.Play();   // sound
    }

    private void StopSpin()
    {
        spinSpeed = 0.0f;
        isSpinning = false;

        OnReelSpinFinished?.Invoke(spinnedIndex);
    }
}
