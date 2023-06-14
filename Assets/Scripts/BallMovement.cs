using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
using DG.Tweening;
using System.Collections.Generic;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private LevelManager levelManager;

    [SerializeField] private float stepDuration = 0.1f;
    [SerializeField] private LayerMask wallsAndRoadsLayer;
    private const float MAX_RAY_DISTANCE = 10f;

    private Vector3 moveDirection;
    private bool canMove = true;


    private void Start()
{
    // transform.position = levelManager.defaultBallRoadTile.position;

    swipeListener.OnSwipe.AddListener(swipe =>
    {
        switch (swipe)
        {
            case "Right":
                Debug.Log(swipe); //debug
                moveDirection = Vector3.right;
                break;
            case "Left":
                Debug.Log(swipe); //debug
                moveDirection = Vector3.left;
                break;
            case "Up":
                Debug.Log(swipe); //debug
                moveDirection = Vector3.forward;
                break;
            case "Down":
                Debug.Log(swipe); //debug
                moveDirection = Vector3.back;
                break;
        }
        MoveBall();
    });
}

private void MoveBall()
{
    if (canMove)
    {
        canMove = false;

        RaycastHit[] hits = Physics.RaycastAll(transform.position, moveDirection, MAX_RAY_DISTANCE, wallsAndRoadsLayer.value);

        Vector3 targetPosition = transform.position;

        int steps = 0;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.isTrigger)
            {

            }
            else // Wall tile
            {
                if (i == 0) // means wall is near the ball
                {
                    canMove = true;
                    return;
                }
                //else:
                steps = i;
                targetPosition = hits[i - 1].transform.position;
                break;
            }
        }

        float moveDuration = stepDuration * steps;

        transform.DOMove(targetPosition, moveDuration).SetEase(Ease.OutExpo).OnComplete(() => canMove = true);
    }
}

}
