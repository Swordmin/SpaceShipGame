using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtackSystem : MonoBehaviour
{
    [SerializeField] private Image IndexAim;

    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject gun;

    [SerializeField] private float scatter;
    [SerializeField] private float reload;

    private void Start()
    {
        StartCoroutine(TimerAim());
    }

    public void Fire()
    {
        if (reload >= 1)
        {
            GameObject bullet = Instantiate(bulletPref, gun.transform.position, gameObject.transform.rotation);
            bullet.GetComponent<BulletControll>().scatter = scatter;
            ReloadBegin();
        }
    }

    private void ReloadBegin() 
    {
        reload = 0;
        IndexAim.fillAmount = 0;
    }

    public void StartAim() 
    {
    }

    private IEnumerator TimerAim()
    {
        IndexAim.fillAmount = reload;
        while (true)
        {
            reload += 0.1f;
            IndexAim.fillAmount = reload;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
