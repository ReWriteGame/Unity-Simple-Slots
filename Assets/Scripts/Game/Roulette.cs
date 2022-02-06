using UnityEngine;
using UnityEngine.Events;
using System.Collections;



public class Roulette : MonoBehaviour
{
    [SerializeField]private float sizeSlots = 10;
    [SerializeField]private Vector2 speedLimit = new Vector2(0.2f,10);
    [SerializeField]private float acceleration = 5;
    [SerializeField]private int sizeSlotsDamping = 5;
    [SerializeField]private Vector3 directionRotate;
    [SerializeField]private Vector2 sizeSlotsRotate;

    private float angleForOneSlot;
    //private bool isActive = false;

    public UnityEvent startRotateEvent;
    public UnityEvent endRotateEvent;
    
    private void Awake()
    {
        angleForOneSlot = 360 / sizeSlots;
    }

    public void StartRandomRotate()
    {
        StartCoroutine(StartRotateCor((int)Random.Range(sizeSlotsRotate.x,sizeSlotsRotate.y)));
    }
   
    public void StartRotate(int sizeItem)
    {
        StartCoroutine(StartRotateCor(sizeItem));
    }
   
    private IEnumerator StartRotateCor(int sizeItem)
    {
        startRotateEvent?.Invoke();
        float fullAngleRotation = angleForOneSlot * sizeItem;
        float fullAngleDamping = angleForOneSlot * sizeSlotsDamping;
           
        for (float rotatedAngle = 0, newRot = 0; rotatedAngle < fullAngleRotation;  rotatedAngle += newRot)
        {
            newRot = (fullAngleRotation - rotatedAngle > fullAngleDamping)
                ? Mathf.Clamp(newRot + acceleration * Time.deltaTime, 0, speedLimit.y)
                : speedLimit.y * (fullAngleRotation - rotatedAngle) / fullAngleDamping + speedLimit.x;
               
            transform.Rotate(directionRotate.normalized * newRot);
            yield return null;
        }
        endRotateEvent?.Invoke();
        yield break;
    }
}