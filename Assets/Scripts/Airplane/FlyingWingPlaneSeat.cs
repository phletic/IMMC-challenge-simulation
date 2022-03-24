
public class FlyingWingPlaneSeat : IsSeat {

    public FlyingWingPlaneSeat(){

    }
    public override bool isSeat(int x, int y){
        if(x == 3 || x == 10 || x == 17 || x == 24){
            return false;
        }
        else if (y == 0){
            return false;
        }
        else if (x < 4 && y <= 3){
            return false;
        }
        else if (x > 24 && y <= 3){
            return false;
        }
        else{
            return true;
        }
    }
}