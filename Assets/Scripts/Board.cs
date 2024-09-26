

using UnityEngine;
using UnityEngine.UI;


public class Board : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
   [SerializeField] private Transform boardUI;
   [SerializeField] private GridLayoutGroup gridLayoutGroup;
   [SerializeField] private int boardSize;
   private string[,] matrix;
   public string currentTurn = "x" ;

   private void Start() {
    matrix = new string[boardSize+1 , boardSize +1];
    gridLayoutGroup.constraintCount = boardSize;
    CreateBorad();
   }
   private void CreateBorad(){
    for (int i = 1 ; i <= boardSize ; i++){
        for (int j = 1 ; j <= boardSize ; j++){
          GameObject cellTransfrom =  Instantiate (cellPrefab, boardUI);
          Cell cell = cellTransfrom.GetComponent<Cell>();
          cell.row = i;
          cell.colum = j;
           matrix[i,j] = "";
        }
    }
   }
   public bool Check(int row, int colum) {
    matrix[row,colum] = currentTurn;
    bool result = false;
     // CheckHangDoc 
     int count = 0;
     for (int i = row - 1 ; i >= 1 ; i--){
        if (matrix[i,colum] == currentTurn){
            count++;
        }
        else {
            break;
        }
     }
     for (int i = row + 1 ; i <= boardSize ; i++){
        if (matrix[i,colum] == currentTurn){
            count++;
        }
        else {
            break;
        }
     }
     if (count + 1 >= 5){
        result = true;
     }

     // CheckHangNgang
     count = 0 ;
      for (int i = colum - 1 ; i >= 1 ; i--){
        if (matrix[row,i] == currentTurn){
            count++;
        }
        else {
            break;
        }
     }
     for (int i = row + 1 ; i <= boardSize ; i++){
        if (matrix[row,i] == currentTurn){
            count++;
        }
        else {
            break;
        }
     }
     if (count + 1 >= 5){
        result = true;
     }

     // CheckHangCheo 
     count = 0;
     for (int i = colum -1 ; i >= 1 ; i--){ // cheo tren trai 
        if (matrix[row - (colum-i),i] == currentTurn){
            count ++ ;
        }
        else {
            break;
        }
     }
     for (int i = colum + 1 ; i <= boardSize ; i++){ // cheo duoi trai 
        if (matrix[row + (colum-i),i] == currentTurn){
            count ++ ;
        }
        else {
            break;
        }
     }
     if (count + 1 >= 5){
        result = true;
     }
     // CheckHangCheo 2
     count = 0;
     for (int i = colum + 1 ; i <= boardSize ; i++){ // cheo tren phai
        if (matrix[row - (colum-i),i] == currentTurn){
            count ++ ;
        }
        else {
            break;
        }
     }

     for (int i = colum - 1 ; i >=1 ; i--){ // cheo duoi phai
        if (matrix[row + (colum-i),i] == currentTurn){
            count ++ ;
        }
        else {
            break;
        }
     }
     if (count + 1 >= 5){
        result = true;
     }
     
     return result;
   }
   
   }

