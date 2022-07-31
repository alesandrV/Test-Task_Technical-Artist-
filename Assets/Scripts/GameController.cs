using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject mainPlayer;

    private Animator cameraAnimator;
    private MovePlayableObject movePlayableObject;

    private float loadSceneDelay = 1.5f;

    private void Awake()
    {
        mainCamera.GetComponent<Animator>().enabled = true;
        mainPlayer.GetComponent<MovePlayableObject>().enabled = false;
        
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
                mainCamera.GetComponent<Animator>().enabled = false;
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
                mainPlayer.GetComponent<MovePlayableObject>().enabled = true;
            else
                Debug.LogError("Set the object to play");
        }
    }

    //Starting coroutine with back to menu logic
    private void BackToMenu()
    {
        if (mainPlayer.GetComponent<InitializeParticle>().floorTouched)
        {
            StartCoroutine(BackToMenuAfterTime(loadSceneDelay));
        }
    }

    //Back to main menu in "loadSceneDelay" seconds
    IEnumerator BackToMenuAfterTime(float loadSceneDelay)
    {
        Debug.Log("Courutine started");
        yield return new WaitForSeconds(loadSceneDelay);

        gameObject.GetComponent<ScenesController>().LoadScene("MenuScene");
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
}
