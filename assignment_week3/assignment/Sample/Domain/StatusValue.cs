using System;
using System.Collections.Generic;
using System.Text;

namespace assignment.Sample.Domain
{
    /// <summary>
    /// 스테이터 값을 위한 클래스
    /// </summary>
    public class StatusValue
    {
        public int HP { get; private set; }
        public int EXP { get; private set; }

        public StatusValue() { }
        public StatusValue(int hp, int exp)
        {
            this.HP = hp;
            this.EXP = exp;
        }
        public void SetHP(int val)
        {
            HP = val;
        }
        public void SetEXP(int val)
        {
            EXP = val;
        }
    }
}
