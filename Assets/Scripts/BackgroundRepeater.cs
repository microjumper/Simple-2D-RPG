using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private new Camera camera;
    
    private Repeatable repeatable;
    private float offset;
    private List<GameObject> backgrounds;

    private void Awake()
    {
        camera = Camera.main;
        
        repeatable = GetComponentInChildren<Repeatable>();
    }

    private void Start()
    {
        Debug.Log(repeatable.Width);;
        offset = camera.transform.position.x - repeatable.transform.position.x;
        
        var width = repeatable.Width;
        var count = Mathf.CeilToInt(camera.orthographicSize * 2f / width) + 1;
        
        backgrounds = Enumerable.Range(0, count).Select(i => Instantiate(repeatable.gameObject, transform)).ToList();

        for (var i = 0; i < backgrounds.Count; i++)
        {
            backgrounds[i].transform.position = new Vector3(width * (i + 1) - offset, repeatable.transform.position.y, repeatable.transform.position.z);
        }
        
        backgrounds.Insert(0, repeatable.gameObject);
    }

    private void LateUpdate()
    {

        if (camera.transform.position.x >= backgrounds.First().transform.position.x + repeatable.Width +offset)
        {
            var background = backgrounds.First();
            backgrounds.RemoveAt(0);
            background.transform.position = new Vector3(
                backgrounds.Last().transform.position.x + repeatable.Width, repeatable.transform.position.y, repeatable.transform.position.z);
            backgrounds.Add(background);
        }
    }
}
