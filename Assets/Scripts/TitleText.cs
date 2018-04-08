using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleText : MonoBehaviour
{
    private Text text;

    [TextArea(2, 3)]
    public string fullTitle;

    public float startDelay;
    public float totalTimeToReveal = 3f;
    public float timeToStayOnScreen = 2f;

    bool finished;
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        finished = false;
    }

    void Update()
    {
        float t = Time.timeSinceLevelLoad;
        if (t > startDelay && ! finished)
        {
            int len = Mathf.FloorToInt(fullTitle.Length * Mathf.Min(1f, (t - startDelay) / totalTimeToReveal));
            text.text = fullTitle.Substring(0, len);
            if (len >= fullTitle.Length)
            {
                Destroy(gameObject, timeToStayOnScreen);
                finished = true;
            }
        }
    }
}
