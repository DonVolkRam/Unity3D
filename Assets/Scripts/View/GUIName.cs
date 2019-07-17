using UnityEngine;
using System.Collections;
namespace Geekbrains
{
    public class GUIName : MonoBehaviour
    {
        public Transform cam1; // Камера
        RaycastHit rch1;// луч который будет выходить из камеры
        public bool _showName; // переменная
        void Update()
        {

            Vector3 Direction = cam1.TransformDirection(Vector3.forward); //
            if (Physics.Raycast(cam1.position, Direction, out rch1, 10)) //заставляет бить из нашей камеры луч на дистанцию равную 3
            {
                if (rch1.collider.GetComponent<Name>()) // и если этот луч встретился с коллайдером объекта на котором есть скрипт Name,
                {
                    _showName = true; // то переменная становится равна true.
                }
            }
            else
                _showName = false;
        }
        public void OnGUI()
        {
            if (_showName) // если переменная становится равна true
            {
                GUI.Label(new Rect((Screen.width) / 2, (Screen.height) / 2, 125, 25), " " + rch1.collider.GetComponent<Name>().nameGui); // то отображаем на экране персонажа, в указанном месте, значение nameGUI, которое берем из скрипта Name.
            }
        }
    }
}