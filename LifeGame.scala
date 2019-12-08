import scala.util.Try
import scala.util.Random

object LifeGame {
  def main(args: Array[String]): Unit = {
    val gameField = new GameField
    gameField.construct() //make first positions for each cell on the field
    gameField.game(35) //game start point with steps number
  }
}

class Cell {
  var state: Int = 0 //cell is dead firstly

  override def toString() : String = {
    if (state == 1)
      return "# " //alive cell image on the field
    else 
      return "  " //dead cell image on the field
  }

  def start() : Unit = {
    state = Random.nextInt(2) //first random life status for cell
  }


  def life(nNum:Int) : Unit = {
    //alive cells-neigbours number

    if (nNum < 2) {
      state = 0
    }

    else if (nNum > 3){
      state = 0
    }

    else if (state == 1 && (nNum == 3 || nNum == 2)){
      state = 1
    }

    else if (state == 0 && nNum == 3){
      state = 1;
    }

  }
}

class GameField{
  val lifeFieldLen:Int = 15
  val lifeField = Array.ofDim[Cell](lifeFieldLen,lifeFieldLen); //field size 

  def construct() : Unit = {
    for (i <- 0 until lifeFieldLen){
      for (j <- 0 until lifeFieldLen){
        lifeField(i)(j) = new Cell(); //create cells
        lifeField(i)(j).start(); //create first cells life status 
      }
    } 
  } 

  def game(S:Int) : Unit = {
    for (i <- 0 until S){
      print("\u001b[2J") //clean terminal window
      for (i <- 0 until lifeFieldLen){
        for (j <- 0 until lifeFieldLen){
          var neigbours_states:Int = 0

          Try(neigbours_states += lifeField(i-1)(j-1).state)
          Try(neigbours_states += lifeField(i-1)(j).state)
          Try(neigbours_states += lifeField(i-1)(j+1).state)
          Try(neigbours_states += lifeField(i)(j-1).state)
          Try(neigbours_states += lifeField(i)(j+1).state)
          Try(neigbours_states += lifeField(i+1)(j-1).state)
          Try(neigbours_states += lifeField(i+1)(j).state)
          Try(neigbours_states += lifeField(i+1)(j+1).state)

          lifeField(i)(j).life(neigbours_states) //change life status depend on alive neigbours number
          print(lifeField(i)(j))
        }
        println();
      }
        Thread.sleep(400)
    }
  }

}
