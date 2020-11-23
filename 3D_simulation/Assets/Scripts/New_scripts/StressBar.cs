using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressBar : MonoBehaviour
{
    private Transform stressbar;
    public Text stresstext = null;

    // Start is called before the first frame update
    void Start()
    {
        stressbar = transform.Find("StressBar");
    }

    public void SetSize(float sizeNormalized)
    {
        stressbar.localScale = new Vector3(sizeNormalized, 1f);
        stresstext.text = (sizeNormalized * 100).ToString() + "%";
    }
}
