using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Prisma : MonoBehaviour
{
    [SerializeField]
    float steps = 12;
    float rotationSteps;

    public Transform[] rings;

    public float CorrectRingStep1 = 1;
    public float CorrectRingStep2 = 1;
    public float CorrectRingStep3 = 1;

    float currentRingStep1;
    float currentRingStep2;
    float currentRingStep3;

    public float startingRingStep1;
    public float startingRingStep2;
    public float startingRingStep3;

    public bool canRotate = true;
    Sequence resetSequence;

    public void Awake(){
        rotationSteps = 360/steps;
        resetSequence = DOTween.Sequence();
        foreach(Transform ring in rings){
            resetSequence.Append(ring.DORotate(new Vector3(0,0,0),1).SetEase(Ease.InOutBack));
        }
    }

    public void Start(){
    
    }

    public void InitRings(){

    }

    public void OnValidate(){
        rotationSteps = 360/steps;
        ResetSteps();
    }

    public void UseButton1(){
        if(canRotate){
            Transform ring = rings[0];
            canRotate = false;
            if (currentRingStep1 == 12f)
            {
                currentRingStep1 = 1;
            }
            else
            {
                currentRingStep1 += 1;
            }
            // DOTween.To(()=> ring.rotation, x=>ring.rotation=x,new Vector3(0,rotationSteps*currentRingStep1,0),1).OnComplete(RotateToggle);
            ring.DORotate(new Vector3(0, rotationSteps * currentRingStep1, 0), 1).OnComplete(RotateToggle);
        }
    }

    public void UseButton2(){
        if(canRotate){
            Transform ring = rings[1];
            canRotate = false;
            if (currentRingStep2 == 12f)
            {
                currentRingStep2 = 1;
            }
            else
            {
                currentRingStep2 += 1;
            }
            //DOTween.To(()=> ring.rotation, x=>ring.rotation=x,new Vector3(0,rotationSteps*currentRingStep2,0),1).OnComplete(RotateToggle);
            ring.DORotate(new Vector3(0, rotationSteps * currentRingStep2, 0), 1);
        }
    }

    public void UseButton3(){
        if(canRotate){
            Transform ring = rings[2];
            canRotate = false;
            if (currentRingStep3 == 12f)
            {
                currentRingStep3 = 1;
            }
            else
            {
                currentRingStep3 += 1;
            }
            //DOTween.To(()=> ring.rotation, x=>ring.rotation=x,new Vector3(0,rotationSteps*currentRingStep3,0),1).OnComplete(RotateToggle);
            ring.DORotate(new Vector3(0, rotationSteps * currentRingStep3, 0), 1);
        }
    }

    public void ResetSteps(){
        canRotate = false;
        resetSequence.Play().OnComplete(RotateToggle);
        currentRingStep1 = 0;
        currentRingStep2 = 0;
        currentRingStep3 = 0;
    }

    public void RotateToggle(){
        canRotate = !canRotate;
    }
}
