using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAtackSystem : MonoBehaviour
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
            bullet.GetComponent<BulletControll>()._pC = GetComponent<PlayerControll>();

            float сalculation = 50f + GetComponent<PlayerControll>().ship.GetGunnerExp(0);
            bullet.GetComponent<BulletControll>().сhanceMiss = сalculation - Percent(сalculation, 100 - GetComponent<PlayerControll>().partHealth[2], 0);
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
            reload += 0.2f;
            IndexAim.fillAmount = reload;
            yield return new WaitForSeconds(0.5f);
        }
    }

    private float Percent(float a, float p, float result)
    {
        return result = a * (p / 100);
    } //Считаем процент который будем отнимать от шанса попадания 
}
