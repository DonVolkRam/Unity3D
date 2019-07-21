using UnityEngine;
namespace Geekbrains // Данный класс является помощником, поэтому помещаем его в пространство имен Geekbrains.Helper
{
    /// <summary>
    /// Класс для хранения ссылок на объекты
    /// </summary>
    public class ObjectManager : MonoBehaviour
    {
        [SerializeField]
        private Ammunition[] _ammunitionList = new
        Ammunition[5];
        [SerializeField] private Weapon[] _weaponsList = new Weapon[5];
        #region Property
        public Weapon[] GetWeaponsList
        {
            get { return _weaponsList; }
        }
        public Ammunition[] GetAmmunitionList
        {
            get { return _ammunitionList; }
        }
        #endregion
    }
}