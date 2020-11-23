using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Smiley Generator 
// Author: chouhansolo

// Important notes:
// The smiley is made up from 10 image elements : Head, Mouth_Static, Mouth_Dynamic_Right, Mouth_Dynemic_Left,
// Eye_Right, Eye_Left, Eyebrow_Right_Out, Eyebrow_Left_Out, Eyebrow_Right_In, Eyebrow_Left_In.
//
// The mouth is made out of 3 pieces, whilst the eyebrows are made out of 2 pieces each. (2-2)
// Each element will be described below.

public class SmileyGenerator : MonoBehaviour
{
    [Header("Emotion Dataset")] // Please note, that these values can be changed in real-time in the inspector. 
    [Range(0.0f, 1.0f)]
    public float Anger = 0f; // The value of Anger.
    [Range(0.0f, 1.0f)]
    public float Disgust = 0f; // The value of Disgust.
    [Range(0.0f, 1.0f)]
    public float Fear = 0f; // The value of Fear.
    [Range(0.0f, 1.0f)]
    public float Happiness = 0f; // The value of Happiness.
    [Range(0.0f, 1.0f)]
    public float Neutral = 0f; // The value of Neutral.
    [Range(0.0f, 1.0f)]
    public float Sadness = 0f; // The value of Sadness.
    [Range(0.0f, 1.0f)]
    public float Surprise = 0f; // The value of Surprise.

    [Header("Tweak Settings")]
    public float Expression_Strenght = 10f;
    public float Max_Eye_Scale = 7f;
    public float Max_Negative_Mouth_Scale = -0.5f;
    public float Max_Positive_Mouth_Scale = 0.5f;
    public float Max_Negative_Eyebrow_Scale = -0.5f;
    public float Max_Positive_Eyebrow_Scale = 0.5f;
    public float Surprise_Mouth_Value = 0.3f;

    [Header("Results")]
    public bool isSmiling;

    [Header("Smiley Elements")]
    public Image Head; // This is the outline of the head, a basic Knob sprite built into Unity. | Base Position: X:0, Y:0, Z:0 | Width : 250, Height : 250 | Scale : X:1, Y:1, Z:1 |
    public Image Mouth_Static; // This is the base mouth which only moves on the Y axis. | Base Position: X:0, Y:-50, Z:0 | Width : 60, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Mouth_Dynamic_Right; // This is the right side of the animated mouth. | Base Position: X:40, Y:-50, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Mouth_Dynamic_Left; // This is the left side of the animated mouth. | Base Position: X:-40, Y:-50, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Mouth_Surprise;
    public Image Eye_Right; // This is the right eye. Only will be affected by Disgust. | Base Position: X:35, Y:5, Z:0 | Width : 100, Height : 100 | Scale : X:0.3, Y:0.5, Z:0.5 |
    public Image Eye_Left; // This is the left eye. Only will be affected by Disgust. | Base Position: X:-35, Y:5, Z:0 | Width : 100, Height : 100 | Scale : X:0.3, Y:0.5, Z:0.5 |
    public Image Eyebrow_Right_Out; //Outer side of the right eyebrow. | Base Position: X:55, Y:45, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Eyebrow_Right_In; // Inner side of the right eyebrow. | Base Position: X:30, Y:45, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Eyebrow_Left_Out; // Outer side of the left eyebrow. | Base Position: X:-55, Y:45, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |
    public Image Eyebrow_Left_In; // Inner side of the left eyebrow. | Base Position: X:-30, Y:45, Z:0 | Width : 35, Height : 10 | Scale : X:1, Y:1, Z:1 |

    private GameObject Smiley;
    private bool sadnessDominant;
    private bool surpriseDominant;

    private float EyeVal;
    private float MouthVal;
    private float EyebrowVal;

    void Awake()
    {
        Smiley = GameObject.FindWithTag("Smiley");
        InitialiseElement(Head, "Head");
        InitialiseElement(Mouth_Static, "Mouth_Static");
        InitialiseElement(Mouth_Dynamic_Right, "Mouth_Dynamic_Right");
        InitialiseElement(Mouth_Dynamic_Left, "Mouth_Dynamic_Left");
        InitialiseElement(Eye_Right, "Eye_Right");
        InitialiseElement(Eye_Left, "Eye_Left");
        InitialiseElement(Eyebrow_Right_Out, "Eyebrow_Right_Out");
        InitialiseElement(Eyebrow_Right_In, "Eyebrow_Right_In");
        InitialiseElement(Eyebrow_Left_Out, "Eyebrow_Left_Out");
        InitialiseElement(Eyebrow_Left_In, "Eyebrow_Left_In");
    }

    void Update()
    {

        CalculateEyeVal(Disgust);
        CalculateMouthVal(Anger, Disgust, Fear, Happiness, Sadness, Surprise);
        CalculateEyebrowVal(Anger, Disgust, Fear, Happiness, Surprise, Sadness);

        SetEye(EyeVal * Expression_Strenght);
        SetMouth(MouthVal * Expression_Strenght);
        SetEyebrow(EyebrowVal * Expression_Strenght);


    }

