using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{

    [SerializeField]
    private float speed;

    public GameManager trackTransport;

    public float enableRendererPosition = 5f;
    public float disableRendererPosition = 0f;

    private MeshRenderer[] childMeshRenderers;

    private void Start()
    {
        speed = trackTransport.trackSpeed;

        // Disable all child mesh renderers at start, including inactive children
        childMeshRenderers = GetComponentsInChildren<MeshRenderer>(true);
        foreach (MeshRenderer renderer in childMeshRenderers)
        {
            renderer.enabled = false;
        }
    }

    void Update()
    {
        
        transform.Translate(0, 0, -speed * Time.deltaTime);

        // Enable mesh renderers when we've passed enableRendererPosition
        if (transform.position.z <= enableRendererPosition && transform.position.z > disableRendererPosition)
        {
            foreach (MeshRenderer renderer in childMeshRenderers)
            {
                renderer.enabled = true;
            }
        }
        // Disable mesh renderers when we've passed disableRendererPosition
        else if (transform.position.z <= disableRendererPosition)
        {
            foreach (MeshRenderer renderer in childMeshRenderers)
            {
                renderer.enabled = false;
            }
        }
    }
}
