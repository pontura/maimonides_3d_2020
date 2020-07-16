using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Character charater;
    public float moveSpeed = 5;
    bool doFollow = false;

    public void OnTrigger(Character _charater, bool entered)
    {        
        if (entered)
        {
            this.charater = _charater;
            GetComponent<WalkRandom>().enabled = false;
            Invoke("LoopShooting", 2);
            Invoke("StartFollowing", 2);
        } else
        {
            doFollow = false;
            CancelInvoke();
            GetComponent<WalkRandom>().enabled = true;
            this.charater = null;
        }
    }
    void StartFollowing()
    {
        doFollow = true;
    }
    void LoopShooting()
    {
        if (charater == null)
            return;

        GetComponent<Shooter>().Shoot();
        Invoke("LoopShooting", 2);
    }
    private void Update()
    {
        if (charater == null)
            return;

        //hay un character!
        transform.LookAt(charater.transform);

        if(doFollow)
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
    }

}
