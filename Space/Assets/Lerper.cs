using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [SerializeField] List<Color32> colors = new List<Color32>();

    SpriteRenderer sr;

    int curColorIndex;
    int nextColorIndex;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        curColorIndex = Random.Range(0, colors.Count);
        sr.color = colors[curColorIndex];
        nextColorIndex = NextColor();
        Debug.Log(curColorIndex + " " + nextColorIndex);
    }

    void Update()
    {
        

    }

    int NextColor()
    {
        int nextColor = Random.Range(0, colors.Count);
        while (curColorIndex == nextColor)
        {
            nextColor = Random.Range(0, colors.Count);
        }
        return nextColor;
    }
}
