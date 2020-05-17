using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    [SerializeField] GameObject asteroid;
    bool isProducing = true;

    [SerializeField] float minW = 1f;
    [SerializeField] float maxW = 2f;

    [SerializeField] float minWait = 1f;
    [SerializeField] float maxWait = 2f;

    [SerializeField] float minX = -2.7f;
    [SerializeField] float maxX = 2.7f;

    Lerper lerp;


    // Start is called before the first frame update
    void Start()
    {
        lerp = FindObjectOfType<Lerper>();
        StartCoroutine(Conveyor());
    }

    IEnumerator Conveyor()
    {
        while (isProducing)
        {
            float ranX = Random.Range(minX, maxX);
            float ranW = Random.Range(minW, maxW);
            float ranWait = Random.Range(minWait, maxWait);
            var ast = Instantiate(asteroid, new Vector2(ranX, transform.position.y), Quaternion.identity);
            ast.transform.localScale = new Vector2(ranW, ranW);
            if (ast.tag == "Planet")
            {
                var color = lerp.RandomColor();
                ast.GetComponent<SpriteRenderer>().color = color;
            }
            yield return new WaitForSecondsRealtime(ranWait);
        }
    }
    
}
