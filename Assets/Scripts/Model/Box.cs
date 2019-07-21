using UnityEngine;
namespace Geekbrains
{
    public class Box : BaseObjectScene, ISetDamage
    {
        [SerializeField] private float _hp = 100; // Количество жизней
        private bool _isDead = false; // Флаг смерти
        private float step = 2f;
        public void Update()
        {
            if (_isDead) // Если персонаж умер,запускаем анимацию смерти
            {
                //Color color = gameObject.color
                Color color = Color.red;
                if (color.a > 0) // Понижаем альфа-канал у материала(плавное затухание)
                {
                    color.a -= step / 100;
                    Color = color;
                }
                if (color.a < 1)
                {
                    Destroy(gameObject.GetComponent<Collider>());
                    Destroy(gameObject, 5f);
                }
            }
        }

        public void SetDamage(InfoCollision info)
        {
            if (_hp > 0) // Если жизней больше 0, получаем урон
            {
                _hp -= info.Damage;
            }
            if (_hp <= 0) // Если жизней меньше 0, окрашиваемся в красный цвет и говорим себе, что умерли
            {
                _hp = 0;
                Color = Color.red;
                _isDead = true;
            }
        }
    }
}