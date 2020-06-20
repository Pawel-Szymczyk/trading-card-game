using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class will show damage dealt to creatures or player
/// </summary>
public class DamageEffect : MonoBehaviour
{
    // an array of sprites with different blood splash graphics 
    public Sprite[] splashes;

    // a UI image to show the blood splashes
    public Image damageImage;

    // CanvasGroup should be attached to the Canvas of this damage effect
    // It is used to fade away the alpha value of this effect
    public CanvasGroup cg;

    // The text component to show the amount of damage taken by target like: "-2"
    public Text AmountText;

    private void Awake()
    {
        // pick random image
        damageImage.sprite = splashes[Random.Range(0, splashes.Length)];
    }

    // A Coroutinen to control the fading of this damage effect
    private IEnumerator ShowDamageEffect()
    {
        // make this effect non-transparent
        cg.alpha = 1f;

        // wait for 1s before fading
        yield return new WaitForSeconds(1f);

        // gradually fade the effect by changing its alpha value
        while(cg.alpha > 0)
        {
            cg.alpha -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }

        // after the effect is shown it gets destroyed.
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Creates the damage effect.
    /// This is static method, so it should be called like this: 
    /// DamageEffect.CreateDamageEffect(transform.position, 5)
    /// </summary>
    /// <param name="position">position</param>
    /// <param name="amount">amount</param>
    public static void CreateDamageEffect(Vector3 position, int amount)
    {
        // Instantiate a damage effect from prefab
        GameObject newDamageEffect = new GameObject();
        // TODO  = GameObject.Instantiate(GlobalSettings.Instance.DamageEffectPrefab, position, Quaternion.identity) as GameObject;

        // get damage effect component in this new game obj
        DamageEffect de = newDamageEffect.GetComponent<DamageEffect>();

        // change the amount text to reflect the amount of damage dealt
        de.AmountText.text = "-" + amount.ToString();

        // start a corutine to fade away and delete this effect after a certain time
        de.StartCoroutine(de.ShowDamageEffect());
    }

}
