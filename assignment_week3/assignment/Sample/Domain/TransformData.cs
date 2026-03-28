using System;
using System.Collections.Generic;
using System.Text;

namespace assignment.Sample.Domain
{
    /// <summary>
    /// 트랜스폼 데이터를 위한 클래스
    /// </summary>
    public class TransformData
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public TransformData() { }
        public TransformData(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public void SetX(float val)
        {
            X = val;
        }
        public void SetY(float val)
        {
            Y = val;
        }
    }
}
