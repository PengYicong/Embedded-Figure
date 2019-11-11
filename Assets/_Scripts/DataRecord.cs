using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;
using System.IO;
using Tobii.Gaming;

public class DataRecord : MonoBehaviour
{
    public Button record;
    public Button create;
    public InputField subjectName;
    public SwitchFigure script;
    private GazePoint gazePosition;
    private DateTime recordTime;
    private Image recordColor;
    private bool isRecording;
    private string filename;
    private StreamWriter writer;
    private Vector2 gazeData;
    private string tempx;
    private string tempy;

    // Start is called before the first frame update
    void Start()
    {
        isRecording = false;
        subjectName.text = "DefaultName";
        tempx = "TEMPX";
        tempy = "TEMPY";
        Button r = record.GetComponent<Button>();
        Button c = create.GetComponent<Button>();
        recordColor = record.GetComponent<Image>();
        r.onClick.AddListener(ToggleRecord);
        c.onClick.AddListener(CreateNewFile);
    }

    void ToggleRecord()
    {
        isRecording = !isRecording;
        if(isRecording)
        {
            recordColor.color = Color.red;
        }
        else
        {
            recordColor.color = Color.white;
        }
    }

    void CreateNewFile()
    {
        if (!isRecording)
        {
            if (File.Exists(subjectName.text))
            {
                Debug.Log(subjectName.text + ".txt exisits creating new file: ");
                filename = subjectName.text + recordTime.ToString("MM") + recordTime.ToString("dd") + "_new.txt";
                writer = File.CreateText(filename);

            }
            else
            {
                filename = subjectName.text + recordTime.ToString("MM") + recordTime.ToString("dd") + ".txt";
                writer = File.CreateText(filename);

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        recordTime = DateTime.Now;
        gazePosition = TobiiAPI.GetGazePoint();
        if (gazePosition.IsValid)
        {
            gazeData = gazePosition.Screen;
        }
        
        //string data = gazeData.x.ToString() + '\t' + gazeData.y.ToString();

        string data = gazeData.x.ToString() + '\t' + gazeData.y.ToString() + '\t' + script.GetInfo().ToString() + '\t' + Time.frameCount.ToString();
        if (isRecording)
        {
            writer.WriteLine(data);
        }
    }
}
