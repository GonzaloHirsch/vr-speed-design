public class Score : Framework.Singleton<Score>
{
    private static int score = 0;

    public void AddScore(int amount){
        score += amount;
    }

    public int GetScore(){
        return score;
    }

    public void ResetScore() {
        score = 0;
    }
}