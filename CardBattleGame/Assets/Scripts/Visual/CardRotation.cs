using System.Collections;
using UnityEngine;

/// <summary>
/// This script should be attached to the card game object to display card's rotation correctly.
/// </summary>

[ExecuteInEditMode]
public class CardRotation : MonoBehaviour
{
    /// <summary>
    /// Parent game object for all the card face graphics.
    /// </summary>
    public RectTransform CardFront;

    /// <summary>
    /// Parent game object for all the card back graphics.
    /// </summary>
    public RectTransform CardBack;

    /// <summary>
    /// An empty game object that is placed a bit above the face of the card, in the center of the card.
    /// </summary>
    public Transform targetFacePoint;

    /// <summary>
    /// 3D collider attached to the card.
    /// </summary>
    public Collider cardCollider;

    /// <summary>
    /// If this is true, our players currently see the card Back.
    /// </summary>
    private bool showingBack = false;

    void Update()
    {
        // Raycast from Camera to a target point on the face of the card 
        // If it passes through the card's collider, we should show the back of the card.
        RaycastHit[] hits;
        hits = Physics.RaycastAll(origin: Camera.main.transform.position,
            direction: (-Camera.main.transform.position + targetFacePoint.position).normalized,
            maxDistance: (-Camera.main.transform.position + targetFacePoint.position).magnitude);

        bool passedThroughColliderOnCard = false;
        foreach(RaycastHit hit in hits)
        {
            if(hit.collider == cardCollider)
            {
                passedThroughColliderOnCard = true;
            }
        }

        if(passedThroughColliderOnCard != showingBack)
        {
            // sth changed
            showingBack = passedThroughColliderOnCard;
            if(showingBack)
            {
                // show the back side
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
            else
            {
                // show the front side
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }
        }
    }
}
