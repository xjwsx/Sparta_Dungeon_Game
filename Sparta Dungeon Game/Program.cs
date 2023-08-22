using System;
using System.Xml.Linq;

namespace Sparta_Dungeon_Game
{
    public class Item
    {
        public string Name { get; set;}
        public string Characteristic { get; set; }
        public int Def { get; set; }
        public int Atk { get; set; }
        public Item(string name, string characteristic, int def, int atk)
        {
            Name = name;
            Characteristic = characteristic;
            Def = def;
            Atk = atk;
        }
    }
    public class Character
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Ate { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Character(string name, string job, int level, int ate, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Ate = ate;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Program
    {
        private static Character player;
        private static Item item;
        static List<Item> itemList = new List<Item>();

        public static void DisplayGameInfo()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(1, 2);
            switch(input)
            {
                case 1:
                    DisplayMyInfo(); 
                    break;
                case 2:
                    DisplayInvantory();
                    break;
            }
        }
        public static void DisplayMyInfo()
        {
            Console.Clear();

            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine("{0} ({1})", player.Name,player.Job);
            Console.WriteLine("공격력 : {0}",player.Ate);
            Console.WriteLine("방어력 : {0}", player.Def);
            Console.WriteLine("체 력 : {0}",player.Hp);
            Console.WriteLine("Gold : {0}", player.Gold);
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameInfo();
                    break;
            }
        }
        public static void DisplayInvantory()
        {
            Console.Clear();

            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("- {0}        | 방어력 +{1} | {2}", itemList[0].Name, itemList[0].Def, itemList[0].Characteristic);
            Console.WriteLine("- {0}         | 공격력 +{1} | {2}", itemList[1].Name, itemList[1].Atk, itemList[1].Characteristic);
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">>");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameInfo();
                    break;
                case 1:
                    DisplayMyInfo();
                    break;
            }

        }
        public static void GameDataSetting()
        {
            player = new Character("Chad", "전사", 01, 10, 5, 100, 1500);
            item = new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷 입니다.", 5, 0);
            itemList.Add(item);
            item = new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 0, 2);
            itemList.Add(item);
        }
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out int ret);
                if(parseSuccess)
                {
                    if(ret >= min && ret <= max)
                    {
                        return ret;
                    }
                }
                Console.WriteLine("잘못된 입력입니다.") ;
            }
        }
        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameInfo();
        }
    }
}