using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script holds the references to all the Text, Images on the card.
/// </summary>
public class OneCardManager : MonoBehaviour
{
    public CardAsset cardAsset;
    public OneCardManager PreviewManager;
    [Header("Text Component References")]
    public Text NameText;
    public Text ManaCostText;
    public Text DescriptionText;
    public Text HealthText;
    public Text AttackText;
    [Header("Image References")] // todo: this will slightly change
    public Image CardTopRibbonImage;
    public Image CardLowRibbonImage;
    public Image CardGraphicsImage;
    public Image CardBodyImage;
    public Image CardFaceFrameImage;
    public Image CardFaceGlowImage;
    public Image CardBackGlowImage;

    private void Awake()
    {
        if(cardAsset != null)
        {
            ReadCardFromAsset();
        }
    }

    private bool canBePlayedNow = false;
    public bool CanBePlayedNow 
    {
        get 
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;
            CardFaceGlowImage.enabled = value;
        }
    }

    public void ReadCardFromAsset()
    {
        // universal actions for any Card.
        // #1. apply tint
        if(cardAsset.characterAsset != null)
        {
            CardBodyImage.color = cardAsset.characterAsset.ClassCardTint;
            CardFaceFrameImage.color = cardAsset.characterAsset.ClassCardTint;
            CardTopRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
            CardLowRibbonImage.color = cardAsset.characterAsset.ClassRibbonsTint;
        }
        else
        {
           // CardBodyImage.color = GlobalSettings.Instance.CardBodyStandardColor;
            CardFaceFrameImage.color = Color.white;
           // CardTopRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
           // CardLowRibbonImage.color = GlobalSettings.Instance.CardRibbonsStandardColor;
        }
        // #2. add card name
        NameText.text = cardAsset.name;
        // #3. add mana cost
        ManaCostText.text = cardAsset.ManaCost.ToString();
        // #4. add description
        DescriptionText.text = cardAsset.Description;
        // #5. change the card graphic sprite
        CardGraphicsImage.sprite = cardAsset.CardImage;

        if(cardAsset.MaxHealth != 0)
        {
            AttackText.text = cardAsset.Attack.ToString();
            HealthText.text = cardAsset.MaxHealth.ToString();
        }

        if(PreviewManager != null)
        {
            // this is a card and not a preview
            // Preview GameObject will have OneCardManager as well, but PreviewManager should be null there
            PreviewManager.cardAsset = cardAsset;
            PreviewManager.ReadCardFromAsset();
        }
    }
    

    
}
