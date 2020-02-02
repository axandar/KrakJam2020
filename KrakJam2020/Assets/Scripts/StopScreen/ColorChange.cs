using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour{
    private TruckColorPicker _truckColorPicker;
    private void Start(){
        _truckColorPicker = GameObject.FindGameObjectWithTag(Tags.TRUCK_COLOR_CHANGER).GetComponent<TruckColorPicker>();
    }

    public void ChangeTruckColor(int value){
        switch (value){
            case 0: _truckColorPicker.color = TruckColorPicker.TruckColor.Cyan;
                break;
            case 1: _truckColorPicker.color = TruckColorPicker.TruckColor.Red;
                break;
            case 2: _truckColorPicker.color = TruckColorPicker.TruckColor.Yellow;
                break;
        }
        _truckColorPicker.ChangeColour();
    }
}
