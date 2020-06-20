using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class PlayerPortraitVisual : MonoBehaviour
{
    public CharacterAsset characterAsset;

    [Header("Text Component References")]
    // public Text NameText;
    public Text HealthText;

    [Header("Image References")]
    public Image HeroPowerIconImage;
    public Image HeroPowerBackgroundImage;
    public Image PortraitImage;
    public Image PortraitBackgroundImage;

    private void Awake()
    {
        if (characterAsset != null)
            ApplyLookFromAsset();
    }

    public void ApplyLookFromAsset()
    {
        HealthText.text = characterAsset.MaxHealth.ToString();
        HeroPowerIconImage.sprite = characterAsset.HeroPowerIconImage;
        HeroPowerBackgroundImage.sprite = characterAsset.HeroPowerBGImage;
        PortraitImage.sprite = characterAsset.AvatarImage;
        PortraitBackgroundImage.sprite = characterAsset.AvatarBGImage;

        HeroPowerBackgroundImage.color = characterAsset.HeroPowerBGTint;
        PortraitBackgroundImage.color = characterAsset.AvatarBGTint;
    }

    public void TakeDamage(int amount, int healthAfter)
    {
        if (amount > 0)
        {
            // TODO DamageEffect.CreateDamageEffect(transform.position, amount);
            HealthText.text = healthAfter.ToString();
        }
    }

    public void Explode()
    {
        // TODO
        //Instantiate(GlobalSettings.Instance.ExplosionPrefab, transform.position, Quaternion.identity);
        //Sequence s = DOTween.Sequence();
        //s.PrependInterval(2f);
        //s.OnComplete(() =? GlobalSettings.Instance.GameOverCanvas.SetActive(true));
    }
}
