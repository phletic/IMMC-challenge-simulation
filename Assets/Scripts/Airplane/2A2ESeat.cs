using UnityEngine;
public class TwoATwoSeat : IsSeat {

    public TwoATwoSeat(){

    }
    public override bool isSeat(int x, int y){

        if(x == 0 || x == 2 || x == 4 || x == 6 || x== 20 || x == 21 || x== 23 || x== 44 || x == 45){
            return false;
        }
        if (x >= 1 && x<=6){
            if(y == 2 || y==5 || y==8){
                return false;
            }else{
                return true;
            }
        }
        if(x == 7){
            if(y>=2 && y<=6){
                return false;
            }else{
                return true;
            }
        }
        if( x>= 8 && x<= 21){
            if(y == 2||y==6){
                return false;
            }
            else{
                return true;
            }
        }
        if (x == 22){
            if( y>=2 && y<=6){

                return false;
            }
            else{
                return true;
            }

        }
        if (x >= 24){
            if( y==2 || y==6){

                return false;
            }
            else{
                return true;
            }

        }
        else{
            return true;
        }
    }
}