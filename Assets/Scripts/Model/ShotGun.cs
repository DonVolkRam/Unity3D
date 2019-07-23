using UnityEngine;
using System.Collections.Generic;

namespace Geekbrains
{
    public sealed class ShotGun : Weapon
    {
        private int GunCountAmunition = 8;
        private int MaxCountClip = 10;
        private int MaxFraction = 10;
        [SerializeField] private int spread = 5;
        List<Quaternion> pellets;

        protected override void Awake()
        {
            base.Awake();
            pellets = new List<Quaternion>(MaxFraction);
            for (int i = 0; i < MaxFraction; i++)
            {
                pellets.Add(Quaternion.Euler(Vector3.zero));
            }
        }

        public override void Fire()
        {
            int i = 0;
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (!Ammunition) return;
            foreach (Quaternion quat in pellets)
            {
                pellets[i] = Random.rotation;
                Ammunition p = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
                p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spread);
                 if (p)
                    p.AddForce(_barrel.forward * _force);
                i++;
            }
            //var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation) as ShotGunBullet;// Pool object
            //if (temAmmunition)
            //    temAmmunition.AddForce(_barrel.forward * _force);
            Clip.CountAmmunition--;
            _isReady = false;
            Invoke(nameof(ReadyShoot), _rechergeTime);
            //_timer.Start(_rechergeTime);
        }

        private void Start()
        {
            CountClip = MaxCountClip;
            for (var i = 0; i <= CountClip; i++)
            {
                AddClip(new Clip { CountAmmunition = GunCountAmunition });
            }

            ReloadClip();
        }

    }
}