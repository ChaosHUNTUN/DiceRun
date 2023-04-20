namespace ConsoleApp1
{
    public static class DiceHepler
    {
        private static int upSide = 1;
        private static int downSide = 6;
        private static int leftSide = 3;
        private static int rightSide = 4;
        private static int frontSide = 2;
        private static int backSide = 5;
        public static bool isUpSure = false;
        public static bool isRightSure = false;
        public static bool isFrontSure = false;
        public static int UpSide
        {
            get => upSide; set
            {
                if (value == 0)
                    value = 6;
                if (isUpSure) return;
                downSide = 7 - value;
                upSide = value;

                isUpSure = true;
                //从备选左右前后中去除上方及下方值
                var b = strings.FindIndex(a => a.Contains(value));
                strings.RemoveAt(b);
                //整理左右前后顺序
                if (IsOdd(value))
                {
                    indexNum.Add(strings[1][0]);
                    indexNum.Add(strings[0][0]);
                    indexNum.Add(strings[1][1]);
                    indexNum.Add(strings[0][1]);

                }
                else
                {
                    indexNum.Add(strings[0][0]);
                    indexNum.Add(strings[1][0]);
                    indexNum.Add(strings[0][1]);
                    indexNum.Add(strings[1][1]);
                }

                //当正上方为1时，正面的结果只能为2，3，4，5
                //当正上方为2时，正面的结果只能为1，3，4，6
            }
        }
        public static bool IsOdd(int a)
        {
            return a % 2 == 0;
        }
        public static List<List<int>> strings;
        public static void CreateNewStrings()
        {
            strings = new List<List<int>>() {
            new List<int> { 1,6},
            new List<int> { 2,5},
            new List<int> { 3,4}
            };
        }
        public static List<int> indexNum = new List<int>();
        //生成一个变量
        


        public static int GetAroundInt(int front)
        {
            var number = indexNum.FindIndex(x => x == front);
            if (number == 0)
                return indexNum[indexNum.Count - 1];
            else
                return indexNum[number - 1];


        }
        /// <summary>
        /// 1:2,3,5,4,6
        /// 2:3,1,4,6,5
        /// 3:1,2,6,5,4
        /// 4:2,1,5,6,3
        /// 5:1,3,6,4,2
        /// 6:3,2,4,5,1
        /// </summary>
        public static int DownSide
        {
            get => downSide; set
            {
                upSide = 7 - value;
                downSide = value;
            }
        }
        public static int LeftSide
        {
            get => leftSide; set
            {
                rightSide = 7 - value;
                leftSide = value;
            }
        }
        public static int RightSide
        {
            get => rightSide; set
            {
                rightSide = indexNum[value];
                FrontSide = GetAroundInt(rightSide);

                leftSide = 7 - rightSide;
                isRightSure = true;
            }
        }
        public static int FrontSide
        {
            get => frontSide; set
            {
                backSide = 7 - value;
                frontSide = value;
            }
        }
        public static int BackSide
        {
            get => backSide; set
            {
                frontSide = 7 - value;
                backSide = value;
            }
        }
        static int[] ying = new int[] { 1, 2, 3 };
        public static string isYING(int a)
        {
            return ying.Contains(a) ? "0" : "1";
        }
    }
}
