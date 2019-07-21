using UnityEngine;

namespace Geekbrains
{
    public sealed class Bullet : Ammunition
    {
        [SerializeField] private float _damage = 20; // Урон пули
        [SerializeField] private float _mass = 0.01f; // Масса пули

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