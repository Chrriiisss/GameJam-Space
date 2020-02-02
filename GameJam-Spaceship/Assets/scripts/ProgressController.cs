using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{
    public RectTransform tick;
    public float currentProgress;

    // Update is called once per frame
    void FixedUpdate()
    {
        tick.localPosition = new Vector2(500*currentProgress - 250f, 20f);
    }
}
