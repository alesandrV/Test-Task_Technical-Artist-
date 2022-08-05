using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeParticle : MonoBehaviour
{
    public bool floorTouched;

    private Transform particleGO;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        particleGO = gameObject.transform.GetChild(0);
    }
    void Update()
    {
        PlayPatricles();
    }

    //Enable object with particles to play
    private void PlayPatricles()
    {
        if (transform.position.y <= 1)
        {
            meshRenderer.enabled = false;
            particleGO.gameObject.SetActive(true);
            floorTouched = true;
        }
    }
}
