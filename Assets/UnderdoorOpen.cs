using UnityEngine;

public class UnderdoorOpen : MonoBehaviour
{
   [SerializeField] GateController openTrigger;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
   public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            openTrigger.OpenGate();
            Debug.Log($"jeg er her hihi");
        }
    }
}
