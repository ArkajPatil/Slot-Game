using UnityEngine;  
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ReelsManager reelsManager;
    public static event Action OnSpinStarted;

    public GameObject lever;
    public GameObject lever1;

    public void StartSpin()
    {
        OnSpinStarted?.Invoke();
        lever1.SetActive(true);
        lever.SetActive(false);
    }

    public void ResetReels()
    {
        reelsManager.ResetReels();

    }
}