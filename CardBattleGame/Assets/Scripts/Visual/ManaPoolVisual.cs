using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ManaPoolVisual : MonoBehaviour
{
    public int TestFullCrystals;
    public int TestTotalCrystalsThisTurn;

    public Image[] Crystals;
    public Text ProgressText;

    private int totalCrystals;
    public int TotalCrystals
    {
        get => this.totalCrystals;
        set
        {
            if (value > this.Crystals.Length)
            {
                this.totalCrystals = this.Crystals.Length;
            }
            else if (value < 0)
            {
                this.totalCrystals = 0;
            }
            else
            {
                this.totalCrystals = value;
            }

            for (int i = 0; i < this.Crystals.Length; i++)
            {
                if (i < this.totalCrystals)
                {
                    if (this.Crystals[i].color == Color.clear)
                    {
                        this.Crystals[i].color = Color.gray;
                    }
                }
                else
                {
                    this.Crystals[i].color = Color.clear;
                }
            }

            // update the text
            this.ProgressText.text = string.Format("{0}/{1}", this.availableCrystals.ToString(), this.totalCrystals.ToString());
        }
    }

    private int availableCrystals;
    public int AvailableCrystals
    {
        get => this.availableCrystals;
        set
        {
            if (value > this.totalCrystals)
            {
                this.availableCrystals = this.totalCrystals;
            }
            else if (value < 0)
            {
                this.availableCrystals = 0;
            }
            else
            {
                this.availableCrystals = value;
            }

            for (int i = 0; i < this.totalCrystals; i++)
            {
                if (i < this.availableCrystals)
                {
                    this.Crystals[i].color = Color.white;
                }
                else
                {
                    this.Crystals[i].color = Color.gray;
                }
            }

            // update the text
            this.ProgressText.text = string.Format("{0}/{1}", this.availableCrystals.ToString(), this.totalCrystals.ToString());
        }
    }

    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            this.TotalCrystals = this.TestTotalCrystalsThisTurn;
            this.AvailableCrystals = this.TestFullCrystals;
        }
    }

}
