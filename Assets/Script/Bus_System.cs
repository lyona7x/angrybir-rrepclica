using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Bus_System : MonoBehaviour
{
   public static Action OnGameOver;
   public static void CallGameOver(){OnGameOver?.Invoke();}
}
