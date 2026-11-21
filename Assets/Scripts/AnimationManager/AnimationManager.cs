using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject gamePanel;
    public GameObject gameWonPanel;
    public GameObject gameLosePanel;

    [Header("Buttons")]
    public GameObject spinButton;
    public GameObject resetReelsButton;

    public GameObject lever;
    public GameObject lever1;

    [Header("Panel Images (For Fading)")]
    public Image gameWonImage;
    public Image gameLoseImage;

    [Header("Animation Settings")]
    public float fadeDuration = 3.5f; 

    // sounds
    [Header("Sounds")]
    [SerializeField] private AudioSource WinSound ;
    [SerializeField] private AudioSource LoseSound ;
    

    
    public void ShowGameWonAnimation()
    {
        StopAllCoroutines(); // Prevents overlapping animations if called more than once
        WinSound.Play();
        StartCoroutine(PlayPanelFadeSequence(gameWonPanel, gameWonImage));
    }


    public void ShowGameLoseAnimation()
    {
        StopAllCoroutines();
        LoseSound.Play();
        StartCoroutine(PlayPanelFadeSequence(gameLosePanel, gameLoseImage));
    }

    private IEnumerator PlayPanelFadeSequence(GameObject targetPanel, Image targetImage)
    {
        // Deactivate main game panel and ensure the other end panel is hidden
        gamePanel.SetActive(false);
        gameWonPanel.SetActive(false);
        gameLosePanel.SetActive(false);

        // activate the target panel -Won or Lose
        targetPanel.SetActive(true);

        // Set image to fully visible (Alpha = 1) at the start
        Color tempColor = targetImage.color;
        tempColor.a = 1f;
        targetImage.color = tempColor;

        // Gradually reduce alpha from 1 to 0 over 3.5 seconds
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            tempColor.a = Mathf.Clamp01(newAlpha);
            targetImage.color = tempColor;

            yield return null; // Wait for the next frame
        }

        tempColor.a = 0f;
        targetImage.color = tempColor;

        // deactivate the Won/Lose panel and bring back the main Game Panel
        targetPanel.SetActive(false);
        gamePanel.SetActive(true);

        // changing buttons
        spinButton.SetActive(false);
        resetReelsButton.SetActive(true);
    }

    public void ReelsReseted()
    {
        spinButton.SetActive(true);
        resetReelsButton.SetActive(false);

        
        lever1.SetActive(false);
        lever.SetActive(true);
    }
}
