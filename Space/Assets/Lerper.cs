using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerper : MonoBehaviour
{
    [SerializeField] List<Color32> colors = new List<Color32>();

    GameObject pl;
    GameObject bkg;
    [SerializeField] GameObject planetColors;

    int curColorIndex;
    int nextColorIndex;

    int curPlanetIndex;
    int nextPlanetIndex;

    bool shouldLoop = true;

    float wait = 30f;

    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        bkg = GameObject.FindGameObjectWithTag("Background");

        nextColorIndex = Random.Range(0, colors.Count);
        nextPlanetIndex = 0;

        //pl.GetComponent<SpriteRenderer>().color = colors[nextColorIndex];
        bkg.GetComponent<SpriteRenderer>().color = colors[nextColorIndex];
        planetColors.GetComponent<SpriteRenderer>().color = colors[nextPlanetIndex];

        StartCoroutine(ColorChange());
    }

    IEnumerator ColorChange()
    {
        while (shouldLoop)
        {
            NewColors();
            wait = Random.Range(30f, 70f);
            //LeanTween.color(pl, colors[nextColorIndex], wait);
            LeanTween.color(bkg, colors[nextColorIndex], wait);
            LeanTween.color(planetColors, colors[nextPlanetIndex], wait);
            Debug.Log("I run");
            yield return new WaitForSecondsRealtime(wait);

        }
    }

    void NewColors()
    {
        int curIndex = nextColorIndex;

        int nextIndex = Random.Range(0, colors.Count);
        while (curIndex == nextIndex)
        {
            nextIndex = Random.Range(0, colors.Count);
        }
        curColorIndex = curIndex;
        nextColorIndex = nextIndex;

        int curPlanet = nextPlanetIndex;
        int nextPlanet = Random.Range(0, colors.Count);
        while (nextPlanet == curPlanet || nextPlanet == curIndex || nextPlanet == nextIndex)
        {
            nextPlanet = Random.Range(0, colors.Count);
        }
        curPlanetIndex = curPlanet;
        nextPlanetIndex = nextPlanet;
    }


    public Color32 RandomColor()
    {
        int ran = Random.Range(0, colors.Count);
        return colors[ran];
    }
}
