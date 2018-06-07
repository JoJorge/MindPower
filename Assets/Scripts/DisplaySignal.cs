using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySignal : MonoBehaviour {

    public Texture2D[] signalIcons;

    private int indexSignalIcons = 1;

    TGCConnectionController controller;

    [SerializeField] RawImage signalImage;

    void Start() {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;

    }

    void OnUpdatePoorSignal(int value){
        if(value < 25){
            indexSignalIcons = 0;
        }else if(value >= 25 && value < 51){
            indexSignalIcons = 4;
        }else if(value >= 51 && value < 78){
            indexSignalIcons = 3;
        }else if(value >= 78 && value < 107){
            indexSignalIcons = 2;
        }else if(value >= 107){
            indexSignalIcons = 1;
        }
        if (signalImage.texture != signalIcons [indexSignalIcons]) {
            signalImage.texture = signalIcons [indexSignalIcons];
        }
    }
        
}
