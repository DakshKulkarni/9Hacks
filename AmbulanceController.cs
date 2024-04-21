using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AmbulanceController : MonoBehaviour
{
    public GameObject hospital; 
    private int humansTakenCount = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Humans"))
        {
            Debug.Log("WORKS");
            Destroy(other.gameObject); 
            humansTakenCount++; 
            DisplayHumansTakenCount();
        }
    }
    void DisplayHumansTakenCount()
    {
        Debug.Log("Humans taken: " + humansTakenCount);
    }
    public void GoToHospital()
    {
        if (hospital != null)
        {
            transform.position = hospital.transform.position;
        }
    }
}
