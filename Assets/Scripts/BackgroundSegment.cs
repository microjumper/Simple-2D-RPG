using System.Linq;
using UnityEngine;

public class BackgroundSegment : MonoBehaviour
{
    private SpriteRenderer[] renderers;

    private float? width;
    
    public float Width => width ??= MeasureWidth(); // compute and cache the result

    private void Awake() => renderers = GetComponentsInChildren<SpriteRenderer>();
    
    private float MeasureWidth() => renderers.Sum(render => render.bounds.size.x);
}
