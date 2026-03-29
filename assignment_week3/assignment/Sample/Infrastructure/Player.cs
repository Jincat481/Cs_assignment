using assignment.Sample.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace assignment.Sample.Infrastructure
{
    public class Player : IPlayer, IGrowable, IMovableObject, IDamageable
    {
        public string ID { get; }
        private TransformData _tr;
        private StatusValue _status;

        public Player() { }
        public Player(string id)
        {
            this.ID = id;
            _tr = new TransformData(0f, 0f); // 초기 생성자
            _status = new StatusValue(100, 0); // 초기 생성자
        }
        /// <summary>
        /// IGrowable 인터페이스 구현
        /// </summary>
        public void SetEXP (int val)
        {
            _status.SetEXP(val);
        }
        /// <summary>
        /// IMovableObject 인터페이스 구현
        /// </summary>
        public void Move(float x, float y)
        {
            _tr.SetX(x);
            _tr.SetY(y);
            Console.WriteLine($"[Player {ID}] 이동 완료 : ({_tr.X}, {_tr.Y})");
        }
        /// <summary>
        /// IDamageable 인터페이스 구현
        /// </summary>
        public void SetHP(int val)
        {
            _status.SetHP(val);
        }
    }
}
