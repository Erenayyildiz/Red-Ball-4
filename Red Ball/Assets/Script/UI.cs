using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Slider healtSlider;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score;

    Health health;

    void Awake()
    {
        health = FindObjectOfType<Health>();
    }

    void Start()
    {
        healtSlider.maxValue = health.GetHealth();
        scoreText.text = score.ToString();
    }

    void Update()
    {
        healtSlider.value = health.GetHealth();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }
}
