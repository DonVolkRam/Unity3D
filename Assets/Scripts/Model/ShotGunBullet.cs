using UnityEngine;
using System.Collections.Generic;

namespace Geekbrains
{
    public sealed class ShotGunBullet : Ammunition
    {
        //[SerializeField] private Transform _fraction;
        [SerializeField] private float _damage = 20; // Урон пули
        [SerializeField] private float _mass = 0.02f; // Масса пули
        [SerializeField] private float _spread = 0.05f; // Разброс
        [SerializeField] private float _fractionCount = 10; //количество дробей
        //[SerializeField] public GameObject pellet;
        //List<Quaternion> pellets;
        

        public float FrcationCount => _fractionCount;

        //var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation) as ShotGunBullet;// Pool object

        protected override void Awake()
        {
            base.Awake();
            //for (int i = 0; i < _fractionCount; i++)
            //{
            //    pellets.Add(Quaternion.Euler(Vector3.zero));
            //}
            
        }
        // Текущий урон, который может нанести пуля
        private float _currentDamage;
        //protected override void Awake()
        //{
        //    base.Awake();
        //    // Если пуля не встретит ничего, то через заданное время пуля самоуничтожится
        //    Destroy(InstanceObject, _timeToDestruct);
        //    _currentDamage = _damage;
        //    GetRigidbody.mass = _mass;
        //}

        //private void SetDamage(ISetDamage obj)
        //{
        //    if (obj != null)
        //        // Вызываем функцию получения урона
        //        obj.ApplyDamage(_currentDamage);
        //}

        public override void AddForce(Vector3 dir)
        {
            Vector3 tempdir = new Vector3(Random.Range(dir.x - dir.magnitude * _spread, dir.x + dir.magnitude * _spread),
                                Random.Range(dir.y - dir.magnitude * _spread, dir.y + dir.magnitude * _spread),
                                Random.Range(dir.z - dir.magnitude * _spread, dir.z + dir.magnitude * _spread));
            //foreach (Quaternion item in pellets)
            //{
            //    GameObject p = Instantiate(pellet, _fraction.position, _fraction.rotation);
                      

                
            //}
            if (!Rigidbody) return;
            Rigidbody.AddForce(tempdir);
        }

        private void OnCollisionEnter(UnityEngine.Collision collision)
        {
            //дописать доп урон
            var tempObj = collision.gameObject.GetComponent<ISetDamage>();

            if (tempObj != null)
            {
                tempObj.SetDamage(new InfoCollision(_curDamage, Rigidbody.velocity));
            }

            Destroy(gameObject);
            // Вернуть в пул


            //// Если столкнулись с другой пулей, ничего не делаем
            //if (collision.collider.tag == "Bullet") return;
            //// Передаем в функцию компоненты унаследованный от интерфейса ISetDamage
            //SetDamage(collision.gameObject.GetComponent<ISetDamage>());
            //// Тут можно дописать функционал. Например, на месте столкновения создавать частицы искр и с помощью декалей вставлять дырки от пуль
            //// Удаляем пулю
            //Destroy(gameObject);
            ////Destroy(InstanceObject);
        }
    }
}