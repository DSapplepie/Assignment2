using UnityEngine;
using UnityEngine.UI;

public class AwarenessBar : MonoBehaviour
{
   public Slider slider;

   public void SetDefaultAwareness(float defaultAwareness){
    slider.maxValue = 1f;
    slider.value = defaultAwareness;
   }
   
   public void SetAwareness (float currentAwareness){
    slider.value = currentAwareness;
    Debug.Log("AWARENESS ACCESSED: = " + slider.value.ToString());
   }
}
