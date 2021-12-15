public class Main
{
    public static void towerOfHanoi(int n,String start,String middle,String end){
        if(n==1){
            System.out.println(start+"-->"+end);   
        }else{
            towerOfHanoi(n-1,start,end,middle);
            System.out.println(start+"-->"+end);
            towerOfHanoi(n-1,middle,start,end);
        }
    }
    
	public static void main(String[] args) {
		towerOfHanoi(3,"A","B","C");
	}
}