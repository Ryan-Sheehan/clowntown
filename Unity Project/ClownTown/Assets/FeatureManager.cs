using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class FeatureManager : MonoBehaviour
{

    public List<Feature> features;
    public int currFeature;

    void OnEnable()
    {
        LoadFeatures();
    }

    void OnDisable()
    {
        SaveFeatures();
    }

    void LoadFeatures()
    {
        features = new List<Feature>();
        features.Add(new Feature("Heads", transform.Find("Face").GetComponent<SpriteRenderer>()));


        for (int i = 0; i < features.Count; i++)
        {
            string key = "FEATURE_" + i;
            if (!PlayerPrefs.HasKey(key))
                PlayerPrefs.SetInt(key, features[i].currIndex);
            features[i].currIndex = PlayerPrefs.GetInt(key);
            features[i].UpdateFeature();
        }
    }

    void SaveFeatures()
    {
        for (int i = 0; i < features.Count; i++)
        {
            string key = "FEATURE_" + i;
            PlayerPrefs.SetInt(key, features[i].currIndex);
        }
        PlayerPrefs.Save();
    }

    public void SetCurrent(int index)
    {
        if (features == null)
            return;
        currFeature = index;
    }

    public void NextChoice()
    {
        if (features == null)
            return;
        features[currFeature].currIndex++;
        features[currFeature].UpdateFeature();
    }

    public void PreviousChoice()
    {
        if (features == null)
            return;
        features[currFeature].currIndex--;
        features[currFeature].UpdateFeature();
    }

}

[Serializable]
public class Feature 
{
    public string ID;
    public int currIndex;
    public Sprite[] choices;
    public SpriteRenderer renderer;

    public Feature (string id, SpriteRenderer rend)
    {
        ID = id;
        renderer = rend;
        UpdateFeature();
    }

    public void UpdateFeature()
    {
        choices = Resources.LoadAll<Sprite>("Textures/" + ID);
        if (choices == null || renderer == null)
            return;

        if (currIndex < 0)
            currIndex = choices.Length - 1;
        if (currIndex >= choices.Length)
            currIndex = 0;

        renderer.sprite = choices[currIndex];
    }

}