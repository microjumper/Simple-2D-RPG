using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    private new Camera camera;
    
    private BackgroundSegment backgroundSegment;
    
    private LinkedList<BackgroundSegment> segments;
    private float cameraOffset;

    private void Awake()
    {
        camera = Camera.main;
        
        backgroundSegment = GetComponentInChildren<BackgroundSegment>();
    }

    private void Start()
    {
        CreateBackground();
        
        cameraOffset = camera.transform.position.x - backgroundSegment.transform.position.x;
    }

    private void LateUpdate()
    {
        var cameraX = camera.transform.position.x - cameraOffset;
        
        while (cameraX >= segments.First.Value.transform.position.x + backgroundSegment.Width)
        {
            var segmentToMove = segments.First.Value;
            segments.RemoveFirst();
            segmentToMove.transform.position = new Vector3(
                segments.Last.Value.transform.position.x + backgroundSegment.Width,
                backgroundSegment.transform.position.y, backgroundSegment.transform.position.z);
            segments.AddLast(segmentToMove);
        }

        while (cameraX <= segments.First.Value.transform.position.x)
        {
            var segmentToMove = segments.Last.Value;
            segments.RemoveLast();
            segmentToMove.transform.position = new Vector3(
                segments.First.Value.transform.position.x - backgroundSegment.Width,
                backgroundSegment.transform.position.y, backgroundSegment.transform.position.z);
            segments.AddFirst(segmentToMove);       
        }
    }

    private void CreateBackground()
    {
        segments = new LinkedList<BackgroundSegment>();
        
        segments.AddFirst(backgroundSegment);
        
        // orthographicSize = 0.5 * (camera's vertical size)
        // aspect = (screen width / screen height)
        var cameraWidth = camera.orthographicSize * camera.aspect * 2;
        
        var segmentsRequired = Mathf.CeilToInt(cameraWidth / backgroundSegment.Width) + 1;
        
        for (var i = 1; i <= segmentsRequired; i++)
        {
            var segment = Instantiate(backgroundSegment, transform);
            segment.transform.position = new Vector3(segment.transform.position.x + backgroundSegment.Width * i,
                backgroundSegment.transform.position.y, backgroundSegment.transform.position.z);
            
            segments.AddLast(segment);
        }
    }
}
