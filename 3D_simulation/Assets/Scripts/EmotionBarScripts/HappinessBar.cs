using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    private Transform happinessbar;
    public Text happinesstext = null;

    // Start is called before the first frame update
    void Start()
    {
        happinessbar = transform.Find("HappinessBar");
    }

    public void SetSize(float sizeNormalized)
    {
        happinessbar.localScale = new Vector3(sizeNormalized, 1f);
        happinesstext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
