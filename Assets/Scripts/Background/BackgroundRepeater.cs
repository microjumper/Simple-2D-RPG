using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxFactor = 1f;
    
    private new Camera camera;
    private Vector3 lastCameraPosition;
    
    private BackgroundSegment backgroundSegment;
    
    private LinkedList<BackgroundSegment> segments;
    
    private void Awake()
    {
        camera = Camera.main;
        
        backgroundSegment = GetComponentInChildren<BackgroundSegment>();
    }

    private void Start()
    {
        lastCameraPosition = camera.transform.position;
        
        CreateBackground();
    }

    private void LateUpdate()
    {
        var deltaMovement = camera.transform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, deltaMovement.z);
        lastCameraPosition = camera.transform.position;

        if (segments.First.Value.transform.position.x + backgroundSegment.Width < deltaMovement.x)
        {
            var segmentToMove = segments.First.Value;
            segments.RemoveFirst();
            segmentToMove.transform.position = new Vector3(
                segments.Last.Value.transform.position.x + backgroundSegment.Width,
                segmentToMove.transform.position.y,
                segmentToMove.transform.position.z);
            segments.AddLast(segmentToMove);
        }
        
        if (segments.First.Value.transform.position.x > deltaMovement.x)
        {
            var segmentToMove = segments.Last.Value;
            segments.RemoveLast();
            segmentToMove.transform.position = new Vector3(
                segments.First.Value.transform.position.x - backgroundSegment.Width,
                segmentToMove.transform.position.y,
                segmentToMove.transform.position.z);
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
        
        var segmentsRequired = Mathf.CeilToInt(cameraWidth / backgroundSegment.Width) + 2;
        
        for (var i = 1; i <= segmentsRequired; i++)
        {
            var segment = Instantiate(backgroundSegment, transform);
            segment.transform.position = new Vector3(segment.transform.position.x + backgroundSegment.Width * i,
                backgroundSegment.transform.position.y, backgroundSegment.transform.position.z);
            
            segments.AddLast(segment);
        }
    }
}
