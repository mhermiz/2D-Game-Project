using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleBar : MonoBehaviour
{
    public Image fillImage;
    public int maxSoulOrbs = 6;
    public float currentSoulOrbs = 0;
    public static bool powerActive = false;

    // Start is called before the first frame update
    void Start()
    {
        fillImage.fillAmount = 0f;
    }

    public void AddCollectible()
    {
        currentSoulOrbs++;
        currentSoulOrbs = Mathf.Clamp(currentSoulOrbs, 0, maxSoulOrbs);

        // Update fill amount
        fillImage.fillAmount = (float)currentSoulOrbs / maxSoulOrbs;

        if (currentSoulOrbs >= maxSoulOrbs)
        {
            // Passive ability when player hits enemy
            powerActive = true;
        }
    }

    public void ResetBar()
    {
        currentSoulOrbs = 0;
        fillImage.fillAmount = 0f;
        powerActive = false;
    }
}
