using System;
using System.Collections.Generic;
using System.Text;

namespace assignment.Sample.Domain
{
    /// <summary>
    /// 움직이는 객체를 위한 인터페이스
    /// </summary>
    public interface IMovableObject
    {
        public void Move(float x, float y);
    }
}
