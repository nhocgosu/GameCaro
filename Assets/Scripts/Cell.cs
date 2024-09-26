
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject gameOver;
    private Transform canvas;
    public int row ;
    public int colum ;
    private Board board ;
   [SerializeField] private Sprite xSprite;
   [SerializeField] private Sprite oSprite;

   private Image image;
   private Button button;

   private void Awake() {
    image = GetComponent<Image>();
    button = GetComponent<Button>();
    button.onClick.AddListener(OnClick);
   }
   private void Start() {
   board = FindObjectOfType<Board>();
    if (board == null)
    {
        Debug.LogError("Không tìm thấy đối tượng Board!");
    }
    canvas = FindObjectOfType<Canvas>().transform;
   }

   public void ChangeImage (string s ){
    if (s == "x"){
        image.sprite = xSprite;
    }
    else {
        image.sprite = oSprite;
    }
   }
   public void OnClick() {
    ChangeImage(board.currentTurn);
    if (board.Check(row, colum)){
      GameObject gameOverWindow =  Instantiate(gameOver,canvas);
      gameOverWindow.GetComponent<GameOver>().SetName(board.currentTurn);
    }
    if (board.currentTurn == "o"){
        board.currentTurn = "x";
    }
    else{
        board.currentTurn = "o";
    }
   }
}