    void InitialiseElement(Image x, string y)
    {
        x = GameObject.Find(y).GetComponent<Image>();
    }

    void CalculateEyeVal(float x)
    {
        EyeVal = x;
    }

    void CalculateMouthVal(float a, float b, float c, float d, float e, float f)
    { //(Anger, Disgust, Fear, Happiness, Sadness)

        float MouthNegative = (-a * 2) + (-b * 2) + (-c * 1.2f) + (-e * 1.5f);
        float MouthPositive = d * 3.0f;
        float MouthNeutral = Neutral / 2;
        float SurpriseMouth = f * 2;

        float MouthResult = (MouthNegative + MouthPositive + SurpriseMouth) / 2;
        //Debug.Log("Mouth Result = " + MouthResult);

        if (SurpriseMouth > (Surprise_Mouth_Value * 1.5f))
        {
            surpriseDominant = true;
        }
        else
        {
            surpriseDominant = false;
        }

        if (SurpriseMouth > Max_Positive_Mouth_Scale)
        {
            SurpriseMouth = 0.5f;
        }
        else if (Surprise > Max_Negative_Mouth_Scale)
        {
            SurpriseMouth = -0.5f;
        }
        else if (SurpriseMouth > 0 && SurpriseMouth < 0.2)
        {
            SurpriseMouth = 0.3f;
        }

        if (MouthResult > 0)
        { //Neutral will decrease "happy mouth".
            MouthResult -= (MouthNeutral * 0.75f);
        }
        else if (MouthResult < 0)
        { //Neutral will decrease "sad mouth".
            MouthResult += (MouthNeutral * 0.75f);
        }

        if (MouthResult < 0)
        {
            if (MouthResult > Max_Negative_Mouth_Scale)
            { //Limit mouth to specific angle. (sad mouth)
                MouthVal = MouthResult;
            }
            else if (MouthResult < Max_Negative_Mouth_Scale)
            {
                MouthVal = Max_Negative_Mouth_Scale;
            }
        }
        if (MouthResult > 0)
        {
            if (MouthResult > Max_Positive_Mouth_Scale)
            { //Limit mouth to specific angle. (happy mouth)
                MouthVal = Max_Positive_Mouth_Scale;
            }
            else if (MouthResult < Max_Positive_Mouth_Scale)
            {
                MouthVal = MouthResult;
            }
        }

    }

    void CalculateEyebrowVal(float a, float b, float c, float d, float e, float f)
    { //(Anger, Disgust, Fear, Happiness, Surprise, Neutral, Sadness)

        float EyebrowNegative = (-a) + (-b * 0.5f);
        float EyebrowPositive = c + (d * 0.25f) + e;
        float EyebrowNeutral = Neutral / 2;
        float SadnessEyebrow = f * 2;

        float EyebrowResult = (EyebrowNegative + EyebrowPositive + SadnessEyebrow) / 2;
        //Debug.Log ("Eyebrow Result = " + EyebrowResult);

        if (EyebrowResult > 0)
        { //Neutral will decrease "happy eyebrow".
            EyebrowResult -= (EyebrowNeutral * 0.75f);
        }
        else if (EyebrowResult < 0)
        { //Neutral will decrease "sad eyebrow".
            EyebrowResult += (EyebrowNeutral * 0.75f);
        }

        if (SadnessEyebrow > EyebrowResult)
        {
            sadnessDominant = true;
        }
        else
        {
            sadnessDominant = false;
        }

        if (EyebrowResult > 0)
        {
            if (EyebrowResult > Max_Positive_Eyebrow_Scale)
            { //Limit eyebrow to specific angle. (happy eyebrow)
                EyebrowVal = Max_Positive_Eyebrow_Scale;
            }
            else if (EyebrowResult < Max_Positive_Eyebrow_Scale)
            {
                EyebrowVal = EyebrowResult;
            }
        }
        if (EyebrowResult < 0)
        {
            if (EyebrowResult < Max_Negative_Eyebrow_Scale)
            { //Limit eyebrow to specific angle. (angry eyebrow)
                EyebrowVal = Max_Negative_Eyebrow_Scale;
            }
            else if (EyebrowResult > Max_Negative_Eyebrow_Scale)
            {
                EyebrowVal = EyebrowResult;
            }
        }

        Debug.Log("Eyebrow Val = " + EyebrowVal);

    }

