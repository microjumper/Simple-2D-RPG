using System.Linq;
using UnityEngine;

public class Repeatable : MonoBehaviour
{
    private SpriteRenderer[] renderers;

    private float? width;
    
    public float Width => width ??= MeasureWidth(); // compute anc cache the result

    private void Awake() => renderers = GetComponentsInChildren<SpriteRenderer>();
    
    private float MeasureWidth() => renderers.Sum(render => render.bounds.size.x);
}
