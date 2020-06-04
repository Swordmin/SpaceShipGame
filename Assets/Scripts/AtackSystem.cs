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

    [SerializeField] public int onAimId;

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
            bullet.GetComponent<BulletControll>().onAimId = onAimId;
            float _chance = 50f + GetComponent<PlayerControll>().ship.GetGunnerExp(0);
            bullet.GetComponent<BulletControll>().сhanceMiss = _chance;
            bullet.GetComponent<BulletControll>()._pC = GetComponent<PlayerControll>();
            ReloadBegin();
        }
    }

    private void ReloadBegin() 
    {
        reload = 0;
        IndexAim.fillAmount = 0;
    }

    public void OnAim(int id)
    {
        onAimId = id;
    }

    private IEnumerator TimerAim()
    {
        IndexAim.fillAmount = reload;
        while (true)
        {
            reload += 0.5f;
            IndexAim.fillAmount = reload;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
