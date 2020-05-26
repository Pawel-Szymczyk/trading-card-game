using DG.Tweening;
using UnityEngine;

public class HoverPreview : MonoBehaviour
{
    // PUBLIC FIELDS
    public GameObject TurnThisOffWhenPreviewing;  // if this is null, will not turn off anything 
    public Vector3 TargetPosition;
    public float TargetScale;
    public GameObject previewGameObject;
    public bool ActivateInAwake = false;

    // PRIVATE FIELDS
    private static HoverPreview currentlyViewing = null;

    // PROPERTIES WITH UNDERLYING PRIVATE FIELDS
    private static bool _PreviewsAllowed = true;
    public static bool PreviewsAllowed
    {
        get => _PreviewsAllowed;

        set
        {
            _PreviewsAllowed = value;
            if (!_PreviewsAllowed)
                StopAllPreviews();
        }
    }

    private bool _thisPreviewEnabled = false;
    public bool ThisPreviewEnabled
    {
        get => this._thisPreviewEnabled;

        set
        {
            this._thisPreviewEnabled = value;
            if (!this._thisPreviewEnabled)
                this.StopThisPreview();
        }
    }

    public bool OverCollider { get; set; }

    // MONOBEHVIOUR METHODS
    private void Awake()
    {
        this.ThisPreviewEnabled = this.ActivateInAwake;
    }

    private void OnMouseEnter()
    {
        this.OverCollider = true;
        if (PreviewsAllowed && this.ThisPreviewEnabled)
            this.PreviewThisObject();
    }

    private void OnMouseExit()
    {
        this.OverCollider = false;

        if (!PreviewingSomeCard())
            StopAllPreviews();
    }

    // OTHER METHODS
    private void PreviewThisObject()
    {
        // 1) clone this card 
        // first disable the previous preview if there is one already
        StopAllPreviews();
        // 2) save this HoverPreview as curent
        currentlyViewing = this;
        // 3) enable Preview game object
        this.previewGameObject.SetActive(true);
        // 4) disable if we have what to disable
        if (this.TurnThisOffWhenPreviewing != null)
            this.TurnThisOffWhenPreviewing.SetActive(false);
        // 5) tween to target position
        this.previewGameObject.transform.localPosition = Vector3.zero;
        this.previewGameObject.transform.localScale = Vector3.one;

        this.previewGameObject.transform.DOLocalMove(this.TargetPosition, 1f).SetEase(Ease.OutQuint);
        this.previewGameObject.transform.DOScale(this.TargetScale, 1f).SetEase(Ease.OutQuint);
    }

    private void StopThisPreview()
    {
        this.previewGameObject.SetActive(false);
        this.previewGameObject.transform.localScale = Vector3.one;
        this.previewGameObject.transform.localPosition = Vector3.zero;
        if (this.TurnThisOffWhenPreviewing != null)
            this.TurnThisOffWhenPreviewing.SetActive(true);
    }

    // STATIC METHODS
    private static void StopAllPreviews()
    {
        if (currentlyViewing != null)
        {
            currentlyViewing.previewGameObject.SetActive(false);
            currentlyViewing.previewGameObject.transform.localScale = Vector3.one;
            currentlyViewing.previewGameObject.transform.localPosition = Vector3.zero;
            if (currentlyViewing.TurnThisOffWhenPreviewing != null)
                currentlyViewing.TurnThisOffWhenPreviewing.SetActive(true);
        }

    }

    private static bool PreviewingSomeCard()
    {
        if (!PreviewsAllowed)
            return false;

        HoverPreview[] allHoverBlowups = GameObject.FindObjectsOfType<HoverPreview>();

        foreach (HoverPreview hb in allHoverBlowups)
        {
            if (hb.OverCollider && hb.ThisPreviewEnabled)
                return true;
        }

        return false;
    }


}
