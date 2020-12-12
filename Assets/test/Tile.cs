using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Valve.VR;
using Valve.VR.InteractionSystem;
using System.Net;

public class Tile : MonoBehaviour
{
    public enum memoryType{
        red = 0,
        blue = 1,
        green = 2,
        yellow= 3,
        black = 4
    }
    public bool reset = false;
    public bool canInteract = true;
    Color startColor;
    Renderer rend;
    public memoryType memType;
    SteamVR_Action_Boolean BooleanAction;

    void Awake()
    {
        BooleanAction = SteamVR_Actions._default.GrabPinch;
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void PressAnimation(){
        DOTween.To(()=>transform.localPosition, x=> transform.localPosition = x, new Vector3(-0.03f,0,0) , 1f);

        switch (memType)
        {
            case memoryType.red:
                rend.material.DOColor(Color.red, 2);
                break;
            case memoryType.blue:
                rend.material.DOColor(Color.blue, 2);
                break;
            case memoryType.green:
                rend.material.DOColor(Color.green, 2);
                break;
            case memoryType.yellow:
                rend.material.DOColor(Color.yellow, 2);
                break;
            case memoryType.black:
                rend.material.DOColor(Color.black, 2);
                break;
            default:
                break;
        }

    }
    void Update()
    {
        if (reset)
        {
            reset = false;
            ResetAnimation();
        }
    }

    public void ResetAnimation(){
        DOTween.To(()=>transform.localPosition, x=> transform.localPosition = x, new Vector3(0,0,0) , 1f);
        rend.material.DOColor(startColor, 2);
        canInteract = true;
    }

    private void HandHoverUpdate(Hand hand)
    {
        if (BooleanAction.stateDown)
        {
            canInteract = false;
            PressAnimation();         
        }
	}
}
