
namespace Geekbrains
{
    public sealed class Gun : Weapon
    {
        private int GunCountAmunition = 30;
        private int MaxCountClip = 6;
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;
            if (!Ammunition) return;
            var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation) as Bullet;// Pool object
            if (temAmmunition)
                temAmmunition.AddForce(_barrel.forward * _force);
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