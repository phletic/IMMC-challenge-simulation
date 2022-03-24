
public class NarrowBodyPlaneSeats : IsSeat {

    public NarrowBodyPlaneSeats(){

    }
    public override bool isSeat(int x, int y){
        if (x == 3) 
        {
            return false;
        }
        else if (y == 0){
            return false;
        }
        else if (y == 1 && x>= 4 && x<=6){
            return false;
        }
        else{
            return true;
        }
    }
}