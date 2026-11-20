
using UnityEngine;

public class ReelController : MonoBehaviour
{
    [Header("Reel Settings")]
    [SerializeField] private float spinSpeed = 1000f;
    [SerializeField] private float loopDistance = 500f;
    
    private float loopOffset = 40f;
    private RectTransform symbols;
    private bool isSpinning = false;

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
    }

    public void StartSpin()
    {
        isSpinning = true;
    }

    public void StopSpin()
    {
        isSpinning = false;
    }
}
