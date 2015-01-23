﻿using UnityEngine;

[RequireComponent(typeof(ScorpionSelector))]
public class KeyboardController : MonoBehaviour
{
    public KeyCode LeftLegKey = KeyCode.W;
    public KeyCode RightLegKey = KeyCode.E;

    private bool LeftLegPressed = false;
    private bool RightLegPressed = false;

    public Transform leftLeg;
    public Transform rightLeg;

    private Vector3 leftLegStart;
    private Vector3 rightLegStart;

    public float HeightYCoordinate;

    private float animationTime;
    private float maxAnimationTime = 0.25f;

    private ScorpionSelector selector;

    // Use this for initialization
    void Start()
    {
        leftLegStart = leftLeg.position;
        rightLegStart = rightLeg.position;
        animationTime = maxAnimationTime;

        selector = this.transform.GetComponent<ScorpionSelector>();
        if (selector == null)
            throw new MissingReferenceException();
    }

    // Update is called once per frame
    void Update()
    {
        if (LeftLegPressed || RightLegPressed)
        {
            //If you already raised a leg, just animate it
            animationTime -= Time.deltaTime;

            float animationFraction = animationTime / maxAnimationTime;

            if (LeftLegPressed)
            {
                Vector3 endPosition = leftLegStart;
                endPosition.y = HeightYCoordinate;

                leftLeg.position = Vector3.Lerp(endPosition, leftLegStart, animationFraction);
            }
            else if (RightLegPressed)
            {
                Vector3 endPosition = rightLegStart;
                endPosition.y = HeightYCoordinate;

                rightLeg.position = Vector3.Lerp(endPosition, rightLegStart, animationFraction);
            }

            return;
        }

        if (Input.GetKeyDown(LeftLegKey))
        {
            LeftLegPressed = true;

            if (selector.EntryPoint == ScorpionSelector.EntryPoints.Left)
            {
                // Signal WON
                Debug.Log("You win...");
            }
        }

        if (Input.GetKeyDown(RightLegKey))
        {
            RightLegPressed = true;

            if (selector.EntryPoint == ScorpionSelector.EntryPoints.Right)
            {
                // Signal WON
                Debug.Log("You win...");
            }
        }
    }
}