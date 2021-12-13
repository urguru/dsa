/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
public class Main
{
	public static void main(String[] args) {
		printStairs(3,"");
	}
	
	public static void printStairs(int n,String stepsCovered){
	    if(n==0){
	       System.out.println("Success  "+ stepsCovered); 
	    } else if(n>0){
	        //When person takes 1 step
	        System.out.println("Steps covered so far "+ stepsCovered);
	        printStairs(n-1,stepsCovered + "One ");
	        printStairs(n-2,stepsCovered + "Two");
	        printStairs(n-3,stepsCovered + "Three");
	    }else{
	        System.out.println("Failed  " + stepsCovered);
	    }
	}
}
