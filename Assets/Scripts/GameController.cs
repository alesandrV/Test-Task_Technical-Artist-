using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mainPlayer;

    private Animator cameraAnimator;
    private MovePlayableObject movePlayableObject;
    private InitializeParticle initializeParticle;
    private ScenesController scenesController;

    private float loadSceneDelay = 1.5f;

    private void Awake()
    {
        cameraAnimator = mainCamera.GetComponent<Animator>();
        cameraAnimator.enabled = true;

        movePlayableObject = mainPlayer.GetComponent<MovePlayableObject>();
        movePlayableObject.enabled = true;

        initializeParticle = mainPlayer.GetComponent<InitializeParticle>();

        scenesController = gameObject.GetComponent<ScenesController>();
    }

    private void Update()
    {
        EnableCameraFollow();
        EnablePlayerMove();
        BackToMenu();
    }
    
    //Allow camera to follow playable cylinder
    private void EnableCameraFollow()
    {
        if(mainCamera.transform.position.z >= 40f)
        {
            if (mainCamera)
                cameraAnimator.enabled = false;
            else
                Debug.LogError("Set the camera");
        }
    }

    //Allow player to to push cylinder
    private void EnablePlayerMove()
    {
        if (mainCamera.transform.position.z >= 40f)
        {
            if (mainPlayer)
                movePlayableObject.enabled = true;
            else
                Debug.LogError("Set the object to play");
        }
    }
    
    //Starting coroutine with back to menu logic
    private void BackToMenu()
    {
        if (initializeParticle.floorTouched)
        {
            StartCoroutine(BackToMenuAfterTime(loadSceneDelay));
        }
    }

    //Back to main menu in "loadSceneDelay" seconds
    IEnumerator BackToMenuAfterTime(float loadSceneDelay)
    {
        Debug.Log("Courutine started");
        yield return new WaitForSeconds(loadSceneDelay);

        scenesController.LoadScene("MenuScene");
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
