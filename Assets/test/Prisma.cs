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

    public float CorrectRingStep1 = 0;
    public float CorrectRingStep2 = 0;
    public float CorrectRingStep3 = 0;

    float currentRingStep1;
    float currentRingStep2;
    float currentRingStep3;

    public bool canRotate = true;
    Sequence resetSequence;

    public void Awake(){
        rotationSteps = 360/steps;
        resetSequence = DOTween.Sequence();
        foreach(Transform ring in rings){
            resetSequence.Append(ring.DORotate(new Vector3(0,0,0),1).SetEase(Ease.InOutBack));
        }
    }
    public void OnValidate(){
        rotationSteps = 360/steps;
        ResetSteps();
    }

    public void UseButton1(){

    }

    public void UseButton2(){
        
    }

    public void UseButton3(){
        
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
