using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    public Tank[] neighbours;
    bool active = false;
    public Transform tankbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

    public void Use(){
        active = !active;
        Animate();
        foreach(Tank tank in neighbours){
            tank.active = !tank.active;
            tank.Animate();        
        }
    }
    void Animate(){
        if(!active){
            DOTween.To(()=>tankbody.localPosition, x=> tankbody.localPosition = x, new Vector3(tankbody.localPosition.x,-2f,tankbody.localPosition.z), 1f);
        }
        else{
            DOTween.To(()=>tankbody.localPosition, x=> tankbody.localPosition = x, new Vector3(tankbody.localPosition.x, 0f,tankbody.localPosition.z), 1f);
        }
    }
}
