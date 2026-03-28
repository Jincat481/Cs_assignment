using assignment.Sample.Domain;
using assignment.Sample.Infrastructure;
using System.Numerics;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 초기 데이터 생성
            // TransformData initPos = new TransformData(10.0f, 20.0f);
            // StatusValue initStatus = new StatusValue(100, 0);

            // 2. Player 생성 (합성 데이터 주입)
            Player player = new Player("User_001");

            // 3. 인벤토리 생성 및 의존성 주입
            ItemInventory inventory = new ItemInventory();
            inventory.SetOwner(player);

            // 4. 동작 테스트
            player.Move(66.6f, 4444.4444f);
            inventory.LoadInventory();
        }
    }
}