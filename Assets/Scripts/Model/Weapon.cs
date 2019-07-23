﻿using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
	public abstract class Weapon : BaseObjectScene
	{
		private int _maxCountAmmunition = 40;
		private int _minCountAmmunition = 20;
		private int _countClip = 5;
		public Ammunition Ammunition;
		public Clip Clip;

        protected AmmunitionType[] _ammunitionType = {AmmunitionType.Bullet};

		[SerializeField] protected Transform _barrel;
		[SerializeField] protected float _force = 999;
		[SerializeField] protected float _rechergeTime = 0.2f;

		private Queue<Clip> _clips = new Queue<Clip>();
        public int MaxCountAmmunition { get => _maxCountAmmunition; set => _maxCountAmmunition = value; }
        public int MinCountAmmunition { get => _minCountAmmunition; set => _minCountAmmunition = value; }
        public int CountClip { get => _countClip; set => _countClip = value; }


        protected bool _isReady = true;
		protected Timer _timer = new Timer();

        private void Start()
        {
            //for (var i = 0; i <= _countClip; i++)
            //{
            //    AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
            //}

            //ReloadClip();
        }

        public abstract void Fire();

        protected virtual void Update()
        {
            _timer.Update();
            if (_timer.IsEvent())
            {
                ReadyShoot();
            }
        }

        protected void ReadyShoot()
		{
			_isReady = true;
		}

		protected void AddClip(Clip clip)
		{
			_clips.Enqueue(clip);
		}

		public void ReloadClip()
		{
			if (CurrentCountClip <= 0) return;
			Clip = _clips.Dequeue();
		}

		public int CurrentCountClip => _clips.Count;
	}
}