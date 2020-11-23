using System.Collections.Generic;

namespace WebApplication
{
    public class RoomsRepo
    {
        public string[] Types = new[] {"o", "x", "empty"};
        public Dictionary<string, string[][]> RoomsAndBoards;

        public RoomsRepo()
        {
            this.RoomsAndBoards = new Dictionary<string, string[][]>();
            for (int i = 1; i < 10; i++)
            {
                RoomsAndBoards["Room "+i] = CreateEmptyBoard(); 
            }
        }
        

        public string[][] CreateEmptyBoard()
        {
            var arr = new string[3][];

            for (int i = 0; i < 3; i++)
            {
                arr[i] = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    arr[i][j] = "empty";
                }
            }

            return arr;
        }
    }
}