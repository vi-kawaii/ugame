using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.ML;
using Microsoft.ML.Data;
using SentimentAnalysis;

public class main : MonoBehaviour
{
    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            var sampleData = new SentimentModel.ModelInput()
            {
                Col0 = "This restaurant was wonderful."
            };

            Debug.Log($"Text: {sampleData.Col0}\nSentiment: {SentimentModel.Predict(sampleData).PredictedLabel}");
            flag = false;
        }
    }
}