    void SetEye(float x)
    { // Only effected by disgust.

        // Right Eye rotation (-)
        // Left Eye rotation (+)

        if (x < Max_Eye_Scale)
        {
            Eye_Right.rectTransform.sizeDelta = new Vector2(100 + (x * 5), (100 - (x * 10)));
            Eye_Left.rectTransform.sizeDelta = new Vector2(100 + (x * 5), (100 - (x * 10)));
            Eye_Right.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.05f);
            Eye_Left.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.05f);
        }
        else
        {
            Eye_Right.rectTransform.sizeDelta = new Vector2(155, 15);
            Eye_Left.rectTransform.sizeDelta = new Vector2(155, 15);
        }
    }

    void SetMouth(float x)
    {

        if (x > 0 && !surpriseDominant)
        { //If positive emotion
            isSmiling = true;
            Mouth_Dynamic_Right.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.05f);
            Mouth_Dynamic_Left.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.05f);
            Mouth_Static.rectTransform.anchoredPosition = new Vector3(0, ((-50) - (x * 0.7f)), 0);


        }
        else if (x < 0.5f && x > -0.5f)
        {
            Mouth_Dynamic_Right.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Mouth_Dynamic_Left.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Mouth_Static.rectTransform.anchoredPosition = new Vector3(0, -50, 0);

        }
        else if (x < 0 && !surpriseDominant)
        {
            Mouth_Dynamic_Right.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.05f);
            Mouth_Dynamic_Left.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.05f);
            Mouth_Static.rectTransform.anchoredPosition = new Vector3(0, ((-50) - (x * 0.7f)), 0);
        }

        if (surpriseDominant)
        {
            Mouth_Dynamic_Left.gameObject.SetActive(false);
            Mouth_Dynamic_Right.gameObject.SetActive(false);
            Mouth_Static.gameObject.SetActive(false);
            Mouth_Surprise.gameObject.SetActive(true);

            Mouth_Surprise.rectTransform.localScale = new Vector3(3f + (x / 1.5f), 3f + (x / 20), 3f + (x / 2));

            //Mouth_Surprise.rectTransform.scale 

        }
        else
        {
            Mouth_Dynamic_Left.gameObject.SetActive(true);
            Mouth_Dynamic_Right.gameObject.SetActive(true);
            Mouth_Static.gameObject.SetActive(true);
            Mouth_Surprise.gameObject.SetActive(false);
        }

    }

    void SetEyebrow(float x)
    {

        if (x > 0 && !sadnessDominant)
        { // If positive emotion (when positive, outer eyebrow is more rotated and scaled by width).
            Eyebrow_Right_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.14f);
            Eyebrow_Right_Out.rectTransform.sizeDelta = new Vector2(35 + (x * 2.5f), 10); // Scale Outer Right eyebrow.
            Eyebrow_Right_In.rectTransform.sizeDelta = new Vector2(35 + (x * 0.2f), 10); // Scale Inner Right eyebrow.
            Eyebrow_Right_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.20f);
            Eyebrow_Left_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.14f);
            Eyebrow_Left_Out.rectTransform.sizeDelta = new Vector2(35 + (x * 2.5f), 10); // Scale Outer Left eyebrow.
            Eyebrow_Left_In.rectTransform.sizeDelta = new Vector2(35 + (x * 0.2f), 10); // Scale Inner Left eyebrow.
            Eyebrow_Left_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.20f);
        }
        else if (x < 0.5f && x > -0.5f)
        {
            Eyebrow_Right_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Eyebrow_Right_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Eyebrow_Left_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Eyebrow_Left_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, 0f);
            Eyebrow_Right_Out.rectTransform.sizeDelta = new Vector2(35, 10); // Scale Outer Right eyebrow.
            Eyebrow_Left_Out.rectTransform.sizeDelta = new Vector2(35, 10); // Scale Outer eyebrow.
            Eyebrow_Right_In.rectTransform.anchoredPosition = new Vector3(25f, 45, 0f);
            Eyebrow_Left_In.rectTransform.anchoredPosition = new Vector3(-25f, 45, 0f);
        }
        else if (x < 0 && !sadnessDominant)
        { // If negative emotion.
            Eyebrow_Right_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.20f);
            Eyebrow_Right_In.rectTransform.sizeDelta = new Vector2(35 + (-x * 2.5f), 10); // Scale Inner Right eyebrow.
            Eyebrow_Right_Out.rectTransform.sizeDelta = new Vector2(35 + (-x * 0.2f), 10); // Scale Outer Right eyebrow.
            Eyebrow_Right_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.15f);
            Eyebrow_Left_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.20f);
            Eyebrow_Left_In.rectTransform.sizeDelta = new Vector2(35 + (-x * 2.5f), 10); // Scale  Inner Left eyebrow.
            Eyebrow_Left_Out.rectTransform.sizeDelta = new Vector2(35 + (-x * 0.2f), 10); // Scale Outer Left eyebrow.
            Eyebrow_Left_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.15f);

        }

        if (sadnessDominant)
        {
            Eyebrow_Right_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.10f);
            Eyebrow_Right_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, -x * 0.10f);
            Eyebrow_Left_Out.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.10f);
            Eyebrow_Left_In.rectTransform.rotation = Quaternion.EulerAngles(0f, 0f, x * 0.10f);
            Eyebrow_Right_In.rectTransform.anchoredPosition = new Vector3(25f, 45 + (x * 2.8f), 0f);
            Eyebrow_Left_In.rectTransform.anchoredPosition = new Vector3(-25f, 45 + (x * 2.8f), 0f);
        }
        else
        {
            Eyebrow_Right_In.rectTransform.anchoredPosition = new Vector3(25f, 45, 0f);
            Eyebrow_Left_In.rectTransform.anchoredPosition = new Vector3(-25f, 45, 0f);
        }

    }

}
