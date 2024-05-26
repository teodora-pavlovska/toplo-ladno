
public class Game{

  int duckRow = 8; // Starting position of the duck
  int duckCol = 3;

          var movements = new Dictionary<string, (int, int)>
  {
      { "up", (-1, 0) },
      { "down", (1, 0) },
      { "left", (0, -1) },
      { "right", (0, 1) }
  };

    public static void MoveDuck(string direction)
    {
        int newRow = duckRow + direction.Item1;
        int newCol = duckCol + direction.Item2;

        if (board[newRow, newCol] == ".")
        {
            board[duckRow, duckCol] = ".";
            duckRow = newRow;
            duckCol = newCol;
            board[duckRow, duckCol] = "D"; // D represents the duck
            Spread(board);
        }
    }

string[,] init_state = new string[,]
{
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "l", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", ".", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", "g", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", "b", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "#", "w", "#", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "w", "w", "w", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "w", "w", "w", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"}
};

  public static void Main(string [] args){

  }
}
// assumed initial state of the board 


// desired state 

string[,] desiredState = new string[,]
{
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "l", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", ".", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", "g", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", ".", ".", "b", ".", ".", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "#", "w", "#", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "w", "w", "w", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", ".", ".", ".", "#", "w", "w", "w", "#", ".", ".", ".", ".", ".", ".", "#"},
    { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"}
};
// its probably better to have one general function for the spread action and another one for the adjacents ?

int rows = board.GetLength(0);
int cols = board.GetLength(1);
string[,] newBoard = (string[,])board.Clone(); 

 for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (board[i, j] == "w") // Water
            {
                SpreadToAdjacentTiles(board, newBoard, r, c, "w");
            }
            else if (board[i, j] == "l") // Lava
            {
                SpreadToAdjacentTiles(board, newBoard, r, c, "l");
            }
        }
    }