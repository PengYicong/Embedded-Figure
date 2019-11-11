using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchFigure : MonoBehaviour
{
    public Texture[] test = new Texture[4];
    public Texture shape;
    public Button nextFigure;
    public RawImage testImage;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        testImage.texture = shape;
        nextFigure.onClick.AddListener(NextFigure);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void NextFigure()
    {
        if (index>3)
        {
            index = 0;
        }
        testImage.texture = test[index];
        index++;
    }
    
    public int GetInfo()
    {
        int temp;
        if (testImage.texture == shape)
        {
            temp = -1;
        }
        else
        {
            temp = index;
        }
        return temp;
    }
}
