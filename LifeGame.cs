using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class LifeGame {
  public static void Main (string[] args) {
    GameField gameField = new GameField();
    gameField.Construct();
    gameField.Game(30);

    
  }
}

public class Cell{
  public int state = 0;

  public override string ToString(){
    if (state == 1)
      return "# ";
    else
      return "  ";  
  }

  public void Start(){
    Random rand = new Random();
    this.state = rand.Next(0, 2);
  }


  public void Life(int[] neigbours){
    int nNum = neigbours.Sum();
    
    if (nNum < 2){
      this.state = 0;
    }

    else if (nNum > 3){
      this.state = 0;
    }

    else if (nNum == 3){
      this.state = 1;
    }

  }
}


public class GameField{
  public static int lifeFieldLen = 15;
  Cell[,] lifeField = new Cell[lifeFieldLen, lifeFieldLen];


  public void Construct(){
    for (int i = 0; i < lifeFieldLen; i++){
      for (int j = 0; j < lifeFieldLen; j++){
        this.lifeField[i, j] = new Cell();
        this.lifeField[i, j].Start();
      }
    }
  }


  public void Game(int S){
    for (int s = 0; s < S; s++){
      Console.Clear();
      for (int i = 0; i < lifeFieldLen; i++){
        for (int j = 0; j < lifeFieldLen; j++){
          int[] neigbours_states = new int[8];
          
          try {
            neigbours_states[0] = lifeField[i-1, j-1].state;
          }
          catch (Exception e){
            neigbours_states[0] = 0;
          }

          try {
            neigbours_states[1] = lifeField[i-1, j].state;
          }
          catch (Exception e){
            neigbours_states[1] = 0;
          }

          try {
            neigbours_states[2] = lifeField[i-1, j+1].state;
          }
          catch (Exception e){
            neigbours_states[2] = 0;
          }

          try {
            neigbours_states[3] = lifeField[i, j-1].state;
          }
          catch (Exception e){
            neigbours_states[3] = 0;
          }

          try {
            neigbours_states[4] = lifeField[i, j+1].state;
          }
          catch (Exception e){
            neigbours_states[4] = 0;
          }

          try {
            neigbours_states[5] = lifeField[i+1, j-1].state;
          }
          catch (Exception e){
            neigbours_states[5] = 0;
          }

          try {
            neigbours_states[6] = lifeField[i+1, j].state;
          }
          catch (Exception e){
            neigbours_states[6] = 0;
          }
          
          try {
            neigbours_states[7] = lifeField[i+1, j+1].state;
          }
          catch (Exception e){
            neigbours_states[7] = 0;
          }

          lifeField[i, j].Life(neigbours_states);
          Console.Write(lifeField[i, j]);
        }
      Console.WriteLine();
      }

      Thread.Sleep(400);
    }

  }

    
}
