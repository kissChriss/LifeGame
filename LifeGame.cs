using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class LifeGame {
  public static void Main (string[] args) {
    GameField gameField = new GameField();
    gameField.Construct(); //make first positions for each cell on the field
    gameField.Game(30); //game start point with steps number

    
  }
}

public class Cell{
  public int state = 0; //cell is dead firstly

  public override string ToString(){
    if (state == 1)
      return "# "; //alive cell image on the field
    else
      return "  "; //dead cell image on the field
  }

  public void Start(){
    Random rand = new Random();
    this.state = rand.Next(0, 2); //first random life status for cell
  }


  public void Life(int nNum){
    //alive cells-neigbours number
    
    if (nNum < 2){
      this.state = 0;
    }

    else if (nNum > 3){
      this.state = 0;
    }

    else if (state == 1 && (nNum == 3 || nNum == 2)){
      this.state = 1; 
    }

    else if (state == 0 && nNum == 3){
      this.state = 1; 
    }

  }
}


public class GameField{
  public static int lifeFieldLen = 15; 
  Cell[,] lifeField = new Cell[lifeFieldLen, lifeFieldLen]; //field size = 15x15


  public void Construct(){
    for (int i = 0; i < lifeFieldLen; i++){
      for (int j = 0; j < lifeFieldLen; j++){
        this.lifeField[i, j] = new Cell(); //create cells
        this.lifeField[i, j].Start(); //create first cells life status 
      }
    }
  }


  public void Game(int S){
    for (int s = 0; s < S; s++){
      Console.Clear();
      for (int i = 0; i < lifeFieldLen; i++){
        for (int j = 0; j < lifeFieldLen; j++){
          int neigbours_states = 0;
          
          try {
            neigbours_states += lifeField[i-1, j-1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i-1, j].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i-1, j+1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i, j-1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i, j+1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i+1, j-1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          try {
            neigbours_states += lifeField[i+1, j].state;
          }
          catch (IndexOutOfRangeException e){
          }
          
          try {
            neigbours_states += lifeField[i+1, j+1].state;
          }
          catch (IndexOutOfRangeException e){
          }

          lifeField[i, j].Life(neigbours_states); //change life status depend on alive neigbours number
          Console.Write(lifeField[i, j]); //draw current step 
        }
      Console.WriteLine();
      }

      Thread.Sleep(400);
    }

  }

    
}
